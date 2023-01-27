using RepositoryPattern.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Application.Commons.Abstractions.Data.Commons
{
    public interface IWriteRepository<T> where T : EntityBase
    {
        Task<IRepositoryResponse> AddAsync(T entity);
        Task<IRepositoryResponse> AddRangeAsync(IEnumerable<T> entities);
        IRepositoryResponse Remove(T entity);
        IRepositoryResponse RemoveRange(IEnumerable<T> entities);
        IRepositoryResponse Update(T entity);
        IRepositoryResponse UpdateRange(IEnumerable<T> entities);
        Task<IRepositoryResponse> RemoveBulkAsync(Expression<Func<T, bool>> expression);
        Task<IRepositoryResponse> UpdateBulkAsync<TDestination>(Expression<Func<T, bool>> expression, Func<T, TDestination> field, Func<T, TDestination> value);
    }
}
