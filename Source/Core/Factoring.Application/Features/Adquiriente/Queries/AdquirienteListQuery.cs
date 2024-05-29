using Factoring.Application.DTOs.Adquiriente;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Features.Adquiriente.Queries
{
    public class AdquirienteListQuery : IRequest<Response<IReadOnlyList<AdquirienteResponseLista>>>
    {
        public class AdquirienteListQueryHandler : IRequestHandler<AdquirienteListQuery, Response<IReadOnlyList<AdquirienteResponseLista>>>
        {
            private readonly IAdquirienteRepositoryAsync _adquirienteRepositoryAsync;
            public AdquirienteListQueryHandler(IAdquirienteRepositoryAsync adquirienteRepositoryAsync)
            {
                _adquirienteRepositoryAsync = adquirienteRepositoryAsync;
            }

            public async Task<Response<IReadOnlyList<AdquirienteResponseLista>>> Handle(AdquirienteListQuery query, CancellationToken cancellationToken)
            {

                var adList = await _adquirienteRepositoryAsync.GetListaAdquiriente();

                return new Response<IReadOnlyList<AdquirienteResponseLista>>(adList);
            }
        }

    }
}

