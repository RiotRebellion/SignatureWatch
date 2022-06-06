using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SignatureWatch.Presentation.WebApp.Controllers.Base
{
    public class CustomController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
    }
}
