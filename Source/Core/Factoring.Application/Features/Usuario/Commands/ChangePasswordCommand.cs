using AutoMapper;
using Factoring.Application.DTOs.Account.Request;
using Factoring.Application.DTOs.Account.Response;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using Factoring.Domain.Settings;
using Factoring.Domain.Util;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Factoring.Application.Features.Usuario.Commands
{
    public class ChangePasswordCommand : IRequest<Response<AuthenticationResponse>>
    {
        public int IdUsuario { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string Token { get; set; }

    }
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Response<AuthenticationResponse>>
    {
        private readonly IUsuarioRepositoryAsync _usuarioRepositoryAsync;
        private readonly IMapper _mapper;
        private readonly JWTSettings _jwtSettings;
        public ChangePasswordCommandHandler(IUsuarioRepositoryAsync usuarioRepositoryAsync,
            IMapper mapper,
            IOptions<JWTSettings> jwtSettings)
        {
            _usuarioRepositoryAsync = usuarioRepositoryAsync;
            _mapper = mapper;
            _jwtSettings = jwtSettings.Value;
        }
        public async Task<Response<AuthenticationResponse>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var principal = ValidateToken(request.Token);
            var userPassword = principal.Claims.FirstOrDefault(c => c.Type == "ucpassword")?.Value;
            var userId = principal.Claims.FirstOrDefault(c => c.Type == "uidusuario")?.Value;

            var nombreUsuario = principal.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
            var nombrePais = principal.Claims.FirstOrDefault(c => c.Type == "pais")?.Value;
            var codigoUsuario = principal.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;

            string passwordDecrypt = AesEncryption.Decrypt(userPassword, "RFR7YZT8XK92MLGQT4NB", "F@ct0r1n6@91u5P3");

            if (request.CurrentPassword != passwordDecrypt)
            {
                return new Response<AuthenticationResponse>() { Succeeded = false,Message="La contraseña actual no es correcta." };
            }
            request.IdUsuario = Convert.ToInt32(userId);
            request.NewPassword = AesEncryption.Encrypt(request.NewPassword, "RFR7YZT8XK92MLGQT4NB", "F@ct0r1n6@91u5P3");
            var userRequest = _mapper.Map<ChangePasswordRequest>(request);
            userRequest.MustChangePassword = 0;
            var user = await _usuarioRepositoryAsync.ChangePassword(userRequest);

            return new Response<AuthenticationResponse>() {Succeeded=true,  Data = new AuthenticationResponse() {cCodigoUsuario = codigoUsuario, cNombreUsuario = nombreUsuario, cNombrePais = nombrePais },Message = user.Message };
        }
        public ClaimsPrincipal ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _jwtSettings.Issuer,
                ValidAudience = _jwtSettings.Audience, // Configura si usas una audiencia específica
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.Zero // Opcional: Evita una tolerancia predeterminada de 5 minutos
            };

            // Validar el token y obtener los claims
            try
            {
                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                // Verificar que el token sea JWT
                if (validatedToken is JwtSecurityToken jwtToken &&
                    jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    return principal; // Devuelve los Claims del token
                }
                else
                {
                    throw new SecurityTokenException("Token inválido");
                }
            }
            catch (Exception ex)
            {
                // Manejar errores de validación
                throw new SecurityTokenException($"Error al validar el token: {ex.Message}");
            }
        }
    }
}
