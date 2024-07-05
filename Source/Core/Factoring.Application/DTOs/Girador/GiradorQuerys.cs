
namespace Factoring.Application.DTOs.Girador
{
    public class GiradorReporte
    {
        public GiradorReporte()
        {
            Facturas = new List<FacturasGiradorReporte>();
        }
        public int IdGirador { get; set; }
        public string RazonSocial { get; set; }
        public int CantidadAquirientes { get; set; }
        public List<FacturasGiradorReporte> Facturas { get; set; }
    }

    public class FacturasGiradorReporte
    {
        public int CantidadFacturas { get; set; }
        public decimal MontoTotal { get; set; }
        public string Estado { get; set; }
    }

    public class GiradorResponseComentariosLista
    {
        public DateTime dFechaCreacion { get; set; }
        public string cUsuarioCreador { get; set; }
        public string cComentario { get; set; }
        public string nNroOperacion { get; set; }
    }
    public class GiradorGetByIdDto
    {
        public int nIdGirador { get; set; }
        public int nIdPais { get; set; }
        public string cNombrePais { get; set; }
        public string cRegUnicoEmpresa { get; set; }
        public string cRazonSocial { get; set; }
        public string cFormatoUbigeo { get; set; }
        public int nIdSector { get; set; }
        public string cNombreSector { get; set; }
        public decimal nVenta { get; set; }
        public decimal nCompra { get; set; }
        public int nIdGrupoEconomico { get; set; }
        public string cNombreGrupoEconomico { get; set; }
        public int nEstado { get; set; }
        public string NombreEstado { get; set; }
        public List<string> FormatoUbigeoPais { get; set; }

    }
}
