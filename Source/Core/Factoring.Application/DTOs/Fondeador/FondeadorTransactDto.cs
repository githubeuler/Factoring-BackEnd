namespace Factoring.Application.DTOs.Fondeador
{
    public class FondeadorInsertDto
    {
        public int IdDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string NombreFondeador { get; set; }
        //public int IdTipoNegocio { get; set; }
        public int IdPais { get; set; }
        public string UsuarioCreador { get; set; }
    }
    public class FondeadorDeleteDto
    {
        public int IdFondeador { get; set; }
        public string UsuarioActualizacion { get; set; }
    }

    public class FondeadorUpdateDto
    {
        public int IdFondeador { get; set; }
        public int IdPais { get; set; }
        public int TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string NombreFondeador { get; set; }
        public int IdTipoNegocio { get; set; }
        public string UsuarioActualizacion { get; set; }

    }
}
