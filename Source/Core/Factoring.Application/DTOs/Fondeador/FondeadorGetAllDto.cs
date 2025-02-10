using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.DTOs.Fondeador
{
    //public class FondeadorGetAllDto
    //{
    //    public int iIdFondeador { get; set; }
    //    public int iTipoDocumento { get; set; }
    //    public string TipoDocumento { get; set; }
    //    public string cNroDocumento { get; set; }
    //    public string cNombreFondeador { get; set; }
    //    public int iTipodeNegocio { get; set; }
    //    public string TipoNegocio { get; set; }
    //    public int iPais { get; set; }
    //    public string cNombrePais { get; set; }
    //    public string cFormatoUbigeo { get; set; }
    //}

    public class FondeadorGetPermisos
    {
        public int? iIdFondeador { get; set; }
        public int? iMetodoFondeo { get; set; }
        public int? transferencia { get; set; }
        public int? traspaso { get; set; }
        public string? cNombreFondeador { get; set; }
        public int? cantidadInversionistas { get; set; }

    }
    public class FondeadorGetPermisosCabecera
    {
        public int? nActivarTransferencia { get; set; }
        public List<FondeadorGetPermisos> listaFondeador { get; set; }

    }

    public class FacturasGetRegistro
    {
        public int nIdOperaciones { get; set; }
        public int nIdOperacionesFacturas { get; set; }
        public int nIdFondeadorFactura { get; set; }
        public int nEstadoFactura { get; set; }
        public int nIdFondeador { get; set; }
        public string? dFechaDesembolsoFondeador { get; set; }
        public string? dFechaDesembolso { get; set; }
        public int nIdCategoria { get; set; }
        public int nCantOperacion { get; set; }
        public int nCantFacturasRecepcionada { get; set; }
        public bool bFondeadorPlus { get; set; }
        public int nNumeroAsignaciones { get; set; }
        public int nIdEstadoOperacionFactura { get; set; }
        public int nCodFondeadorPlus { get; set; }
        public int nIdFactura { get; set; }
        public string? dFechacAsignacion { get; set; }
        //nIdFactura
        //public int nEstadoFactura { get; set; }

    }

    public class FacturasGetCabeceraRegistro
    {
         public List<FacturasGetRegistro> listaFacturas { get; set; }
        public int? nActivarTransferencia { get; set; }
    }


}
