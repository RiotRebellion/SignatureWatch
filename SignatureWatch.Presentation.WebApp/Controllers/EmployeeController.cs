using Microsoft.AspNetCore.Mvc;
using SignatureWatch.Presentation.WebApp.Controllers.Base;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Features.Commands.EmployeeCommands;

namespace SignatureWatch.Presentation.WebApp.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EmployeeController : ApiController
    {
        
        [HttpPost]
        [Route("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee(EmployeeDTO employeeDTO)
        {
            return Ok(await Mediator.Send(new CreateEmployeeCommand { EmployeeDTO = employeeDTO}));
        }


        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployee()
        {
            return Ok();
        }

        //[HttpPut("id")]
        //[Route("UpdateEmployee")]
        //public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] EmployeeDTO employeeDTO)
        //{
        //    if (id != employeeDTO.Id)
        //        return BadRequest();
        //    return Ok(await Mediator.Send(new UpdateEmployeeCommand { EmployeeDTO = employeeDTO }));
        //}
    }
}
