using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Mobile.Services.Interfaces
{
    public interface IHttpService
    {
        public Task<T> GetAsync<T>(string address);
        public Task<T> PostAsync<T, E>(string address, E body = default(E));
        public Task PostAsync(string address);
        public Task PutAsync<E>(string address, E body);
        public Task DeleteAsync(string address);
    }
}
