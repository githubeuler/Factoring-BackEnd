using AutoMapper;
using Factoring.Application.DTOs.MenuAcciones;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Features.ModuloMenu.Commands
{
    public class CreateModuloMenuAccionCommand : IRequest<Response<int>>
    {
        public int nIdMenu { get; set; }
        public int nIdRol { get; set; }
        public string? filter_Acciones { get; set; }
    }
    public class CreateModuloMenuAccionCommandHandler : IRequestHandler<CreateModuloMenuAccionCommand, Response<int>>
    {
        private readonly IModuloMenuSeguridadRepositoryAsync _moduloMenuSeguridadRepositoryAsync;
        private readonly IMapper _mapper;

        public CreateModuloMenuAccionCommandHandler(IModuloMenuSeguridadRepositoryAsync moduloMenuSeguridadRepositoryAsync, IMapper mapper)
        {
            _moduloMenuSeguridadRepositoryAsync = moduloMenuSeguridadRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateModuloMenuAccionCommand request, CancellationToken cancellationToken)
        {
            var contacto = _mapper.Map<ModuloNewDTO>(request);
            var res = await _moduloMenuSeguridadRepositoryAsync.AddAccionesAsync(contacto);
            return new Response<int>(res, Constantes.SUCCEDED_REGISTER_DETAIL);
        }
    }
}
