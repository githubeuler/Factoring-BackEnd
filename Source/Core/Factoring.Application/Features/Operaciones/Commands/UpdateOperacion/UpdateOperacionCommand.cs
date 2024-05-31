using AutoMapper;
using MediatR;
using Factoring.Application.DTOs.Operaciones;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace Factoring.Application.Features.Operaciones.Commands.UpdateOperacion
{
    public class UpdateOperacionCommand : IRequest<Response<int>>
    {
        public int IdOperaciones { get; set; }
        public int IdGirador { get; set; }
        public int IdAdquiriente { get; set; }
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
        public string? UsuarioActualizacion { get; set; }
        public decimal InteresMoratorio { get; set; }
        public int IdCategoria { get; set; }
        public string? MotivoTransaccion { get; set; }
   
        public class UpdateOperacionCommandHandler : IRequestHandler<UpdateOperacionCommand, Response<int>>
        {
            private readonly IOperacionesRepositoryAsync _operacionesRepositoryAsync;
            private readonly IMapper _mapper;

            public UpdateOperacionCommandHandler(
                IOperacionesRepositoryAsync operacionesRepositoryAsync,
                IMapper mapper

                )
            {
                _operacionesRepositoryAsync = operacionesRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(UpdateOperacionCommand command, CancellationToken cancellationToken)
            {
                var operacion = await _operacionesRepositoryAsync.GetByIdAsync(command.IdOperaciones);

                if (operacion == null)
                {
                    throw new ApiException($"Operacion no encontrada");
                }
                else
                {
                    var operacionEntry = _mapper.Map<OperacionesUpdateDto>(command);
                    var res = await _operacionesRepositoryAsync.UpdateAsync(operacionEntry);
                    return res;
                }
            }
        }
    }
}