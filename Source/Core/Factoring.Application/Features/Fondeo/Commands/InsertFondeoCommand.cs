using AutoMapper;
using Factoring.Application.DTOs.Fondeo;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.Fondeo.Commands
{
    public  class InsertFondeoCommand :  IRequest<Response<int>>
    {
        public int IdFondeadorFactura { get; set; }
        public string? UsuarioCreacion { get; set; }
        public class InsertFondeoCommandHandler : IRequestHandler<InsertFondeoCommand, Response<int>>
        {
            private readonly IFondeoRepositoryAsync _fondeoRepositoryAsync;
            private readonly IMapper _mapper;

            public InsertFondeoCommandHandler(
                IFondeoRepositoryAsync fondeoRepositoryAsync,
                IMapper mapper

                )
            {
                _fondeoRepositoryAsync = fondeoRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(InsertFondeoCommand command, CancellationToken cancellationToken)
            {

                var fondeo = _mapper.Map<FondeoInsertDto>(command);
                await _fondeoRepositoryAsync.InsertAsync(fondeo);
                return new Response<int>(fondeo.IdFondeadorFactura, Constantes.SUCCEDED_UPDATE);
            }
        }


    }
}
