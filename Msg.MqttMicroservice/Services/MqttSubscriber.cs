using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet;
using Msg.MqttMicroservice.Configurations;

namespace Msg.MqttMicroservice.Services
{
    public class MqttSubscriber
    {
        private readonly IConfiguration _configuration;

        protected IManagedMqttClient mqttClient;
        protected ManagedMqttClientOptions mqttOptions;

        public MqttConnectionOptions connectionOptions;

        public MqttSubscriber(MqttConnectionOptions options, IConfiguration configuration)
        {
            InitFields(options);
            SetUpHandlers();
            _configuration = configuration;
        }

        public async Task Connect(string topic)
        {
            await mqttClient.StartAsync(mqttOptions);
            await mqttClient.SubscribeAsync(topic);
        }

        protected void InitFields(MqttConnectionOptions options)
        {
            connectionOptions = options;

            mqttClient = new MqttFactory().CreateManagedMqttClient();

            MqttClientOptionsBuilder builder = new MqttClientOptionsBuilder()
                .WithClientId(connectionOptions.ClientId)
                .WithTcpServer(connectionOptions.BrockerAddress);

            mqttOptions = new ManagedMqttClientOptionsBuilder()
                .WithAutoReconnectDelay(TimeSpan.FromSeconds(connectionOptions.ReconnectionDelay))
                .WithClientOptions(builder.Build())
                .Build();
        }

        protected void SetUpHandlers()
        {
            mqttClient.ConnectedAsync += ConnectedAsync;

            mqttClient.DisconnectedAsync += DisconnectedAsync;

            mqttClient.ConnectingFailedAsync += ConnectingFailedAsync;

            mqttClient.ApplicationMessageReceivedAsync += MessageRecievedAsync;
        }

        private Task ConnectedAsync(MqttClientConnectedEventArgs arg)
        {
            Console.WriteLine("Connected");
            return Task.CompletedTask;
        }

        private Task DisconnectedAsync(MqttClientDisconnectedEventArgs arg)
        {
            Console.WriteLine("Disconnected");
            return Task.CompletedTask;
        }

        private Task ConnectingFailedAsync(ConnectingFailedEventArgs arg)
        {
            Console.WriteLine("Connection failed check network or broker!");
            return Task.CompletedTask;
        }

        private async Task MessageRecievedAsync(MqttApplicationMessageReceivedEventArgs arg)
        {
            Console.WriteLine("Message recieved!");
            var str = arg.ApplicationMessage.ConvertPayloadToString();
            Console.WriteLine(str);
        }
    }
}
