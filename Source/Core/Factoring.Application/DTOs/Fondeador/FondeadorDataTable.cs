namespace Factoring.Application.DTOs.Fondeador
{
    public class FondeadorResponseDataTable
    {
        public int nIdFondeador { get; set; }
        public string cNroDocumento { get; set; }
        public string cNombreFondeador { get; set; }
        public string dFecRegistro { get; set; }
        public string nEstado { get; set; }
        public string NombreEstado { get; set; }
        public int TotalRecords { get; set; }

    }
    public class FondeadorRequestDataTable
    {
        public int Pageno { get; set; }
        public string FilterDoi { get; set; }
        public string FilterRazon { get; set; }
        public string FilterFecCrea { get; set; }
        public string Usuario { get; set; }
        public int PageSize { get; set; }
        public string Sorting { get; set; }
        public string SortOrder { get; set; }
        public int IdEstado { get; set; }
    }
}
