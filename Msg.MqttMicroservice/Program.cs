using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;
using System.Text;
using Msg.DAL;
using Msg.MqttMicroservice.Configurations;
using Msg.MqttMicroservice.Services;
using Msg.MqttMicroservice.HealthChecks;

namespace Msg.MqttMicroservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.AddSingleton<ApplicationContext>();

            builder.Services.AddSingleton<MqttConnectionOptions>(e => 
                MqttConnectionOptions.GetDefault(builder.Configuration));

            builder.Services.AddSingleton<MqttSubscriber>();
            builder.Services.AddSingleton<IDeviceDataPieceService, DeviceDataPieceService>();

            builder.Services.AddHostedService<MainTask>();
            builder.Services.AddSingleton<SystemHealthCheck>();

            builder.Services.AddHealthChecks()
                .AddCheck<SystemHealthCheck>(
                    "System",
                    tags: new[] { "ready" });

            var app = builder.Build();

            app.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
            {
                ResponseWriter = WriteResponse,
                Predicate = healthCheck => healthCheck.Tags.Contains("ready")
            });

            app.Run();
        }


        private static Task WriteResponse(HttpContext context, HealthReport healthReport)
        {
            context.Response.ContentType = "application/json; charset=utf-8";

            var options = new JsonWriterOptions { Indented = true };

            using var memoryStream = new MemoryStream();
            using (var jsonWriter = new Utf8JsonWriter(memoryStream, options))
            {
                jsonWriter.WriteStartObject();
                jsonWriter.WriteString("status", healthReport.Status.ToString());
                jsonWriter.WriteStartObject("results");

                foreach (var healthReportEntry in healthReport.Entries)
                {
                    jsonWriter.WriteStartObject(healthReportEntry.Key);
                    jsonWriter.WriteString("status",
                        healthReportEntry.Value.Status.ToString());
                    jsonWriter.WriteString("description",
                        healthReportEntry.Value.Description);
                    jsonWriter.WriteStartObject("data");

                    foreach (var item in healthReportEntry.Value.Data)
                    {
                        jsonWriter.WritePropertyName(item.Key);

                        JsonSerializer.Serialize(jsonWriter, item.Value,
                            item.Value?.GetType() ?? typeof(object));
                    }

                    jsonWriter.WriteEndObject();
                    jsonWriter.WriteEndObject();
                }

                jsonWriter.WriteEndObject();
                jsonWriter.WriteEndObject();
            }

            return context.Response.WriteAsync(
                Encoding.UTF8.GetString(memoryStream.ToArray()));
        }
    }
}