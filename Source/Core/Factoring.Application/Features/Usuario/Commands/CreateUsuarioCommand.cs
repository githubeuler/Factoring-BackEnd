using AutoMapper;
using Factoring.Application.DTOs.Usuario;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using Factoring.Domain.Util;
using MediatR;

namespace Factoring.Application.Features.Usuario.Commands
{
    public class CreateUsuarioCommand : IRequest<Response<int>>
    {
        public string? CodigoUsuario { get; set; }
        public string? NombreUsuario { get; set; }
        //public string? Password { get; set; }
        public string? Correo { get; set; }
        public string? UsuarioCreador { get; set; }
        public int IdPais { get; set; }
        public int IdRol { get; set; }
    }
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, Response<int>>
    {
        private readonly IUsuarioRepositoryAsync _usuarioRepositoryAsync;
        private readonly IMapper _mapper;
        public CreateUsuarioCommandHandler(IUsuarioRepositoryAsync usuarioRepositoryAsync, IMapper mapper)
        {
            _usuarioRepositoryAsync = usuarioRepositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            string password = AesEncryption.GenerateSecurePassword();
            string newPasswordEncrypt = AesEncryption.Encrypt(password, "RFR7YZT8XK92MLGQT4NB", "F@ct0r1n6@91u5P3");
            var datos = _mapper.Map<UsuarioInsertDto>(request);
            datos.Password = newPasswordEncrypt;
            var res = await _usuarioRepositoryAsync.AddAsync(datos);

            res.Message = "Usuario creado correctamente.<br><br>Usuario : <b>" + request.CodigoUsuario.ToUpper() + "</b><br>Contraseña temporal : <b>" + password + "</b>";

            return res;
        }
    }
}
