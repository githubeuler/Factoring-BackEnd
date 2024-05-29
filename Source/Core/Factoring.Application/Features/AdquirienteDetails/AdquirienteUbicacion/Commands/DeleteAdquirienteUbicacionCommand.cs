using AutoMapper;
using Factoring.Application.DTOs.Adquiriente.UbicacionAdquiriente;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.AdquirienteDetails.AdquirienteUbicacion.Commands
{
    public class DeleteAdquirienteUbicacionCommand : IRequest<Response<int>>
    {
        public string UsuarioActualizacion { get; set; }
        public int IdAdquirienteDireccion { get; set; }

        public class DeleteAdquirienteUbicacionCommandHandler : IRequestHandler<DeleteAdquirienteUbicacionCommand, Response<int>>
        {
            private readonly IAdquirienteDireccionRepositoryAsync _adquirienteDireccionRepositoryAsync;
            private readonly IMapper _mapper;

            public DeleteAdquirienteUbicacionCommandHandler(
                IAdquirienteDireccionRepositoryAsync adquirienteDireccionRepositoryAsync,
                IMapper mapper
                )
            {
                _adquirienteDireccionRepositoryAsync = adquirienteDireccionRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(DeleteAdquirienteUbicacionCommand command, CancellationToken cancellationToken)
            {
                var ubicacionDelete = _mapper.Map<UbicacionAdquirienteDeleteDto>(command);

                await _adquirienteDireccionRepositoryAsync.DeleteAsync(ubicacionDelete);
                return new Response<int>(command.IdAdquirienteDireccion, Constantes.SUCCEDED_DELETE_HEAD);
            }
        }
    }
}
