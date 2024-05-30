using AutoMapper;
using Factoring.Application.DTOs.Adquiriente.UbicacionAdquiriente;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.AdquirienteDetails.AdquirienteUbicacion.Commands
{
    public class CreateAdquirienteUbicacionCommand : IRequest<Response<int>>
    {
        public string FormatoUbigeo { get; set; }
        public string Direccion { get; set; }
        public int IdTipoDireccion { get; set; }
        public int IdAdquiriente { get; set; }

        public class CreateAdquirienteUbicacionCommandHandler : IRequestHandler<CreateAdquirienteUbicacionCommand, Response<int>>
        {
            private readonly IAdquirienteDireccionRepositoryAsync _adquirienteDireccionRepositoryAsync;
            private readonly IMapper _mapper;

            public CreateAdquirienteUbicacionCommandHandler(IAdquirienteDireccionRepositoryAsync adquirienteDireccionRepositoryAsync, IMapper mapper)
            {
                _adquirienteDireccionRepositoryAsync = adquirienteDireccionRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(CreateAdquirienteUbicacionCommand request, CancellationToken cancellationToken)
            {
                var contacto = _mapper.Map<UbicacionAdquirienteInsertDto>(request);
                var res = await _adquirienteDireccionRepositoryAsync.AddAsync(contacto);
                return new Response<int>(res, Constantes.SUCCEDED_REGISTER_DETAIL);
            }
        }
    }
}
