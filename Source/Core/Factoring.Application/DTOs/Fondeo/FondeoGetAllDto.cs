namespace Factoring.Application.DTOs.Fondeo
{
    public  class FondeoGetAllDto
    {
        public int? nIdFondeadorFactura { get; set; }
        public int? nIdOperacion { get; set; }
        public string? cOperacion { get; set; }
        public int? nIdGirador { get; set; }
        public string? cGirador { get; set; }
        public int? nNumeroAsignaciones { get; set; }
        public string? cNumeroAsignacion { get; set; }
        public int? nIdFondeador { get; set; }
        public string? cFondeadorAsignado { get; set; }
        public string? cFechaAsignacion { get; set; }
        public int? nEstadoFondeo { get; set; }
        public string? cEstadoFondeo { get; set; }

    }
}
