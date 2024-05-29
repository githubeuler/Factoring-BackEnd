using MediatR;
using Newtonsoft.Json;
using Factoring.Application.DTOs.Operaciones;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
//using Factoring.Application.Interfaces.Service;
using Factoring.Application.Wrappers;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Factoring.Application.Features.Operaciones.Queries.OperacionesGetByidQuery
{
    public class OperacionesGetByidQuery : IRequest<Response<OperacionesGetByIdDto>>
    {
        public int Id { get; set; }

        public class OperacionesGetByidQueryHandler : IRequestHandler<OperacionesGetByidQuery, Response<OperacionesGetByIdDto>>
        {
            private readonly IOperacionesRepositoryAsync _operacionesRepositoryAsync;

            public OperacionesGetByidQueryHandler(IOperacionesRepositoryAsync operacionesRepositoryAsync)
            {
                _operacionesRepositoryAsync = operacionesRepositoryAsync;
                //_cavaliServiceAsync = cavaliServiceAsync;
            }

            public async Task<Response<OperacionesGetByIdDto>> Handle(OperacionesGetByidQuery query, CancellationToken cancellationToken)
            {
                var operacion = await _operacionesRepositoryAsync.GetByIdAsync(query.Id) ?? throw new ApiException($"Operacion no encontrado.");
                //operacion.SerieDocumentoPais = JsonConvert.DeserializeObject<string>(operacion.cFormatoDocumento).Split(",").ToList();

                return new Response<OperacionesGetByIdDto>(operacion);
            }
        }
    }
}