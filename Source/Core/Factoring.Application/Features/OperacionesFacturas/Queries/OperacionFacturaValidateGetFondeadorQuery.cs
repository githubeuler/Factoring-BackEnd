using Factoring.Application.DTOs.Fondeador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Features.OperacionesFacturas.Queries
{
    
    public class OperacionFacturaValidateGetFondeadorQuery : IRequest<Response<IReadOnlyList<FondeadorGetPermisos>>>
    {
        public int? Id { get; set; }
        public List<int>? nLstIdFacturas { get; set; }
        public List<string>? sLstIdFacturas { get; set; }
        public string? sIdFacturas { get; set; }

        public class OperacionFacturaValidateGetFondeadorQueryHandler : IRequestHandler<OperacionFacturaValidateGetFondeadorQuery, Response<IReadOnlyList<FondeadorGetPermisos>>>
        {
            private readonly IOperacionesFacturaRepositoryAsync _operacionesFacturaRepositoryAsync;
            public OperacionFacturaValidateGetFondeadorQueryHandler(IOperacionesFacturaRepositoryAsync operacionesFacturaRepositoryAsync)
            {
                _operacionesFacturaRepositoryAsync = operacionesFacturaRepositoryAsync;
            }
            public async Task<Response<IReadOnlyList<FondeadorGetPermisos>>> Handle(OperacionFacturaValidateGetFondeadorQuery query, CancellationToken cancellationToken)
            {
                string sFacturas = string.Empty;
                int cantidad = query.nLstIdFacturas.Count;
                int contador = 1;
                foreach (var item in query.nLstIdFacturas)
                {
                    if (cantidad == 1 || contador == cantidad) sFacturas = sFacturas + item.ToString();
                    else
                    {
                        sFacturas = sFacturas + item.ToString() + ",";
                    }
                    contador++;
                }

                var operacion = await _operacionesFacturaRepositoryAsync.GetValidateFondeadoresAsync(sFacturas);

                if (operacion[0].cantidadInversionistas == 1)
                {
                    var lstFondeadorGetPermisosSGC = await _operacionesFacturaRepositoryAsync.GetListadoFondeadoresAsync(sFacturas);
                    return new Response<IReadOnlyList<FondeadorGetPermisos>>(lstFondeadorGetPermisosSGC);
                }
                else
                {
                    return new Response<IReadOnlyList<FondeadorGetPermisos>>(operacion);
                }
            }
        }
    }
}