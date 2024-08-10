namespace Factoring.Application.DTOs.Fondeador.DocumentoFondeador
{
    public class DocumentosFondeadorResponseListDto
    {
        public int iIdFondeadorDocumento { get; set; }
        public int iIdFondeadorTipoDocumento { get; set; }
        public string NombreTipoDocumento { get; set; }
        public string cNombreDocumento { get; set; }
        public string cRutaDocumento { get; set; }
        public DateTime dFechaCreacion { get; set; }
    }

    public class DocumentosFondeadorCreateDto
    {
        public string RutaDocumento { get; set; }
        public string NombreDocumento { get; set; }
        public int IdTipoDocumento { get; set; }
        public string UsuarioCreador { get; set; }
        public int IdFondeador { get; set; }

    }
    public class DocumentosFondeadorDeleteDto
    {
        public int IdFondeadorDocumento { get; set; }
        public string UsuarioActualizacion { get; set; }

    }
}
