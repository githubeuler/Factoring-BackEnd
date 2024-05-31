using AutoMapper;
using Factoring.Application.DTOs.Operaciones;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.Operaciones.Commands
{
    public class CreateOperacionCommand : IRequest<Response<int>>
    {
        public int IdGirador { get; set; }
        public int IdAdquiriente { get; set; }
        //public int IdInversionista { get; set; }
        public int IdTipoMoneda { get; set; }
        public int IdGiradorDireccion { get; set; }
        public int IdAdquirienteDireccion { get; set; }
        public decimal TEM { get; set; }
        public decimal PorcentajeFinanciamiento { get; set; }
        public decimal PorcentajeRetencion { get; set; }

        public decimal MontoOperacion { get; set; }
        public decimal DescContrato { get; set; }
        public decimal DescFactura { get; set; }
        public decimal DescCobranza { get; set; }
        public string? UsuarioCreador { get; set; }
        public decimal InteresMoratorio { get; set; }
        //*************Ini-09-01-2023-RCARRILLO******//
        public int IdCategoria { get; set; }
        public string? SustentoComercial { get; set; }
        public string? MotivoTransaccion { get; set; }
        public int Plazo { get; set; }
        public int CantidadFactura { get; set; }
        //*************Fin-09-01-2023-RCARRILLO******//
    }

    public class CreateOperacionCommandHandler : IRequestHandler<CreateOperacionCommand, Response<int>>
    {
        private readonly IOperacionesRepositoryAsync _operacionesRepositoryAsync;
        private readonly IMapper _mapper;

        public CreateOperacionCommandHandler(IOperacionesRepositoryAsync operacionesRepositoryAsync, IMapper mapper)
        {
            _operacionesRepositoryAsync = operacionesRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateOperacionCommand request, CancellationToken cancellationToken)
        {
            var operacion = _mapper.Map<OperacionesInsertDto>(request);
            var res = await _operacionesRepositoryAsync.AddAsync(operacion);
            return res;
            //return new Response<int>(res, Constantes.SUCCEDED_REGISTER_HEAD);
        }
    }
}
