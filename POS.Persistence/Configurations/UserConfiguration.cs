using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Persistence.Models;

namespace POS.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                 new ApplicationUser
                 {
                     Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                     Email = "admin@arp.com", // Updated email here
                     NormalizedEmail = "ADMIN@ARP.COM", // Updated normalized email here
                     FirstName = "System",
                     LastName = "Admin",
                     UserName = "admin@arp.com", // Updated username here
                     NormalizedUserName = "ADMIN@ARP.COM", // Updated normalized username here
                     DefaultRole = "Administrator",
                     PasswordHash = hasher.HashPassword(null, "123"),
                     EmailConfirmed = true
                 },
                 new ApplicationUser
                 {
                     Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                     Email = "user@arp.com", // Updated email here
                     NormalizedEmail = "USER@ARP.COM", // Updated normalized email here
                     FirstName = "System",
                     LastName = "User",
                     UserName = "user@arp.com", // Updated username here
                     NormalizedUserName = "USER@ARP.COM", // Updated normalized username here
                     PasswordHash = hasher.HashPassword(null, "123"),
                     EmailConfirmed = true
                 }
            );
        }
    }
}
