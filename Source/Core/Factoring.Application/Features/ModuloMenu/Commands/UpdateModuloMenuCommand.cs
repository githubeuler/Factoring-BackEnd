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
    public class UpdateModuloMenuCommand : IRequest<Response<int>>
    {
        public int nIdRol { get; set; }
    }
    public class UpdateModuloMenuCommandHandler : IRequestHandler<UpdateModuloMenuCommand, Response<int>>
    {
        private readonly IModuloMenuSeguridadRepositoryAsync _moduloMenuSeguridadRepositoryAsync;
        private readonly IMapper _mapper;

        public UpdateModuloMenuCommandHandler(IModuloMenuSeguridadRepositoryAsync moduloMenuSeguridadRepositoryAsync, IMapper mapper)
        {
            _moduloMenuSeguridadRepositoryAsync = moduloMenuSeguridadRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateModuloMenuCommand request, CancellationToken cancellationToken)
        {
            var res = await _moduloMenuSeguridadRepositoryAsync.UpdateAsync(request.nIdRol);
            return new Response<int>(res, Constantes.SUCCEDED_REGISTER_DETAIL);
        }
    }
}

