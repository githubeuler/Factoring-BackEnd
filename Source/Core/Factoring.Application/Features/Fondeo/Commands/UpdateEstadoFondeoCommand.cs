using AutoMapper;
using Factoring.Application.DTOs.Fondeo;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.Fondeo.Commands
{
    public class UpdateEstadoFondeoCommand : IRequest<Response<int>>
    {
        public int IdFondeadorFactura { get; set; }
        public int IdEstadoFondeo { get; set; }
        public string? Comentario { get; set; }
        public string? UsuarioModificacion { get; set; }

        public class UpdateEstadoFondeoCommandHandler : IRequestHandler<UpdateEstadoFondeoCommand, Response<int>>
        {
            private readonly IFondeoRepositoryAsync _fondeoRepositoryAsync;
            private readonly IMapper _mapper;

            public UpdateEstadoFondeoCommandHandler(
                IFondeoRepositoryAsync fondeoRepositoryAsync,
                IMapper mapper

                )
            {
                _fondeoRepositoryAsync = fondeoRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(UpdateEstadoFondeoCommand command, CancellationToken cancellationToken)
            {

                var fondeo = _mapper.Map<FondeoUpdateStateDto>(command);
                await _fondeoRepositoryAsync.UpdateStateAsync(fondeo);
                return new Response<int>(fondeo.IdFondeadorFactura, Constantes.SUCCEDED_UPDATE);

            }
        }

    }
}
