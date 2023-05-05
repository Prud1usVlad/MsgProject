using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Mobile.Models
{
    public class Warning
    {
        public long Id { get; set; }
        public bool IsSolved { get; set; }
        public List<PropertyModel> Results { get; set; }
        public List<PropertyModel> Required { get; set; }
    }
}
