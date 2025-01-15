using Factoring.Application.DTOs.EvaluacionOperaciones;
using Factoring.Application.DTOs.Girador.UbicacionGirador;
using Factoring.Application.DTOs.Operaciones.OperacionFactura;
using Factoring.Application.DTOs.Operaciones;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factoring.Application.DTOs.Cavali;
using Factoring.Application.DTOs.Externo;
using Factoring.Application.Interfaces.Service;
using static Factoring.Application.Enums.Enums;
using System.Diagnostics;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Engineering;

namespace Factoring.Application.Features.OperacionesFacturas.Queries.InvoicesCavaliSendQuery
{
    public class InvoicesCavaliSendQuery : IRequest<Response<ResponseCavaliInvoice4012>>
    {
        public int FlagRegisterProcess { get; set; }
        public int FlagAcvProcess { get; set; }
        public int FlagTransferProcess { get; set; }
        public int CodParticipante { get; set; }
        public string UsuarioCreador { get; set; }
        public List<int> Invoices { get; set; }
        public int InvoicesFactura { get; set; }
        public int nIdModalidad { get; set; }
        public int nSegundoEnvio { get; set; }
        public int nCategoriaFondeador { get; set; }
        public int? nCantidadAsignacion { get; set; }
        public int? nIdGiradorPlus { get; set; }
        public bool bFondeadorPlus { get; set; }
        public bool bSegundoFlagDiferente { get; set; }

        public class InvoicesCavaliSendQueryHandler : IRequestHandler<InvoicesCavaliSendQuery, Response<ResponseCavaliInvoice4012>>
        {
            private readonly IOperacionesRepositoryAsync _operacionesRepositoryAsync;
            private readonly IOperacionesFacturaRepositoryAsync _operacionesFacturaRepositoryAsync;
            private readonly ICavaliServiceAsync _cavaliServiceAsync;
            private readonly IGiradorDireccionRepositoryAsync _giradorDireccionRepositoryAsync;
            private readonly IAdquirienteDireccionRepositoryAsync _adquirienteDireccionRepositoryAsync;
            private readonly IEvaluacionOperacionesRepositoryAsync _evaluacionOperacionesRepositoryAsync;
            private readonly IMailFunctionsRepositoryAsync _mailFunctionsRepositoryAsync;
            public InvoicesCavaliSendQueryHandler(
                IOperacionesRepositoryAsync operacionesRepositoryAsync,
                IOperacionesFacturaRepositoryAsync operacionesFacturaRepositoryAsync,
                ICavaliServiceAsync cavaliServiceAsync,
                IGiradorDireccionRepositoryAsync giradorDireccionRepositoryAsync,
                IAdquirienteDireccionRepositoryAsync adquirienteDireccionRepositoryAsync,
                IEvaluacionOperacionesRepositoryAsync evaluacionOperacionesRepositoryAsync,
                IMailFunctionsRepositoryAsync mailFunctionsRepositoryAsync)
            {
                _operacionesRepositoryAsync = operacionesRepositoryAsync;
                _operacionesFacturaRepositoryAsync = operacionesFacturaRepositoryAsync;
                _cavaliServiceAsync = cavaliServiceAsync;
                _giradorDireccionRepositoryAsync = giradorDireccionRepositoryAsync;
                _adquirienteDireccionRepositoryAsync = adquirienteDireccionRepositoryAsync;
                _evaluacionOperacionesRepositoryAsync = evaluacionOperacionesRepositoryAsync;
                _mailFunctionsRepositoryAsync = mailFunctionsRepositoryAsync;
            }

            public string GetLastTwoCharacter(string input)
            {
                int tam_var = input.Length;
                return input.Substring((tam_var - 2), 2);
            }
            public async Task<Response<ResponseCavaliInvoice4012>> Handle(InvoicesCavaliSendQuery query, CancellationToken cancellationToken)
            {
                try
                {
                    var fondeador = new DivisoGetFondeador();
                    if (query.FlagTransferProcess == 1)
                    {
                        //if(query.nCategoriaFondeador==1 && query.nCantidadAsignacion=1)
                        fondeador = await _operacionesRepositoryAsync.GetObtenerIversionistaEnvio(query.nCategoriaFondeador, query.CodParticipante, 1, query.nCantidadAsignacion.Value);
                    }
                    else
                    {
                        fondeador.iCodParticipante = 0;
                        fondeador.iCodRUT = "1";
                    }

                    var facturas = new List<OperacionesFacturaListDto>();
                    var invoice = new InvoiceRoot();
                    var invoiceHolder = new InvoiceRootHolder();
                    var invoiceHolder_NoPafactoring = new InvoiceRootHolder();
                    int nIdOperacion = 0, nIdOperacionFactura = 0, nEstadoOperacion = 0;
                    int nCorrela = await _operacionesRepositoryAsync.GetprocessNumberFacturas();


                    var processNumber = Convert.ToString(nCorrela);
                    if (fondeador.iCodRUT != null && fondeador.iCodRUT != "0")
                    {
                        invoice.processDetail.processNumber = processNumber;
                        invoice.processDetail.invoiceCount = 1;
                    }
                    else
                    {
                        invoiceHolder.processDetail.processNumber = processNumber;
                        invoiceHolder.processDetail.invoiceCount = 1;
                    }
                    facturas.Add((await _operacionesFacturaRepositoryAsync.GetFacturaById(query.InvoicesFactura)));

                    if (query.FlagRegisterProcess == 1 && query.FlagAcvProcess == 0 && query.FlagTransferProcess == 0)
                    {

                        invoice.processDetail.flagRegisterProcess = 1;
                        invoice.processDetail.flagAcvProcess = 1;
                        nEstadoOperacion = (int)EstadoOperacion.Estado15;

                        foreach (var item in facturas)
                        {
                            nIdOperacion = item.nIdOperaciones;
                            nIdOperacionFactura = item.nIdOperacionesFacturas;
                            var operacion = await _operacionesRepositoryAsync.GetByIdAsync(item.nIdOperaciones);

                            var direccionGirador = (await _giradorDireccionRepositoryAsync.GetAllDireccionByGirador(operacion.nIdGirador)).OrderByDescending(x => x.nIdGiradorDireccion).ToList();

                            var giradorDr = direccionGirador.FirstOrDefault();

                            var ubicacionGirador = JsonConvert.DeserializeObject<UbicacionGiradorSingleJson>(giradorDr.cFormatoUbigeo);

                            var direccionAcq = (await _adquirienteDireccionRepositoryAsync.GetAllDireccionByIdAdquiriente(operacion.nIdAdquiriente)).OrderByDescending(x => x.nIdAdquirienteDireccion).ToList();

                            var acqDr = direccionAcq.FirstOrDefault();

                            var ubicacionAcq = JsonConvert.DeserializeObject<UbicacionGiradorSingleJson>(acqDr.cFormatoUbigeo);


                            invoice.invoiceDetail.invoice.Add(new Invoice
                            {
                                fileName = item.cNombreDocumentoXML,
                                fileXml = await _operacionesRepositoryAsync.GetFileBase64(item.cRutaDocumentoXML),
                                expirationDate = item.dFechaPagoNegociado.ToString("dd/MM/yyyy"),//item.dFechaVencimiento.ToString("dd/MM/yyyy"),
                                holderCode = 1,
                                participantDestination = 905,
                                department = ubicacionGirador.Departamento,
                                province = GetLastTwoCharacter(ubicacionGirador.Provincia),
                                district = GetLastTwoCharacter(ubicacionGirador.Distrito),
                                addressSupplier = giradorDr.cDireccion,
                                acqDepartment = ubicacionAcq.Departamento,
                                acqProvince = GetLastTwoCharacter(ubicacionAcq.Provincia),
                                acqDistrict = GetLastTwoCharacter(ubicacionAcq.Distrito),
                                addressAcquirer = acqDr.cDireccion,
                                typePayment = 0,
                                deliverDateAcq = DateTime.Now.ToString("dd/MM/yyyy"),
                                paymentDate = item.dFechaPagoNegociado.ToString("dd/MM/yyyy"),
                                netAmount = item.nMonto,

                            });
                        }
                    }

                    if (query.FlagAcvProcess == 1 && query.FlagRegisterProcess == 0 && query.FlagTransferProcess == 0)
                    {
                        //15
                        invoice.processDetail.flagAcvProcess = 1;
                        nEstadoOperacion = (int)EstadoOperacion.Estado15;
                        foreach (var item in facturas)
                        {
                            nIdOperacion = item.nIdOperaciones;
                            nIdOperacionFactura = item.nIdOperacionesFacturas;

                            var operacion = await _operacionesRepositoryAsync.GetByIdAsync(item.nIdOperaciones);

                            var direccionGirador = (await _giradorDireccionRepositoryAsync.GetAllDireccionByGirador(operacion.nIdGirador)).OrderByDescending(x => x.nIdGiradorDireccion).ToList();

                            var giradorDr = direccionGirador.FirstOrDefault();

                            var ubicacionGirador = JsonConvert.DeserializeObject<UbicacionGiradorSingleJson>(giradorDr.cFormatoUbigeo);

                            var direccionAcq = (await _adquirienteDireccionRepositoryAsync.GetAllDireccionByIdAdquiriente(operacion.nIdAdquiriente)).OrderByDescending(x => x.nIdAdquirienteDireccion).ToList();

                            var acqDr = direccionAcq.FirstOrDefault();

                            var ubicacionAcq = JsonConvert.DeserializeObject<UbicacionGiradorSingleJson>(acqDr.cFormatoUbigeo);

                            invoice.invoiceDetail.invoice.Add(new Invoice
                            {
                                fileName = item.cNombreDocumentoXML,
                                fileXml = await _operacionesRepositoryAsync.GetFileBase64(item.cRutaDocumentoXML),
                                expirationDate = item.dFechaVencimiento.ToString("dd/MM/yyyy"),
                                holderCode = 1,
                                participantDestination = 905,
                                department = ubicacionGirador.Departamento,
                                province = GetLastTwoCharacter(ubicacionGirador.Provincia),
                                district = GetLastTwoCharacter(ubicacionGirador.Distrito),
                                addressSupplier = giradorDr.cDireccion,
                                acqDepartment = ubicacionAcq.Departamento,
                                acqProvince = GetLastTwoCharacter(ubicacionAcq.Provincia),
                                acqDistrict = GetLastTwoCharacter(ubicacionAcq.Distrito),
                                addressAcquirer = acqDr.cDireccion,
                                typePayment = 0,
                                deliverDateAcq = DateTime.Now.ToString("dd/MM/yyyy"),
                                paymentDate = item.dFechaVencimiento.ToString("dd/MM/yyyy"),
                                netAmount = item.nMonto,

                            });
                        }
                    }
                    var newInvoice2 = new InvoiceRoot2();
                    if (query.FlagTransferProcess == 1 && query.FlagAcvProcess == 0 && query.FlagRegisterProcess == 0)
                    {
                        nEstadoOperacion = (int)EstadoOperacion.Estado16;
                        if (fondeador.iCodRUT != null && fondeador.iCodRUT != "0")
                        {
                            invoice.processDetail.flagTransferProcess = 1;
                        }
                        else
                        {
                            invoiceHolder.processDetail.flagTransferProcess = 1;
                        }

                        newInvoice2 = null;
                        foreach (var item in facturas)
                        {
                            nIdOperacion = item.nIdOperaciones;
                            nIdOperacionFactura = item.nIdOperacionesFacturas;
                            var operacion = await _operacionesRepositoryAsync.GetByIdAsync(item.nIdOperaciones);

                            var direccionGirador = (await _giradorDireccionRepositoryAsync.GetAllDireccionByGirador(operacion.nIdGirador)).OrderByDescending(x => x.nIdGiradorDireccion).ToList();

                            var giradorDr = direccionGirador.FirstOrDefault();

                            var ubicacionGirador = JsonConvert.DeserializeObject<UbicacionGiradorSingleJson>(giradorDr.cFormatoUbigeo);

                            var direccionAcq = (await _adquirienteDireccionRepositoryAsync.GetAllDireccionByIdAdquiriente(operacion.nIdAdquiriente)).OrderByDescending(x => x.nIdAdquirienteDireccion).ToList();

                            var acqDr = direccionAcq.FirstOrDefault();

                            var ubicacionAcq = JsonConvert.DeserializeObject<UbicacionGiradorSingleJson>(acqDr.cFormatoUbigeo);
                            if (fondeador.iCodRUT != null && fondeador.iCodRUT != "0")
                            {
                                invoice.invoiceDetail.invoice.Add(new Invoice
                                {
                                    fileName = item.cNombreDocumentoXML,
                                    fileXml = await _operacionesRepositoryAsync.GetFileBase64(item.cRutaDocumentoXML),
                                    expirationDate = item.dFechaVencimiento.ToString("dd/MM/yyyy"),
                                    participantDestination = Convert.ToInt32(fondeador.iCodParticipante),
                                    holderCode = Convert.ToInt32(fondeador.iCodRUT),
                                    department = ubicacionGirador.Departamento,
                                    province = GetLastTwoCharacter(ubicacionGirador.Provincia),
                                    district = GetLastTwoCharacter(ubicacionGirador.Distrito),
                                    addressSupplier = giradorDr.cDireccion,
                                    acqDepartment = ubicacionAcq.Departamento,
                                    acqProvince = GetLastTwoCharacter(ubicacionAcq.Provincia),
                                    acqDistrict = GetLastTwoCharacter(ubicacionAcq.Distrito),
                                    addressAcquirer = acqDr.cDireccion,
                                    typePayment = 0,
                                    deliverDateAcq = DateTime.Now.ToString("dd/MM/yyyy"),
                                    paymentDate = item.dFechaVencimiento.ToString("dd/MM/yyyy"),
                                    netAmount = item.nMonto,

                                });
                            }
                            else
                            {
                                invoiceHolder.invoiceDetail.invoice.Add(new InvoiceUnHolder
                                {
                                    fileName = item.cNombreDocumentoXML,
                                    fileXml = await _operacionesRepositoryAsync.GetFileBase64(item.cRutaDocumentoXML),
                                    expirationDate = item.dFechaVencimiento.ToString("dd/MM/yyyy"),
                                    participantDestination = Convert.ToInt32(fondeador.iCodParticipante),
                                    department = ubicacionGirador.Departamento,
                                    province = GetLastTwoCharacter(ubicacionGirador.Provincia),
                                    district = GetLastTwoCharacter(ubicacionGirador.Distrito),
                                    addressSupplier = giradorDr.cDireccion,
                                    acqDepartment = ubicacionAcq.Departamento,
                                    acqProvince = GetLastTwoCharacter(ubicacionAcq.Provincia),
                                    acqDistrict = GetLastTwoCharacter(ubicacionAcq.Distrito),
                                    addressAcquirer = acqDr.cDireccion,
                                    typePayment = 0,
                                    deliverDateAcq = DateTime.Now.ToString("dd/MM/yyyy"),
                                    paymentDate = item.dFechaVencimiento.ToString("dd/MM/yyyy"),
                                    netAmount = item.nMonto,

                                });
                            }
                        }
                    }

                    //var response = new ResponseCavaliInvoice4012();
                    var response = new Response<ResponseCavaliInvoice4012>();
                    var userAuthCavly = await _cavaliServiceAsync.AuthenticationApi();
                    if (userAuthCavly.Succeeded)
                    {
                        //if (query.nSegundoEnvio == 1)
                        //{
                        //    var resultcodPart = await _operacionesRepositoryAsync.GetObtenerIversionistaFSeleccionado(query.CodParticipante);
                        //    invoiceHolder.invoiceDetail.invoice.ForEach(z => z.participantDestination = Convert.ToInt32(resultcodPart.iCodParticipante));
                        //}
                        if (fondeador.iCodRUT != null && fondeador.iCodRUT != "0")
                        {
                            response = await _cavaliServiceAsync.SendInvoice4012(invoice, newInvoice2, userAuthCavly.Data.JWToken);
                        }
                        else
                        {
                            response = await _cavaliServiceAsync.SendInvoice4012Holder(invoiceHolder, newInvoice2, userAuthCavly.Data.JWToken);
                        }

                        if (response.Data.Valores != null)
                        {
                        }

                        await _operacionesFacturaRepositoryAsync.AddInvoicesLogCavaliAsync(new OperacionesFacturaInsertCavaliDto
                        {

                            UsuarioCreador = query.UsuarioCreador,
                            ConjuntoFacturasJson = JsonConvert.SerializeObject(facturas),
                            TramaEnvio4012 = invoice.processDetail.processNumber == null ? JsonConvert.SerializeObject(invoiceHolder) : JsonConvert.SerializeObject(invoice),
                            TramaRespuesta4012 = JsonConvert.SerializeObject(response.Data.Valores),
                            IdOperaciones = (int)nIdOperacion,
                            IdOperacionesFactura = (int)nIdOperacionFactura,
                            cParticipantCode = fondeador.iCodParticipante.ToString(),
                        });


                        var res = await _evaluacionOperacionesRepositoryAsync.AddFacturaEvaluacionAsync(new EvaluacionOperacionesInsertDto
                        {
                            IdOperaciones = (int)nIdOperacion,
                            IdOperacionesFactura = (int)nIdOperacionFactura,
                            IdCatalogoEstado = (int)nEstadoOperacion,
                            UsuarioCreador = Constantes.UADMIN,
                            Comentario = string.Empty
                        });
                    
                        if (query.FlagTransferProcess == 1 && query.nCantidadAsignacion == 1 && query.nCategoriaFondeador==1 && query.bFondeadorPlus==false && (!response.Data.Error && response.Data.Valores != null))
                        {
                            var result2 = await _operacionesRepositoryAsync.GetObtenerIversionistaEnvio(query.nCategoriaFondeador, query.CodParticipante, 2,query.nCantidadAsignacion.Value);
                            if (response.Data.Valores.statusCode == 200)
                            {
                                var nTiempoResult = await _mailFunctionsRepositoryAsync.ObtenerTiempo();
                                int tiempoMaximo = Convert.ToInt32(nTiempoResult); // Máximo tiempo permitido en segundos
                                var timer = Stopwatch.StartNew(); // Iniciar el temporizador

                                while (timer.Elapsed.TotalSeconds <= tiempoMaximo)
                                {
                                    // Obtener el estado de la operación
                                    var objNew = await _operacionesFacturaRepositoryAsync.GetEstadoOperacion((int)nIdOperacionFactura);
                                    if (objNew.nEstado == 9) // Resultado esperado
                                    {
                                        await _evaluacionOperacionesRepositoryAsync.AddFacturaEvaluacionAsync(new EvaluacionOperacionesInsertDto
                                        {
                                            IdOperaciones = (int)nIdOperacion,
                                            IdOperacionesFactura = (int)nIdOperacionFactura,
                                            IdCatalogoEstado = (int)nEstadoOperacion,
                                            UsuarioCreador = Constantes.UADMIN,
                                            Comentario = string.Empty
                                        });

                                        invoiceHolder.invoiceDetail.invoice.ForEach(z =>
                                            z.participantDestination = Convert.ToInt32(result2.iCodParticipante));
                                        response = await _cavaliServiceAsync.SendInvoice4012Holder(invoiceHolder, newInvoice2, userAuthCavly.Data.JWToken);

                                        // Guardar logs de la operación
                                        await _operacionesFacturaRepositoryAsync.AddInvoicesLogCavaliAsync(new OperacionesFacturaInsertCavaliDto
                                        {
                                            UsuarioCreador = query.UsuarioCreador,
                                            ConjuntoFacturasJson = JsonConvert.SerializeObject(facturas),
                                            TramaEnvio4012 = invoice.processDetail.processNumber == null ? JsonConvert.SerializeObject(invoiceHolder) : JsonConvert.SerializeObject(invoice),
                                            TramaRespuesta4012 = JsonConvert.SerializeObject(response),
                                            IdOperaciones = (int)nIdOperacion,
                                            IdOperacionesFactura = (int)nIdOperacionFactura,
                                            cParticipantCode = fondeador.iCodParticipante.ToString(),
                                        });

                                        break; // Salir del bucle porque se encontró el resultado esperado
                                    }
                                    // Esperar un pequeño intervalo para evitar llamadas excesivas
                                    await Task.Delay(1000); // 1 segundo
                                }

                                timer.Stop(); // Detener el temporizador
                            }
                        }
                    }
                    return new Response<ResponseCavaliInvoice4012>(response.Data);
                }
                catch (Exception ex)
                {
                    var response = new ResponseCavaliInvoice4012();
                    response.Error = true;
                    response.Mensaje = ex.Message.ToString() + ex.StackTrace.ToString();
                    return new Response<ResponseCavaliInvoice4012>(response);
                }
            }
        }

    }
}
