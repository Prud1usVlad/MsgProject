using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Msg.Core.BasicModels;

public class DevicePack
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public DateOnly DateBought { get; set; }

    public string UserId { get; set; }
    public long PackTypeId { get; set; }

    public virtual User User { get; set; }
    public virtual PackType PackType { get; set; }
    public virtual ICollection<Device> Devices { get; set; }
}