namespace Factoring.Application.DTOs.Ubigeo
{
    public class UbigeoGetDto
    {
        public string cCodigo { get; set; }
        public string cDescripcion { get; set; }
    }

    public class UbigeoDataPeru
    {
        public int cCodigoDepartamento { get; set; }
        public string cDescripcionDepartamento { get; set; }
        public int cCodigoProvincia { get; set; }
        public string cDescripcionProvincia { get; set; }
        public int cCodigoDistrito { get; set; }
        public string cDescripcionDistrito { get; set; }
    }
}
