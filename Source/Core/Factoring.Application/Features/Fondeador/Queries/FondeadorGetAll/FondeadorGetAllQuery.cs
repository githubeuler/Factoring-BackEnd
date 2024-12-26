using AutoMapper;
using Factoring.Application.DTOs.Fondeador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using Factoring.Domain.Util;
using MediatR;

namespace Factoring.Application.Features.Fondeador.Queries.FondeadorGetAll
{
    public class FondeadorGetAllQuery : IRequest<Response<IReadOnlyList<FondeadorGetAllDto>>>
    {
        public class FondeadorGetAllQueryHandler : IRequestHandler<FondeadorGetAllQuery, Response<IReadOnlyList<FondeadorGetAllDto>>>
        {
            private readonly IFondeadorRepositoryAsync _fondeadorRepositoryAsync;
            private readonly IMapper _mapper;
            public FondeadorGetAllQueryHandler(IFondeadorRepositoryAsync fondeadorRepositoryAsync, IMapper mapper)
            {
                _fondeadorRepositoryAsync = fondeadorRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<IReadOnlyList<FondeadorGetAllDto>>> Handle(FondeadorGetAllQuery query, CancellationToken cancellationToken)
            {
                var fondeadorList = await _fondeadorRepositoryAsync.GetAllAsync();
                return new Response<IReadOnlyList<FondeadorGetAllDto>>(fondeadorList);
            }
        }
    }
}
