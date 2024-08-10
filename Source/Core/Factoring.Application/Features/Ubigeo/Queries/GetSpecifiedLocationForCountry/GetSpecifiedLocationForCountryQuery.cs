using Factoring.Application.DTOs.Ubigeo;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.Ubigeo.Queries.GetSpecifiedLocationForCountry
{
    public class GetSpecifiedLocationForCountryQuery : IRequest<Response<IEnumerable<UbigeoGetDto>>>
    {
        public int IdPais { get; set; }
        public int Tipo { get; set; }
        public string? Codigo { get; set; }
        public class GetSpecifiedLocationForCountryQueryHandler : IRequestHandler<GetSpecifiedLocationForCountryQuery, Response<IEnumerable<UbigeoGetDto>>>
        {
            private readonly IUbigeoRepositoryAsync _ubigeoRepositoryAsync;

            public GetSpecifiedLocationForCountryQueryHandler(IUbigeoRepositoryAsync ubigeoRepositoryAsync)
            {
                _ubigeoRepositoryAsync = ubigeoRepositoryAsync;
            }

            public async Task<Response<IEnumerable<UbigeoGetDto>>> Handle(GetSpecifiedLocationForCountryQuery query, CancellationToken cancellationToken)
            {
                var data = await _ubigeoRepositoryAsync.GetUbigeoAsync(query.IdPais, query.Tipo, query.Codigo);
                if (data == null) throw new ApiException($"Lista no encontrada.");
                return new Response<IEnumerable<UbigeoGetDto>>(data);
            }
        }
    }
}
