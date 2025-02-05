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
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
           builder.HasData(
               new IdentityRole
               {
                   Id = "6e09f3fe-8e73-4266-8d7f-fbf7738ff919",
                   Name = "Admin",
                   NormalizedName = "ADMIN"
               },
               new IdentityRole
               {
                   Id = "f93b9889-721d-482e-a442-0837d050a350",
                   Name = "ActiveAppUser",
                   NormalizedName = "ACTIVEAPPUSER"
               },
               new IdentityRole
               {
                   Id = "fc0f9913-ecd1-4b99-b7b1-c6989531af42",
                   Name = "InactiveAppUser",
                   NormalizedName = "INACTIVEAPPUSER"
               }
           );
        }
    }
}
