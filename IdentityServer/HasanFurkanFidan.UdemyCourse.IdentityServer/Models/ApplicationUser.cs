using Microsoft.AspNetCore.Identity;

namespace HasanFurkanFidan.UdemyCourse.IdentityServer.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
