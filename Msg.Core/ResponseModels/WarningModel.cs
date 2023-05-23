using Msg.Core.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Core.ResponseModels
{
    public class WarningModel
    {
        public long Id { get; set; }
        public bool IsSolved { get; set; }
        public List<PropertyModel> Results { get; set; }
        public List<PropertyModel> Required { get; set; }
        public DateOnly Date { get; set; }
        public long DeviceId { get; set; }
    } 
}
