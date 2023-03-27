using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Core.RequestModels
{
    public class SubstrateFilterModel
    {
        public double MinAcidity { get; set; } = double.MaxValue;
        public double MaxAcidity { get; set; } = double.MinValue;
        public double MinElectricalCapacity { get; set; } = double.MaxValue;
        public double MaxElectricalCapacity { get; set; } = double.MinValue;
        public double MinMoisureContent { get; set; } = double.MaxValue;
        public double MaxMoisureContent { get; set; } = double.MinValue;
        public double MinPrice { get; set; } = double.MaxValue; 
        public double MaxPrice { get; set; } = double.MinValue;
        public double MinVolume { get; set; } = double.MaxValue;
        public double MaxVolume { get; set; } = double.MinValue;
    }
}
