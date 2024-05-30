using AutoMapper;
using Factoring.Application.DTOs.Operaciones.OperacionFactura;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.OperacionesFacturas.Commands
{
    public class CreateOperacionFacturaCommand : IRequest<Response<int>>
    {
        public int IdOperaciones { get; set; }
        public string? NroDocumento { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string? NombreDocumentoXML { get; set; }
        public string? RutaDocumentoXML { get; set; }
        public string? NombreDocumentoPDF { get; set; }
        public string? RutaDocumentoPDF { get; set; }
        public string? UsuarioCreador { get; set; }
        public DateTime FechaPagoNegociado { get; set; }
    }

    public class CreateOperacionFacturaCommandHandler : IRequestHandler<CreateOperacionFacturaCommand, Response<int>>
    {
        private readonly IOperacionesFacturaRepositoryAsync _operacionesFacturaRepositoryAsync;
        private readonly IMapper _mapper;

        public CreateOperacionFacturaCommandHandler(IOperacionesFacturaRepositoryAsync operacionesFacturaRepositoryAsync, IMapper mapper)
        {
            _operacionesFacturaRepositoryAsync = operacionesFacturaRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateOperacionFacturaCommand request, CancellationToken cancellationToken)
        {
            var factura = _mapper.Map<OperacionesFacturaInsertDto>(request);
            var res = await _operacionesFacturaRepositoryAsync.AddAsync(factura);
            return new Response<int>(res, Constantes.SUCCEDED_REGISTER_HEAD);
        }
    }
}
