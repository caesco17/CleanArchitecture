using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "a83181e6-cbe5-4023-b2f7-04d0b1bbd256",
                    UserId = "60a9d4eb-a04d-4e32-a803-6af464b9587c"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "ce95535f-4f12-4a2d-b980-a39efbc8f0f5",
                    UserId = "3c029b79-61d5-49cc-96bd-3c1a60dcc006"
                }
            );
        }
    }
}
