namespace Factoring.Application.DTOs.Girador
{
    internal class GiradorTransactDto
    {
    }
    public class GiradorDeleteDto
    {
        public int IdGirador { get; set; }
        public string? UsuarioActualizacion { get; set; }


    }
    public class GiradorInsertDto
    {
        public int IdPais { get; set; }
        public string? RegUnicoEmpresa { get; set; }
        public string? RazonSocial { get; set; }
        public int IdSector { get; set; }
        public decimal Venta { get; set; }
        public decimal Compra { get; set; }
        public int IdGrupoEconomico { get; set; }
        public string? UsuarioCreador { get; set; }
    }

    public class GiradorUpdateDto
    {
        public int IdGirador { get; set; }
        public int IdPais { get; set; }
        public string? RegUnicoEmpresa { get; set; }
        public string? RazonSocial { get; set; }
        public int IdSector { get; set; }
        public decimal Venta { get; set; }
        public decimal Compra { get; set; }
        public int IdGrupoEconomico { get; set; }
        public string? UsuarioActualizacion { get; set; }

    }


    public class GiradorEvaluacionUpdateDto
    {
        public int IdGirador { get; set; }
        public string? UsuarioEvaluacion { get; set; }
        public int Estado { get; set; }
    }

    public class GiradorInsertComentarioDto
    {
        public int IdGirador { get; set; }
        public int IdEvaluacionComentarioGirador { get; set; }
        public string? Comentario { get; set; }
        public string? Usuario { get; set; }
    }


    public class AlertGetByCodigoDto
    {
        public int nIdPlantilla { get; set; }
        public string? cCodigoTemplate { get; set; }
        public string? cCuerpo { get; set; }
        public string? cDescripcion { get; set; }
        public string? Asunto { get; set; }
        public string? cDestinatarios { get; set; }
        public string? cCopia { get; set; }
        public int nTipo { get; set; }
        public bool nEstado { get; set; }
        public int nActivar { get; set; }


        public class AlertEmailGiradorDto
        {
            public string? cCorreo { get; set; }
        }
        public class GiradorAdquirienteDto
        {
            public int nIdPais { get; set; }
            public string? cRucGirador { get; set; }
            public string? cRucAdquiriente { get; set; }
        }

    }
}
