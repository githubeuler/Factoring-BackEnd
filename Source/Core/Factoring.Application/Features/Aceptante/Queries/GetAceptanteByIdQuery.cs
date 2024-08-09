using Factoring.Application.DTOs.Aceptante;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Features.Aceptante.Queries
{
    public class GetAceptanteByIdQuery : IRequest<Response<AceptanteGetByIdDto>>
    {
        public int Id { get; set; }

        public class GetAceptanteByIdQueryHandler : IRequestHandler<GetAceptanteByIdQuery, Response<AceptanteGetByIdDto>>
        {
            private readonly IAceptanteRepositoryAsync _aceptanteRepositoryAsync;

            public GetAceptanteByIdQueryHandler(IAceptanteRepositoryAsync aceptanteRepositoryAsync)
            {
                _aceptanteRepositoryAsync = aceptanteRepositoryAsync;
            }
            public async Task<Response<AceptanteGetByIdDto>> Handle(GetAceptanteByIdQuery query, CancellationToken cancellationToken)
            {
                var adquiriente = await _aceptanteRepositoryAsync.GetByIdAsync(query.Id);
                if (adquiriente == null) throw new ApiException($"Adquiriente no encontrado.");
                adquiriente.FormatoUbigeoPais = JsonConvert.DeserializeObject<string>(adquiriente.cFormatoUbigeo).Split(",").ToList();
                return new Response<AceptanteGetByIdDto>(adquiriente);
            }
        }
    }
}

