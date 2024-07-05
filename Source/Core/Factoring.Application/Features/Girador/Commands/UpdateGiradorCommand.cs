
using AutoMapper;
using Factoring.Application.DTOs.Girador;
using Factoring.Application.Exceptions;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.Girador.Commands
{
    public class UpdateGiradorCommand : IRequest<Response<int>>
    {
        public int IdGirador { get; set; }
        public int IdPais { get; set; }
        public string RegUnicoEmpresa { get; set; }
        public string RazonSocial { get; set; }
        public int IdSector { get; set; }
        public decimal Venta { get; set; }
        public decimal Compra { get; set; }
        public int IdGrupoEconomico { get; set; }
        public string UsuarioActualizacion { get; set; }

        public class UpdateGiradorCommandHandler : IRequestHandler<UpdateGiradorCommand, Response<int>>
        {
            private readonly IGiradorRepositoryAsync _giradorRepositoryAsync;
            private readonly IMapper _mapper;

            public UpdateGiradorCommandHandler(
                IGiradorRepositoryAsync giradorRepositoryAsync,
                IMapper mapper

                )
            {
                _giradorRepositoryAsync = giradorRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(UpdateGiradorCommand command, CancellationToken cancellationToken)
            {
                var girador = await _giradorRepositoryAsync.GetByIdAsync(command.IdGirador);

                if (girador == null)
                {
                    throw new ApiException($"Girador no encontrado");
                }
                else
                {
                    var giradorEntry = _mapper.Map<GiradorUpdateDto>(command);
                    await _giradorRepositoryAsync.UpdateAsync(giradorEntry);
                    return new Response<int>(giradorEntry.IdGirador, Constantes.SUCCEDED_UPDATE);
                }
            }
        }
    }
}
