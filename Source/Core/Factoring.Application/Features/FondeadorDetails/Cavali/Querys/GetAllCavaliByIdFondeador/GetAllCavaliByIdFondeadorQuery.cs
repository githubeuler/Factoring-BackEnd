using Factoring.Application.DTOs.Fondeador.CavaliFondeador;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.FondeadorDetails.Cavali.Querys.GetAllCavaliByIdFondeador
{
    public class GetAllCavaliByIdFondeadorQuery : IRequest<Response<IEnumerable<CavaliFondeadorResponseListDto>>>
    {
        public int Id { get; set; }
        public class GetAllCavaliByIdFondeadorQueryHandler : IRequestHandler<GetAllCavaliByIdFondeadorQuery, Response<IEnumerable<CavaliFondeadorResponseListDto>>>
        {
            private readonly IFondeadorCavaliRepositoryAsync _fondeadorCavaliRepositoryAsync;

            public GetAllCavaliByIdFondeadorQueryHandler(IFondeadorCavaliRepositoryAsync fondeadorCavaliRepositoryAsync)
            {
                _fondeadorCavaliRepositoryAsync = fondeadorCavaliRepositoryAsync;
            }

            public async Task<Response<IEnumerable<CavaliFondeadorResponseListDto>>> Handle(GetAllCavaliByIdFondeadorQuery query, CancellationToken cancellationToken)
            {
                var cavaliFondeadorList = await _fondeadorCavaliRepositoryAsync.GetAllCavaliByIdFondeador(query.Id);
                if (cavaliFondeadorList == null) throw new ApiException($"Lista no encontrada.");
                return new Response<IEnumerable<CavaliFondeadorResponseListDto>>(cavaliFondeadorList);
            }
        }
    }
}
