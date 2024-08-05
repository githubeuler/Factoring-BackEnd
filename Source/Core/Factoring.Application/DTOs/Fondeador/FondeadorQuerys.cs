namespace Factoring.Application.DTOs.Fondeador
{
    public class FondeadorGetByIdDto
    {
        public int iIdFondeador { get; set; }
        public int iTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string cNroDocumento { get; set; }
        public string cNombreFondeador { get; set; }
        //public int iTipodeNegocio { get; set; }
        //public string TipoNegocio { get; set; }
        public int iPais { get; set; }
        public string cNombrePais { get; set; }
        public string cFormatoUbigeo { get; set; }
        public int iEstado { get; set; }
        public string NombreEstado { get; set; }
        public List<string> FormatoUbigeoPais { get; set; }
    }

    public class FondeadorGetAllDto
    {
        public int iIdFondeador { get; set; }
        public int iTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string cNroDocumento { get; set; }
        public string cNombreFondeador { get; set; }
        public int iTipodeNegocio { get; set; }
        public string TipoNegocio { get; set; }
        public int iPais { get; set; }
        public string cNombrePais { get; set; }
        public string cFormatoUbigeo { get; set; }
    }
}