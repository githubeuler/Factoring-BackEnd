using MediatR;
using Factoring.Application.DTOs.Girador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Factoring.Application.Features.Girador.Queries
{
    public class GiradorListQuery : IRequest<Response<IReadOnlyList<GiradorResponseList>>>
    {
        public class GiradorListQueryHandler : IRequestHandler<GiradorListQuery, Response<IReadOnlyList<GiradorResponseList>>>
        {
            private readonly IGiradorRepositoryAsync _giradorRepositoryAsync;
            public GiradorListQueryHandler(IGiradorRepositoryAsync giradorRepositoryAsync)
            {
                _giradorRepositoryAsync = giradorRepositoryAsync;
            }

            public async Task<Response<IReadOnlyList<GiradorResponseList>>> Handle(GiradorListQuery query, CancellationToken cancellationToken)
            {
                var giradorList = await _giradorRepositoryAsync.GetListaGirador();

                return new Response<IReadOnlyList<GiradorResponseList>>(giradorList);
            }
        }

    }
}