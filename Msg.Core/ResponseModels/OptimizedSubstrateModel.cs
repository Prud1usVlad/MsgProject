using Msg.Core.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Core.ResponseModels
{
    public class OptimizedSubstrateModel
    {
        public SubstrateModel Substrate { get; set; }
        public double Volume { get; set; }
        public int PacksAmount { get; set; }
    }
}
