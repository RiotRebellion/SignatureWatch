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
    public class SignaturesController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllSignatures()
        {
            return Ok(await Mediator.Send(new GetAllSignaturesQuery()));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetSignatureById(Guid guid)
        {
            var signature = await Mediator.Send(new GetSignatureByIdQuery());
            if (signature == null)
                return NoContent();
            else
                return Ok(signature);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSignature([FromBody] SignatureDTO signatureDTO)
        {
            return Ok(await Mediator.Send(new CreateSignatureCommand { SignatureDTO = signatureDTO }));
        }

        [HttpPut("{guid}")]
        public async Task<IActionResult> UpdateSignature(Guid guid, [FromBody] SignatureDTO signatureDTO)
        {
            var result = await Mediator.Send(new UpdateSignatureCommand
            {
                Guid = guid,
                SignatureDTO = signatureDTO
            });
            if (result.IsSuccess == true)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteSignature(Guid guid)
        {
            var result = await Mediator.Send(new DeleteSignatureCommand { Guid = guid });
            if (result.IsSuccess == true)
                return NoContent();
            else
                return NotFound(result);
        }
    }
}
