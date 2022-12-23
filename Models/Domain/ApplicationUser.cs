using Microsoft.AspNetCore.Identity;

namespace AminesStream.Models.Domain
{
    public class ApplicationUser: IdentityUser
    {
        public string? Name { get; set; }
    }
}
