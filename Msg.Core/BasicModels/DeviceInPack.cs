namespace Msg.Core.BasicModels;

public class DeviceInPack
{
    public long DeviceTypeId { get; set; }
    public long PackTypeId { get; set; }

    public int Amount { get; set; }

    public virtual DeviceType DeviceType { get; set; }
    public virtual PackType PackType { get; set; }
}