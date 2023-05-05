using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Mobile.Models
{
    class Plant
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public List<PropertyModel> Characteristics { get; set; }
    }
}
