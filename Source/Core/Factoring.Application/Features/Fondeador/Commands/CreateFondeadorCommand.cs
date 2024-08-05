using AutoMapper;
using Factoring.Application.DTOs.Fondeador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.Fondeador.Commands
{
    public class CreateFondeadorCommand : IRequest<Response<int>>
    {
        public int IdDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string NombreFondeador { get; set; }
        //public int IdTipoNegocio { get; set; }
        public int IdPais { get; set; }
        public string UsuarioCreador { get; set; }
    }
    public class CreateFondeadorCommandHandler : IRequestHandler<CreateFondeadorCommand, Response<int>>
    {
        private readonly IFondeadorRepositoryAsync _fondeadorRepositoryAsync;
        private readonly IMapper _mapper;

        public CreateFondeadorCommandHandler(IFondeadorRepositoryAsync fondeadorRepositoryAsync, IMapper mapper)
        {
            _fondeadorRepositoryAsync = fondeadorRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateFondeadorCommand request, CancellationToken cancellationToken)
        {
            var fondeador = _mapper.Map<FondeadorInsertDto>(request);
            var res = await _fondeadorRepositoryAsync.AddAsync(fondeador);
            return new Response<int>(res, Constantes.SUCCEDED_REGISTER_HEAD);
        }
    }
}
