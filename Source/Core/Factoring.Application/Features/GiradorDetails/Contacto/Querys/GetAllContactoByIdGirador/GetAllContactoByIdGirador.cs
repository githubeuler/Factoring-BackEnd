using Factoring.Application.DTOs.Girador.ContactoGirador;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.GiradorDetails.Contacto.Querys.GetAllContactoByIdGirador
{
    public class GetAllContactoByIdGirador : IRequest<Response<IEnumerable<ContactoGiradorResponseListDto>>>
    {
        public int Id { get; set; }
        public class GetAllContactoByIdGiradorQueryHandler : IRequestHandler<GetAllContactoByIdGirador, Response<IEnumerable<ContactoGiradorResponseListDto>>>
        {
            private readonly IGiradorContactoRepositoryAsync _giradorContactoRepositoryAsync;

            public GetAllContactoByIdGiradorQueryHandler(IGiradorContactoRepositoryAsync giradorContactoRepositoryAsync)
            {
                _giradorContactoRepositoryAsync = giradorContactoRepositoryAsync;
            }

            public async Task<Response<IEnumerable<ContactoGiradorResponseListDto>>> Handle(GetAllContactoByIdGirador query, CancellationToken cancellationToken)
            {
                var contactoGiradorList = await _giradorContactoRepositoryAsync.GetAllContactoByIdGirador(query.Id);
                if (contactoGiradorList == null) throw new ApiException($"Lista no encontrada.");
                return new Response<IEnumerable<ContactoGiradorResponseListDto>>(contactoGiradorList);
            }
        }
    }
}