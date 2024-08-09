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
    public class UpdateAceptanteCommand : IRequest<Response<int>>
    {
        public int IdAdquiriente { get; set; }
        public int IdPais { get; set; }
        public string? RegUnicoEmpresa { get; set; }
        public string? RazonSocial { get; set; }
        public int IdSector { get; set; }
        public int IdGrupoEconomico { get; set; }
        public string? UsuarioActualizacion { get; set; }

        public class UpdateAceptanteCommandHandler : IRequestHandler<UpdateAceptanteCommand, Response<int>>
        {
            private readonly IAceptanteRepositoryAsync _aceptanteRepositoryAsyn;
            private readonly IMapper _mapper;

            public UpdateAceptanteCommandHandler(
                IAceptanteRepositoryAsync aceptanteRepositoryAsyn,
                IMapper mapper

                )
            {
                _aceptanteRepositoryAsyn = aceptanteRepositoryAsyn;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(UpdateAceptanteCommand command, CancellationToken cancellationToken)
            {
                var adquiriente = await _aceptanteRepositoryAsyn.GetByIdAsync(command.IdAdquiriente);

                if (adquiriente == null)
                {
                    throw new ApiException($"Adquiriente no encontrado");
                }
                else
                {
                    var adquirienteUpdate = _mapper.Map<AdquirienteUpdateDto>(command);
                    var resultado = await _aceptanteRepositoryAsyn.UpdateAsync(adquirienteUpdate);
                    return resultado;
                }
            }
        }
    }
}