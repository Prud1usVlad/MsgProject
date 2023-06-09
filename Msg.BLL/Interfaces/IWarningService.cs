using Msg.Core.BasicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.BLL.Interfaces
{
    public interface IWarningService
    {
        public Task<List<Warning>> GetUserWarnings(string userId);
        public Task ResolveWarning(string userId, long warningId);
    }
}
