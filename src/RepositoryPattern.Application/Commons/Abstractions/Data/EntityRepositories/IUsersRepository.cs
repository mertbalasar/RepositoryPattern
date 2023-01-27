using RepositoryPattern.Application.Commons.Abstractions.Data.ContextRepositories;
using RepositoryPattern.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Application.Commons.Abstractions.Data.EntityRepositories
{
    public interface IUsersRepository : IMainContextRepository<Users>
    {
    }
}
