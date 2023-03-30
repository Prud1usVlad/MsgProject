using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Core.RequestModels
{
    public class OrderModel
    {
        public long Id { get; set; }
        public long PackTypeId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
