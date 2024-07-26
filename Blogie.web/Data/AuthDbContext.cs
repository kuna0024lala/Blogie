using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blogie.web.Data
{
    public class AuthDbContext: IdentityDbContext
    {
        public AuthDbContext(DbContextOptions options) : base(options) 
        {
                
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // seed Roles (user, Admin, SuperAdmin)
            var adminRoleId = "d3ea0e7b-a2f7-4fb9-a53e-c1a3960440fb";
            var superAdminRoleId = "21077a1c-8b6b-49b8-bc3a-2c994188729f";
            var userRoleId = "27a25d68-9bb7-4bf6-a269-1290400dff44";
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole
                {
                    Name= "SuperAdmin",
                    NormalizedName = "SuperAdmin",
                    Id = superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            //Seed SuperAdminUser
            var superAdminId = "37bf3365-2bdb-43fa-ad30-33555b6ea7e1";
            var superAdminUser = new IdentityUser
            {
                UserName = "superAdmin@blogie.com",
                NormalizedUserName = "superAdmin@blogie.com".ToUpper(),
                Email = "superAdmin@blogie.com",
                NormalizedEmail = "superAdmin@blogie.com".ToUpper(),
                Id = superAdminId

            };
            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(superAdminUser, "superadmin@123");


            builder.Entity<IdentityUser>().HasData(superAdminUser);

            //Add All Roles to SuperAdminUser
            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId

                },
                 new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId ,
                    UserId = superAdminId

                },
                  new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = superAdminId

                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }
    }
}
