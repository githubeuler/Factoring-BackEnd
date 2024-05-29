namespace Factoring.Application.DTOs.Girador.UbicacionGirador
{
    public class UbicacionGiradorInsertDto
    {
        public string FormatoUbigeo { get; set; }
        public string Direccion { get; set; }
        public int IdTipoDireccion { get; set; }
        public int IdGirador { get; set; }
    }


    public class UbicacionGiradorSingleJson
    {
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
    }

    public class DireccionGiradorSingleDto
    {
        public int nIdGiradorDireccion { get; set; }
        public string cDireccion { get; set; }
    }

    public class UbicacionGiradorListDto
    {
        public int nIdGiradorDireccion { get; set; }
        public string cFormatoUbigeo { get; set; }
        public string cDireccion { get; set; }
    }

    public class UbicacionGiradorSingleDto
    {
        public string cCodigoDepartamento { get; set; }
        public string cDescripcionDepartamento { get; set; }
        public string cCodigoProvincia { get; set; }
        public string cDescripcionProvincia { get; set; }
        public string cCodigoDistrito { get; set; }
        public string cDescripcionDistrito { get; set; }



    }

    public class UbicacionGiradorDeleteDto
    {
        public int IdGiradorDireccion { get; set; }
        public string UsuarioActualizacion { get; set; }
    }
}
