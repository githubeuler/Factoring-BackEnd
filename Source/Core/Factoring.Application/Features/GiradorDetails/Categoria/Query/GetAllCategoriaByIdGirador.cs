using Factoring.Application.DTOs.Girador.Confirming;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.GiradorDetails.Categoria.Query
{
    public class GetAllCategoriaByIdGirador : IRequest<Response<IEnumerable<GiradorConfirmingDto>>>
    {
        public int Id { get; set; }
        public class GetAllCategoriaByIdGiradorQueryHandler : IRequestHandler<GetAllCategoriaByIdGirador, Response<IEnumerable<GiradorConfirmingDto>>>
        {
            private readonly IGiradorCategoriaRepositoryAsync _giradorCategoriaRepositoryAsync;

            public GetAllCategoriaByIdGiradorQueryHandler(IGiradorCategoriaRepositoryAsync giradorCategoriaRepositoryAsync)
            {
                _giradorCategoriaRepositoryAsync = giradorCategoriaRepositoryAsync;
            }

            public async Task<Response<IEnumerable<GiradorConfirmingDto>>> Handle(GetAllCategoriaByIdGirador query, CancellationToken cancellationToken)
            {
                var categoriaGiradorList = await _giradorCategoriaRepositoryAsync.GetAllCategoriaByIdGirador(query.Id);
                if (categoriaGiradorList == null) throw new ApiException($"Lista no encontrada.");
                return new Response<IEnumerable<GiradorConfirmingDto>>(categoriaGiradorList);
            }
        }
    }
}
