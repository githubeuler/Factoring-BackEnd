using Factoring.Application.DTOs.ContactoAceptante;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Features.AceptanteContacto.Queries
{
    public class GetAllContactoByIdAceptanteQuery : IRequest<Response<IEnumerable<ContactoAdquirienteResponseListDto>>>
    {
        public int Id { get; set; }

        public class GetAllContactoByIdAceptanteQueryHandler : IRequestHandler<GetAllContactoByIdAceptanteQuery, Response<IEnumerable<ContactoAdquirienteResponseListDto>>>
        {
            private readonly IAceptanteContactoRepositoryAsync _aceptanteContactoRepositoryAsync;

            public GetAllContactoByIdAceptanteQueryHandler(IAceptanteContactoRepositoryAsync aceptanteContactoRepositoryAsync)
            {
                _aceptanteContactoRepositoryAsync = aceptanteContactoRepositoryAsync;
            }
            public async Task<Response<IEnumerable<ContactoAdquirienteResponseListDto>>> Handle(GetAllContactoByIdAceptanteQuery query, CancellationToken cancellationToken)
            {
                var contactoGiradorList = await _aceptanteContactoRepositoryAsync.GetAllContactoByIdAdquiriente(query.Id);
                if (contactoGiradorList == null) throw new ApiException($"Lista no encontrada.");
                return new Response<IEnumerable<ContactoAdquirienteResponseListDto>>(contactoGiradorList);
            }
        }
    }
}

