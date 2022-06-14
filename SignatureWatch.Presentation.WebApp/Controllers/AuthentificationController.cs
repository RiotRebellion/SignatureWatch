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
        public async Task<ActionResult> Login([FromBody] LoginDTO loginVM)
        {
            if (ModelState.IsValid)
            {
                return Ok(await Mediator.Send(new LoginQuery()));
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
            return Ok(await Mediator.Send(new CreateUserCommand() { RegistrationDTO = registrationDTO}));
        }
    }
}
