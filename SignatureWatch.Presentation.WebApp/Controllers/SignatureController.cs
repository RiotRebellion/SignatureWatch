using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SignatureWatch.Presentation.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignatureController : ControllerBase
    {
        private IMediator _mediator;

        public IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();

        [HttpGet]
        public async Task<IActionResult> GetSignatures()
        {
            return Ok();
        }
    }
}
