namespace Factoring.Application.DTOs.Fondeador
{
    public class FondeadorGetByIdDto
    {
        public int nIdFondeador { get; set; }
        public int nTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string cNroDocumento { get; set; }
        public string cNombreFondeador { get; set; }
        //public int iTipodeNegocio { get; set; }
        //public string TipoNegocio { get; set; }
        public int iPais { get; set; }
        public string cNombrePais { get; set; }
        public string cFormatoUbigeo { get; set; }
        public int nEstado { get; set; }
        public string NombreEstado { get; set; }
        public List<string> FormatoUbigeoPais { get; set; }

        public int nIdProducto { get; set; }
        public int nIdInteresCalculado { get; set; }
        public int nIdTipoFondeo { get; set; }
        public string cDistribucionFondeador { get; set; }
    }

    public class FondeadorGetAllDto
    {
        public int nIdFondeador { get; set; }
        public int nTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string cNroDocumento { get; set; }
        public string cNombreFondeador { get; set; }
        public int nTipodeNegocio { get; set; }
        public string TipoNegocio { get; set; }
        public int nPais { get; set; }
        public string cNombrePais { get; set; }
        public string cFormatoUbigeo { get; set; }
    }
}