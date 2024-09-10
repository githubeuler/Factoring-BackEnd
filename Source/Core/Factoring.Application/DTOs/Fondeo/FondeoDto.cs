namespace Factoring.Application.DTOs.Fondeo
{
    public class ReporteFondeoDTO
    {
        public int Id { get; set; }
        public string? NroOperacion { get; set; }
        public string? NumeroAsignaciones { get; set; }
        public string? GiradorOperacion { get; set; }
        public string? AceptanteOperacion { get; set; }
        public string? Factura { get; set; }
        public string? Fondeador { get; set; }
        public string? Producto { get; set; }
        public string? Moneda { get; set; }
        public string? TipoFondeo { get; set; }
        public string? EstadoFondeo { get; set; }
        public string? EstadoFactura { get; set; }
        public string? FechaAsignacionFondeador { get; set; }
        public string? FechaDesembolsoFondeador { get; set; }
        public string? PorcentajeCapitalFinanciado { get; set; }
        public string? PorcentajeTasaAnualFondeo { get; set; }
        public string? PorcentajeComisionFactura { get; set; }
        public string? PorcentajeSpread { get; set; }
        public string? PorcentajeTasaMensual { get; set; }
        public string? MontoCapitalFinanciado { get; set; }
        public string? MontoInteresFondeador { get; set; }
        public string? ComisionFondeador { get; set; }
        public string? Igv { get; set; }
        public string? MontoADesembolsarFondeador { get; set; }
        public string? FechaPagoFondeador { get; set; }

    }

}
