using AutoMapper;
using MediatR;
using Factoring.Application.DTOs.Catalogo;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Factoring.Application.Features.Catalogo.Query.CatalogoListQuery
{
    public class CatalogoListCategoriaQuery : IRequest<Response<IReadOnlyList<CatalogoResponseListDto>>>
    {
        public int Codigo { get; set; }
        public class CatalogoListCategoriaQueryHandler : IRequestHandler<CatalogoListCategoriaQuery, Response<IReadOnlyList<CatalogoResponseListDto>>>
        {
            private readonly ICatalogoRepository _catalogoRepository;
            private readonly IMapper _mapper;
            public CatalogoListCategoriaQueryHandler(ICatalogoRepository catalogoRepository, IMapper mapper)
            {
                _catalogoRepository = catalogoRepository;
                _mapper = mapper;
            }

            public async Task<Response<IReadOnlyList<CatalogoResponseListDto>>> Handle(CatalogoListCategoriaQuery query, CancellationToken cancellationToken)
            {
                var request = _mapper.Map<CatalogoListDto>(query);

                var evopList = await _catalogoRepository.GetListCategoriaCatalogo(request);

                return new Response<IReadOnlyList<CatalogoResponseListDto>>(evopList);
            }
        }

    }
}
