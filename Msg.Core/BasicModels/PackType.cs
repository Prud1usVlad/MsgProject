using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Msg.Core.BasicModels;

public class PackType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }

    public virtual ICollection<DeviceInPack> DevicesInPack { get; set; }
    public virtual ICollection<DevicePack> DevicePacks { get; set; }
}