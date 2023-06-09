using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Msg.Core.BasicModels;

public class DataPiece
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string? Name { get; set; } = "";
    public string? MeasureUnit { get; set; } = "";

    public virtual ICollection<DataLabelDataPiece> DataLabelDataPieces { get; set; }
    public virtual ICollection<PlantDataPiece> PlantDataPieces { get; set; }
    public virtual ICollection<SubstrateDataPiece> SubstrateDataPieces { get; set; }
    public virtual ICollection<DeviceDataPiece> DeviceDataPieces { get; set; }
}