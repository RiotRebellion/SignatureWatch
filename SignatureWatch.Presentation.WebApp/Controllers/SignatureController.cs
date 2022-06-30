using MediatR;
using Microsoft.AspNetCore.Mvc;
using SignatureWatch.Presentation.WebApp.Controllers.Base;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Features.Commands.SignatureCommands;
using SignatureWatch.UseCases.Features.Queries.SignatureQueries;

namespace SignatureWatch.Presentation.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignatureController : ApiController
    {
        [HttpGet]
        [Route("GetAllSignatures")]
        public async Task<IActionResult> GetAllSignatures()
        {
            return Ok(await Mediator.Send(new GetAllSignaturesQuery()));
        }

        [HttpPost]
        [Route("CreateSignature")]
        public async Task<IActionResult> CreateSignature([FromBody] SignatureDTO signatureDTO)
        {
            return Ok(await Mediator.Send(new CreateSignatureCommand { SignatureDTO = signatureDTO}));
        }
    }
}
