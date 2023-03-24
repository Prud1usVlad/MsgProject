namespace Msg.Core.BasicModels;

public class DeviceDataPiece
{
    public long DeviceId { get; set; }
    public long DataPieceId { get; set; }

    public double Value { get; set; }

    public virtual Device Device { get; set; }
    public virtual DataPiece DataPiece { get; set; }
}