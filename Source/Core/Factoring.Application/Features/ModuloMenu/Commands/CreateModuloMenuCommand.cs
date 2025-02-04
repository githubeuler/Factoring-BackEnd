using AutoMapper;
using Factoring.Application.DTOs.Adquiriente;
using Factoring.Application.DTOs.Adquiriente.UbicacionAdquiriente;
using Factoring.Application.DTOs.MenuAcciones;
using Factoring.Application.Features.Adquiriente.Commands;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.ModuloMenu.Commands
{
    public class CreateModuloMenuCommand : IRequest<Response<int>>
    {
        public int? nIdMenu { get; set; }
        public int? nIdRol { get; set; }
        public string? cRol { get; set; }
        public string? filter_Acciones { get; set; }
    }
    public class CreateModuloMenuCommandHandler : IRequestHandler<CreateModuloMenuCommand, Response<int>>
    {
        private readonly IModuloMenuSeguridadRepositoryAsync _moduloMenuSeguridadRepositoryAsync;
        private readonly IMapper _mapper;

        public CreateModuloMenuCommandHandler(IModuloMenuSeguridadRepositoryAsync moduloMenuSeguridadRepositoryAsync, IMapper mapper)
        {
            _moduloMenuSeguridadRepositoryAsync = moduloMenuSeguridadRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateModuloMenuCommand request, CancellationToken cancellationToken)
        {
            var contacto = _mapper.Map<ModuloDTO>(request);
            var res = await _moduloMenuSeguridadRepositoryAsync.AddAsync(contacto);
            return new Response<int>(res, Constantes.SUCCEDED_REGISTER_DETAIL);
        }
    }
}
