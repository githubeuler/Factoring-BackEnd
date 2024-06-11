using AutoMapper;
using MediatR;
using OfficeOpenXml;
using Factoring.Application.DTOs.Operaciones;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Factoring.Application.Features.Operaciones.Queries.OperacionesReport
{
    public class GetOperacionesGetDataTableDonwloadQuery : IRequest<Response<string>>
    {
        public string? FilterNroOperacion { get; set; }
        public string? FilterRazonGirador { get; set; }
        public string? FilterRazonAdquiriente { get; set; }
        public string? FilterFecCrea { get; set; }
        public string? Estado { get; set; }

        public class GetOperacionesGetDataTableDonwloadQueryHandler : IRequestHandler<GetOperacionesGetDataTableDonwloadQuery, Response<string>>
        {
            private readonly IOperacionesRepositoryAsync _operacionesRepositoryAsync;
            private readonly IMapper _mapper;
            public GetOperacionesGetDataTableDonwloadQueryHandler(IOperacionesRepositoryAsync operacionesRepositoryAsync, IMapper mapper)
            {
                _operacionesRepositoryAsync = operacionesRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<string>> Handle(GetOperacionesGetDataTableDonwloadQuery request, CancellationToken cancellationToken)
            {
                var _request = _mapper.Map<OperacionesRequestDataTableDto>(request);
                var response = await _operacionesRepositoryAsync.GetListOperacionesDonwload(_request);

                var stream = new MemoryStream();
                using (var xlPackage = new ExcelPackage(stream))
                {
                    var worksheet = xlPackage.Workbook.Worksheets.Add("hoja");
                    var namedStyle = xlPackage.Workbook.Styles.CreateNamedStyle("HyperLink");
                    namedStyle.Style.Font.UnderLine = true;
                    namedStyle.Style.Font.Color.SetColor(Color.Blue);
                    const int startRow = 5;
                    var row = startRow;

                    worksheet.Cells["A1"].Value = "GIRADOR";

                    worksheet.Cells["B1"].Value = "ACEPTANTE";
                    //worksheet.Cells["C1"].Value = "FONDEADOR";

                    worksheet.Cells["C1"].Value = "NRO OPERACIÓN";
                    worksheet.Cells["D1"].Value = "NRO FACTURA";
                    worksheet.Cells["E1"].Value = "MONTO OPERACIÓN";
                    worksheet.Cells["F1"].Value = "MONEDA";
                    worksheet.Cells["G1"].Value = "IMPORTE NETO FACTURA	";
                    worksheet.Cells["H1"].Value = "PORCENTAJE FINANCIAMIENTO";
                    worksheet.Cells["I1"].Value = "TEM";
                    worksheet.Cells["J1"].Value = "COMISIÓN COBRANZA";
                    worksheet.Cells["K1"].Value = "NRO DOCUMENTO";
                    worksheet.Cells["L1"].Value = "DÍAS ADELANTO";
                    worksheet.Cells["M1"].Value = "IMPORTE FINANCIAR";
                    worksheet.Cells["N1"].Value = "TASA ANUAL";
                    worksheet.Cells["O1"].Value = "INTERES";
                    worksheet.Cells["P1"].Value = "COMISIÓN COBRANZA";
                    worksheet.Cells["Q1"].Value = "INTERES MORATORIO";
                    worksheet.Cells["R1"].Value = "INTERES COMPENSATORIO GIRADOR";
                    //worksheet.Cells["T1"].Value = "PLAN COBERTURA";
                    //worksheet.Cells["U1"].Value = "RETENCIÓN";
                    worksheet.Cells["S1"].Value = "IGV";
                    worksheet.Cells["T1"].Value = "DEVOLUCIÓN ESTIMADA GIRADOR";
                    worksheet.Cells["U1"].Value = "DEVOLUCIÓN TOTAL GIRADOR";
                    //worksheet.Cells["Y1"].Value = "DESEMBOLSO PROTECTUM";
                    //worksheet.Cells["Z1"].Value = "DESEMBOLSO PALANTE";
                    worksheet.Cells["V1"].Value = "MONTO DESEMBOLSAR";
                    worksheet.Cells["W1"].Value = "FECHA DESEMBOLSO";
                    worksheet.Cells["X1"].Value = "FECHA VENCIMIENTO";
                    worksheet.Cells["Y1"].Value = "FECHA CANCELADO";
                    worksheet.Cells["Z1"].Value = "FECHA PAGO NEGOCIADO";
                    worksheet.Cells["AA1"].Value = "FECHA CREACION OPERACION";
                    worksheet.Cells["AB1"].Value = "MONTO TOTAL SERVICIOS";
                    worksheet.Cells["AC1"].Value = "ESTADO FACTURA";
                    worksheet.Cells["AD1"].Value = "ESTADO OPERACIÓN";
                    worksheet.Cells["AE1"].Value = "USUARIO CREADOR";
                    worksheet.Cells["AF1"].Value = "COMENTARIO";
                    using (var r = worksheet.Cells["A1:AF1"])
                    {
                        //r.Merge = true;
                        r.Style.Font.Color.SetColor(Color.White);
                        r.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                        r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        r.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));
                    }

                    row = 2;
                    foreach (var item in response)
                    {
                        worksheet.Cells[row, 1].Value = item.Girador;
                        worksheet.Cells[row, 2].Value = item.Adquirente;
                        //worksheet.Cells[row, 3].Value = item.Aceptante;
                        worksheet.Cells[row, 3].Value = item.nNroOperacion;
                        worksheet.Cells[row, 4].Value = item.NroFactura;
                        worksheet.Cells[row, 5].Value = item.nMontoOperacion;
                        worksheet.Cells[row, 6].Value = item.cMoneda;
                        worksheet.Cells[row, 7].Value = item.ImporteNetoFactura;
                        worksheet.Cells[row, 8].Value = item.nPorcentajeFinanciamiento;
                        worksheet.Cells[row, 9].Value = item.nTEM;
                        worksheet.Cells[row, 10].Value = item.ComisionCobranza;
                        worksheet.Cells[row, 11].Value = item.nNroDocumento;
                        worksheet.Cells[row, 12].Value = item.nDiasAdelanto;
                        worksheet.Cells[row, 13].Value = item.nImporteaFinanciar;
                        worksheet.Cells[row, 14].Value = item.nTasaAnual;
                        worksheet.Cells[row, 15].Value = item.Interes;
                        worksheet.Cells[row, 16].Value = item.CostoComisionCobranza;
                        worksheet.Cells[row, 17].Value = item.interesMoratorio;
                        worksheet.Cells[row, 18].Value = item.interesCompuestoGirador;
                        //worksheet.Cells[row, 20].Value = item.planCobertura;
                        //worksheet.Cells[row, 21].Value = item.retencion;
                        worksheet.Cells[row, 19].Value = item.nIgv;
                        worksheet.Cells[row, 20].Value = item.devolucionEstimadaGirador;
                        worksheet.Cells[row, 21].Value = item.devolucionTotalGirador; ;
                        //worksheet.Cells[row, 25].Value = item.desenbolsoProtectum;
                        //worksheet.Cells[row, 26].Value = item.desenbolsoPalante; 
                        worksheet.Cells[row, 22].Value = item.MontoaDesembolsarGirador;
                        worksheet.Cells[row, 23].Value = item.dFechaDesembolso?.ToString("dd/MM/yyyy");
                        worksheet.Cells[row, 24].Value = item.dFechaVencimiento?.ToString("dd/MM/yyyy");
                        worksheet.Cells[row, 25].Value = item.dFechaCobranza?.ToString("dd/MM/yyyy");
                        worksheet.Cells[row, 26].Value = item.dFechaPagoNegociado?.ToString("dd/MM/yyyy");
                        worksheet.Cells[row, 27].Value = item.dFechaCreacionOperacion?.ToString("dd/MM/yyyy");
                        worksheet.Cells[row, 28].Value = item.nComisionEstructuracionTotal;
                        worksheet.Cells[row, 29].Value = item.EstadoFactura;

                        worksheet.Cells[row, 30].Value = item.EstadoOperacion;
                        worksheet.Cells[row, 31].Value = item.UsuarioCreador;
                        worksheet.Cells[row, 32].Value = item.Comentario;
                        row++;
                    }
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    xlPackage.Save();
                }
                stream.Position = 0;

                return new Response<string>(Convert.ToBase64String(stream.ToArray()), "OK");
            }
        }
    }
}
