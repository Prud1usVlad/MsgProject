using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Msg.Core.BasicModels;

public class DeviceType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }

    public virtual ICollection<Device> Devices { get; set; }
    public virtual ICollection<DeviceInPack> DeviceInPacks { get; set; }
}