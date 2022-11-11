using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignatureWatch.Presentation.WebApp.Controllers.Base;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Features.Commands.SoftwareLicenseCommands;
using SignatureWatch.UseCases.Features.Queries.SoftwareLicenseQueries;

namespace SignatureWatch.Presentation.WebApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SoftwareLicensesController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllSoftwareLicenses()
        {
            return Ok(await Mediator.Send(new GetAllSoftwareLicensesQuery()));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetSoftwareLicenseById(Guid guid)
        {
            var signature = await Mediator.Send(new GetSoftwareLicenseByIdQuery() { Guid = guid });
            if (signature == null)
                return NoContent();
            else
                return Ok(signature);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSoftwareLicense([FromBody] SoftwareLicenseDTO softwareLicenseDTO)
        {
            var result = await Mediator.Send(new CreateSoftwareLicenseCommand { SoftwareLicenseDTO = softwareLicenseDTO });

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
        public async Task<IActionResult> UpdateSoftwareLicense(Guid guid, [FromBody] SoftwareLicenseDTO softwareLicenseDTO)
        {
            var result = await Mediator.Send(new UpdateSoftwareLicenseCommand
            {
                Guid = guid,
                SoftwareLicenseDTO = softwareLicenseDTO
            });
            if (result.IsSuccess == true)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteSoftwareLicense(Guid guid)
        {
            var result = await Mediator.Send(new DeleteSoftwareLicenseCommand { Guid = guid });
            if (result.IsSuccess == true)
                return NoContent();
            else
                return NotFound(result);
        }
    }
}
