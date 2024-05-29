namespace Factoring.Application.DTOs.Girador.Confirming
{
    public class GiradorConfirmingDto
    {
        public int nIdGiradorConfirming { get; set; }
        public int nIdAceptante { get; set; }
        public int nIdGirador { get; set; }
        public int nCategoria { get; set; }
        public string Usuario { get; set; }
        public string Aceptante { get; set; }
        public string Girador { get; set; }
        public string Categoria { get; set; }
        public DateTime dFechaCreacion { get; set; }
    }

    public class ResponseCategoriaDto
    {
        public int IdGiradorConfirming { get; set; }
    }

    public class CategoriaGiradorCreateDto
    {
        public int nIdAceptante { get; set; }
        public int nIdGirador { get; set; }
        public int nCategoria { get; set; }
        public string Usuario { get; set; }
    }

    public class CategoriaGiradorDeleteDto
    {
        public string UsuarioActualizacion { get; set; }
        public int IdGiradorConfirming { get; set; }
    }

}
