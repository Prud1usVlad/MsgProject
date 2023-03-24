using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MsgCore.BasicModels;

public class PlantDataPiece
{
    public long PlantId { get; set; }
    public long DataPieceId { get; set; }
    
    public double Value { get; set; }
    
    public virtual Plant Plant { get; set; }
    public virtual DataPiece DataPiece { get; set; }
}