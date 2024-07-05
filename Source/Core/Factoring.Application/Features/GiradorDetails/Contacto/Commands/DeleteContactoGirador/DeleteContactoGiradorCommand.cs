using AutoMapper;
using Factoring.Application.DTOs.Girador.ContactoGirador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.GiradorDetails.Contacto.Commands.DeleteContactoGirador
{
    public class DeleteContactoGiradorCommand : IRequest<Response<int>>
    {
        public int IdGiradorContacto { get; set; }
        public string UsuarioActualizacion { get; set; }

        public class DeleteContactoGiradorCommandHandler : IRequestHandler<DeleteContactoGiradorCommand, Response<int>>
        {
            private readonly IGiradorContactoRepositoryAsync _giradorContactoRepositoryAsync;
            private readonly IMapper _mapper;

            public DeleteContactoGiradorCommandHandler(IGiradorContactoRepositoryAsync giradorContactoRepositoryAsync, IMapper mapper)
            {
                _giradorContactoRepositoryAsync = giradorContactoRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(DeleteContactoGiradorCommand command, CancellationToken cancellationToken)
            {
                var giradorEntry = _mapper.Map<ContactoGiradorDeleteDto>(command);

                await _giradorContactoRepositoryAsync.DeleteAsync(giradorEntry);
                return new Response<int>(command.IdGiradorContacto, Constantes.SUCCEDED_DELETE_HEAD);
            }
        }
    }
}
