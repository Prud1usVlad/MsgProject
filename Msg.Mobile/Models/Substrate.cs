using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Mobile.Models
{
    public class Substrate
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public double Price { get; set; }
        public double Volume { get; set; }

        public List<PropertyModel> Characteristics { get; set; }
    }
}
