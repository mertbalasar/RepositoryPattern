using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Application.Commons.Abstractions.Data.Commons;
using RepositoryPattern.Application.Commons.Abstractions.Data.ContextRepositories;
using RepositoryPattern.Domain.Commons;
using RepositoryPattern.Infrastructure.Persistence.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Infrastructure.Persistence.ContextRepositories
{
    public class MainContextRepository<T> : IMainContextRepository<T> where T : EntityBase
    {
        private readonly MainContext _context;

        public MainContextRepository(MainContext context)
        {
            _context = context;
        }

        public async Task<IRepositoryResponse> AddAsync(T entity)
        {
            var response = new RepositoryResponse();

            try
            {
                await _context.Set<T>().AddAsync(entity);
                return response;
            }
            catch (Exception ex)
            {
                response.Succeed = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<IRepositoryResponse> AddRangeAsync(IEnumerable<T> entities)
        {
            var response = new RepositoryResponse();

            try
            {
                await _context.Set<T>().AddRangeAsync(entities);
                return response;
            }
            catch (Exception ex)
            {
                response.Succeed = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<IRepositoryResponse<IEnumerable<T>>> FindAsync(Expression<Func<T, bool>> expression)
        {
            var response = new RepositoryResponse<IEnumerable<T>>();

            try
            {
                var result = await _context.Set<T>().Where(expression).AsNoTracking().ToListAsync();
                response.Result = result;
                return response;
            }
            catch (Exception ex)
            {
                response.Succeed = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<IRepositoryResponse<IEnumerable<T>>> GetAllAsync()
        {
            var response = new RepositoryResponse<IEnumerable<T>>();

            try
            {
                var result = await _context.Set<T>().AsNoTracking().ToListAsync();
                response.Result = result;
                return response;
            }
            catch (Exception ex)
            {
                response.Succeed = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<IRepositoryResponse<T>> GetByIdAsync(Guid id)
        {
            var response = new RepositoryResponse<T>();

            try
            {
                var result = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
                response.Result = result;
                return response;
            }
            catch (Exception ex)
            {
                response.Succeed = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public IRepositoryResponse Remove(T entity)
        {
            var response = new RepositoryResponse();

            try
            {
                _context.Set<T>().Remove(entity);
                return response;
            }
            catch (Exception ex)
            {
                response.Succeed = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public IRepositoryResponse RemoveRange(IEnumerable<T> entities)
        {
            var response = new RepositoryResponse();

            try
            {
                _context.Set<T>().RemoveRange(entities);
                return response;
            }
            catch (Exception ex)
            {
                response.Succeed = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public IRepositoryResponse Update(T entity)
        {
            var response = new RepositoryResponse();

            try
            {
                _context.Set<T>().Update(entity);
                return response;
            }
            catch (Exception ex)
            {
                response.Succeed = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public IRepositoryResponse UpdateRange(IEnumerable<T> entities)
        {
            var response = new RepositoryResponse();

            try
            {
                _context.Set<T>().UpdateRange(entities);
                return response;
            }
            catch (Exception ex)
            {
                response.Succeed = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<IRepositoryResponse> RemoveBulkAsync(Expression<Func<T, bool>> expression)
        {
            var response = new RepositoryResponse();

            try
            {
                await _context.Set<T>().AsNoTracking().Where(expression).ExecuteDeleteAsync();
                return response;
            }
            catch (Exception ex)
            {
                response.Succeed = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<IRepositoryResponse> UpdateBulkAsync<TDestination>(Expression<Func<T, bool>> expression, Func<T, TDestination> field, Func<T, TDestination> value)
        {
            var response = new RepositoryResponse();

            try
            {
                await _context.Set<T>().AsNoTracking().Where(expression).ExecuteUpdateAsync(x => x.SetProperty(field, value));
                return response;
            }
            catch (Exception ex)
            {
                response.Succeed = false;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
