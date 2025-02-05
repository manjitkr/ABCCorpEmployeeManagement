using ABCCorp.EmployeeManagement.Domain;
using MediatR;

namespace ABCCorp.EmployeeManagement.Application.Contracts.Persistence
{
    public interface IEmployeeRecordRepository : IGenericRepository<EmployeeRecord>
    {
        Task<List<EmployeeRecord>> GetAll(string? filterFirstName, string? filterLastName,string? filterDateCreated, string? filterDateModified,
        string? sortBy, string? sortDirection,int page, int pageSize);
        Task<bool> IsEmailIdExists(string employeeEmailToSave);
    }
}
