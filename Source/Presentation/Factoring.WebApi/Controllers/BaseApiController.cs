﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Factoring.WebApi.Controllers
{
    [ApiController]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}