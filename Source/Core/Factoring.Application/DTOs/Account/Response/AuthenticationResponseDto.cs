using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.DTOs.Account.Response
{
    public class AuthenticationResponseDto
    {
        public string JWToken { get; set; }
        public string RefreshToken { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
