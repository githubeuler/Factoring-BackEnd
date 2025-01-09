using AutoMapper;
using Factoring.Application.DTOs.Usuario;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.Usuario.Commands
{
    public class DeleteUsuarioCommand : IRequest<Response<int>>
    {
        public int IdUsuario { get; set; }
        public string? UsuarioModificacion { get; set; }
    }
    public class DeleteUsuarioCommandHandler : IRequestHandler<DeleteUsuarioCommand, Response<int>>
    {
        private readonly IUsuarioRepositoryAsync _usuarioRepositoryAsync;
        private readonly IMapper _mapper;
        public DeleteUsuarioCommandHandler(IUsuarioRepositoryAsync usuarioRepositoryAsync, IMapper mapper)
        {
            _usuarioRepositoryAsync = usuarioRepositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            var datos = _mapper.Map<UsuarioDeleteDto>(request);
            var res = await _usuarioRepositoryAsync.DeleteAsync(datos);
            return res;
        }
    }
}
