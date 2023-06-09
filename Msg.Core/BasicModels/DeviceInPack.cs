using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Msg.Core.BasicModels;

public class DeviceInPack
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long DeviceTypeId { get; set; }
    public long PackTypeId { get; set; }

    public int Amount { get; set; }

    public virtual DeviceType DeviceType { get; set; }
    public virtual PackType PackType { get; set; }
}