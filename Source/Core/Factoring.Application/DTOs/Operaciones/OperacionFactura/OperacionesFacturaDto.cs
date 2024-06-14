using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.DTOs.Operaciones.OperacionFactura
{
    public class FacturaParserXml
    {
        public string CountryDocumentId { get; set; }
        public string CountryId { get; set; }
        public DateTime Date { get; set; }
        public int DateNumber { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; }
        public double NetAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double FreeAmount { get; set; }
        public double SurchargeAmount { get; set; }
        public double TaxAmount { get; set; }
        public double TipAmount { get; set; }
        public double TotalAmount { get; set; }
        public string CurrencyType { get; set; }
        public string SeriesNumber { get; set; }
        public string Series { get; set; }
        public ulong Number { get; set; }
        public string NumberStr { get; set; }
        public string DocumentSenderCode { get; set; }
        public string DocumentSenderName { get; set; }
        public string DocumentReceiverCode { get; set; }
        public string DocumentReceiverName { get; set; }
        public string ExternalId { get; set; }
        public string DocumentFinancialOwnerCode { get; set; }
        public string DocumentFinancialOwnerName { get; set; }
        public DateTime FinancialDate { get; set; }
        public DateTime DocumentTimeStamp { get; set; }
        public DateTime? AuthorityTimeStamp { get; set; }
        public DateTime? AuthorityLastCheck { get; set; }
        public Guid? SyncPoint { get; set; }
        public Guid? GlobalTrackId { get; set; }
        public string PaymentMethod { get; set; }
        public string NameDocumentXML { get; set; }

    }


    public class OperacionesFacturaListDto
    {
        public int nIdOperacionesFacturas { get; set; }
        public string nroOperacion { get; set; }
        public string cNroDocumento { get; set; }
        public decimal nMontoOperacion { get; set; }
        public decimal nMonto { get; set; }
        public DateTime dFechaEmision { get; set; }
        public DateTime dFechaVencimiento { get; set; }
        public DateTime dFechaPago { get; set; }
        public DateTime dFechaPagoNegociado { get; set; }
        public string cNombreDocumentoXML { get; set; }
        public string cRutaDocumentoXML { get; set; }
        public string cNombreDocumentoPDF { get; set; }
        public string cRutaDocumentoPDF { get; set; }
        public int nEstado { get; set; }
        public string NombreEstado { get; set; }
        public string cFormatoDocumento { get; set; }
        public int nIdOperaciones { get; set; }
        public string rucGirador { get; set; }
        public string cIdEstadoFacturaHistorico { get; set; }
        public string cFactura { get; set; }
        public DateTime? dFechaRegistro { get; set; }
        public int TotalRecords { get; set; }

    }

    public class EvaluacionOperacionesFacturaInsertDto
    {
        public int IdOperaciones { get; set; }
        public int IdOperacionesFactura { get; set; }
        public int IdCatalogoEstado { get; set; }
        public string UsuarioCreador { get; set; }
    }
    public class OperacionesFacturaSingleDto
    {
        public int nIdOperacionesFacturas { get; set; }
        public string cNroDocumento { get; set; }
        public decimal nMonto { get; set; }
        public DateTime dFechaEmision { get; set; }
        public DateTime dFechaVencimiento { get; set; }
        public DateTime dFechaPago { get; set; }
        public string cNombreDocumentoXML { get; set; }
        public string cRutaDocumentoXML { get; set; }
        public string cNombreDocumentoPDF { get; set; }
        public string cRutaDocumentoPDF { get; set; }
        public int nEstado { get; set; }
        public string NombreEstado { get; set; }
        public string cFormatoDocumento { get; set; }

    }




    public class OperacionesFacturaInsertDto
    {

        public int IdOperaciones { get; set; }
        public string NroDocumento { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string NombreDocumentoXML { get; set; }
        public string RutaDocumentoXML { get; set; }
        public string NombreDocumentoPDF { get; set; }
        public string RutaDocumentoPDF { get; set; }
        public string UsuarioCreador { get; set; }
        public DateTime FechaPagoNegociado { get; set; }
    }

    public class OperacionesFacturaDeleteDto
    {
        public int IdOperacionesFacturas { get; set; }
        public string UsuarioActualizacion { get; set; }
    }

    public class OperacionesFacturaEditDto
    {
        public int IdOperacionesFacturas { get; set; }
        public string UsuarioActualizacion { get; set; }
        public DateTime FechaPagoNegociado { get; set; }
    }

    public class OperacionesFacturaEditMontoDto
    {
        public int nIdOperaciones { get; set; }
        public int nIdOperacionesFacturas { get; set; }
        public string? cUsuarioActualizacion { get; set; }
        public decimal nMonto { get; set; }
    }
    public class OperacionesFacturaInsertCavaliDto
    {
        public string ConjuntoFacturasJson { get; set; }
        public string UsuarioCreador { get; set; }
        public string TramaEnvio4012 { get; set; }
        public string TramaRespuesta4012 { get; set; }
        public int IdOperaciones { get; set; }
        public int IdOperacionesFactura { get; set; }
        public string cParticipantCode { get; set; }
    }

    public class OperacionesFacturaRequestDataTableDto
    {
        public int Pageno { get; set; }
        public string FilterNroOperacion { get; set; }
        public int PageSize { get; set; }
        public string Sorting { get; set; }
        public string SortOrder { get; set; }
        public int nEstado { get; set; }
        public string FechaCreacion { get; set; }
    }


    public class OperacionesFacturaResponseDataTable
    {
        public int nIdOperacionesFacturas { get; set; }
        public string cNroDocumento { get; set; }

        public string Serie { get; set; }
        public string Numero { get; set; }
        public decimal nMonto { get; set; }
        public string Estado { get; set; }
        public int EstadoId { get; set; }
        public DateTime dFechaVencimiento { get; set; }
        public DateTime dFechaPago { get; set; }
        public string nNroOperacion { get; set; }
        public int totalRecords { get; set; }

        public int nEstado { get; set; }
        public string cProcessResult { get; set; }
        public DateTime dFechaPagoNegociado { get; set; }
    }

    public class DocumentosSolicitudperacionesInsertDto
    {

        public int nIdSolEvalOperaciones { get; set; }
        public int nTipoDocumento { get; set; }
        public string cNombreDocumento { get; set; }
        public string cRutaDocumento { get; set; }
        public int nEstado { get; set; }
        public string cUsuarioCreador { get; set; }
        public DateTime? dFechaCreacion { get; set; }
    }

    public class DocumentoSolicitudOperacionListDto
    {
        public int nIdDocumentoSolEvalOperacion { get; set; }
        public int IdSolEvalOperacion { get; set; }
        public int nTipoDocumento { get; set; }
        public string DesDocumento { get; set; }
        public string NombreDocumento { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string cRutaDocumento { get; set; }

    }
    public class DocumentoSolicitudOperacionListIdDto
    {
        public int nIdDocumentoSolEvalOperaciones { get; set; }
        public int IdSolEvalOperacion { get; set; }
        public string cRutaDocumento { get; set; }
    }

    public class OperacionesSolicitudDeleteDto
    {
        public int nIdDocumentoSolEvalOperaciones { get; set; }
        public string UsuarioActualizacion { get; set; }
    }

}

