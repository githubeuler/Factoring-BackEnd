using AutoMapper;
using Factoring.Application.DTOs.Catalogo;
using Factoring.Application.DTOs.Pais;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.Pais.Query
{
    public class PaisListQuery : IRequest<Response<IReadOnlyList<PaisResponseListDto>>>
    {
    }
    public class PaisListQueryHandler : IRequestHandler<PaisListQuery, Response<IReadOnlyList<PaisResponseListDto>>>
    {
        private readonly IPaisRepositoryAsync _paisRepositoryAsync;
        private readonly IMapper _mapper;
        public PaisListQueryHandler(IPaisRepositoryAsync paisRepositoryAsync, IMapper mapper)
        {
            _paisRepositoryAsync = paisRepositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<IReadOnlyList<PaisResponseListDto>>> Handle(PaisListQuery request, CancellationToken cancellationToken)
        {
            var list = await _paisRepositoryAsync.GetListPais();

            return new Response<IReadOnlyList<PaisResponseListDto>>(list);
        }
    }
}
