using Factoring.Application.Exceptions;
using Factoring.Application.Features.Fondeador.DatosFondeador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.FondeadorDetails.Prestamo.Querys
{
    public class GetAllPrestamoByIdFondeadorQuery : IRequest<Response<IEnumerable<FondeadorPrestamoResponseListDto>>>
    {
        public int Id { get; set; }
    }
    public class GetAllPrestamoByIdFondeadorQueryHandler : IRequestHandler<GetAllPrestamoByIdFondeadorQuery, Response<IEnumerable<FondeadorPrestamoResponseListDto>>>
    {
        private readonly IFondeadorDatosRepositoryAsync _fondeadorDatosRepositoryAsync;

        public GetAllPrestamoByIdFondeadorQueryHandler(IFondeadorDatosRepositoryAsync fondeadorDatosRepositoryAsync)
        {
            _fondeadorDatosRepositoryAsync = fondeadorDatosRepositoryAsync;
        }
        public async Task<Response<IEnumerable<FondeadorPrestamoResponseListDto>>> Handle(GetAllPrestamoByIdFondeadorQuery query, CancellationToken cancellationToken)
        {
            var datosFondeadorList = await _fondeadorDatosRepositoryAsync.GetAllPrestamoByIdFondeador(query.Id);
            if (datosFondeadorList == null) throw new ApiException($"Lista no encontrada.");
            return new Response<IEnumerable<FondeadorPrestamoResponseListDto>>(datosFondeadorList);
        }
    }
}
