﻿using ABCCorp.EmployeeManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorp.EmployeeManagement.Domain
{

    public class EmployeeRecord : BaseEntity
    {
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Email { get; set; }
        public required string Mobile { get; set; }
        public  string? EmergencyContact { get; set; }
        public string? BloodGroup { get; set; }
        public int ExperienceInYears { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public required string Role { get; set; }
        public required string Status { get; set; }
        public string? ManagerName { get; set; }
        public string? ManagerEmail { get; set; }
        public string? PreviousCompanyEmployerName { get; set; }
        public required string AdminVerificationStatus { get; set; }
        public string? AdminVerificationComment { get; set; }


    }
}
