using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                    new ApplicationUser
                    {
                        Id = "60a9d4eb-a04d-4e32-a803-6af464b9587c",
                        UserName = "admin",
                        NormalizedUserName = "ADMIN",
                        Email = "admin@localhost",
                        NormalizedEmail = "ADMIN@LOCALHOST",
                        FirstName = "Admin",
                        LastName = "Admin",
                        PasswordHash = hasher.HashPassword(null, "Admin@123"),
                    },
                    new ApplicationUser
                    {
                        Id = "3c029b79-61d5-49cc-96bd-3c1a60dcc006",
                        UserName = "user",
                        NormalizedUserName = "USER",
                        Email = "user@localhost",
                        NormalizedEmail = "USER@LOCALHOST",
                        FirstName = "user",
                        LastName = "user",
                        PasswordHash = hasher.HashPassword(null, "Admin@123"),
                    }
                );
        }
    }
}
