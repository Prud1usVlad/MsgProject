using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet;
using Msg.MqttMicroservice.Configurations;
using Msg.DAL;
using System.Text.Json;
using Msg.MqttMicroservice.Models;
using Msg.MqttMicroservice.HealthChecks;

namespace Msg.MqttMicroservice.Services
{
    public class MqttSubscriber
    {
        private readonly IDeviceDataPieceService _deviceDataPieceService;
        private readonly SystemHealthCheck _healthCheck;

        protected IManagedMqttClient mqttClient;
        protected ManagedMqttClientOptions mqttOptions;
        protected JsonSerializerOptions jsonSerializerOptions;

        public MqttConnectionOptions connectionOptions;

        public MqttSubscriber(
            MqttConnectionOptions options,
            IDeviceDataPieceService deviceDataPieceService,
            SystemHealthCheck healthCheck)
        {
            InitFields(options);
            SetUpHandlers();

            jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                AllowTrailingCommas = true,
            };
            _deviceDataPieceService = deviceDataPieceService;
            _healthCheck = healthCheck;
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
            _healthCheck.ServiceState = ServiceState.Connected;
            return Task.CompletedTask;
        }

        private Task DisconnectedAsync(MqttClientDisconnectedEventArgs arg)
        {
            Console.WriteLine("Disconnected");
            _healthCheck.ServiceState = ServiceState.Disconnected;
            return Task.CompletedTask;
        }

        private Task ConnectingFailedAsync(ConnectingFailedEventArgs arg)
        {
            Console.WriteLine("Connection failed check network or broker!");
            _healthCheck.ServiceState = ServiceState.ConnectingFailed;
            return Task.CompletedTask;
        }

        private async Task MessageRecievedAsync(MqttApplicationMessageReceivedEventArgs arg)
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', 38));
            Console.WriteLine($"Message recieved | {DateTime.Now}");
            var str = arg.ApplicationMessage.ConvertPayloadToString();

            var message = JsonSerializer.Deserialize<MqttMessage>(str, jsonSerializerOptions);

            await TrySaveMessage(message);
        }

        private async Task TrySaveMessage(MqttMessage message)
        {
            try
            {
                await _deviceDataPieceService.ProcessMqttMessage(message);

                Console.WriteLine($"Recieved data from device: {message.DeviceId} | V{message.DeviceVersion}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Occured error with message: {ex.Message} ");
            }

            Console.WriteLine(new string('-', 38));

        }
    }
}
