namespace Factoring.Application.DTOs.Adquiriente
{
    public class AdquirienteRequestDataTable
    {
        public int Pageno { get; set; }
        public string FilterRuc { get; set; }
        public string FilterRazon { get; set; }
        public int FilterIdPais { get; set; }
        public string FilterFecCrea { get; set; }
        public int FilterIdSector { get; set; }
        public int FilterIdGrupoEconomico { get; set; }
        public string Usuario { get; set; }
        public int PageSize { get; set; }
        public string Sorting { get; set; }
        public string SortOrder { get; set; }
    }


    public class AdquirienteResponseComentariosLista
    {
        public DateTime dFechaCreacion { get; set; }
        public string cUsuarioCreador { get; set; }
        public string cComentario { get; set; }
        public string nNroOperacion { get; set; }
    }

    public class AdquirienteResponseDataTable
    {
        public int nIdAdquiriente { get; set; }
        public string cRegUnicoEmpresa { get; set; }
        public string cRazonSocial { get; set; }
        public string cNombreSector { get; set; }
        public DateTime dFechaCreacion { get; set; }
        public string cNombrePais { get; set; }
        public string nEstado { get; set; }
        public string NombreEstado { get; set; }
        public int TotalRecords { get; set; }

    }
}
