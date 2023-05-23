using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Mobile.Models
{
    public class HelperResult
    {
        public bool IsSucceed { get; set; }
        public double Price { get; set; }
        public double Volume { get; set; }
        public double Deviation { get; set; }

        public List<SubstrateComponent> Result { get; set; }
    }
}
