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
        public int PorTasaMensual { get; set; }
        public int PorComisionFactura { get; set; }
        public int PorSpread { get; set; }
        public int PorCapitalFinanciado { get; set; }
        public int PorTasaAnualFondeo { get; set; }
        public int PorTasaMoraFondeo { get; set; }
        public string? UsuarioModificacion { get; set; }
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
