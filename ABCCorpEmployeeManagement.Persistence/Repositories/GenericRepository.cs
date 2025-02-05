using ABCCorp.EmployeeManagement.Application.Contracts.Persistence;
using ABCCorp.EmployeeManagement.Domain.Common;
using ABCCorpEmployeeManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCCorpEmployeeManagement.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity // Change 'class' to 'BaseEntity'
    {
        protected readonly EmployeeManagementDatabaseContext _context;

        public GenericRepository(EmployeeManagementDatabaseContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
           await  _context.AddAsync(entity);
           await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        

        public Task<List<T>> GetAll(string? filterFirstName)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(t=>t.Id == id);
          
            return entity;
        }

        public Task UpdateAsync(T entity)
        {
           _context.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
    }
}
