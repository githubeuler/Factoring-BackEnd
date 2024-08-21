using Factoring.Application.DTOs.Fondeador;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.Fondeador.Queries.FondeadorGetByTipoFondeo
{


    public class GetFondeadorByTipoFondeoQuery : IRequest<Response<IReadOnlyList<FondeadorGetByIdDto>>>
    {
        public int Id { get; set; }

        public class GetFondeadorByTipoFondeoQueryHandler : IRequestHandler<GetFondeadorByTipoFondeoQuery, Response<IReadOnlyList<FondeadorGetByIdDto>>>
        {
            private readonly IFondeadorRepositoryAsync _fondeadorRepositoryAsync;

            public GetFondeadorByTipoFondeoQueryHandler(
                IFondeadorRepositoryAsync fondeadorRepositoryAsync
                )
            {
                _fondeadorRepositoryAsync = fondeadorRepositoryAsync;
            }

            public async Task<Response<IReadOnlyList<FondeadorGetByIdDto>>> Handle(GetFondeadorByTipoFondeoQuery query, CancellationToken cancellationToken)
            {
                var fondeador = await _fondeadorRepositoryAsync.GetByTipoFondeoAsync(query.Id);
                if (fondeador == null) throw new ApiException($"Fondeadores no encontrado.");
                //fondeador.FormatoUbigeoPais = JsonConvert.DeserializeObject<string>(fondeador.cFormatoUbigeo).Split(",").ToList();

                return new Response<IReadOnlyList<FondeadorGetByIdDto>>(fondeador);
            }
        }
    }
}
