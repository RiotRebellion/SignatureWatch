using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignatureWatch.Presentation.WebApp.Controllers.Base;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Features.Commands.SupportCommands;
using SignatureWatch.UseCases.Features.Queries.SupportQueries;

namespace SignatureWatch.Presentation.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupportsController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllSupport()
        {
            return Ok(await Mediator.Send(new GetAllSupportsQuery()));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetSupportById(Guid guid)
        {
            var result = await Mediator.Send(new GetSupportByIdQuery() { Guid = guid });
            if (result == null)
                return NoContent();
            else
                return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupport([FromBody] SupportDTO supportDTO)
        {
            return Ok(await Mediator.Send(new CreateSupportCommand { SupportDTO = supportDTO }));
        }

        [HttpPut("{guid}")]
        public async Task<IActionResult> UpdateSupport(Guid guid, [FromBody] SupportDTO supportDTO)
        {
            var result = await Mediator.Send(new UpdateSupportCommand
            {
                Guid = guid,
                SupportDTO = supportDTO
            });

            if (result.IsSuccess == true)
                return Ok(result);
            else
                return BadRequest(result);

        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeteleSupport(Guid guid)
        {
            var result = await Mediator.Send(new DeleteSupportCommand { Guid = guid });
            if (result.IsSuccess == true)
                return NoContent();
            else
                return NotFound(result);
        }
    }
}