using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MsgCore.BasicModels;

public class DevicePack
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    
    public DateOnly DateBought { get; set; }
    
    //public long UserId { get; set; }
    public long PackTypeId { get; set; }
    
    //public virtual User User { get; set; }
    public virtual PackType PackType { get; set; }
}