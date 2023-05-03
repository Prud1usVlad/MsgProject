using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Msg.BLL.Interfaces;
using Msg.Core.BasicModels;
using Msg.Core.Dtos;
using Msg.Core.RequestModels;
using Msg.Core.ResponseModels;
using Msg.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.BLL.AdvancedServices
{
    public class OptimizingModelService : IOptimizingModelService 
    {
        private readonly ApplicationContext _context;
        private readonly IDataPieceService _dataPieceService;

        public OptimizingModelService(ApplicationContext context, IDataPieceService dataPieceService)
        {
            _context = context;
            _dataPieceService = dataPieceService;
        }

        public async Task<OptimizingModelResponse> GetOptimizedSubstrate(OptimizingModelInput input)
        {
            // TODO needs real implementation
            return new OptimizingModelResponse()
            {
                Price = 23,
                Volume = 5.62,
            };
        }

        public async Task<OptimizingModelResponse> Optimize(OptimizingModelInput input)
        {
            var arguments = await Init(input);

            var success = Main(arguments);
            List<SubstrateModel> resValues = arguments.BestVariant.Sub;

            var res = new OptimizingModelResponse()
            {
                IsSucceed = success,
                Result = new List<OptimizedSubstrateModel>(),
                Price = 0,
                Deviation = arguments.BestVariant.Deviation,
            };

            foreach (var sub in resValues)
            {
                sub.Characteristics = null;
                var dbEntity = await _context.Substrates.FirstAsync(s => s.Id == sub.Id);
                var packsAmount = (int)Math.Ceiling((double)(sub.Volume / dbEntity.Volume));

                res.Price += (double)(packsAmount * dbEntity.Price);

                res.Result.Add(new OptimizedSubstrateModel
                {
                    Substrate = sub,
                    Volume = (double)sub.Volume,
                    PacksAmount = packsAmount,
                });
            }

            return res;

        }

        private async Task<List<SubstrateModel>> InitSubstrates(OptimizingModelInput input, List<DataPiece> props)
        {
            List<SubstrateModel> subs = input.SelectedSubstratesId
                .Select(id => GetModelFromSubstrate(_context.Substrates.Find(id)))
                .ToList();

            foreach (var prop in props)
            {
                foreach (var sub in subs)
                {
                    var subDataPiece = await _context.SubstrateDataPieces
                        .FirstAsync(p => p.DataPieceId == prop.Id && p.SubstrateId == sub.Id);

                    sub.Characteristics.Add(new PropertyModel
                    {
                        Name = prop.Name,
                        Value = subDataPiece.Value,
                        DataPieceId = prop.Id,
                    });
                }
            }

            return subs;
        }

        private async Task<PlantModel> InitPlant(OptimizingModelInput input, List<DataPiece> props)
        {
            Plant plant = await _context.Plants
                .FirstAsync(p => p.Id == input.SelectedPlantID);

            PlantModel pm = new PlantModel
            {
                Characteristics = new List<PropertyModel>(),
                Name = plant.Name,
                Id = plant.Id,
            };

            foreach (var prop in props)
            {
                var plantDataPiece = await _context.PlantDataPieces
                  .FirstAsync(p => p.DataPieceId == prop.Id && p.PlantId == plant.Id);

                pm.Characteristics.Add(new PropertyModel
                {
                    Name = prop.Name,
                    Value = plantDataPiece.Value,
                    DataPieceId = prop.Id,
                });
            }

            return pm;
        }

        private async Task<OptimizingModelArguments> Init(OptimizingModelInput input)
        {
            List<DataPiece> props = await _dataPieceService.
                GetDataPiecesAsync(Core.Enums.DataPieceLabel.OptimizingModelRequired);

            List<SubstrateModel> substrates = await InitSubstrates(input, props);

            PlantModel plant = await InitPlant(input, props);

            substrates = substrates.OrderBy(s => s.Price).ToList();

            return new OptimizingModelArguments
            {
                V = input.SubstrateVolume,
                D = input.Deviation,
                Sub = substrates,
                Plant = plant,
            };
        }

        private bool Main(OptimizingModelArguments arguments)
        {
            for (double j = 2; j < 20; j++)
            {
                double vSum = 0;

                for (var i = 0; i < arguments.Sub.Count; i++)
                    arguments.Sub[i].Volume = 0;

                for (var i = 0; i < arguments.Sub.Count; i++)
                {
                    bool res = TryValues(arguments, i, arguments.V - vSum, j);

                    vSum += (double)arguments.Sub[i].Volume;

                    if (vSum == arguments.V && res)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool TryValues(OptimizingModelArguments arguments, int index, double val, double depth)
        {
            if (val <= 0 || depth <= 0)
            {  
                return false;
            }
            else
            {
                arguments.Sub[index].Volume = Math.Round(val, 1);

                if (Check(arguments))
                {
                    return true;
                }
                else
                {
                    return TryValues(arguments, index, Math.Round(val - val * 0.05, 1), depth - 1);
                }
            }
        }

        private bool Check(OptimizingModelArguments arguments)
        {
            bool res = true;
            double sum = 0;

            var cons = arguments.Plant.Characteristics;
            var sub = arguments.Sub;

            for (var i = 0; i <  cons.Count; i++)
            {
                double upperSum = 0;
                double subSum = 0;

                for (var j = 0; j < sub.Count; j++)
                {
                    upperSum += sub[j].Characteristics[i].Value * (double)sub[j].Volume;
                    subSum += (double)sub[j].Volume;
                }

                double val = Math.Round(((Math.Abs((upperSum / arguments.V) - cons[i].Value)) / cons[i].Value), 3);
                sum += val;

                if (arguments.D <= val)
                    res = false;
            }

            if (sum / cons.Count < arguments.BestVariant.Deviation)
            {

                var arr = new List<SubstrateModel>();

                for (var k = 0; k < sub.Count; k++)
                {
                    arr.Add(CopyModel(sub[k]));
                }

                if (arr.Sum(m => m.Volume) >= arguments.V)
                {
                    arguments.BestVariant = new BestVariant
                    {
                        Deviation = sum / cons.Count,
                        Sub = arr,
                    };
                }
            }

            return res;
        }

        private SubstrateModel GetModelFromSubstrate(Substrate substrate)
        {
            var model = new SubstrateModel
            {
                Id = substrate.Id,
                Name = substrate.Name,
                Price = substrate.Price,
                Volume = 0,
                Characteristics = new List<PropertyModel>(),
            };

            return model;
        }

        private SubstrateModel CopyModel(SubstrateModel model)
        {
            var res = new SubstrateModel()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Volume = model.Volume,
                Characteristics = new List<PropertyModel>(),
            };

            foreach (var c  in model.Characteristics)
            {
                res.Characteristics.Add(new PropertyModel()
                {
                    DataPieceId = c.DataPieceId,
                    Name = c.Name,
                    Value = c.Value,
                });
            }

            return res;
        }
    }
}
