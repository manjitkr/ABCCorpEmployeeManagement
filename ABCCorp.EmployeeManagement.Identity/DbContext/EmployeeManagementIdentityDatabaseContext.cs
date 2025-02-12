﻿using ABCCorp.EmployeeManagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.EmployeeManagement.Identity.DbContext
{
    class EmployeeManagementIdentityDatabaseContext: IdentityDbContext<ApplicationUser>
    {
        public EmployeeManagementIdentityDatabaseContext(DbContextOptions<EmployeeManagementIdentityDatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(typeof(EmployeeManagementIdentityDatabaseContext).Assembly);
            base.OnModelCreating(builder);  
        }
    }
}
