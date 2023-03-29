using Msg.Core.BasicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.BLL.Interfaces
{
    public interface IPackTypeService
    {
        public Task<PackType> GetPackTypeAsync(long id);
        public Task<List<PackType>> GetPackTypesAsync(string name);
        public Task<List<PackType>> GetPackTypesAsync();
        public Task<long> AddPackTypeAsync(PackType type);
        public Task UpdatePackTypeAsync(PackType type);
        public Task DeletePackTypeAsync(long id);
    }
}
