using Factoring.Application.DTOs.Fondeador;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;
using Newtonsoft.Json;

namespace Factoring.Application.Features.Fondeador.Queries.FondeadorGetById
{
    public class GetFondeadorByIdQuery : IRequest<Response<FondeadorGetByIdDto>>
    {
        public int Id { get; set; }

        public class GetFondeadorByIdQueryHandler : IRequestHandler<GetFondeadorByIdQuery, Response<FondeadorGetByIdDto>>
        {
            private readonly IFondeadorRepositoryAsync _fondeadorRepositoryAsync;

            public GetFondeadorByIdQueryHandler(
                IFondeadorRepositoryAsync fondeadorRepositoryAsync
                )
            {
                _fondeadorRepositoryAsync = fondeadorRepositoryAsync;
            }

            public async Task<Response<FondeadorGetByIdDto>> Handle(GetFondeadorByIdQuery query, CancellationToken cancellationToken)
            {
                var fondeador = await _fondeadorRepositoryAsync.GetByIdAsync(query.Id);
                if (fondeador == null) throw new ApiException($"Fondeador no encontrado.");
                //fondeador.FormatoUbigeoPais = JsonConvert.DeserializeObject<string>(fondeador.cFormatoUbigeo).Split(",").ToList();

                return new Response<FondeadorGetByIdDto>(fondeador);
            }
        }
    }
}
