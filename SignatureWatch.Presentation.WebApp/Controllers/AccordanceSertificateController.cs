using Microsoft.AspNetCore.Mvc;
using SignatureWatch.Presentation.WebApp.Controllers.Base;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Features.Commands.AccordanceSertificateCommands;
using SignatureWatch.UseCases.Features.Queries.AccordanceSertificateQueries;

namespace SignatureWatch.Presentation.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccordanceSertificateController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAccordanceSertificates()
        {
            return Ok(await Mediator.Send(new GetAllAccordanceSertificatesQuery()));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetAccordanceSertificateById(Guid guid)
        {
            var signature = await Mediator.Send(new GetAccordanceSertificateByIdQuery() { Guid = guid });
            if (signature == null)
                return NoContent();
            else
                return Ok(signature);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccordanceSertificate([FromBody] AccordanceSertificateDTO accordanceSertificateDTO)
        {
            var result = await Mediator.Send(new CreateAccordanceSertificateCommand { AccordanceSertificateDTO = accordanceSertificateDTO });

            if (result.IsSuccess == true)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut("{guid}")]
        public async Task<IActionResult> UpdateAccordanceSertificate(Guid guid, [FromBody] AccordanceSertificateDTO accordanceSertificateDTO)
        {
            var result = await Mediator.Send(new UpdateAccordanceSertificateCommand
            {
                Guid = guid,
                AccordanceSertificateDTO = accordanceSertificateDTO
            });
            if (result.IsSuccess == true)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteAccordanceSertificate(Guid guid)
        {
            var result = await Mediator.Send(new DeleteAccordanceSertificateCommand { Guid = guid });
            if (result.IsSuccess == true)
                return NoContent();
            else
                return NotFound(result);
        }
    }
}
