using Msg.Core.BasicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Core.Dtos
{
    public class OptimizingModelInput
    {
        public long SelectedPlantID { get; set; }
        public List<long> SelectedSubstratesId { get; set; }
        public double SubstrateVolume { get; set; }
    }
}
