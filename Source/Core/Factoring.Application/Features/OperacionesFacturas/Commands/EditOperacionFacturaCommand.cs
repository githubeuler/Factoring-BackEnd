using AutoMapper;
using Factoring.Application.DTOs.Operaciones.OperacionFactura;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.OperacionesFacturas.Commands
{
    public class EditOperacionFacturaCommand : IRequest<Response<int>>
    {
        public int IdOperacionesFacturas { get; set; }
        public string? UsuarioActualizacion { get; set; }
        public DateTime FechaPagoNegociado { get; set; }

        public class EditOperacionFacturaCommandHandler : IRequestHandler<EditOperacionFacturaCommand, Response<int>>
        {
            private readonly IOperacionesFacturaRepositoryAsync _operacionesFacturaRepositoryAsync;
            private readonly IMapper _mapper;

            public EditOperacionFacturaCommandHandler(
                IOperacionesFacturaRepositoryAsync operacionesFacturaRepositoryAsync,
                IMapper mapper)
            {
                _operacionesFacturaRepositoryAsync = operacionesFacturaRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(EditOperacionFacturaCommand command, CancellationToken cancellationToken)
            {
                var editFactura = _mapper.Map<OperacionesFacturaEditDto>(command);

                await _operacionesFacturaRepositoryAsync.EditAsync(editFactura);
                return new Response<int>(command.IdOperacionesFacturas, Constantes.SUCCEDED_UPDATE);
            }
        }
    }
}
