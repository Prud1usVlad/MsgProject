using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Core.BasicModels
{
    public class DataLabel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Label { get; set; }

        public virtual ICollection<DataLabelDataPiece> DataLabelDataPieces { get; set; }
    }
}
