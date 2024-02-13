using Microsoft.AspNetCore.Identity;

namespace POS.Persistence.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        //[EncryptColumn]
        public string? Code { get; set; }
    }
}
