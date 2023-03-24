using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MsgCore.BasicModels;

public class SubstrateDataPiece
{
    public long SubstrateId { get; set; }
    public long DataPieceId { get; set; }
    
    public double Value { get; set; }
    
    public virtual DataPiece DataPiece { get; set; }
    public virtual Substrate Substrate { get; set; }
}