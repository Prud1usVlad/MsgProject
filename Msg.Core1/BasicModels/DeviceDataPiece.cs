using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MsgCore.BasicModels;

public class DeviceDataPiece
{
    public long DeviceId { get; set; }
    public long DataPieceId { get; set; }
    
    public double Value { get; set; }
    
    public virtual Device Device { get; set; }
    public virtual DataPiece DataPiece { get; set; }
}