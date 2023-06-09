using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Msg.Core.BasicModels;

public class Device
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long DevicePackId { get; set; }
    public long DeviceTypeId { get; set; }
    public long? PlantId { get; set; }

    public virtual ICollection<DeviceDataPiece> DataPieces { get; set; }
    public virtual DeviceType DeviceType { get; set; }
    public virtual DevicePack DevicePack { get; set; }
    public virtual Plant Plant { get; set; }
}