using RepositoryPattern.Application.Commons.Abstractions.Data.Commons;
using RepositoryPattern.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Application.Commons.Abstractions.Data.ContextRepositories
{
    public interface IMainContextRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : EntityBase
    {
    }
}
