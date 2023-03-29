using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Core.BasicModels
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateTime? DateTime { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool Processed { get; set; } = false;

        public long? PackTypeId { get; set; }
        public long? UserId { get; set; }

        public virtual PackType PackType { get; set; }
        public virtual User User { get; set; }
    }
}
