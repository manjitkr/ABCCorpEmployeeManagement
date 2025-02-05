using ABCCorp.EmployeeManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorpEmployeeManagement.Persistence.Configurations
{
    class EmployeeRecordConfiguration : IEntityTypeConfiguration<EmployeeRecord>
    {
        public void Configure(EntityTypeBuilder<EmployeeRecord> builder)
        {
            builder.HasData
                 (
                 new EmployeeRecord
                 {
                     Id = 1,
                     FirstName = "John",
                     LastName = "Doe",
                     Mobile = "123-456-789",
                     Email = "johndoe@email.com",
                     Role = "Developer",
                     Status = "Active",
                     DateModified = DateTime.Now,
                     DateCreated = DateTime.Now,
                     AdminVerificationStatus = "PendingVerification"
                 }
                 );
        }
    }
}
