using AutoMapper;
using Factoring.Application.DTOs.Usuario;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.Usuario.Commands
{
    public class CreateUsuarioCommand : IRequest<Response<int>>
    {
        public string? CodigoUsuario { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Password { get; set; }
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
            var datos = _mapper.Map<UsuarioInsertDto>(request);
            var res = await _usuarioRepositoryAsync.AddAsync(datos);
            return res;
        }
    }
}
