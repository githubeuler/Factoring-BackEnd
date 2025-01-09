using AutoMapper;
using Factoring.Application.DTOs.Usuario;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.Usuario.Queries
{
    public class GetUsuarioListAll : IRequest<Response<IReadOnlyList<UsuarioResponseDataTable>>>
    {
        public int Pageno { get; set; }
        public string? FilterCodigoUsuario { get; set; }
        public string? FilterNombreUsuario { get; set; }
        public string? FilterActivo { get; set; }
        public int FilterIdPais { get; set; }

        public int PageSize { get; set; }
        public string? Sorting { get; set; }
        public string? SortOrder { get; set; }
    }
    public class GetUsuarioListAllHandler : IRequestHandler<GetUsuarioListAll, Response<IReadOnlyList<UsuarioResponseDataTable>>>
    {
        private readonly IUsuarioRepositoryAsync _usuarioRepositoryAsync;
        private readonly IMapper _mapper;
        public GetUsuarioListAllHandler(IUsuarioRepositoryAsync usuarioRepositoryAsync, IMapper mapper)
        {
            _usuarioRepositoryAsync = usuarioRepositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<IReadOnlyList<UsuarioResponseDataTable>>> Handle(GetUsuarioListAll request, CancellationToken cancellationToken)
        {
            var objRequest = _mapper.Map<UsuarioRequestDataTable>(request);

            var list = await _usuarioRepositoryAsync.GetListUsuario(objRequest);

            return new Response<IReadOnlyList<UsuarioResponseDataTable>>(list);
        }
    }
}
