using AutoMapper;
using Factoring.Application.DTOs.Operaciones.OperacionFactura;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.OperacionesFacturas.Commands
{
    public class EditOperacionFacturaMontoCommand : IRequest<Response<int>>
    {
        public int nIdOperaciones { get; set; }
        public int nIdOperacionesFacturas { get; set; }
        public string? cUsuarioActualizacion { get; set; }
        public decimal nMonto { get; set; }

        public class EditOperacionFacturaMontoCommandHandler : IRequestHandler<EditOperacionFacturaMontoCommand, Response<int>>
        {
            private readonly IOperacionesFacturaRepositoryAsync _operacionesFacturaRepositoryAsync;
            private readonly IMapper _mapper;

            public EditOperacionFacturaMontoCommandHandler(
                IOperacionesFacturaRepositoryAsync operacionesFacturaRepositoryAsync,
                IMapper mapper)
            {
                _operacionesFacturaRepositoryAsync = operacionesFacturaRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(EditOperacionFacturaMontoCommand command, CancellationToken cancellationToken)
            {
                var editFactura = _mapper.Map<OperacionesFacturaEditMontoDto>(command);
                await _operacionesFacturaRepositoryAsync.EditMontoAsync(editFactura);
                return new Response<int>(command.nIdOperacionesFacturas, Constantes.SUCCEDED_UPDATE);
            }
        }
    }
}

