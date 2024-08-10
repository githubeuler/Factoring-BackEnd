using AutoMapper;
using Factoring.Application.DTOs.Fondeador;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.Fondeador.Commands.UpdateFondeador
{
    public class UpdateFondeadorCommand : IRequest<Response<int>>
    {
        public int IdFondeador { get; set; }
        public int IdPais { get; set; }
        public int TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string NombreFondeador { get; set; }
        public int IdTipoNegocio { get; set; }
        public string UsuarioActualizacion { get; set; }

        public int IdProducto { get; set; }
        public int IdInteresCalculado { get; set; }
        public int IdTipoFondeo { get; set; }
        public string? DistribucionFondeador { get; set; }


        public class UpdateFondeadorCommandHandler : IRequestHandler<UpdateFondeadorCommand, Response<int>>
        {
            private readonly IFondeadorRepositoryAsync _fondeadorRepositoryAsync;
            private readonly IMapper _mapper;

            public UpdateFondeadorCommandHandler(
                IFondeadorRepositoryAsync fondeadorRepositoryAsync,
                IMapper mapper

                )
            {
                _fondeadorRepositoryAsync = fondeadorRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(UpdateFondeadorCommand command, CancellationToken cancellationToken)
            {
                var fondeador = await _fondeadorRepositoryAsync.GetByIdAsync(command.IdFondeador);

                if (fondeador == null)
                {
                    throw new ApiException($"Fondeador no encontrado");
                }
                else
                {
                    var fondeadorEntry = _mapper.Map<FondeadorUpdateDto>(command);
                    await _fondeadorRepositoryAsync.UpdateAsync(fondeadorEntry);
                    return new Response<int>(fondeadorEntry.IdFondeador, Constantes.SUCCEDED_UPDATE);
                }
            }
        }
    }
}
