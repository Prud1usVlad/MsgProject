using Microsoft.Extensions.Diagnostics.HealthChecks;
using Msg.MqttMicroservice.Models;

namespace Msg.MqttMicroservice.HealthChecks
{
    public class SystemHealthCheck : IHealthCheck
    {
        private volatile ServiceState _serviceState = ServiceState.Preparing;

        public ServiceState ServiceState { get => _serviceState; set => _serviceState = value; }

        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context, CancellationToken cancellationToken = default)
        {

            switch (this.ServiceState)
            {
                case (ServiceState.Preparing):
                    return Task.FromResult(HealthCheckResult.Unhealthy("Service is still preparing"));
                case (ServiceState.Connected):
                    return Task.FromResult(HealthCheckResult.Healthy("Service successfully connected to brocker"));
                case (ServiceState.Disconnected):
                    return Task.FromResult(HealthCheckResult.Unhealthy("Service disconnected from brocker"));
                case (ServiceState.ConnectingFailed):
                    return Task.FromResult(HealthCheckResult.Unhealthy("Service failed to connect to brocker"));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("Unexpected state"));
        }
    }
}
