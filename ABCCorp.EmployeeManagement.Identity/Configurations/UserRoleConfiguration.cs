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
    class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
           builder.HasData(
               new IdentityUserRole<string>
               {
                   RoleId = "6e09f3fe-8e73-4266-8d7f-fbf7738ff919",
                   UserId = "7e09f3fe-8e73-4266-8d7f-fbf7738ff919"
               },
               new IdentityUserRole<string>
               {
                   RoleId = "f93b9889-721d-482e-a442-0837d050a350",
                   UserId = "g93b9889-721d-482e-a442-0837d050a350"
               },
                 new IdentityUserRole<string>
                 {
                     RoleId = "fc0f9913-ecd1-4b99-b7b1-c6989531af42",
                     UserId = "c282ea7b-7ffc-45af-af9f-5720c594da86"
                 }
           );
        }
    }
}
