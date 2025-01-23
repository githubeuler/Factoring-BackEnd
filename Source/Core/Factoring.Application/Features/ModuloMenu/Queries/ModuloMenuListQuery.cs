using AutoMapper;
using Factoring.Application.DTOs.Adquiriente;
using Factoring.Application.DTOs.MenuAcciones;
using Factoring.Application.Features.Adquiriente.Queries;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.ModuloMenu.Queries
{
    public class ModuloMenuListQuery : IRequest<Response<IReadOnlyList<MenuAccionesResponseDto>>>
    {
        public int nRol { get; set; }
        public class ModuloMenuListQueryHandler : IRequestHandler<ModuloMenuListQuery, Response<IReadOnlyList<MenuAccionesResponseDto>>>
        {
            private readonly IModuloMenuSeguridadRepositoryAsync _moduloMenuSeguridadRepositoryAsync;
            private readonly IMapper _mapper;
            public ModuloMenuListQueryHandler(IModuloMenuSeguridadRepositoryAsync moduloMenuSeguridadRepositoryAsync, IMapper mapper)
            {
                _moduloMenuSeguridadRepositoryAsync = moduloMenuSeguridadRepositoryAsync;
                _mapper = mapper;
            }
            public async Task<Response<IReadOnlyList<MenuAccionesResponseDto>>> Handle(ModuloMenuListQuery query, CancellationToken cancellationToken)
            {
               
                var adList = await _moduloMenuSeguridadRepositoryAsync.GetListNenuModulo(query.nRol);
                return new Response<IReadOnlyList<MenuAccionesResponseDto>>(adList);
            }
        }

    }
}




