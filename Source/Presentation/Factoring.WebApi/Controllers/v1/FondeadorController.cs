using Factoring.Application.Features.Fondeador.Commands;
using Factoring.Application.Features.Fondeador.Commands.CreatePrestamoFondeador;
using Factoring.Application.Features.Fondeador.Commands.DeleteFondeador;
using Factoring.Application.Features.Fondeador.Commands.DeletePrestamoFondeador;
using Factoring.Application.Features.Fondeador.Commands.UpdateFondeador;
using Factoring.Application.Features.Fondeador.Queries.FondeadorGetAll;
using Factoring.Application.Features.Fondeador.Queries.FondeadorGetById;
using Factoring.Application.Features.Fondeador.Queries.FondeadorReportExport;
using Factoring.Application.Features.Fondeador.Queries.FondeadorSearch;
using Factoring.Application.Features.FondeadorDetails.Prestamo.Querys;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Drawing;

namespace Factoring.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class FondeadorController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateFondeadorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetFondeadorByIdQuery { Id = id }));
        }
        [HttpGet("lista-fondeadores")]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new FondeadorGetAllQuery { }));
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetFondeadorListAll filter)
        {
            return Ok(await Mediator.Send(filter));
        }
        [HttpGet("delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteFondeadorByIdCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(UpdateFondeadorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost("download-file")]
        public async Task<IActionResult> DownloadFiles(GetListControlFileFondeadorExportQuery query)
        {
            var res = await Mediator.Send(query);

            var stream = new MemoryStream();
            using (var xlPackage = new ExcelPackage(stream))
            {
                var worksheet = xlPackage.Workbook.Worksheets.Add("Users");
                var namedStyle = xlPackage.Workbook.Styles.CreateNamedStyle("HyperLink");
                namedStyle.Style.Font.UnderLine = true;
                namedStyle.Style.Font.Color.SetColor(Color.Blue);
                const int startRow = 5;
                var row = startRow;

                worksheet.Cells["A1"].Value = "Fecha Registro";
                worksheet.Cells["B1"].Value = "Nombre Fondeador";
                worksheet.Cells["C1"].Value = "Tipo Documento";
                worksheet.Cells["D1"].Value = "Documento";
                worksheet.Cells["E1"].Value = "Tipo Negocio";
                worksheet.Cells["F1"].Value = "Estado";

                using (var r = worksheet.Cells["A1:F1"])
                {
                    //r.Merge = true;
                    r.Style.Font.Color.SetColor(Color.White);
                    r.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                    r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    r.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(23, 55, 93));
                }

                row = 2;
                foreach (var item in res.Data)
                {
                    worksheet.Cells[row, 1].Value = item.dFecRegistro;
                    worksheet.Cells[row, 2].Value = item.cNombreFondeador;
                    worksheet.Cells[row, 3].Value = item.TipoDocumento;
                    worksheet.Cells[row, 4].Value = item.cNroDocumento;
                    worksheet.Cells[row, 5].Value = item.TipoNegocio;
                    worksheet.Cells[row, 6].Value = item.NombreEstado;

                    row++;
                }
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                xlPackage.Save();
            }
            stream.Position = 0;

            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ReportFondeador.xlsx");
        }

        [HttpPost("create-prestamo")]
        public async Task<IActionResult> PostPrestamo(CreateFondeadorPrestamoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet("lista-fondeador-prestamo/{id}")]
        public async Task<IActionResult> GetPrestamo(int id)
        {
            return Ok(await Mediator.Send(new GetAllPrestamoByIdFondeadorQuery { Id = id }));
        }
        [HttpGet("delete-prestamo")]
        public async Task<IActionResult> DeletePrestamo([FromQuery] DeletePrestamoFondeadorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}
