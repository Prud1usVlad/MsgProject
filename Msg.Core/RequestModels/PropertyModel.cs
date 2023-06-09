using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Core.RequestModels
{
    public class PropertyModel
    {
        public string Name { get; set; }
        public long DataPieceId { get; set; }
        public double Value { get; set; }

    }
}
