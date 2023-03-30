using Msg.Core.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Core.ResponseModels
{
    public class OrderViewModel : OrderModel
    {
        public bool Processed { get; set; }
        public DateOnly? Date { get; set; }
        public PackTypeModel PackType { get; set; }
    }
}
