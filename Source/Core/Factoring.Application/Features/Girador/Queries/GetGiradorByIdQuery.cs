using Factoring.Application.DTOs.Girador;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;
using Newtonsoft.Json;

namespace Factoring.Application.Features.Girador.Queries
{
    public class GetGiradorByIdQuery : IRequest<Response<GiradorGetByIdDto>>
    {
        public int Id { get; set; }

        public class GetGiradorByIdQueryHandler : IRequestHandler<GetGiradorByIdQuery, Response<GiradorGetByIdDto>>
        {
            private readonly IGiradorRepositoryAsync _giradorRepositoryAsync;

            public GetGiradorByIdQueryHandler(
                IGiradorRepositoryAsync giradorRepositoryAsync
                )
            {
                _giradorRepositoryAsync = giradorRepositoryAsync;
            }

            public async Task<Response<GiradorGetByIdDto>> Handle(GetGiradorByIdQuery query, CancellationToken cancellationToken)
            {
                var girador = await _giradorRepositoryAsync.GetByIdAsync(query.Id);
                if (girador == null) throw new ApiException($"Girador no encontrado.");
                //girador.FormatoUbigeoPais = JsonConvert.DeserializeObject<string>(girador.cFormatoUbigeo).Split(",").ToList();

                return new Response<GiradorGetByIdDto>(girador);
            }
        }
    }
}
