namespace Factoring.Application.DTOs.Fondeo
{
    public class FondeoResponseDataTable
    {
        public int nIdFondeadorFactura { get; set; }
        public int nIdOperaciones { get; set; }
        public string cNroOperacion { get; set; }
        public int nIdGirador { get; set; }
        public string cGirador { get; set; }
        public int nNumeroAsignaciones { get; set; }
        public string cNumeroAsignacion { get; set; }
        public int nIdFondeador { get; set; }
        public string? cFondeadorAsignado { get; set; }
        public string cFechaAsignacion { get; set; }
        public int nEstadoFondeo { get; set; }
        public string cEstadoFondeo { get; set; }
        public int nIdMoneda { get; set; }
        public string cMoneda { get; set; }
        public int nIdTipoFondeo { get; set; }
        public int TotalRecords { get; set; }

        public decimal nPorcentajeCapitalFinanciado { get; set; }
        public decimal nPorcentajeComisionFactura { get; set; }
        public decimal nPorcentajeSpread { get; set; }
        public decimal nPorcentajeTasaAnualFondeo { get; set; }
        public decimal nPorcentajeTasaMensual { get; set; }
        public decimal nPorcentajeTasaMoraFondeo { get; set; }
        public string? dFechaDesembolsoFondeador { get; set; }
        public string? dFechaCobranzaFondeador { get; set; }

    }
    public class FondeoRequestDataTable
    {
        public int Pageno { get; set; }
        public string FilterNroOperacion { get; set; }
        public string FilterFondeadorAsignado { get; set; }
        public string FilterGirador { get; set; }
        public string FilterFechaRegistro { get; set; }
        public string FilterEstadoFondeo { get; set; }
        public int PageSize { get; set; }
        public string Sorting { get; set; }
        public string SortOrder { get; set; }
        public int IdEstado { get; set; }
    }
}
