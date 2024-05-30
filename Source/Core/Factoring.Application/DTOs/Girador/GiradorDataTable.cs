namespace Factoring.Application.DTOs.Girador
{
    public class GiradorRequestDataTable
    {
        public int Pageno { get; set; }
        public string FilterRuc { get; set; }
        public string FilterRazon { get; set; }
        public int FilterIdPais { get; set; }
        public int FilterIdSector { get; set; }
        public int FilterIdGrupoEconomico { get; set; }
        public string FilterFecCrea { get; set; }
        public int PageSize { get; set; }
        public string Sorting { get; set; }
        public string SortOrder { get; set; }

    }




    public class GiradorResponseDataTable
    {
        public int nIdGirador { get; set; }
        public string cRegUnicoEmpresa { get; set; }
        public string cRazonSocial { get; set; }
        public string cNombreSector { get; set; }
        public DateTime dFechaCreacion { get; set; }
        public string cNombrePais { get; set; }
        public string nEstado { get; set; }
        public string NombreEstado { get; set; }
        public int TotalRecords { get; set; }

    }

    public class GiradorReporteFacturas
    {
        public int Facturas { get; set; }
        public string cNroOperacion { get; set; }
        public string cRazonSocial { get; set; }
        public decimal MontoFactura { get; set; }
        public string Estado { get; set; }
        public int EstadoEntero { get; set; }

    }
}
