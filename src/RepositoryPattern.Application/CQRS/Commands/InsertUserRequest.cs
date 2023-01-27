using MediatR;
using RepositoryPattern.Application.CQRS.Responses;
using RepositoryPattern.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Application.CQRS.Commands
{
    public class InsertUserRequest : IRequest<ServiceResponse>
    {
        public Users User { get; set; }
    }
}
