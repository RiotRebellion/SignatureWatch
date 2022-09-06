using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignatureWatch.Presentation.WebApp.Controllers.Base;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Features.Commands.UserCommands;
using SignatureWatch.UseCases.Features.Queries.UserQueries;

namespace SignatureWatch.Presentation.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthentificationController : ApiController
    {
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            return Ok(await Mediator.Send(new LoginQuery { LoginDTO = loginDTO }));
        }

        [HttpPost]
        [Authorize]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationDTO registrationDTO)
        {
            return Ok(await Mediator.Send(new CreateUserCommand() { RegistrationDTO = registrationDTO }));
        }
    }
}
