using MediatR;
using Microsoft.AspNetCore.Mvc;
using SignatureWatch.UseCases.Contracts.ViewModels;
using SignatureWatch.UseCases.Features.UserFeatures.Commands;
using SignatureWatch.UseCases.Features.UserFeatures.Queries;

namespace SignatureWatch.Presentation.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthentificationController : ControllerBase
    {
        private IMediator _mediator;

        public IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();

        [HttpPost]
        [Route("Login")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel loginVM)
        {
            return Ok(await Mediator.Send(new GetUserQuery()));
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegistrationViewModel registrationVM)
        {
            return Ok(await Mediator.Send(new CreateUserCommand() { RegistrationVM = registrationVM}));
        }
    }
}
