using AutoMapper;
using Factoring.Application.DTOs.Girador.UbicacionGirador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.GiradorDetails.GiradorUbicacion.Commands
{
    public class DeleteGiradorUbicacionCommand : IRequest<Response<int>>
    {
        public int IdGiradorDireccion { get; set; }
        public string? UsuarioActualizacion { get; set; }

    }
    public class DeleteGiradorUbicacionCommandHandler : IRequestHandler<DeleteGiradorUbicacionCommand, Response<int>>
    {
        private readonly IGiradorDireccionRepositoryAsync _giradorDireccionRepositoryAsync;
        private readonly IMapper _mapper;

        public DeleteGiradorUbicacionCommandHandler(IGiradorDireccionRepositoryAsync giradorDireccionRepositoryAsync, IMapper mapper)
        {
            _giradorDireccionRepositoryAsync = giradorDireccionRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(DeleteGiradorUbicacionCommand command, CancellationToken cancellationToken)
        {
            var ubicacion = _mapper.Map<UbicacionGiradorDeleteDto>(command);

            await _giradorDireccionRepositoryAsync.DeleteAsync(ubicacion);
            return new Response<int>(command.IdGiradorDireccion, Constantes.SUCCEDED_DELETE_HEAD);
        }
    }
}
