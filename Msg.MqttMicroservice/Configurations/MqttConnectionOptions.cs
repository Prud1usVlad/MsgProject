namespace Msg.MqttMicroservice.Configurations
{
    public class MqttConnectionOptions
    {
        public string ClientId { get; set; }
        public string BrockerAddress { get; set; }
        public int BrockerPort { get; set; }
        public int ReconnectionDelay { get; set; }

        public static MqttConnectionOptions GetDefault(IConfiguration config)
        {
            return new MqttConnectionOptions()
            {
                ClientId = config["MqttConnection:ClientId"],
                BrockerAddress = config["MqttConnection:BrockerAddress"],
                BrockerPort = int.Parse(config["MqttConnection:BrockerPort"]),
                ReconnectionDelay = int.Parse(config["MqttConnection:ReconnectionDelay"]),
            };
        }
    }
}
