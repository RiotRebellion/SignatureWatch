using MediatR;
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login([FromBody] LoginDTO LoginDTO)
        {
            if (ModelState.IsValid)
            {
                return Ok(await Mediator.Send(new LoginQuery { LoginDTO = LoginDTO }));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationDTO registrationDTO)
        {
            if (ModelState.IsValid)
            {
                return Ok(await Mediator.Send(new CreateUserCommand() { RegistrationDTO = registrationDTO }));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
