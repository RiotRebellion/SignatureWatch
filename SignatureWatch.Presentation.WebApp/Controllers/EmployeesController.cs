using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignatureWatch.Presentation.WebApp.Controllers.Base;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Features.Commands.EmployeeCommands;
using SignatureWatch.UseCases.Features.Queries.EmployeeQueries;
using SignatureWatch.UseCases.Features.Queries.SignatureQueries;

namespace SignatureWatch.Presentation.WebApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            return Ok(await Mediator.Send(new GetAllEmployeesQuery()));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetEmployeeById(Guid guid)
        {
            var result = await Mediator.Send(new GetEmployeeByIdQuery() { Guid = guid});
            if (result == null)
                return NoContent();
            else
                return Ok(result);
        }

        [HttpGet("{guid}/signatures")]
        public async Task<IActionResult> GetAllSignaturesByEmployee(Guid guid)
        {
             return Ok(await Mediator.Send(new GetAllSignaturesByEmployee { Guid = guid }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeDTO employeeDTO)
        {
            return Ok(await Mediator.Send(new CreateEmployeeCommand { EmployeeDTO = employeeDTO }));
        }

        [HttpPut("{guid}")]
        public async Task<IActionResult> UpdateEmployee(Guid guid, [FromBody] EmployeeDTO employeeDTO)
        {
            var result = await Mediator.Send(new UpdateEmployeeCommand
            {
                Guid = guid,
                EmployeeDTO = employeeDTO
            });

            if (result.IsSuccess == true)
                return Ok(result);
            else
                return BadRequest(result);

        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeteleEmployee(Guid guid)
        {
            var result = await Mediator.Send(new DeleteEmployeeCommand { Guid = guid });
            if (result.IsSuccess == true)
                return NoContent();
            else
                return NotFound(result);
        }
    }
}
