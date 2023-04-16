using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Msg.Core.BasicModels;

public class DeviceDataPiece
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public long DeviceId { get; set; }
    public long DataPieceId { get; set; }

    public DateOnly Date { get; set; }
    public double Value { get; set; }

    public virtual Device Device { get; set; }
    public virtual DataPiece DataPiece { get; set; }
}