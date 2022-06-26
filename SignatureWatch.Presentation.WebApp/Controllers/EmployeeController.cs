using Microsoft.AspNetCore.Mvc;
using SignatureWatch.Presentation.WebApp.Controllers.Base;

namespace SignatureWatch.Presentation.WebApp.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EmployeeController : ApiController
    {
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
