using AutoMapper;
using MediatR;
using Factoring.Application.DTOs.Operaciones;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace Factoring.Application.Features.Operaciones.Commands.DeleteOperacion
{
    public class DeleteOperacionByIdCommand : IRequest<Response<int>>
    {
        public int IdOperaciones { get; set; }
        public string UsuarioActualizacion { get; set; }

        public class DeleteOperacionByIdCommandHandler : IRequestHandler<DeleteOperacionByIdCommand, Response<int>>
        {
            private readonly IOperacionesRepositoryAsync _operacionesRepositoryAsync;
            private readonly IMapper _mapper;

            public DeleteOperacionByIdCommandHandler(IOperacionesRepositoryAsync operacionesRepositoryAsync, IMapper mapper)
            {
                _operacionesRepositoryAsync = operacionesRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(DeleteOperacionByIdCommand command, CancellationToken cancellationToken)
            {
                var operaciones = await _operacionesRepositoryAsync.GetByIdAsync(command.IdOperaciones);
                if (operaciones == null) throw new ApiException($"Operacion no encontrado.");
                var operacionEntry = _mapper.Map<OperacionesDeleteDto>(command);
                await _operacionesRepositoryAsync.DeleteAsync(operacionEntry);
                return new Response<int>(operacionEntry.IdOperaciones, Constantes.SUCCEDED_DELETE_HEAD);
            }
        }
    }
}
