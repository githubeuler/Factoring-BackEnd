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

                    worksheet.Cells["A1"].Value = "OPERACIÓN";
                    worksheet.Cells["B1"].Value = "GIRADOR";
                    worksheet.Cells["C1"].Value = "ACEPTANTE";
                    worksheet.Cells["D1"].Value = "FECHA REGISTRO";
                    worksheet.Cells["E1"].Value = "ESTADO";
                    using (var r = worksheet.Cells["A1:E1"])
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
                        worksheet.Cells[row, 1].Value = item.nNroOperacion;
                        worksheet.Cells[row, 2].Value = item.cRazonSocialGirador;
                        worksheet.Cells[row, 3].Value = item.cRazonSocialAdquiriente;
                        worksheet.Cells[row, 4].Value = item.dFechaCreacion.ToString("dd/MM/yyyy");
                        worksheet.Cells[row, 5].Value = item.NombreEstado;



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
