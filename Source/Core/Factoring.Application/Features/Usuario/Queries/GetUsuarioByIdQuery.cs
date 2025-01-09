using AutoMapper;
using Factoring.Application.DTOs.Fondeador;
using Factoring.Application.DTOs.Usuario;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.Usuario.Queries
{
    public class GetUsuarioByIdQuery : IRequest<Response<UsuarioGetByIdDto>>
    {
        public int IdUsuario { get; set; }
    }
    public class GetUsuarioByIdQueryHandler : IRequestHandler<GetUsuarioByIdQuery, Response<UsuarioGetByIdDto>>
    {
        private readonly IUsuarioRepositoryAsync _usuarioRepositoryAsync;
        public GetUsuarioByIdQueryHandler(IUsuarioRepositoryAsync usuarioRepositoryAsync)
        {
            _usuarioRepositoryAsync = usuarioRepositoryAsync;
        }
        public async Task<Response<UsuarioGetByIdDto>> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _usuarioRepositoryAsync.GetByIdAsync(request.IdUsuario);
            if (data == null) throw new ApiException($"Usuario no encontrado.");
            return new Response<UsuarioGetByIdDto>(data);
        }
    }
}
