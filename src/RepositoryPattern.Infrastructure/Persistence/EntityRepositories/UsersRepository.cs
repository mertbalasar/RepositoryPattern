using RepositoryPattern.Application.Commons.Abstractions.Data.EntityRepositories;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Infrastructure.Persistence.ContextRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Infrastructure.Persistence.EntityRepositories
{
    public class UsersRepository : MainContextRepository<Users>, IUsersRepository
    {
        public UsersRepository(MainContext context) : base(context)
        {
        }
    }
}
