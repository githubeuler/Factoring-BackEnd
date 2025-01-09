namespace Factoring.Application.DTOs.Usuario
{
    public class UsuarioTransactDto
    {
    }
    public class UsuarioInsertDto
    {
        public string? CodigoUsuario { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Password { get; set; }
        public string? Correo { get; set; }
        public string? UsuarioCreador { get; set; }
        public int IdPais{ get; set; }
    }
    public class UsuarioUpdateDto
    {
        public int IdUsuario { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Password { get; set; }
        public string? Correo { get; set; }
        public int Activo { get; set; }
        public string? FechaCese { get; set; }
        public string? UsuarioModificacion { get; set; }
    }
    public class UsuarioGetByIdDto
    {
        public string? cCodigoUsuario { get; set; }
        public string?  cNombreUsuario { get; set; }
        public string? cFechaRegistro { get; set; }
        public string? cFechaCese { get; set; }
        public string? cCorreo { get; set; }
        public string? cActivo { get; set; }
        public string? cNombrePais { get; set; }
        public string? cPassword { get; set; }
        public string? cUsuarioRegistro { get; set; }
    }
    public class UsuarioDeleteDto
    {
        public int IdUsuario { get; set; }
        public string? UsuarioModificacion { get; set; }
    }

}
