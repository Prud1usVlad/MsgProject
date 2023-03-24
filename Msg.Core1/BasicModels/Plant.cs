using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MsgCore.BasicModels;

public class Plant
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? PhotoUrl { get; set; }
    
    public virtual ICollection<PlantDataPiece> Characteristics { get; set; }
}