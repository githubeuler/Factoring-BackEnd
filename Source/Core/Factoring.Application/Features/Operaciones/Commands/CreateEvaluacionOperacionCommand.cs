using AutoMapper;
using MediatR;
using Factoring.Application.DTOs.EvaluacionOperaciones;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace Factoring.Application.Features.Operaciones.Commands
{
    public class CreateEvaluacionOperacionCommand : IRequest<Response<int>>
    {
        public int IdOperaciones { get; set; }
        public int IdCatalogoEstado { get; set; }
        public string UsuarioCreador { get; set; } 
       public string? Comentario { get; set; }
    }

    public class CreateEvaluacionOperacionCommandHandler : IRequestHandler<CreateEvaluacionOperacionCommand, Response<int>>
    {
        private readonly IEvaluacionOperacionesRepositoryAsync _evaluacionOperacionesRepositoryAsync;
        private readonly IMapper _mapper;

        public CreateEvaluacionOperacionCommandHandler(
            IEvaluacionOperacionesRepositoryAsync evaluacionOperacionesRepositoryAsync,
            IMapper mapper)
        {
            _evaluacionOperacionesRepositoryAsync = evaluacionOperacionesRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateEvaluacionOperacionCommand request, CancellationToken cancellationToken)
        {
            var evaluacionEntry = _mapper.Map<EvaluacionOperacionesInsertDto>(request);
            var res = await _evaluacionOperacionesRepositoryAsync.AddAsync(evaluacionEntry);
            return res;
        }
    }
}
