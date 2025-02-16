﻿namespace Factoring.Application.DTOs.Usuario
{
    internal class UsuarioDataTable
    {
    }
    public class UsuarioResponseDataTable
    {
        public int nIdUsuario { get; set; }
        public string? cCodigoUsuario { get; set; }
        public string? cNombreUsuario { get; set; }
        public string? cFechaRegistro{ get; set; }
        public string? cFechaCese { get; set; }
        public string? cCorreo { get; set; }
        public string? cActivo { get; set; }
        public string? cNombrePais { get; set; }
        public string? cNombreRol { get; set; }

        public int mIdTipoDocumento { get; set; }
        public string? cNumeroDocumento { get; set; }
        public string? cTelefono { get; set; }
        public string? cCelular { get; set; }
        public string? cCargo { get; set; }
        public string? cRuc { get; set; }
        public string? cRazonSocial { get; set; }


        public int TotalRecords { get; set; }
    }
    public class UsuarioRequestDataTable
    {
        public int Pageno { get; set; }
        public string? FilterCodigoUsuario { get; set; }
        public string? FilterNombreUsuario { get; set; }
        public string? FilterActivo { get; set; }
        public int FilterIdPais { get; set; }
        public int FilterIdRol { get; set; }
        public int PageSize { get; set; }
        public string? Sorting { get; set; }
        public string? SortOrder { get; set; }
    }
}
