namespace Msg.Core.BasicModels;

public class PlantDataPiece
{
    public long PlantId { get; set; }
    public long DataPieceId { get; set; }

    public double Value { get; set; }

    public virtual Plant Plant { get; set; }
    public virtual DataPiece DataPiece { get; set; }
}