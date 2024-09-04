using AutoMapper;
using Factoring.Application.DTOs.Operaciones.OperacionFactura;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Features.OperacionesFacturas.Commands
{
    public class DeleteSolicitudOperacionCommand : IRequest<Response<int>>
    {
        public int nIdDocumentoSolEvalOperaciones { get; set; }
        public string UsuarioActualizacion { get; set; }

        public class DeleteSolicitudOperacionCommandHandler : IRequestHandler<DeleteSolicitudOperacionCommand, Response<int>>
        {
            private readonly IOperacionesFacturaRepositoryAsync _operacionesFacturaRepositoryAsync;
            private readonly IMapper _mapper;

            public DeleteSolicitudOperacionCommandHandler(
                IOperacionesFacturaRepositoryAsync operacionesFacturaRepositoryAsync,
                IMapper mapper)
            {
                _operacionesFacturaRepositoryAsync = operacionesFacturaRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(DeleteSolicitudOperacionCommand command, CancellationToken cancellationToken)
            {
                var deleteFactura = _mapper.Map<OperacionesSolicitudDeleteDto>(command);

                await _operacionesFacturaRepositoryAsync.DeleteDocumentoAsync(deleteFactura);
                return new Response<int>(command.nIdDocumentoSolEvalOperaciones, Constantes.SUCCEDED_DELETE_HEAD);
            }
        }
    }
}