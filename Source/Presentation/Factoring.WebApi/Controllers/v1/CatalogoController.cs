using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Factoring.Application.Features.Catalogo.Query.CatalogoListQuery;
using System.Threading.Tasks;

namespace Factoring.WebApi.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class CatalogoController :  BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CatalogoListQuery filter)
        {
            return Ok(await Mediator.Send(filter));
        }

        [HttpGet("get-catogoria-girador")]
        public async Task<IActionResult> GetCategoriaGirador([FromQuery] CatalogoListCategoriaQuery filter)
        {
            return Ok(await Mediator.Send(filter));
        }


    }
}
