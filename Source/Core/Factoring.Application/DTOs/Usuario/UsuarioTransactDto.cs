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
        public int IdRol { get; set; }

        public int IdTipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Telefono { get; set; }
        public string? Celular { get; set; }
        public string? Cargo { get; set; }
        public string? Ruc { get; set; }
        public string? RazonSocial { get; set; }

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
        public int IdRol { get; set; }

        public int IdTipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Telefono { get; set; }
        public string? Celular { get; set; }
        public string? Cargo { get; set; }
        public string? Ruc { get; set; }
        public string? RazonSocial { get; set; }
    }
    public class UsuarioGetByIdDto
    {
        public int IdUsuario { get; set; }
        public string? CodigoUsuario { get; set; }
        public string?  NombreUsuario { get; set; }
        public string? FechaRegistro { get; set; }
        public string? FechaCese { get; set; }
        public string? Correo { get; set; }
        public int IdEstado { get; set; }
        public string? Estado { get; set; }
        public string? NombrePais { get; set; }
        public string? Contrasena { get; set; }
        public int IdPais { get; set; }
        public int IdRol { get; set; }
        public string? Pais { get; set; }
        public string? Rol { get; set; }
        public string? UsuarioRegistro { get; set; }
        public int IdTipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Telefono { get; set; }
        public string? Celular { get; set; }
        public string? Cargo { get; set; }
        public string? Ruc { get; set; }
        public string? RazonSocial { get; set; }

    }
    public class UsuarioDeleteDto
    {
        public int IdUsuario { get; set; }
        public string? UsuarioModificacion { get; set; }
    }

}
