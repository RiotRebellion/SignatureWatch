using Microsoft.AspNetCore.Mvc;
using SignatureWatch.Presentation.WebApp.Controllers.Base;
using SignatureWatch.UseCases.Contracts.DTO;
using SignatureWatch.UseCases.Features.Commands.FormularCommands;
using SignatureWatch.UseCases.Features.Queries.FormularQueries;

namespace SignatureWatch.Presentation.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormularController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllFormulars()
        {
            return Ok(await Mediator.Send(new GetAllFormularsQuery()));
        }

        [HttpGet("{guid}")]
        public async Task<IActionResult> GetFormularById(Guid guid)
        {
            var result = await Mediator.Send(new GetFormularByIdQuery() { Guid = guid });
            if (result == null)
                return NoContent();
            else
                return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFormular(FormularDTO formularDTO)
        {
            return Ok(await Mediator.Send(new CreateFormularCommand { FormularDTO = formularDTO }));
        }

        [HttpPut("{guid}")]
        public async Task<IActionResult> UpdateFormular(Guid guid, [FromBody] FormularDTO formularDTO)
        {
            var result = await Mediator.Send(new UpdateFormularCommand
            {
                Guid = guid,
                FormularDTO = formularDTO
            });

            if (result.IsSuccess == true)
                return Ok(result);
            else
                return BadRequest(result);

        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteFormular(Guid guid)
        {
            var result = await Mediator.Send(new DeleteFormularCommand { Guid = guid });
            if (result.IsSuccess == true)
                return NoContent();
            else
                return NotFound(result);
        }
    }
}
