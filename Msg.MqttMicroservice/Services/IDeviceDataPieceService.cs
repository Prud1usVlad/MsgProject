using Msg.Core.BasicModels;
using Msg.MqttMicroservice.Models;

namespace Msg.MqttMicroservice.Services
{
    public interface IDeviceDataPieceService
    {
        public Task AddDeviceDataPiece(DeviceDataPiece deviceDataPiece);
        public Task ProcessMqttMessage(MqttMessage message);
    }
}
