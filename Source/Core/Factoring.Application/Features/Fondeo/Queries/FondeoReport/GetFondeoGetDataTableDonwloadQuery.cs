using AutoMapper;
using Factoring.Application.DTOs.Fondeo;
using Factoring.Application.Interfaces.Repositories;
using Factoring.Application.Wrappers;
using MediatR;
using OfficeOpenXml;
using System.Drawing;

namespace Factoring.Application.Features.Fondeo.Queries.FondeoReport
{
    public  class GetFondeoGetDataTableDonwloadQuery : IRequest<Response<string>>
    {
        public string? FilterNroOperacion { get; set; }
        public string? FilterFondeadorAsignado { get; set; }
        public string? FilterGirador { get; set; }
        public string? FilterFechaRegistro { get; set; }
        public string? FilterEstadoFondeo { get; set; }
        public class GetFondeoGetDataTableDonwloadQueryHandler : IRequestHandler<GetFondeoGetDataTableDonwloadQuery, Response<string>>
        {
            private readonly IFondeoRepositoryAsync _fondeoRepositoryAsync;
            private readonly IMapper _mapper;
            public GetFondeoGetDataTableDonwloadQueryHandler(IFondeoRepositoryAsync fondeoRepositoryAsync, IMapper mapper)
            {
                _fondeoRepositoryAsync = fondeoRepositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<string>> Handle(GetFondeoGetDataTableDonwloadQuery request, CancellationToken cancellationToken)
            {
                var _request = _mapper.Map<FondeoRequestDataTable>(request);
                var response = await _fondeoRepositoryAsync.GetListFondeoDonwload(_request);

                var stream = new MemoryStream();
                using (var xlPackage = new ExcelPackage(stream))
                {
                    var worksheet = xlPackage.Workbook.Worksheets.Add("hoja");
                    var namedStyle = xlPackage.Workbook.Styles.CreateNamedStyle("HyperLink");
                    namedStyle.Style.Font.UnderLine = true;
                    namedStyle.Style.Font.Color.SetColor(Color.Blue);
                    const int startRow = 5;
                    var row = startRow;

                    worksheet.Cells["A1"].Value = "CORRELATIVO";
                    worksheet.Cells["B1"].Value = "NRO OPERACIÓN";
                    worksheet.Cells["C1"].Value = "NRO ASIGNACIÓN";
                    worksheet.Cells["D1"].Value = "GIRADOR OPERACIÓN";
                    worksheet.Cells["E1"].Value = "ACEPTANTE OPERACIÓN";
                    worksheet.Cells["F1"].Value = "NRO FACTURA";
                    worksheet.Cells["G1"].Value = "FONDEADOR";
                    worksheet.Cells["H1"].Value = "PRODUCTO";
                    worksheet.Cells["I1"].Value = "MONEDA";
                    worksheet.Cells["J1"].Value = "TIPO FONDEO";
                    worksheet.Cells["K1"].Value = "ESTADO FONDEO";
                    worksheet.Cells["L1"].Value = "ESTADO FACTURA";
                    worksheet.Cells["M1"].Value = "FECHA ASIGNACIÓN FONDEADOR";
                    worksheet.Cells["N1"].Value = "FECHA DESEMBOLSO FONDEADOR";
                    worksheet.Cells["O1"].Value = "PORCENTAJE CAPITAL FINANCIADO";
                    worksheet.Cells["P1"].Value = "PORCENTAJE TASA ANUAL";
                    worksheet.Cells["Q1"].Value = "PORCENTAJE COMISION FACTURA";
                    worksheet.Cells["R1"].Value = "PORCENTAJE SPREAD";
                    worksheet.Cells["S1"].Value = "PORCENTAJE TASA MENSUAL";
                    worksheet.Cells["T1"].Value = "MONTO CAPITAL FINANCIADO";
                    worksheet.Cells["U1"].Value = "MONTO INTERES FONDEADOR";
                    worksheet.Cells["V1"].Value = "COMISION FONDEADOR";
                    worksheet.Cells["W1"].Value = "IGV";
                    worksheet.Cells["X1"].Value = "MONTO A DESEMBOLSAR FONDEADOR";
                    worksheet.Cells["Y1"].Value = "FECHA PAGO FONDEADOR";
                   
                    using (var r = worksheet.Cells["A1:X1"])
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
                        worksheet.Cells[row, 1].Value = item.Id;
                        worksheet.Cells[row, 2].Value = item.NroOperacion;
                        worksheet.Cells[row, 3].Value = item.NumeroAsignaciones;
                        worksheet.Cells[row, 4].Value = item.GiradorOperacion;
                        worksheet.Cells[row, 5].Value = item.AceptanteOperacion;
                        worksheet.Cells[row, 6].Value = item.Factura;
                        worksheet.Cells[row, 7].Value = item.Fondeador;
                        worksheet.Cells[row, 8].Value = item.Producto;
                        worksheet.Cells[row, 9].Value = item.Moneda;
                        worksheet.Cells[row, 10].Value = item.TipoFondeo;
                        worksheet.Cells[row, 11].Value = item.EstadoFondeo;
                        worksheet.Cells[row, 12].Value = item.EstadoFactura;
                        worksheet.Cells[row, 13].Value = item.FechaAsignacionFondeador;
                        worksheet.Cells[row, 14].Value = item.FechaDesembolsoFondeador;
                        worksheet.Cells[row, 15].Value = item.PorcentajeCapitalFinanciado;
                        worksheet.Cells[row, 16].Value = item.PorcentajeTasaAnualFondeo;
                        worksheet.Cells[row, 17].Value = item.PorcentajeComisionFactura;
                        worksheet.Cells[row, 18].Value = item.PorcentajeSpread;
                        worksheet.Cells[row, 19].Value = item.PorcentajeTasaMensual;
                        worksheet.Cells[row, 20].Value = item.MontoCapitalFinanciado;
                        worksheet.Cells[row, 21].Value = item.MontoInteresFondeador; ;
                        worksheet.Cells[row, 22].Value = item.ComisionFondeador;
                        worksheet.Cells[row, 23].Value = item.Igv;
                        worksheet.Cells[row, 24].Value = item.MontoADesembolsarFondeador;
                        worksheet.Cells[row, 25].Value = item.FechaPagoFondeador;

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
