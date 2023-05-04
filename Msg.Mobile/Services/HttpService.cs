using Microsoft.Maui.ApplicationModel.Communication;
using Msg.Mobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Msg.Mobile.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _serializerOptions;

        public HttpService(HttpClient httpClient, JsonSerializerOptions serializerOptions)
        {
            _httpClient = httpClient;
            _serializerOptions = serializerOptions;
        }

        public async Task DeleteAsync(string address)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(address);

            response.EnsureSuccessStatusCode();
        }

        public async Task<T> GetAsync<T>(string address)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(address);
            response.EnsureSuccessStatusCode();

            string stringResult = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(stringResult, _serializerOptions);
        }

        public async Task<T> PostAsync<T, E>(string address, E body = default)
        {
            HttpResponseMessage response = await _httpClient.PostAsync(address,
                new StringContent(JsonSerializer.Serialize(body),
                    Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            string stringResult = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(stringResult, _serializerOptions);
        }

        public async Task<T> PutAsync<T, E>(string address, E body)
        {
            HttpResponseMessage response = await _httpClient.PutAsync(address,
                new StringContent(JsonSerializer.Serialize(body),
                    Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            string stringResult = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(stringResult, _serializerOptions);
        }
    }
}
