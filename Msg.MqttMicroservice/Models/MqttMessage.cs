namespace Msg.MqttMicroservice.Models
{
    public class MqttMessage
    {
        public long DeviceId { get; set; }
        public string DeviceVersion { get; set; }
        public List<DataElement> Data { get; set; } 
    }
}
