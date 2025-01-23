using AutoMapper;
using Factoring.Application.DTOs.Account.Request;
using Factoring.Application.DTOs.Account.Response;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using Factoring.Domain.Settings;
using Factoring.Domain.Util;
using MediatR;
using Microsoft.Extensions.Options;

namespace Factoring.Application.Features.Usuario.Commands
{
    public class ResetPasswordCommand : IRequest<Response<int>>
    {
        public int IdUsuario { get; set; }
        public string CodigoUsuario { get; set; }
    }
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, Response<int>>
    {
        private readonly IUsuarioRepositoryAsync _usuarioRepositoryAsync;
        private readonly IMapper _mapper;

        public ResetPasswordCommandHandler(IUsuarioRepositoryAsync usuarioRepositoryAsync,
            IMapper mapper)
        {
            _usuarioRepositoryAsync = usuarioRepositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            string password = AesEncryption.GenerateSecurePassword();
            string newPasswordEncrypt = AesEncryption.Encrypt(password, "RFR7YZT8XK92MLGQT4NB", "F@ct0r1n6@91u5P3");

            var userRequest = _mapper.Map<ChangePasswordRequest>(request);
            userRequest.MustChangePassword = 1;
            userRequest.NewPassword = newPasswordEncrypt;
            var user = await _usuarioRepositoryAsync.ChangePassword(userRequest);
            user.Message = "Se reseteo la contraseña correctamente.<br><br>Usuario : <b>" + request.CodigoUsuario.ToUpper() + "</b><br>Contraseña temporal : <b>" + password + "</b>";
            return user;
        }
    }
}
