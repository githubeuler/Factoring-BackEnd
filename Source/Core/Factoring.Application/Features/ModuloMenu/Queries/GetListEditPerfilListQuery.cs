using AutoMapper;
using Factoring.Application.DTOs.Adquiriente;
using Factoring.Application.DTOs.MenuAcciones;
using Factoring.Application.Features.Adquiriente.Queries;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;


namespace Factoring.Application.Features.ModuloMenu.Queries
{
    public class GetListEditPerfilListQuery : IRequest<Response<PerfilResponseEditDto>>
    {
        public int nIdRol { get; set; }
        public class GetListEditPerfilListQueryHandler : IRequestHandler<GetListEditPerfilListQuery, Response<PerfilResponseEditDto>>
        {
            private readonly IModuloMenuSeguridadRepositoryAsync _moduloMenuSeguridadRepositoryAsync;
            private readonly IMapper _mapper;
            public GetListEditPerfilListQueryHandler(IModuloMenuSeguridadRepositoryAsync moduloMenuSeguridadRepositoryAsync, IMapper mapper)
            {
                _moduloMenuSeguridadRepositoryAsync = moduloMenuSeguridadRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<PerfilResponseEditDto>> Handle(GetListEditPerfilListQuery query, CancellationToken cancellationToken)
            {
                var adList = await _moduloMenuSeguridadRepositoryAsync.GetListRolEdit(query.nIdRol);
                return new Response<PerfilResponseEditDto>(adList);
            }
        }

    }
}