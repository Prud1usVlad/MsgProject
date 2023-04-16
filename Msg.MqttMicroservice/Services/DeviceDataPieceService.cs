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
            }
        }
    }
}
