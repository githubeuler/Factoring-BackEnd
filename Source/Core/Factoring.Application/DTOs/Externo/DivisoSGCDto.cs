using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.DTOs.Externo
{
    public class DivisoFondeadores
    {
        public int? nIdFondeador { get; set; }
        public string? cFondeador { get; set; }
        public string? cDocumento { get; set; }
        public string? cCodParticipante { get; set; }

    }
    public class FondeadorGetAllNewSgcDto
    {
        public int? iIdFondeador { get; set; }
        public int? iTipoDocumento { get; set; }
        public string? TipoDocumento { get; set; }
        public string? cNroDocumento { get; set; }
        public string? cNombreFondeador { get; set; }
        public int? iTipodeNegocio { get; set; }
        public string? TipoNegocio { get; set; }
        public int? iPais { get; set; }
        public string? cNombrePais { get; set; }
        public string? cFormatoUbigeo { get; set; }
    }
    public class FondeadorGetAllDto
    {
        public int? iIdFondeador { get; set; }
        public int? iTipoDocumento { get; set; }
        public string? TipoDocumento { get; set; }
        public string? cNroDocumento { get; set; }
        public string? cNombreFondeador { get; set; }
        public int? iTipodeNegocio { get; set; }
        public string? TipoNegocio { get; set; }
        public int? iPais { get; set; }
        public string? cNombrePais { get; set; }
        public string? cFormatoUbigeo { get; set; }
    }
    public class FondeadorGetPermisosSGC
    {
        public int? iIdFondeador { get; set; }
        public int? iMetodoFondeo { get; set; }
        public int? transferencia { get; set; }
        public int? traspaso { get; set; }
        public string? cNombreFondeador { get; set; }
        public int? cantidadInversionistas { get; set; }

    }
    public class DivisoGetFondeador
    {
        public int? nIdFondeador { get; set; }
        public string? cFondeador { get; set; }
        public string? cDocumento { get; set; }
        public string? cCodParticipante { get; set; }
        public int? iIdFondeador { get; set; }
        public int? iTipoDocumento { get; set; }
        public string? tipoDocumento { get; set; }
        public string? cNroDocumento { get; set; }
        public string? cNombreFondeador { get; set; }
        public int? iTipodeNegocio { get; set; }
        public string? tipoNegocio { get; set; }
        public int? iPais { get; set; }
        public string? cNombrePais { get; set; }
        public string? cFormatoUbigeo { get; set; }
        public int? iIdFondeadorCavali { get; set; }
        public int? iCodParticipante { get; set; }
        public string? iCodRUT { get; set; }

    }
}
