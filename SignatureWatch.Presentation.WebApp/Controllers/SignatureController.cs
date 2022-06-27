﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using SignatureWatch.Presentation.WebApp.Controllers.Base;
using SignatureWatch.UseCases.Features.Queries.SignatureQueries;

namespace SignatureWatch.Presentation.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignatureController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetSignatures()
        {
            return Ok(await Mediator.Send(new GetAllSignaturesQuery()));
        }
    }
}
