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
    public class OperacionesFacturaEnviRegistroValidateQuery : IRequest<Response<FacturasGetCabeceraRegistro>>
    {
        public List<int>? nLstIdFacturas { get; set; }
        public int nIdOpcionOperacion { get; set; }
        public int nTipo { get; set; }
        public class OperacionesFacturaEnviRegistroValidateQueryHandler : IRequestHandler<OperacionesFacturaEnviRegistroValidateQuery, Response<FacturasGetCabeceraRegistro>>
        {
            private readonly IOperacionesFacturaRepositoryAsync _operacionesFacturaRepositoryAsync;
            public OperacionesFacturaEnviRegistroValidateQueryHandler(IOperacionesFacturaRepositoryAsync operacionesFacturaRepositoryAsync)
            {
                _operacionesFacturaRepositoryAsync = operacionesFacturaRepositoryAsync;
            }
            public async Task<Response<FacturasGetCabeceraRegistro>> Handle(OperacionesFacturaEnviRegistroValidateQuery query, CancellationToken cancellationToken)
            {
                FacturasGetCabeceraRegistro oData = new();
                string mensaje = string.Empty;
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
                IReadOnlyList<FacturasGetRegistro> olistafacturas = await _operacionesFacturaRepositoryAsync.GetListaFacturasRegistradasAsync(sFacturas, query.nTipo);
                oData.listaFacturas = olistafacturas.ToList();
                if (olistafacturas.Count > 0)
                {
                    int nCantidadFiltro = 0;
                    if (query.nTipo == 1)
                    {
                        nCantidadFiltro = olistafacturas.Where(x => x.nEstadoFactura == 1).Count();
                        if (cantidad == nCantidadFiltro)
                        {
                            oData.nActivarTransferencia = 1;
                        }
                        else
                        {
                            oData.nActivarTransferencia = 0;
                        }
                    }
                    else if (query.nTipo == 3)
                    {
                        nCantidadFiltro = olistafacturas.Count();
                        if (cantidad == nCantidadFiltro)
                        {
                            oData.nActivarTransferencia = 1;
                        }
                        else
                        {
                            oData.nActivarTransferencia = 0;
                        }
                    }
                    else
                    {
                        oData.nActivarTransferencia = 1;
                    }

                }
                else {
                    oData.nActivarTransferencia = 0;
                    mensaje = "No existe facturas con el estado requerido para procesar";


                }
                return new Response<FacturasGetCabeceraRegistro>(oData, mensaje);

            }
        }
    }
}

