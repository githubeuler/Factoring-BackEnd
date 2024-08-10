using AutoMapper;
using Factoring.Application.Features.Fondeador.DatosFondeador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.Fondeador.Commands.DeletePrestamoFondeador
{
    public class DeletePrestamoFondeadorCommand : IRequest<Response<int>>
    {

        public int iIdFondeadorPrestamo { get; set; }
        public string UsuarioActualizacion { get; set; }
    }
    public class DeletePrestamoFondeadorCommandHandler : IRequestHandler<DeletePrestamoFondeadorCommand, Response<int>>
    {
        private readonly IFondeadorDatosRepositoryAsync _fondeadorDatosRepositoryAsync;
        private readonly IMapper _mapper;

        public DeletePrestamoFondeadorCommandHandler(IFondeadorDatosRepositoryAsync fondeadorDatosRepositoryAsync, IMapper mapper)
        {
            _fondeadorDatosRepositoryAsync = fondeadorDatosRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(DeletePrestamoFondeadorCommand command, CancellationToken cancellationToken)
        {
            var fondeadorEntry = _mapper.Map<FondeadorPrestamoDeleteDto>(command);
            await _fondeadorDatosRepositoryAsync.DeletePrestamoAsync(fondeadorEntry);
            return new Response<int>(command.iIdFondeadorPrestamo, Constantes.SUCCEDED_DELETE_HEAD);
        }
    }

}
