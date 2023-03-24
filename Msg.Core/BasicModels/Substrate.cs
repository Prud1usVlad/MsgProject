using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Msg.Core.BasicModels;

public class Substrate
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? PhotoUrl { get; set; }
    public double? Price { get; set; }
    public double? Volume { get; set; }

    public virtual ICollection<SubstrateDataPiece> Characteristics { get; set; }
}