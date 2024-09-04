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
    public class CreateDocumentoSolicitudOperacionesCommand : IRequest<Response<int>>
    {
        public int nIdSolEvalOperaciones { get; set; }
        public int nTipoDocumento { get; set; }
        public string cNombreDocumento { get; set; }
        public string cRutaDocumento { get; set; }
        public int nEstado { get; set; }
        public string cUsuarioCreador { get; set; }
        public DateTime? dFechaCreacion { get; set; }
    }

    public class CreateDocumentoSolicitudOperacionesCommandHandler : IRequestHandler<CreateDocumentoSolicitudOperacionesCommand, Response<int>>
    {
        private readonly IOperacionesFacturaRepositoryAsync _operacionesFacturaRepositoryAsync;
        private readonly IMapper _mapper;

        public CreateDocumentoSolicitudOperacionesCommandHandler(IOperacionesFacturaRepositoryAsync operacionesFacturaRepositoryAsync, IMapper mapper)
        {
            _operacionesFacturaRepositoryAsync = operacionesFacturaRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateDocumentoSolicitudOperacionesCommand request, CancellationToken cancellationToken)
        {
            var Documento = _mapper.Map<DocumentosSolicitudperacionesInsertDto>(request);
            var res = await _operacionesFacturaRepositoryAsync.AddDocumentoSolicitudOperacionesAsync(Documento);
            return new Response<int>(res, Constantes.SUCCEDED_REGISTER_HEAD);
        }
    }
}