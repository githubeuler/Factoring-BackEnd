﻿using AutoMapper;
using Factoring.Application.DTOs.Fondeo;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;

namespace Factoring.Application.Features.Fondeo.Commands
{
    public class UpdateFondeoCommand : IRequest<Response<int>>
    {
        public int IdFondeadorFactura { get; set; }
        public int IdOperacion { get; set; }
        public int IdFondeador { get; set; }
        public int IdTipoProducto { get; set; }
        public string? FechaDesembolso { get; set; }
        public string? FechaCobranza { get; set; }
        public int PorTasaMensual { get; set; }
        public int PorComisionFactura { get; set; }
        public int PorSpread { get; set; }
        public int PorCapitalFinanciado { get; set; }
        public int PorTasaAnualFondeo { get; set; }
        public int PorTasaMoraFondeo { get; set; }
        public string? UsuarioModificacion { get; set; }

        public class UpdateFondeoCommandHandler : IRequestHandler<UpdateFondeoCommand, Response<int>>
        {
            private readonly IFondeoRepositoryAsync _fondeoRepositoryAsync;
            private readonly IMapper _mapper;

            public UpdateFondeoCommandHandler(
                IFondeoRepositoryAsync fondeoRepositoryAsync,
                IMapper mapper

                )
            {
                _fondeoRepositoryAsync = fondeoRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(UpdateFondeoCommand command, CancellationToken cancellationToken)
            {
                //var fondeador = await _fondeoRepositoryAsync.GetByIdAsync(command.IdFondeador);

                //if (fondeador == null)
                //{
                //    throw new ApiException($"Fondeador no encontrado");
                //}
                //else
                //{
                    var fondeo = _mapper.Map<FondeoUpdateDto>(command);
                    await _fondeoRepositoryAsync.UpdateAsync(fondeo);
                    return new Response<int>(fondeo.IdFondeadorFactura, Constantes.SUCCEDED_UPDATE);
                //}
            }
        }

    }
}