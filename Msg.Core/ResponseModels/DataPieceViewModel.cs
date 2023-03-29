using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Core.ResponseModels
{
    public class DataPieceViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string MeasureUnit { get; set; } = string.Empty;
        public List<string> Labels { get; set; } = new List<string>();
    }
}
