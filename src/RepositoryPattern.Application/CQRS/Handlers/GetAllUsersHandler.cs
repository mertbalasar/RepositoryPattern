using MediatR;
using RepositoryPattern.Application.Commons.Abstractions.Data.ContextRepositories;
using RepositoryPattern.Application.CQRS.Queries;
using RepositoryPattern.Application.CQRS.Responses;
using RepositoryPattern.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Application.CQRS.Handlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, ServiceResponse<IEnumerable<Users>>>
    {
        private readonly IMainContextRepository<Users> _userRepository;

        public GetAllUsersHandler(IMainContextRepository<Users> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ServiceResponse<IEnumerable<Users>>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            var response = await _userRepository.GetAllAsync();

            return new()
            {
                Succeed = response.Succeed,
                Message = response.Message,
                Result = response.Result
            };
        }
    }
}
