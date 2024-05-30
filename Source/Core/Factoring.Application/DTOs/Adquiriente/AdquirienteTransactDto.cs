namespace Factoring.Application.DTOs.Adquiriente
{
    internal class AdquirienteTransactDto
    {
    }
    public class AdquirienteDeleteDto
    {
        public int IdAdquiriente { get; set; }
        public string? UsuarioActualizacion { get; set; }


    }
    public class AdquirienteInsertDto
    {
        public int IdPais { get; set; }
        public string? RegUnicoEmpresa { get; set; }
        public string? RazonSocial { get; set; }
        public int IdSector { get; set; }
        public int IdGrupoEconomico { get; set; }
        public string? UsuarioCreador { get; set; }
    }

    public class AdquirienteUpdateDto
    {
        public int IdAdquiriente { get; set; }
        public int IdPais { get; set; }
        public string? RegUnicoEmpresa { get; set; }
        public string? RazonSocial { get; set; }
        public int IdSector { get; set; }
        public int IdGrupoEconomico { get; set; }
        public string? UsuarioActualizacion { get; set; }

    }
}
