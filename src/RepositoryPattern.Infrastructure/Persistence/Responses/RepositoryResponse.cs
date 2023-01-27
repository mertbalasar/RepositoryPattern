using RepositoryPattern.Application.Commons.Abstractions.Data.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Infrastructure.Persistence.Responses
{
    public class RepositoryResponse : IRepositoryResponse
    {
        public bool Succeed { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }

    public class RepositoryResponse<T> : RepositoryResponse, IRepositoryResponse<T>
    {
        public T? Result { get; set; }
    }
}
