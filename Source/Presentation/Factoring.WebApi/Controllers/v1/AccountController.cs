using Factoring.Application.Features.Usuario.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Factoring.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AccountController : BaseApiController
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Auth(AuthenticateCommand command)
        {
            //comment
            return Ok(await Mediator.Send(command));
        }
    }
}
