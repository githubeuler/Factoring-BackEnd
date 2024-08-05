using AutoMapper;
using Factoring.Application.Features.Fondeador.DatosFondeador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.Fondeador.Commands.CreatePrestamoFondeador
{
    public class CreateFondeadorPrestamoCommand : IRequest<Response<int>>
    {
        public int IdFondeadorCabecera { get; set; }
        public int IdProductoPrestamo { get; set; }
        public int IdMonedaPrestamo { get; set; }
        public int IdModalidadPrestamo { get; set; }
        public decimal nCapitalPrestamo { get; set; }
        public decimal nInteresPrestamo { get; set; }
        public decimal nInteresPeriodoGraciaPrestamo { get; set; }
        public bool bAplicanCapitalPrestamo { get; set; }
        public bool bAplicanInteresPrestamo { get; set; }
        public bool bAplicaInteresPeriodoGraciaPrestamo { get; set; }
        public string UsuarioCreador { get; set; }
    }

    public class CreateFondeadorPrestamoCommandHandler : IRequestHandler<CreateFondeadorPrestamoCommand, Response<int>>
    {
        private readonly IFondeadorDatosRepositoryAsync _fondeadorDatosRepositoryAsync;
        private readonly IMapper _mapper;

        public CreateFondeadorPrestamoCommandHandler(IFondeadorDatosRepositoryAsync fondeadorDatosRepositoryAsync, IMapper mapper)
        {
            _fondeadorDatosRepositoryAsync = fondeadorDatosRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateFondeadorPrestamoCommand request, CancellationToken cancellationToken)
        {
            var datos = _mapper.Map<DatosFondeadorPrestamoCreateDto>(request);
            var res = await _fondeadorDatosRepositoryAsync.AddPrestamoAsync(datos);
            return new Response<int>(res, Constantes.SUCCEDED_REGISTER_DETAIL);
        }
    }

}
