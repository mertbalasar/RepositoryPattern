using MediatR;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Application.CQRS.Commands;
using RepositoryPattern.Application.CQRS.Responses;

namespace RepositoryPattern.Presentation.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> InsertUser([FromBody] InsertUserRequest request)
        {
            ServiceResponse response = await _mediator.Send(request);
            if (response.Succeed)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}
