namespace Factoring.Application.Features.Fondeador.DatosFondeador
{
    public class DatosFondeadorCreateDto
    {
        public int IdProducto { get; set; }
        public decimal TasaFondeo { get; set; }
        public decimal TasaMora { get; set; }
        public int iMoneda { get; set; }
        public decimal CapitalFinanciado { get; set; }
        public int IdMetodoCalculo { get; set; }
        public int DiaPago { get; set; }
        public int iRetencionInicialFondeador { get; set; }
        public int IdModalidad { get; set; }
        public string UsuarioCreador { get; set; }
        public int IdFondeador { get; set; }
        public int ITipodeNegocio { get; set; }
        public int iCalculoInteres { get; set; }
    }
    public class DatosFondeadorResponseListDto
    {
        public string iIdFondeadorDatos { get; set; }
        public string iIdProducto { get; set; }
        public string iTipodeNegocio { get; set; }
        public string TipodeNegocio { get; set; }
        public string iModalidad { get; set; }
        public string Modalidad { get; set; }
        public string NombreProducto { get; set; }
        public string nTasaFondeo { get; set; }
        public string nTasaMora { get; set; }
        public string nCapitalFinanciado { get; set; }
        public string iDiaPago { get; set; }
        public string iMetodoCalculo { get; set; }
        public string NombreMetodoCalculo { get; set; }
        public string dFecRegistro { get; set; }
        public string cUsuario { get; set; }
        public string iMoneda { get; set; }
        public string Moneda { get; set; }
        public string iRetencionInicialFondeador { get; set; }
        public string RetencionInicialFondeador { get; set; }
        public string iCalculoInteres { get; set; }
        public string CalculoInteres { get; set; }
    }
    public class DatosFondeadorDeleteDto
    {
        public string UsuarioActualizacion { get; set; }
        public int IdFondeadorDatos { get; set; }
    }

    public class DatosFondeadorPrestamoCreateDto
    {
        public int IdFondeadorCabecera { get; set; }
        public int IdProductoPrestamo { get; set; }
        public int IdMonedaPrestamo { get; set; }
        public int IdModalidadPrestamo { get; set; }
        public decimal nCapitalPrestamo { get; set; }
        public decimal nInteresPrestamo { get; set; }
        public decimal nInteresPeriodoGraciaPrestamo { get; set; }
        public bool bAplicanCapitalPrestamo { get; set; }
        public bool bAplicanInteresPrestamo { get; set; }
        public bool bAplicaInteresPeriodoGraciaPrestamo { get; set; }
        public string UsuarioCreador { get; set; }
    }
    public class FondeadorPrestamoResponseListDto
    {
        public string iIdFondeadorPrestamo { get; set; }
        public string cProducto { get; set; }
        public string cMoneda { get; set; }
        public string cModalidad { get; set; }
        public decimal nPorcentajeCapital { get; set; }
        public decimal nPorcentajeInteres { get; set; }
        public decimal nPorcentajeInteresPG { get; set; }
    }
    public class FondeadorPrestamoDeleteDto
    {
        public int iIdFondeadorPrestamo { get; set; }
        public string UsuarioActualizacion { get; set; }
    }
}
