
using AutoMapper;
using Factoring.Application.DTOs.Usuario;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.Usuario.Commands
{
    public class UpdateUsuarioCommand : IRequest<Response<int>>
    {
        public int IdUsuario { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Password { get; set; }
        public string? Correo { get; set; }
        public int Activo { get; set; }
        public string? FechaCese { get; set; }
        public int IdRol { get; set; }
        public string? UsuarioModificacion { get; set; }

        public int IdTipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Telefono { get; set; }
        public string? Celular { get; set; }
        public string? Cargo { get; set; }
        public string? Ruc { get; set; }
        public string? RazonSocial { get; set; }
    }
    public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, Response<int>>
    {
        private readonly IUsuarioRepositoryAsync _usuarioRepositoryAsync;
        private readonly IMapper _mapper;
        public UpdateUsuarioCommandHandler(IUsuarioRepositoryAsync usuarioRepositoryAsync, IMapper mapper)
        {
            _usuarioRepositoryAsync = usuarioRepositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var datos = _mapper.Map<UsuarioUpdateDto>(request);
            var res = await _usuarioRepositoryAsync.UpdateAsync(datos);
            return res;
        }
    }
}
