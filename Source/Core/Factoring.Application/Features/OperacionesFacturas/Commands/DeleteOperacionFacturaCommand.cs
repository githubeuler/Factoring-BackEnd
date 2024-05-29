using AutoMapper;
using Factoring.Application.DTOs.Operaciones.OperacionFactura;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.OperacionesFacturas.Commands
{
    public class DeleteOperacionFacturaCommand : IRequest<Response<int>>
    {
        public int IdOperacionesFacturas { get; set; }
        public string? UsuarioActualizacion { get; set; }

        public class DeleteOperacionFacturaCommandHandler : IRequestHandler<DeleteOperacionFacturaCommand, Response<int>>
        {
            private readonly IOperacionesFacturaRepositoryAsync _operacionesFacturaRepositoryAsync;
            private readonly IMapper _mapper;

            public DeleteOperacionFacturaCommandHandler(
                IOperacionesFacturaRepositoryAsync operacionesFacturaRepositoryAsync,
                IMapper mapper)
            {
                _operacionesFacturaRepositoryAsync = operacionesFacturaRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(DeleteOperacionFacturaCommand command, CancellationToken cancellationToken)
            {
                var deleteFactura = _mapper.Map<OperacionesFacturaDeleteDto>(command);

                await _operacionesFacturaRepositoryAsync.DeleteAsync(deleteFactura);
                return new Response<int>(command.IdOperacionesFacturas, Constantes.SUCCEDED_DELETE_HEAD);
            }
        }
    }
}
