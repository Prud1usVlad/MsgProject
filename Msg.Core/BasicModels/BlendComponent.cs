using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Core.BasicModels
{
    public class BlendComponent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long BlendId { get; set; }
        public long SubstrateId { get; set; }
        public double Volume { get; set; }

        public virtual Blend Blend { get; set; }
        public virtual Substrate Substrate { get; set; }
    }
}
