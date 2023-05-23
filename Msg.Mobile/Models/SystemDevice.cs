using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Mobile.Models
{
    public class SystemDevice
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public List<PropertyModel> DataPieces { get; set; }
        public Plant Plant { get; set; }
    }
}
