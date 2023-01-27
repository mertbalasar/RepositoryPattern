using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Application.Commons.Abstractions.Data.Commons
{
    public interface IRepositoryResponse
    {
        bool Succeed { get; set; }
        string Message { get; set; }
    }

    public interface IRepositoryResponse<T> : IRepositoryResponse
    {
        T? Result { get; set; }
    }
}
