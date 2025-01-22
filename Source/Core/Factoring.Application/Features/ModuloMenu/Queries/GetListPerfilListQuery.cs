using AutoMapper;
using Factoring.Application.DTOs.Adquiriente;
using Factoring.Application.DTOs.MenuAcciones;
using Factoring.Application.Features.Adquiriente.Queries;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.ModuloMenu.Queries
{
    public class GetListPerfilListQuery: IRequest<Response<IReadOnlyList<PerfilResponseDto>>>
    {
        public int Pageno { get; set; }
        public int PageSize { get; set; }
        public string Sorting { get; set; }
        public string SortOrder { get; set; }
        public string cNombrePerfil { get; set; }
        public class GetListPerfilListQueryHandler : IRequestHandler<GetListPerfilListQuery, Response<IReadOnlyList<PerfilResponseDto>>>
    {
        private readonly IModuloMenuSeguridadRepositoryAsync _moduloMenuSeguridadRepositoryAsync;
        private readonly IMapper _mapper;
        public GetListPerfilListQueryHandler(IModuloMenuSeguridadRepositoryAsync moduloMenuSeguridadRepositoryAsync, IMapper mapper)
        {
                _moduloMenuSeguridadRepositoryAsync = moduloMenuSeguridadRepositoryAsync;
                _mapper = mapper;
            }

        public async Task<Response<IReadOnlyList<PerfilResponseDto>>> Handle(GetListPerfilListQuery query, CancellationToken cancellationToken)
        {
                var rolrequest = _mapper.Map<PerfilRequestDto>(query);
                var adList = await _moduloMenuSeguridadRepositoryAsync.GetListRol(rolrequest);

            return new Response<IReadOnlyList<PerfilResponseDto>>(adList);
        }
    }

}
}


