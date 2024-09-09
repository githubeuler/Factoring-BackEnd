namespace Factoring.Application.DTOs.Fondeo
{
    public class FondeoUpdateDto
    {
        public int IdFondeadorFactura { get; set; }
        public int IdOperacion { get; set; }
        public int IdFondeador { get; set; }
        public int IdTipoProducto { get; set; }
        public string? FechaDesembolso { get; set; }
        public string? FechaCobranza { get; set; }
        public decimal PorTasaMensual { get; set; }
        public decimal PorComisionFactura { get; set; }
        public decimal PorSpread { get; set; }
        public decimal PorCapitalFinanciado { get; set; }
        public decimal PorTasaAnualFondeo { get; set; }
        public decimal PorTasaMoraFondeo { get; set; }
        public string? UsuarioModificacion { get; set; }
        public decimal Igv { get; set; }
    }

    public class FondeoInsertDto
    {
        public int IdFondeadorFactura { get; set; }
       
        public string? UsuarioCreacion { get; set; }
    }

    public class FondeoUpdateStateDto
    {
        public int IdFondeadorFactura { get; set; }
        public int IdEstadoFondeo { get; set; }
        public string? Comentario { get; set; }
        public string? UsuarioModificacion { get; set; }
    }
    
}
