using AutoMapper;
using Factoring.Application.DTOs.ContactoAceptante;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Features.AceptanteContacto.Commands
{
    public class DeleteContactoAceptanteCommand : IRequest<Response<int>>
    {
        public string UsuarioActualizacion { get; set; }
        public int IdAdquirienteContacto { get; set; }

        public class DeleteContactoAceptanteCommandHandler : IRequestHandler<DeleteContactoAceptanteCommand, Response<int>>
        {
            private readonly IAceptanteContactoRepositoryAsync _aceptanteContactoRepositoryAsync;
            private readonly IMapper _mapper;

            public DeleteContactoAceptanteCommandHandler(
                IAceptanteContactoRepositoryAsync aceptanteContactoRepositoryAsync,
                IMapper mapper
                )
            {
                _aceptanteContactoRepositoryAsync = aceptanteContactoRepositoryAsync;
                _mapper = mapper;
            }
            public async Task<Response<int>> Handle(DeleteContactoAceptanteCommand command, CancellationToken cancellationToken)
            {
                var contactoEntry = _mapper.Map<ContactoAdquirienteDeleteDto>(command);
                await _aceptanteContactoRepositoryAsync.DeleteAsync(contactoEntry);
                return new Response<int>(command.IdAdquirienteContacto, Constantes.SUCCEDED_DELETE_HEAD);
            }
        }
    }
}
