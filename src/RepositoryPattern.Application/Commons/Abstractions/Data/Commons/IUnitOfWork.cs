using RepositoryPattern.Application.Commons.Abstractions.Data.EntityRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Application.Commons.Abstractions.Data.Commons
{
    public interface IUnitOfWork
    {
        IUsersRepository Users { get; }
        Task<int> Complete();
    }
}
