using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Core.RequestModels
{
    public class SubstrateFilterModel
    {
        public double MinAcidity { get; set; } = double.MinValue;
        public double MaxAcidity { get; set; } = double.MaxValue;
        public double MinElectricalCapacity { get; set; } = double.MinValue;
        public double MaxElectricalCapacity { get; set; } = double.MaxValue;
        public double MinMoisureContent { get; set; } = double.MinValue;
        public double MaxMoisureContent { get; set; } = double.MaxValue;
        public double MinPrice { get; set; } = double.MinValue; 
        public double MaxPrice { get; set; } = double.MaxValue;
        public double MinVolume { get; set; } = double.MinValue;
        public double MaxVolume { get; set; } = double.MaxValue;
    }
}
