using Msg.Mobile.Models;
using Msg.Mobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Mobile.Services
{
    public class SubstrateService : ISubstrateService
    {
        private readonly IHttpService _httpService;

        public SubstrateService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<List<Substrate>> GetSubstrates()
        {
            return await _httpService.GetAsync<List<Substrate>>("Substrates");
        }
    }
}
