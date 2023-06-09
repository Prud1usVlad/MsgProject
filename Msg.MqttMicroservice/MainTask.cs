using Msg.MqttMicroservice.Configurations;
using Msg.MqttMicroservice.HealthChecks;
using Msg.MqttMicroservice.Services;

namespace Msg.MqttMicroservice
{
    public class MainTask : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly MqttSubscriber _subscriber;

        public MainTask(IConfiguration configuration, MqttSubscriber subscriber)
            : base()
        {
            _configuration = configuration;
            _subscriber = subscriber;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await StartUpMqttClient();
        }

        private async Task StartUpMqttClient()
        {
            await _subscriber.Connect(_configuration["Mqtt:Topic"]);
        }
    }
}
