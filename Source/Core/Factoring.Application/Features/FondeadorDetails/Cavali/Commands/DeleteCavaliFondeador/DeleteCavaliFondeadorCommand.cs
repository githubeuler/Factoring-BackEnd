using AutoMapper;
using Factoring.Application.DTOs.Fondeador.CavaliFondeador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.FondeadorDetails.Cavali.Commands.DeleteCavaliFondeador
{
    public class DeleteCavaliFondeadorCommand : IRequest<Response<int>>
    {
        public int IdFondeadorCavali { get; set; }
        public string UsuarioActualizacion { get; set; }

        public class DeleteCavaliFondeadorCommandHandler : IRequestHandler<DeleteCavaliFondeadorCommand, Response<int>>
        {
            private readonly IFondeadorCavaliRepositoryAsync _fondeadorCavaliRepositoryAsync;
            private readonly IMapper _mapper;

            public DeleteCavaliFondeadorCommandHandler(IFondeadorCavaliRepositoryAsync fondeadorCavaliRepositoryAsync, IMapper mapper)
            {
                _fondeadorCavaliRepositoryAsync = fondeadorCavaliRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(DeleteCavaliFondeadorCommand command, CancellationToken cancellationToken)
            {
                var fondeadorEntry = _mapper.Map<CavaliFondeadorDeleteDto>(command);

                await _fondeadorCavaliRepositoryAsync.DeleteAsync(fondeadorEntry);
                return new Response<int>(command.IdFondeadorCavali, Constantes.SUCCEDED_DELETE_HEAD);
            }
        }
    }
}
