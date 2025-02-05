using ABCCorp.EmployeeManagement.Domain;
using ABCCorp.EmployeeManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorpEmployeeManagement.Persistence.DatabaseContext
{
    public class EmployeeManagementDatabaseContext :DbContext
    {
        public EmployeeManagementDatabaseContext(DbContextOptions<EmployeeManagementDatabaseContext> options):base(options)
        {
                
        }

        public DbSet<EmployeeRecord> EmployeeRecords { get; set; }

        

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var ent in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q=>q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                ent.Entity.DateModified = DateTime.Now;

                if (ent.State == EntityState.Added)
                {
                    ent.Entity.DateCreated = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeManagementDatabaseContext).Assembly);

;


            base.OnModelCreating(modelBuilder);
        }
    }
}
