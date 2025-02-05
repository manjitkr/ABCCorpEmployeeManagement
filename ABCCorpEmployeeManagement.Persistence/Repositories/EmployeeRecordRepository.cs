using ABCCorp.EmployeeManagement.Application.Contracts.Persistence;
using ABCCorp.EmployeeManagement.Application.Exceptions;
using ABCCorp.EmployeeManagement.Domain;
using ABCCorpEmployeeManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorpEmployeeManagement.Persistence.Repositories
{
    public class EmployeeRecordRepository : GenericRepository<EmployeeRecord>, IEmployeeRecordRepository
    {
        private readonly ABCCorpEmployeeManagement.Persistence.DatabaseContext.EmployeeManagementDatabaseContext _dbContext;
        public EmployeeRecordRepository(EmployeeManagementDatabaseContext context):base(context)
        {
            _dbContext = context;
        }

        public async Task<List<EmployeeRecord>> GetAll(string? filterFirstName, string? filterLastName, string? filterDateCreated, string? filterDateModified,
            string? sortBy, string? sortDirection, int page, int pageSize)
        {
            var query = _dbContext.EmployeeRecords.AsQueryable();

            if (!string.IsNullOrEmpty(filterFirstName))
            {
                query = query.Where(e => e.FirstName.Contains(filterFirstName));
            }

            if (!string.IsNullOrEmpty(filterLastName))
            {
                query = query.Where(e => e.LastName!=null && e.LastName.Contains(filterLastName));
            }

            if (!string.IsNullOrEmpty(filterDateCreated) && DateTime.TryParse(filterDateCreated, out var dateCreated))
            {
                query = query.Where(e => e.DateCreated.HasValue && e.DateCreated.Value.Date == dateCreated.Date);
            }

            if (!string.IsNullOrEmpty(filterDateModified) && DateTime.TryParse(filterDateModified, out var dateModified))
            {
                query = query.Where(e => e.DateModified.HasValue && e.DateModified.Value.Date == dateModified.Date);
            }


            if (!string.IsNullOrEmpty(sortBy))
            {
                query = sortBy switch
                {
                    "FirstName" => sortDirection == "desc" ? query.OrderByDescending(e => e.FirstName) : query.OrderBy(e => e.FirstName),
                    "LastName" => sortDirection == "desc" ? query.OrderByDescending(e => e.LastName) : query.OrderBy(e => e.LastName),
                    "Email" => sortDirection == "desc" ? query.OrderByDescending(e => e.Email) : query.OrderBy(e => e.Email),
                    "Mobile" => sortDirection == "desc" ? query.OrderByDescending(e => e.Mobile) : query.OrderBy(e => e.Mobile),
                    "EmergencyContact" => sortDirection == "desc" ? query.OrderByDescending(e => e.EmergencyContact) : query.OrderBy(e => e.EmergencyContact),
                    "BloodGroup" => sortDirection == "desc" ? query.OrderByDescending(e => e.BloodGroup) : query.OrderBy(e => e.BloodGroup),
                    "ExperienceInYears" => sortDirection == "desc" ? query.OrderByDescending(e => e.ExperienceInYears) : query.OrderBy(e => e.ExperienceInYears),
                    "ProfilePictureUrl" => sortDirection == "desc" ? query.OrderByDescending(e => e.ProfilePictureUrl) : query.OrderBy(e => e.ProfilePictureUrl),
                    "Role" => sortDirection == "desc" ? query.OrderByDescending(e => e.Role) : query.OrderBy(e => e.Role),
                    "Status" => sortDirection == "desc" ? query.OrderByDescending(e => e.Status) : query.OrderBy(e => e.Status),
                    "ManagerName" => sortDirection == "desc" ? query.OrderByDescending(e => e.ManagerName) : query.OrderBy(e => e.ManagerName),
                    "ManagerEmail" => sortDirection == "desc" ? query.OrderByDescending(e => e.ManagerEmail) : query.OrderBy(e => e.ManagerEmail),
                    "PreviousCompanyEmployerName" => sortDirection == "desc" ? query.OrderByDescending(e => e.PreviousCompanyEmployerName) : query.OrderBy(e => e.PreviousCompanyEmployerName),
                    "AdminVerificationStatus" => sortDirection == "desc" ? query.OrderByDescending(e => e.AdminVerificationStatus) : query.OrderBy(e => e.AdminVerificationStatus),
                    "AdminVerificationComment" => sortDirection == "desc" ? query.OrderByDescending(e => e.AdminVerificationComment) : query.OrderBy(e => e.AdminVerificationComment),
                    _ => sortDirection == "desc" ? query.OrderByDescending(e => e.Id) : query.OrderBy(e => e.Id)
                };
            }

            return await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task UpdateAdminEntriesAsync(EmployeeRecord employeeRecordToUpdate)
        {
            var existingRecord = await _dbContext.EmployeeRecords.FirstOrDefaultAsync(e => e.Id == employeeRecordToUpdate.Id);
            if (existingRecord==null)
            {
                throw new BadRequestException ($"Id {employeeRecordToUpdate.Id} Record not found");
            }

            existingRecord.AdminVerificationStatus = employeeRecordToUpdate.AdminVerificationStatus;
            existingRecord.AdminVerificationComment = employeeRecordToUpdate.AdminVerificationComment;

            _dbContext.Update(employeeRecordToUpdate);
            _dbContext.Entry(employeeRecordToUpdate).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task<bool> IsEmailIdExists(string emailId)
        {
            var result= await _context.EmployeeRecords.AnyAsync(e => e.Email == emailId);
            return result;
        }
    }
}
