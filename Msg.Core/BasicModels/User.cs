using Microsoft.AspNetCore.Identity;

namespace Msg.Core.BasicModels;

public class User : IdentityUser
{
    public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<DevicePack> DevicePacks { get; set; }
}