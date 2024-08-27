namespace Factoring.Application.DTOs.Fondeo
{
    public class ReporteFondeoDTO
    {
        public int nNroOperacion { get; set; }
        public string? Girador { get; set; }
        public string? Aceptante { get; set; }
        public string? NroFactura { get; set; }
        public decimal? nMontoOperacion { get; set; }
        public string? Estado { get; set; }
        public DateTime? dFechaDesembolso { get; set; }
        public DateTime? dFechaCobranza { get; set; }
        public DateTime? dFechaVencimiento { get; set; }
        public DateTime? dFechaCreacionOperacion { get; set; }
        public string? cMoneda { get; set; }
        public decimal? ImporteNetoFactura { get; set; }
        public string? nPorcentajeFinanciamiento { get; set; }
        public string? nTEM { get; set; }
        public string? ComisionCobranza { get; set; }
        public int? nNroDocumento { get; set; }
        public int? nDiasAdelanto { get; set; }
        public decimal? nImporteaFinanciar { get; set; }
        public string? nTasaAnual { get; set; }
        public string? Interes { get; set; }
        public decimal? CostoComisionCobranza { get; set; }
        public decimal? CostoRegistroFactura { get; set; }
        public decimal? CostoElaboracionContrato { get; set; }
        public decimal? nIgv { get; set; }
        public decimal? MontoaDesembolsarGirador { get; set; }
        public DateTime? dFechaAceptante { get; set; }
        public int TotalRecords { get; set; }
        public string? interesMoratorio { get; set; }
        public decimal? devolucionTotalGirador { get; set; }
        public decimal? planCobertura { get; set; }
        public decimal? retencion { get; set; }
        public decimal? devolucionEstimadaGirador { get; set; }
        public string? interesCompuestoGirador { get; set; }
        public decimal? desenbolsoProtectum { get; set; }
        public decimal? desenbolsoPalante { get; set; }
        public string? Adquirente { get; set; }
        public decimal? nComisionEstructuracionTotal { get; set; }
        public DateTime? dFechaPagoNegociado { get; set; }


        public string? EstadoFactura { get; set; }
        public string? EstadoOperacion { get; set; }
        public string? UsuarioCreador { get; set; }
        public string? Comentario { get; set; }

    }

}
