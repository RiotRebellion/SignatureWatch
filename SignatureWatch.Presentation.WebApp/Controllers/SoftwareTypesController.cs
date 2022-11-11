using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignatureWatch.Presentation.WebApp.Controllers.Base;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Features.Commands.SoftwareTypeCommands;
using SignatureWatch.UseCases.Features.Queries.SoftwareTypeQueries;

namespace SignatureWatch.Presentation.WebApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SoftwareTypesController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllSoftwareType()
        {
            return Ok(await Mediator.Send(new GetAllSoftwareTypesQuery()));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetSoftwareTypeById(Guid guid)
        {
            var result = await Mediator.Send(new GetSoftwareTypeByIdQuery() { Guid = guid });
            if (result == null)
                return NoContent();
            else
                return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSoftwareType([FromBody] SoftwareTypeDTO softwareTypeDTO)
        {
            return Ok(await Mediator.Send(new CreateSoftwareTypeCommand { SoftwareTypeDTO = softwareTypeDTO }));
        }

        [HttpPut("{guid}")]
        public async Task<IActionResult> UpdateSoftwareType(Guid guid, [FromBody] SoftwareTypeDTO softwareTypeDTO)
        {
            var result = await Mediator.Send(new UpdateSoftwareTypeCommand
            {
                Guid = guid,
                SoftwareTypeDTO = softwareTypeDTO
            });

            if (result.IsSuccess == true)
                return Ok(result);
            else
                return BadRequest(result);

        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteSoftwareType(Guid guid)
        {
            var result = await Mediator.Send(new DeleteSoftwareTypeCommand { Guid = guid });
            if (result.IsSuccess == true)
                return NoContent();
            else
                return NotFound(result);
        }
    }
}
