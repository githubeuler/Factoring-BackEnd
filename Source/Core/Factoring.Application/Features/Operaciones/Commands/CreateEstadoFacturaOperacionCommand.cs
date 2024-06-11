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

namespace Factoring.Application.Features.Operaciones.Commands
{
    public class CreateEstadoFacturaOperacionCommand : IRequest<Response<int>>
    {
        public int IdOperaciones { get; set; }
        public int IdOperacionesFactura { get; set; }
        public int IdCatalogoEstado { get; set; }
        public string UsuarioCreador { get; set; }
        public string? Comentario { get; set; }
        public bool? bRegistro { get; set; }
    }

    public class CreateEstadoFacturaOperacionCommandHandler : IRequestHandler<CreateEstadoFacturaOperacionCommand, Response<int>>
    {
        private readonly IEvaluacionOperacionesRepositoryAsync _evaluacionOperacionesRepositoryAsync;
        private readonly IMapper _mapper;

        public CreateEstadoFacturaOperacionCommandHandler(
            IEvaluacionOperacionesRepositoryAsync evaluacionOperacionesRepositoryAsync,
            IMapper mapper)
        {
            _evaluacionOperacionesRepositoryAsync = evaluacionOperacionesRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateEstadoFacturaOperacionCommand request, CancellationToken cancellationToken)
        {
            var evaluacionEntry = _mapper.Map<EvaluacionOperacionesInsertDto>(request);
            var res = await _evaluacionOperacionesRepositoryAsync.AddFacturaAsync(evaluacionEntry);
            return res;
        }
    }
}
