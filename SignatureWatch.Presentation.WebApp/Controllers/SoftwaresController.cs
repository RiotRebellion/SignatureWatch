using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignatureWatch.Presentation.WebApp.Controllers.Base;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Features.Commands.SoftwareCommands;
using SignatureWatch.UseCases.Features.Queries.SoftwareQueries;

namespace SignatureWatch.Presentation.WebApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SoftwaresController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllSoftware()
        {
            return Ok(await Mediator.Send(new GetAllSoftwaresQuery()));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetSoftwareById(Guid guid)
        {
            var signature = await Mediator.Send(new GetSoftwareByIdQuery() { Guid = guid });
            if (signature == null)
                return NoContent();
            else
                return Ok(signature);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSoftware([FromBody] SoftwareDTO softwareDTO)
        {
            var result = await Mediator.Send(new CreateSoftwareCommand { SoftwareDTO = softwareDTO });

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
        public async Task<IActionResult> UpdateSoftware(Guid guid, [FromBody] SoftwareDTO softwareDTO)
        {
            var result = await Mediator.Send(new UpdateSoftwareCommand
            {
                Guid = guid,
                SoftwareDTO = softwareDTO
            });
            if (result.IsSuccess == true)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteSoftware(Guid guid)
        {
            var result = await Mediator.Send(new DeleteSoftwareCommand { Guid = guid });
            if (result.IsSuccess == true)
                return NoContent();
            else
                return NotFound(result);
        }
    }
}
