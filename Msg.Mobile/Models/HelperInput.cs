using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Mobile.Models
{
    public class HelperInput
    {
        public long SelectedPlantId { get; set; }
        public List<long> SelectedSubstratesId { get; set;}
        public long SubstrateVolume { get; set; }
        public long Deviation { get; set; }
    }
}
