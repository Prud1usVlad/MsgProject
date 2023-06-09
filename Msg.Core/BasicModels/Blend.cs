using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msg.Core.BasicModels
{
    public class Blend
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string? Name { get; set; }
        public DateOnly? Date { get; set; }
        public string UserId { get; set; }
        public double? Volume { get; set; } 

        virtual public User User { get; set; }
        virtual public List<BlendComponent> Components { get; set; }


    }
}
