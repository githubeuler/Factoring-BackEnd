using AutoMapper;
using Factoring.Application.DTOs.Girador.UbicacionGirador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.GiradorDetails.GiradorUbicacion.Commands
{
    public class CreateGiradorUbicacionCommand : IRequest<Response<int>>
    {
        public string? FormatoUbigeo { get; set; }
        public string? Direccion { get; set; }
        public int IdTipoDireccion { get; set; }
        public int IdGirador { get; set; }
    }
    public class CreateGiradorUbicacionCommandHandler : IRequestHandler<CreateGiradorUbicacionCommand, Response<int>>
    {
        private readonly IGiradorDireccionRepositoryAsync _giradorDireccionRepositoryAsync;
        private readonly IMapper _mapper;

        public CreateGiradorUbicacionCommandHandler(IGiradorDireccionRepositoryAsync giradorDireccionRepositoryAsync, IMapper mapper)
        {
            _giradorDireccionRepositoryAsync = giradorDireccionRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateGiradorUbicacionCommand request, CancellationToken cancellationToken)
        {
            var contacto = _mapper.Map<UbicacionGiradorInsertDto>(request);
            var res = await _giradorDireccionRepositoryAsync.AddAsync(contacto);
            return new Response<int>(res, Constantes.SUCCEDED_REGISTER_DETAIL);
        }
    }
}
