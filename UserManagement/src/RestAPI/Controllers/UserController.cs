using Application.Commands;
using Core.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator mediator;

        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        [HttpPost(Name = "CreateUser")]
        public async Task<UserDto> CreateUser(CreateUserCommand command)
        {
            try
            {
                return await mediator.Send(command);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
