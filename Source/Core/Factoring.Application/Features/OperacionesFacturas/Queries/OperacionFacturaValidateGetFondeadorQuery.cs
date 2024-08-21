using Factoring.Application.DTOs.Fondeador;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Features.OperacionesFacturas.Queries
{

    public class OperacionFacturaValidateGetFondeadorQuery : IRequest<Response<FondeadorGetPermisosCabecera>>
    {
        public int? Id { get; set; }
        public List<int>? nLstIdFacturas { get; set; }
        public List<string>? sLstIdFacturas { get; set; }
        public string? sIdFacturas { get; set; }
        public int nIdOpcionOperacion { get; set; }

        public class OperacionFacturaValidateGetFondeadorQueryHandler : IRequestHandler<OperacionFacturaValidateGetFondeadorQuery, Response<FondeadorGetPermisosCabecera>>
        {
            private readonly IOperacionesFacturaRepositoryAsync _operacionesFacturaRepositoryAsync;
            public OperacionFacturaValidateGetFondeadorQueryHandler(IOperacionesFacturaRepositoryAsync operacionesFacturaRepositoryAsync)
            {
                _operacionesFacturaRepositoryAsync = operacionesFacturaRepositoryAsync;
            }
            public async Task<Response<FondeadorGetPermisosCabecera>> Handle(OperacionFacturaValidateGetFondeadorQuery query, CancellationToken cancellationToken)
            {
                //IReadOnlyList < FondeadorGetPermisos >>
                FondeadorGetPermisosCabecera oData = new();
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
                    List<FondeadorGetPermisos> olist = new();
                    //IReadOnlyList<FondeadorGetPermisos> olistFinal=null;
                    //var lstFondeadorGetPermisosSGC = await _operacionesFacturaRepositoryAsync.GetListadoFondeadoresAsync(sFacturas);
                    if (query.nIdOpcionOperacion == 2)
                    {
                        foreach (var item2 in query.nLstIdFacturas)
                        {
                            var olista = await _operacionesFacturaRepositoryAsync.GetListadoFondeadoresAsync(item2.ToString());
                            if (olista.Count > 0)
                            {
                                FondeadorGetPermisos obj = new()
                                {
                                    iIdFondeador = olista[0].iIdFondeador,
                                    iMetodoFondeo = olista[0].iMetodoFondeo,
                                    transferencia = olista[0].transferencia,
                                    traspaso = olista[0].traspaso,
                                    cNombreFondeador = olista[0].cNombreFondeador,
                                    cantidadInversionistas = operacion[0].cantidadInversionistas,
                                };
                                olist.Add(obj);
                            }
                        }
                        int nCantTrans = olist.Where(x => x.transferencia == 1).ToList().Count;
                        int nCantFact = query.nLstIdFacturas.Count;
                        if (nCantTrans == nCantFact)
                        {
                            oData.nActivarTransferencia = 1;
                        }
                        oData.listaFondeador = olist;
                    }
                    else
                    {
                        var olista = await _operacionesFacturaRepositoryAsync.GetListadoFondeadoresAsync(sFacturas);
                        olist = olista.ToList();
                        if (olist.Count > 0)
                        {
                            olist[0].cantidadInversionistas = operacion[0].cantidadInversionistas;
                        }
                        oData.listaFondeador = olist;
                    }
                    //return new Response<IReadOnlyList<FondeadorGetPermisos>>(olist);
                    return new Response<FondeadorGetPermisosCabecera>(oData);
                }
                else
                {
                    return new Response<FondeadorGetPermisosCabecera>(oData);
                    //return new Response<IReadOnlyList<FondeadorGetPermisos>>(operacion);
                }
            }
        }
    }
}