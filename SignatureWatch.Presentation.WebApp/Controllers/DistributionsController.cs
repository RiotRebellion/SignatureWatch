using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignatureWatch.Presentation.WebApp.Controllers.Base;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Features.Commands.DistributionCommands;
using SignatureWatch.UseCases.Features.Queries.DistributionQueries;

namespace SignatureWatch.Presentation.WebApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DistributionsController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllDistributions()
        {
            return Ok(await Mediator.Send(new GetAllDistributionsQuery()));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetDistributionById(Guid guid)
        {
            var result = await Mediator.Send(new GetDistributionByIdQuery() { Guid = guid });
            if (result == null)
                return NoContent();
            else
                return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDistribution(DistributionDTO distributionDTO)
        {
            return Ok(await Mediator.Send(new CreateDistributionCommand { DistributionDTO = distributionDTO }));
        }

        [HttpPut("{guid}")]
        public async Task<IActionResult> UpdateDistribution(Guid guid, [FromBody] DistributionDTO distributionDTO)
        {
            var result = await Mediator.Send(new UpdateDistributionCommand
            {
                Guid = guid,
                DistributionDTO = distributionDTO
            });

            if (result.IsSuccess == true)
                return Ok(result);
            else
                return BadRequest(result);

        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteDistribution(Guid guid)
        {
            var result = await Mediator.Send(new DeleteDistributionCommand { Guid = guid });
            if (result.IsSuccess == true)
                return NoContent();
            else
                return NotFound(result);
        }
    }
}
