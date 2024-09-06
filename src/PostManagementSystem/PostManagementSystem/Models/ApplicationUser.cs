using Microsoft.AspNetCore.Identity;

namespace PostManagementSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? RoleID { get; set; }

        public IdentityRole Role { get; set; }
    }
}
