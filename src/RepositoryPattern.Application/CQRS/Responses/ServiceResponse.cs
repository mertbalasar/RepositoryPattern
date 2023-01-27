using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Application.CQRS.Responses
{
    public class ServiceResponse
    {
        public bool Succeed { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }

    public class ServiceResponse<T> : ServiceResponse
    {
        public T? Result { get; set; }
    }
}
