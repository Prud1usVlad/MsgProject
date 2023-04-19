using Microsoft.EntityFrameworkCore;
using Msg.Core.BasicModels;
using Msg.DAL;
using Msg.MqttMicroservice.Models;

namespace Msg.MqttMicroservice.Services
{
    public class DeviceDataPieceService : IDeviceDataPieceService
    {
        private readonly ApplicationContext _context;

        public DeviceDataPieceService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddDeviceDataPiece(DeviceDataPiece deviceDataPiece)
        {
            _context.DeviceDataPieces.Add(deviceDataPiece);

            await _context.SaveChangesAsync();
        }

        public async Task ProcessMqttMessage(MqttMessage message)
        {
            var newDdps = new List<DeviceDataPiece>();

            foreach (var dataElement in message.Data)
            {
                var ddp = new DeviceDataPiece
                {
                    DeviceId = message.DeviceId,
                    Value = dataElement.Value,
                    DataPieceId = dataElement.DataPieceId,
                    Date = DateOnly.FromDateTime(DateTime.Now),
                };

                
                await AddDeviceDataPiece(ddp);

                newDdps.Add(ddp);
            }

            await DetectWarnings(newDdps);
        }

        private async Task DetectWarnings(List<DeviceDataPiece> ddps)
        {
            var device = await _context.Devices
                .FirstOrDefaultAsync(d => d.Id == ddps.First().DeviceId);

            var plant = await _context.Plants
                .Include(p => p.Characteristics)
                .FirstOrDefaultAsync(p => p.Id == device.PlantId);

            Warning warning = null;

            foreach (var piece in ddps) 
            {
                var plantValue = plant.Characteristics.FirstOrDefault(c => c.DataPieceId == piece.DataPieceId);

                if (Math.Abs(plantValue.Value - piece.Value) > plantValue.Value * 0.25) 
                {
                    warning = new Warning() { IsSolved = false };
                    _context.Warnings.Add(warning);
                    _context.SaveChanges();
                    break;
                }
            }

            foreach (var piece in ddps)
            {
                if (warning is null)
                    break;

                piece.WarningId = warning.Id;
            }

            _context.DeviceDataPieces.UpdateRange(ddps);
            _context.SaveChanges();
        }
    }
}
