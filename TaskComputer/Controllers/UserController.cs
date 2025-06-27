using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskComputer.Application.Features.User.Commands.Create;

namespace TaskComputer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ApiController
    {
        private readonly ISender _sender;

        public UserController(ISender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        [HttpPost()]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var createCustomerResult = await _sender.Send(command);

            return createCustomerResult.Match(
                user => Ok(user),
                errors => Problem(errors)
            );

        }
    }
}
