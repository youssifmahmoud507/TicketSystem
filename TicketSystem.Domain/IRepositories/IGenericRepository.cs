using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketSystem.Domain.Common;

namespace TicketSystem.Domain.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
    
        Task<T> GetByIdAsync(Guid id);

  
        Task<PagedResult<T>> GetAllAsync(int pageNumber = 1, int pageSize = 10);

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T entity);

   
        Task AddRangeAsync(IEnumerable<T> entities);


        void Update(T entity);

       
        void Delete(T entity);

        void DeleteRange(IEnumerable<T> entities);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

     
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
    }
}
