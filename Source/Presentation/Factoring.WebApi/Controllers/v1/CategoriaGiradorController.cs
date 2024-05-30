using Factoring.Application.Features.GiradorDetails.Categoria.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Factoring.WebApi.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class CategoriaGiradorController : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllCategoriaByIdGirador(int id)
        {
            return Ok(await Mediator.Send(new GetAllCategoriaByIdGirador()
            {
                Id = id
            }));
        }
    }
}
