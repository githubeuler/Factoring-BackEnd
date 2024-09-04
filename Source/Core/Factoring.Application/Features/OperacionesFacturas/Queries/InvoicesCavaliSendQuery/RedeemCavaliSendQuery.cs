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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Features.OperacionesFacturas.Queries.InvoicesCavaliSendQuery
{
    public class RedeemCavaliSendQuery : IRequest<Response<Response4007>>
    {
        public DateTime fechaPago { get; set; }
        public string? UsuarioCreador { get; set; }
        public List<string>? sInvoices { get; set; }
        public int InvoicesFactura { get; set; }

        public class RedeemCavaliSendQueryHandler : IRequestHandler<RedeemCavaliSendQuery, Response<Response4007>>
        {
            private readonly IOperacionesRepositoryAsync _operacionesRepositoryAsync;
            private readonly IOperacionesFacturaRepositoryAsync _operacionesFacturaRepositoryAsync;
            private readonly ICavaliServiceAsync _cavaliServiceAsync;
            private readonly IGiradorDireccionRepositoryAsync _giradorDireccionRepositoryAsync;
            private readonly IAdquirienteDireccionRepositoryAsync _adquirienteDireccionRepositoryAsync;
            private readonly IEvaluacionOperacionesRepositoryAsync _evaluacionOperacionesRepositoryAsync;
            public RedeemCavaliSendQueryHandler(
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
            public async Task<Response<Response4007>> Handle(RedeemCavaliSendQuery query, CancellationToken cancellationToken)
            {

                var nIdOperacion = 0;
                var nIdOperacionFactura = 0;
                var nEstadoOperacion = 30;

                var response = new Response4007();
                var request4007 = new Request4007();
                var lstinvoice4007 = new List<Invoice4007>();
                var invoice4007 = new Invoice4007();
                var serieNumero = new SerieNumero();
                var lstpayment = new List<Payment4007>();
                var paymentDetail4007 = new PaymentDetail4007();
                var payment = new Payment4007();
                var serieInvalida = false;

                try
                {
                    var facturas = new List<OperacionesFacturaListDto>();
                    facturas.Add((await _operacionesFacturaRepositoryAsync.GetFacturaById(query.InvoicesFactura)));

                    foreach (var item in facturas)
                    {
                        serieNumero = JsonConvert.DeserializeObject<SerieNumero>(item.cNroDocumento);
                        if (serieNumero.Serie.Length < 4 || item.rucGirador.Length < 11)
                            serieInvalida = true;
                    }
                    if (!serieInvalida)
                    {
                        foreach (var item in facturas)
                        {
                            invoice4007 = new Invoice4007();
                            payment = new Payment4007();
                            nIdOperacion = item.nIdOperaciones;
                            nIdOperacionFactura = item.nIdOperacionesFacturas;
                            serieNumero = JsonConvert.DeserializeObject<SerieNumero>(item.cNroDocumento);
                            invoice4007.providerRuc = (long)Convert.ToInt64(item.rucGirador);
                            invoice4007.series = serieNumero.Serie;
                            invoice4007.numeration = (long)serieNumero.Numero;
                            invoice4007.authorizationNumber = "0686089183";
                            invoice4007.invoiceType = "01";
                            payment.effectiveDatePayment = query.fechaPago.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                            payment.number = 0;
                            lstpayment.Add(payment);
                            paymentDetail4007.payment = lstpayment;
                            invoice4007.paymentDetail = paymentDetail4007;
                            invoice4007.additionalFieldOne = "additionalFieldOne";
                            invoice4007.additionalFieldTwo = "additionalFieldTwo";
                            lstinvoice4007.Add(invoice4007);
                        }

                        request4007.invoice = lstinvoice4007;

                        var userAuth = await _cavaliServiceAsync.AuthenticationApi();
                        if (userAuth.Succeeded)
                        {
                            response = await _cavaliServiceAsync.SendRedeem4007(request4007, userAuth.Data.JWToken);

                            await _operacionesFacturaRepositoryAsync.AddInvoicesLogCavaliAsync(new OperacionesFacturaInsertCavaliDto
                            {

                                UsuarioCreador = query.UsuarioCreador,
                                ConjuntoFacturasJson = JsonConvert.SerializeObject(facturas),
                                TramaEnvio4012 = JsonConvert.SerializeObject(request4007),
                                TramaRespuesta4012 = JsonConvert.SerializeObject(response),
                                IdOperaciones = (int)nIdOperacion,
                                IdOperacionesFactura = (int)nIdOperacionFactura,
                                cParticipantCode = "0"
                            });


                            if (!response.Succeeded && response.Valores != null)
                            {
                                if (response.Valores.statusCode == 200)
                                {
                                    var res = await _evaluacionOperacionesRepositoryAsync.AddFacturaAsync(new EvaluacionOperacionesInsertDto
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
                        return new Response<Response4007>(response);
                    }
                    else
                    {
                        response = new Response4007();
                        response.Message = "La serie asociada no cumple con el estándar de 4 dígitos como mínimo.";
                        response.Succeeded = true;
                        return new Response<Response4007>(response);
                    }
                }
                catch (Exception ex)
                {
                    response = new Response4007();
                    response.Message = ex.Message.ToString();
                    response.Succeeded = true;
                    return new Response<Response4007>(response);
                }
            }
        }

    }
}
