using Msg.MqttMicroservice.Configurations;
using Msg.MqttMicroservice.Services;

namespace Msg.MqttMicroservice
{
    public class MainTask : BackgroundService
    {
        private readonly IConfiguration _configuration;

        public MainTask(IConfiguration configuration)
            : base()
        {
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            StartUpMqttClient();
        }

        private void StartUpMqttClient()
        {
            var s = new MqttSubscriber(
                MqttConnectionOptions.GetDefault(_configuration), 
                _configuration
            );

            s.Connect(_configuration["Mqtt:Topic"]);

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}
