using Microsoft.AspNetCore.Mvc;
using SignatureWatch.Presentation.WebApp.Controllers.Base;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Features.Commands.ContractCommands;
using SignatureWatch.UseCases.Features.Queries.ContractQueries;

namespace SignatureWatch.Presentation.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractsController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllContracts()
        {
            return Ok(await Mediator.Send(new GetAllContractsQuery()));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetContractById(Guid guid)
        {
            var result = await Mediator.Send(new GetContractByIdQuery() { Guid = guid });
            if (result == null)
                return NoContent();
            else
                return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContract(ContractDTO contractDTO)
        {
            return Ok(await Mediator.Send(new CreateContractCommand { ContractDTO = contractDTO }));
        }

        [HttpPut("{guid}")]
        public async Task<IActionResult> UpdateContract(Guid guid, [FromBody] ContractDTO contractDTO)
        {
            var result = await Mediator.Send(new UpdateContractCommand
            {
                Guid = guid,
                ContractDTO = contractDTO
            });

            if (result.IsSuccess == true)
                return Ok(result);
            else
                return BadRequest(result);

        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteContract(Guid guid)
        {
            var result = await Mediator.Send(new DeleteContractCommand { Guid = guid });
            if (result.IsSuccess == true)
                return NoContent();
            else
                return NotFound(result);
        }
    }
}
