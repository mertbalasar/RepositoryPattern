using MediatR;
using RepositoryPattern.Application.Commons.Abstractions.Data.ContextRepositories;
using RepositoryPattern.Application.CQRS.Commands;
using RepositoryPattern.Application.CQRS.Responses;
using RepositoryPattern.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Application.CQRS.Handlers
{
    public class InsertUserHandler : IRequestHandler<InsertUserRequest, ServiceResponse>
    {
        private readonly IMainContextRepository<Users> _userRepository;

        public InsertUserHandler(IMainContextRepository<Users> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ServiceResponse> Handle(InsertUserRequest request, CancellationToken cancellationToken)
        {
            var response = await _userRepository.AddAsync(request.User);

            return new()
            {
                Succeed = response.Succeed,
                Message = response.Message
            };
        }
    }
}
