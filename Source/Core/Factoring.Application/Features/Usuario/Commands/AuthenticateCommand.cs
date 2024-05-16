using AutoMapper;
using Factoring.Application.DTOs.Account.Request;
using Factoring.Application.DTOs.Account.Response;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using Factoring.Domain.Settings;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Factoring.Application.Features.Usuario.Commands
{
    public partial class AuthenticateCommand : IRequest<Response<AuthenticationResponse>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, Response<AuthenticationResponse>>
    {
        private readonly IUsuarioRepositoryAsync _usuarioRepositoryAsync;
        private readonly IMapper _mapper;
        private readonly JWTSettings _jwtSettings;

        public AuthenticateCommandHandler(
            IUsuarioRepositoryAsync usuarioRepositoryAsync,
            IMapper mapper,
            IOptions<JWTSettings> jwtSettings

            )
        {
            _usuarioRepositoryAsync = usuarioRepositoryAsync;
            _mapper = mapper;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<Response<AuthenticationResponse>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            var userRequest = _mapper.Map<AuthenticationRequest>(request);
            var user = await _usuarioRepositoryAsync.GetUserAuth(userRequest);

            if (user == null)
            {
                throw new ApiException($"Usuario o contraseña incorrecta.");
            }
            else
            {
                #region Menu

                var menu = new List<MenuResponse>();
                AuthenticationRequest parametro = new AuthenticationRequest
                {
                    Username = user.cCodigoUsuario
                };
                var resultMenu = await _usuarioRepositoryAsync.GetListMenu(parametro);
                menu = ListMenu(resultMenu);

                #endregion Menu

                user.Menu = menu;
                JwtSecurityToken jwtSecurityToken = GenerateJWToken(user);
                user.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

                return new Response<AuthenticationResponse>(user, $"Usuario autenticado {user.cNombreUsuario}");
            }
        }

        private List<MenuResponse> ListMenu(List<MenuResponse> olista)
        {
            List<MenuResponse> listResult = new List<MenuResponse>();
            MenuResponse obj;
            if (olista.Count > 0)
            {
                int codigo = 0;
                string cadAcciones = string.Empty;
                foreach (var item in olista)
                {
                    obj = new MenuResponse();
                    var dto = olista.Where(y => y.nIdMenu == item.nIdMenu).ToList();
                    if (dto.Count > 1 && codigo != item.nIdMenu)
                    {
                        var datoResult = GetActionMenu(dto);
                        obj.nIdMenu = item.nIdMenu;
                        obj.cNombreMenu = item.cNombreMenu;
                        obj.cUrl = item.cUrl;
                        obj.nNivel = item.nNivel;
                        obj.nOrder = item.nOrder;
                        obj.cIcono = item.cIcono;
                        obj.nActivo = item.nActivo;
                        obj.cMenuPermisos = datoResult;
                        listResult.Add(obj);
                    }
                    else
                    {
                        if (codigo != item.nIdMenu)
                        {
                            obj.nIdMenu = item.nIdMenu;
                            obj.cNombreMenu = item.cNombreMenu;
                            obj.cUrl = item.cUrl;
                            obj.nNivel = item.nNivel;
                            obj.nOrder = item.nOrder;
                            obj.cIcono = item.cIcono;
                            obj.nActivo = item.nActivo;
                            obj.cMenuPermisos = item.nIdAccion.ToString();
                            listResult.Add(obj);
                        }
                    }
                    codigo = item.nIdMenu;
                }
            }
            return listResult;
        }
        private string GetActionMenu(List<MenuResponse> olista)
        {
            string result = string.Empty;
            string cadResult = string.Empty;
            if (olista.Count > 0)
            {
                foreach (var item in olista)
                {
                    result += item.nIdAccion + ",";
                }
                if (result.Length > 0) cadResult = result.Remove(result.Length - 1);
            }
            return cadResult;
        }
        private JwtSecurityToken GenerateJWToken(AuthenticationResponse user)
        {
            var roleClaims = new List<Claim>();
            roleClaims.Add(new Claim("roles", "Administrador"));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name, user.cNombreUsuario),
                new Claim("pais", user.cNombrePais),
                new Claim("uid", user.cCodigoUsuario),
            }
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddYears(3),//DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

        private string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }
    }
}
