using ABCCorp.EmployeeManagement.Application.Models.Identity;
using ABCCorp.EmployeeManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.EmployeeManagement.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = "7e09f3fe-8e73-4266-8d7f-fbf7738ff919",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@localhost.com",
                    PasswordHash = hasher.HashPassword(null, "Admin@123"),
                    FirstName = "System",
                    LastName = "Admin",

                },
                new ApplicationUser
                {
                    Id = "g93b9889-721d-482e-a442-0837d050a350",
                    UserName = "user1",
                    NormalizedUserName = "USER1",
                    Email = "user1@localhost.com",
                    PasswordHash = hasher.HashPassword(null, "User1@123"),
                    FirstName = "User1",
                    LastName = "noLast",
                },
                new ApplicationUser
                {
                    Id = "c282ea7b-7ffc-45af-af9f-5720c594da86",
                    UserName = "user2",
                    NormalizedUserName = "USER2",
                    Email = "user2@localhost.com",
                    PasswordHash = hasher.HashPassword(null, "User2@123"),
                    FirstName = "User2",
                    LastName = "noLast",
                });
        }
    }
}
