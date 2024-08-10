using AutoMapper;
using Factoring.Application.DTOs.Fondeador.CavaliFondeador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.FondeadorDetails.Cavali.Commands.CreateCavaliFondeador
{
    public class CreateFondeadorCavaliCommand : IRequest<Response<int>>
    {
        public int CodParticipante { get; set; }
        public int CodRUT { get; set; }
        public string UsuarioCreador { get; set; }
        public int IdFondeador { get; set; }
    }

    public class CreateFondeadorCavaliCommandHandler : IRequestHandler<CreateFondeadorCavaliCommand, Response<int>>
    {
        private readonly IFondeadorCavaliRepositoryAsync _fondeadorCavaliRepositoryAsync;
        private readonly IMapper _mapper;

        public CreateFondeadorCavaliCommandHandler(IFondeadorCavaliRepositoryAsync fondeadorCavaliRepositoryAsync, IMapper mapper)
        {
            _fondeadorCavaliRepositoryAsync = fondeadorCavaliRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateFondeadorCavaliCommand request, CancellationToken cancellationToken)
        {
            var cavali = _mapper.Map<CavaliFondeadorCreateDto>(request);
            var res = await _fondeadorCavaliRepositoryAsync.AddAsync(cavali);
            return new Response<int>(res, Constantes.SUCCEDED_REGISTER_DETAIL);
        }
    }
}
