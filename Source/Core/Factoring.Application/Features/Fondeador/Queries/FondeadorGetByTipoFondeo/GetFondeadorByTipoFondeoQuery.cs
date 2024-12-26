using Factoring.Application.DTOs.Fondeador;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using Factoring.Domain.Util;
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

                try
                {
                    var fondeador = await _fondeadorRepositoryAsync.GetByTipoFondeoAsync(query.Id);

                    if (fondeador == null)
                    {
                        throw new ApiException($"Fondeadores no encontrados.");
                    }

                    return new Response<IReadOnlyList<FondeadorGetByIdDto>>(fondeador);
                }
                catch (ApiException ex)
                {
                    // Registro del error específico de la API
                    LogUtil.GetLogger().Error(ex, $"Error en la consulta GetFondeadorByTipoFondeo para Id: {query.Id}");
                    throw;
                }
                catch (Exception ex)
                {
                    // Registro de cualquier error inesperado
                    LogUtil.GetLogger().Error(ex, $"Error inesperado en la consulta GetFondeadorByTipoFondeo para Id: {query.Id}");
                    throw;
                }
            }
        }
    }
}
