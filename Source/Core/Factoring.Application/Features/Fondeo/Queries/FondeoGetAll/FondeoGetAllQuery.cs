using AutoMapper;
using Factoring.Application.DTOs.Fondeo;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.Fondeo.Queries.FondeoGetAll
{
    public class FondeoGetAllQuery : IRequest<Response<IReadOnlyList<FondeoGetAllDto>>>
    {
        public class FondeoGetAllQueryHandler : IRequestHandler<FondeoGetAllQuery, Response<IReadOnlyList<FondeoGetAllDto>>>
        {
            private readonly IFondeoRepositoryAsync _FondeoRepositoryAsync;
            private readonly IMapper _mapper;
            public FondeoGetAllQueryHandler(IFondeoRepositoryAsync FondeoRepositoryAsync, IMapper mapper)
            {
                _FondeoRepositoryAsync = FondeoRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<IReadOnlyList<FondeoGetAllDto>>> Handle(FondeoGetAllQuery query, CancellationToken cancellationToken)
            {
                var FondeoList = await _FondeoRepositoryAsync.GetAllAsync();
                return new Response<IReadOnlyList<FondeoGetAllDto>>(FondeoList);
            }
        }
    }
}
