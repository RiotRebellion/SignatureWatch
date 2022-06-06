using Microsoft.AspNetCore.Mvc;
using SignatureWatch.Presentation.WebApp.Controllers.Base;
using SignatureWatch.UseCases.Features.UserFeatures.Commands;

namespace SignatureWatch.Presentation.WebApp.Controllers
{
    public class AuthentificationController : CustomController
    {

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
