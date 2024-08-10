using AutoMapper;
using Factoring.Application.DTOs.Fondeador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.Fondeador.Commands.DeleteFondeador

    {
    public class DeleteFondeadorByIdCommand : IRequest<Response<int>>
    {
        public int IdFondeador { get; set; }
        public string UsuarioActualizacion { get; set; }

        public class DeleteFondeadorByIdCommandHandler : IRequestHandler<DeleteFondeadorByIdCommand, Response<int>>
        {
            private readonly IFondeadorRepositoryAsync _fondeadorRepositoryAsync;
            private readonly IMapper _mapper;

            public DeleteFondeadorByIdCommandHandler(IFondeadorRepositoryAsync fondeadorRepositoryAsync, IMapper mapper)
            {
                _fondeadorRepositoryAsync = fondeadorRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(DeleteFondeadorByIdCommand command, CancellationToken cancellationToken)
            {
                var fondeadorEntry = _mapper.Map<FondeadorDeleteDto>(command);

                await _fondeadorRepositoryAsync.DeleteAsync(fondeadorEntry);
                return new Response<int>(command.IdFondeador, Constantes.SUCCEDED_DELETE_HEAD);
            }
        }
    }
}


