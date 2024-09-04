using Factoring.Application.DTOs.Cavali.Cavali4012;
using Factoring.Application.DTOs.Cavali;
using Factoring.Application.DTOs.EvaluacionOperaciones;
using Factoring.Application.DTOs.Operaciones.OperacionFactura;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Interfaces.Service;
using Factoring.Application.Wrappers;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Features.OperacionesFacturas.Queries.InvoicesCavaliSendQuery
{
    public class RemoveCavaliSendQuery : IRequest<Response<Response4008>>
    {

        //public int providerRuc { get; set; }
        //public string series { get; set; }
        //public int numeration { get; set; }
        //public string authorizationNumber { get; set; }
        //public string invoiceType { get; set; }
        //public string additionalFieldOne { get; set; }
        //public string additionalFieldTwo { get; set; }
        public int IdMotivo { get; set; }
        public string UsuarioCreador { get; set; }
        public List<int> Invoices { get; set; }
        public int InvoicesFactura { get; set; }

        public class RemoveCavaliSendQueryHandler : IRequestHandler<RemoveCavaliSendQuery, Response<Response4008>>
        {
            private readonly IOperacionesRepositoryAsync _operacionesRepositoryAsync;
            private readonly IOperacionesFacturaRepositoryAsync _operacionesFacturaRepositoryAsync;
            private readonly ICavaliServiceAsync _cavaliServiceAsync;
            private readonly IGiradorDireccionRepositoryAsync _giradorDireccionRepositoryAsync;
            private readonly IAdquirienteDireccionRepositoryAsync _adquirienteDireccionRepositoryAsync;
            private readonly IEvaluacionOperacionesRepositoryAsync _evaluacionOperacionesRepositoryAsync;
            public RemoveCavaliSendQueryHandler(
                IOperacionesRepositoryAsync operacionesRepositoryAsync,
                IOperacionesFacturaRepositoryAsync operacionesFacturaRepositoryAsync,
                ICavaliServiceAsync cavaliServiceAsync,
                IGiradorDireccionRepositoryAsync giradorDireccionRepositoryAsync,
                IAdquirienteDireccionRepositoryAsync adquirienteDireccionRepositoryAsync,
                IEvaluacionOperacionesRepositoryAsync evaluacionOperacionesRepositoryAsync
                )
            {
                _operacionesRepositoryAsync = operacionesRepositoryAsync;
                _operacionesFacturaRepositoryAsync = operacionesFacturaRepositoryAsync;
                _cavaliServiceAsync = cavaliServiceAsync;
                _giradorDireccionRepositoryAsync = giradorDireccionRepositoryAsync;
                _adquirienteDireccionRepositoryAsync = adquirienteDireccionRepositoryAsync;
                _evaluacionOperacionesRepositoryAsync = evaluacionOperacionesRepositoryAsync;
            }

            public string GetLastTwoCharacter(string input)
            {
                int tam_var = input.Length;
                return input.Substring((tam_var - 2), 2);
            }
            public async Task<Response<Response4008>> Handle(RemoveCavaliSendQuery query, CancellationToken cancellationToken)
            {

                var nIdOperacion = 0;
                var nIdOperacionFactura = 0;
                var nEstadoOperacion = 18;
                //var response = new Response4008();
                var response = new Response<Response4008>();
                var request4008 = new Request4008();
                var lstinvoice4008 = new List<Invoice4008>();
                var invoice4008 = new Invoice4008();
                var serieNumero = new SerieNumero();
                //new List<OperacionesFacturaListDto>();
                var facturas = new List<OperacionesFacturaListDto>();
                facturas.Add((await _operacionesFacturaRepositoryAsync.GetFacturaById(query.InvoicesFactura)));

                foreach (var item in facturas)
                {
                    invoice4008 = new Invoice4008();
                    nIdOperacion = item.nIdOperaciones;
                    nIdOperacionFactura = item.nIdOperacionesFacturas;
                    serieNumero = JsonConvert.DeserializeObject<SerieNumero>(item.cNroDocumento);
                    invoice4008.providerRuc = (long)Convert.ToInt64(item.rucGirador);
                    invoice4008.series = serieNumero.Serie;
                    invoice4008.numeration = (long)serieNumero.Numero;
                    invoice4008.authorizationNumber = "12345678";
                    invoice4008.invoiceType = "01";
                    invoice4008.additionalFieldOne = query.IdMotivo.ToString();
                    //invoice4008.additionalFieldTwo = query.IdMotivo.ToString();
                    lstinvoice4008.Add(invoice4008);
                }

                request4008.invoice = lstinvoice4008;

                var userAuth = await _cavaliServiceAsync.AuthenticationApi();
                if (userAuth.Succeeded)
                {
                    var responsenew = await _cavaliServiceAsync.SendRemove4008(request4008, userAuth.Data.JWToken);
                    response = responsenew;
                    await _operacionesFacturaRepositoryAsync.AddInvoicesLogCavaliAsync(new OperacionesFacturaInsertCavaliDto
                    {
                        UsuarioCreador = query.UsuarioCreador,
                        ConjuntoFacturasJson = JsonConvert.SerializeObject(facturas),
                        TramaEnvio4012 = JsonConvert.SerializeObject(request4008),
                        TramaRespuesta4012 = JsonConvert.SerializeObject(response.Data.Valores),
                        IdOperaciones = (int)nIdOperacion,
                        IdOperacionesFactura = (int)nIdOperacionFactura,
                        cParticipantCode = "0"
                    });
                    if (!response.Data.Error && response.Data.Valores != null)
                    {
                        //response.Succeeded= true;
                        if (response.Data.Valores.statusCode == 200)
                        {
                            //var res = await _evaluacionOperacionesRepositoryAsync.AddFacturaAsync(new EvaluacionOperacionesInsertDto
                            //{
                            //    IdOperaciones = (int)nIdOperacion,
                            //    IdOperacionesFactura = (int)nIdOperacionFactura,
                            //    IdCatalogoEstado = (int)nEstadoOperacion,
                            //    UsuarioCreador = Constantes.UADMIN,
                            //    Comentario = string.Empty
                            //});
                            var res = await _evaluacionOperacionesRepositoryAsync.AddFacturaEvaluacionAsync(new EvaluacionOperacionesInsertDto
                            {
                                IdOperaciones = (int)nIdOperacion,
                                IdOperacionesFactura = (int)nIdOperacionFactura,
                                IdCatalogoEstado = (int)nEstadoOperacion,
                                UsuarioCreador = Constantes.UADMIN,
                                Comentario = string.Empty
                            });
                        }
                    }
                }
                return new Response<Response4008>(response.Data);
            }
        }

    }
}
