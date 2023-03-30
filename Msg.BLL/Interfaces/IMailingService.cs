using Msg.Core.BasicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.BLL.Interfaces
{
    public interface IMailingService
    {
        void SendCustom(string to, string subject, string html, string from = null);
        void SendUserCredentials(User user, string username, string password);
    }
}
