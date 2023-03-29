using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Core.BasicModels
{
    public class DataLabelDataPiece
    {
        public long DataLabelId { get; set; }
        public long DataPieceId { get; set; }

        public virtual DataLabel DataLabel { get; set; }
        public virtual DataPiece DataPiece { get; set; }
    }
}
