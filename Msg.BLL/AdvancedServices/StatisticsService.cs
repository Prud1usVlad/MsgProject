using Microsoft.EntityFrameworkCore;
using Msg.BLL.Interfaces;
using Msg.Core.BasicModels;
using Msg.DAL;

namespace Msg.BLL.AdvancedServices
{
    public class StatisticsService : IStatisticsService
    {
        public readonly ApplicationContext _context;

        public StatisticsService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Dictionary<string, string>>> GetDevicePackStatistic()
        {
            var propFunctions = new Dictionary<string, Func<IEnumerable<DevicePack>, string>>();
            var packTypeNames = _context.PackTypes.Select(x => x.Name);

            foreach (var name in packTypeNames)
                propFunctions.Add(name, (data) => data.Count(i => i.PackType.Name == name).ToString());

            var packTypes = _context.DevicePacks
                .Include(p => p.PackType)
                .AsEnumerable();

            return new List<Dictionary<string, string>> { GenerateDictionary(packTypes, "devicePacks", propFunctions) };


        }

        public async Task<List<Dictionary<string, string>>> GetMqttPayloadStatistic()
        {
            var c = _context.DeviceDataPieces
                .GroupBy(p => p.Date)
                .AsEnumerable();

            return c.Select(g => new Dictionary<string, string>()
                {
                    { "Label", g.Key.ToString() },
                    { "Amount", g.Count().ToString() }
                })
                .ToList();
        }

        public async Task<List<Dictionary<string, string>>> GetOrdersStatistic()
        {
            var propFunctions = new Dictionary<string, Func<IEnumerable<Order>, string>>()
            {
                { "Total Income", (orders) => orders.Sum(o => o.PackType.Price).ToString() },
                { "Total Orders Amount", (orders) => orders.Count().ToString() },
                { "Processed Orders", (orders) => orders.Count(o => o.Processed == true).ToString() }
            };

            var packTypeNames = _context.PackTypes.Select(x => x.Name);

            foreach (var name in packTypeNames)
                propFunctions.Add($"{name} Sold", (data) => data.Count(i => i.PackType.Name == name).ToString());

            return _context.Orders
                .Include(p => p.PackType)
                .GroupBy(p => p.Date)
                .AsEnumerable()
                .Select(g => GenerateDictionary(g, g.Key.ToString(), propFunctions))
                .ToList();
        }

        private Dictionary<string, string> GenerateDictionary<T>(
            IEnumerable<T> data, 
            string label, 
            Dictionary<string,Func<IEnumerable<T>, string>> propFunctions)
        {
            var res = new Dictionary<string, string>()
            {
                { "Label", label }
            };

            foreach ( var keyValue in propFunctions )
                res.Add(keyValue.Key, keyValue.Value(data));

            return res;
        }
    }
}
