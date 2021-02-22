using Microsoft.AspNetCore.Identity;

namespace Cinematron.DAL.Models
{
    public class User : IdentityUser
    {
        public string AvatarUrl {get; set;}
    }
}
