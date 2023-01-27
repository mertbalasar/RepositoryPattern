using RepositoryPattern.Application.Commons.Abstractions.Data.Commons;
using RepositoryPattern.Application.Commons.Abstractions.Data.EntityRepositories;
using RepositoryPattern.Infrastructure.Persistence.EntityRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainContext _context;

        public UnitOfWork(MainContext context)
        {
            _context = context;
            Users = new UsersRepository(_context);
        }

        public IUsersRepository Users { get; private set; }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
