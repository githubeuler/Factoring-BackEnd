using Factoring.Application.Features.Adquiriente.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Factoring.WebApi.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class AdquirienteController : BaseApiController
    {
        [HttpGet("lista")]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new AdquirienteListQuery { }));
        }
    }
}
