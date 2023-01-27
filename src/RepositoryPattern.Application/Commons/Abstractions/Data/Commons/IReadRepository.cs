using RepositoryPattern.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Application.Commons.Abstractions.Data.Commons
{
    public interface IReadRepository<T> where T : EntityBase
    {
        Task<IRepositoryResponse<T>> GetByIdAsync(Guid id);
        Task<IRepositoryResponse<IEnumerable<T>>> GetAllAsync();
        Task<IRepositoryResponse<IEnumerable<T>>> FindAsync(Expression<Func<T, bool>> expression);
    }
}
