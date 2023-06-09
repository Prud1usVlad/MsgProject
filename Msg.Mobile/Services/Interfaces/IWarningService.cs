using Msg.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Mobile.Services.Interfaces
{
    public interface IWarningService
    {
        public Task<List<Warning>> GetWarningsAsync();

        public Task ResolveWarningAsync(long warningId);
    }
}
