using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Factoring.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Factoring.WebApi.Controllers.v1
{
    public class PaisController : BaseApiController
    {

        private readonly IPaisRepositoryAsync _paisRepositoryAsync;
        public PaisController(IPaisRepositoryAsync paisRepositoryAsync)
        {
            _paisRepositoryAsync = paisRepositoryAsync;
        }

        [HttpGet("get-sector")]
        public async Task<IActionResult> GetListSector([FromQuery] int? idPais, int idTipo = 1)
        {
            return Ok(await _paisRepositoryAsync.GetListSector(idTipo, idPais));
        }
        [HttpGet("get-grupo")]
        public async Task<IActionResult> GetLisGrupo([FromQuery] int? idPais, int idTipo = 1)
        {
            return Ok(await _paisRepositoryAsync.GetListGrupo(idTipo, idPais));
        }
    }
}
