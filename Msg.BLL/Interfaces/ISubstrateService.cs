using Msg.Core.BasicModels;
using Msg.Core.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.BLL.Interfaces
{
    public interface ISubstrateService
    {
        public Task<Substrate> GetSubstrateAsync(long id);
        public Task<Substrate> GetSubstrateAsync(string name);
        public Task<List<Substrate>> GetSubstratesAsync();
        public Task<List<Substrate>> GetSubstratesAsync(SubstrateFilterModel filter);
        public Task<long> AddSubstrateAsync(Substrate substrate);
        public Task UpdateSubstrateAsync(Substrate substrate);
        public Task DeleteSubstrateAsync(long id);
    }
}
