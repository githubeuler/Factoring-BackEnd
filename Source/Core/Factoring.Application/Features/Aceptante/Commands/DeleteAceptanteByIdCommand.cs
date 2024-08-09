using AutoMapper;
using Factoring.Application.DTOs.Adquiriente;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Features.Aceptante.Commands
{
    public class DeleteAceptanteByIdCommand : IRequest<Response<int>>
    {
        public int IdAdquiriente { get; set; }
        public string UsuarioActualizacion { get; set; }

        public class DeleteAceptanteByIdCommandHandler : IRequestHandler<DeleteAceptanteByIdCommand, Response<int>>
        {
            private readonly IAceptanteRepositoryAsync _aceptanteRepositoryAsync;
            private readonly IMapper _mapper;

            public DeleteAceptanteByIdCommandHandler(IAceptanteRepositoryAsync aceptanteRepositoryAsync, IMapper mapper)
            {
                _aceptanteRepositoryAsync = aceptanteRepositoryAsync;
                _mapper = mapper;
            }
            public async Task<Response<int>> Handle(DeleteAceptanteByIdCommand command, CancellationToken cancellationToken)
            {
                var girador = await _aceptanteRepositoryAsync.GetByIdAsync(command.IdAdquiriente);
                if (girador == null) throw new ApiException($"Girador no encontrado.");
                var giradorEntry = _mapper.Map<AdquirienteDeleteDto>(command);
                await _aceptanteRepositoryAsync.DeleteAsync(giradorEntry);
                return new Response<int>(giradorEntry.IdAdquiriente, Constantes.SUCCEDED_DELETE_HEAD);
            }
        }
    }
}