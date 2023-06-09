using Msg.Core.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Core.Dtos
{
    public class BestVariant
    {
        public double Deviation { get; set; }
        public List <SubstrateModel> Sub { get; set; }
    }
}
