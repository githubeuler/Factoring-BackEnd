using AutoMapper;
using Factoring.Application.DTOs.EvaluacionOperaciones;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Factoring.Application.Features.Operaciones.Commands.UpdateOperacion
{
    public class GenerateFacturaCalculoCommand : IRequest<Response<int>>
    {
        public int IdOperaciones { get; set; }
        public int IdOperacionesFactura { get; set; }
        public int? IdCatalogoEstado { get; set; }
        public string UsuarioCreador { get; set; }
        public string? cFecha { get; set; }
    }

    public class GenerateFacturaCalculoCommandHandler : IRequestHandler<GenerateFacturaCalculoCommand, Response<int>>
    {
        private readonly IEvaluacionOperacionesRepositoryAsync _evaluacionOperacionesRepositoryAsync;
        private readonly IMapper _mapper;

        public GenerateFacturaCalculoCommandHandler(
            IEvaluacionOperacionesRepositoryAsync evaluacionOperacionesRepositoryAsync,
            IMapper mapper)
        {
            _evaluacionOperacionesRepositoryAsync = evaluacionOperacionesRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(GenerateFacturaCalculoCommand request, CancellationToken cancellationToken)
        {
            var evaluacionEntry = _mapper.Map<EvaluacionOperacionesCalculoInsertDto>(request);
            var res = await _evaluacionOperacionesRepositoryAsync.GenerateCalculoFacturaAsync(evaluacionEntry);
            return res;
        }
    }
}

