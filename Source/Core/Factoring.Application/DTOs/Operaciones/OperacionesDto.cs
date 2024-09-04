namespace Factoring.Application.DTOs.Operaciones
{
    public class ProcessDetail
    {
        public string processNumber { get; set; }
        public int flagRegisterProcess { get; set; }
        public int flagAcvProcess { get; set; }
        public int flagTransferProcess { get; set; }
        public int invoiceCount { get; set; }
    }

    public class Payment
    {
        public int? number { get; set; }
        public double? netAmount { get; set; }
        public string? paymentDate { get; set; }
    }

    public class PaymentDetail
    {
        public PaymentDetail()
        {
            payment = new List<Payment>();
        }
        public List<Payment> payment { get; set; }
    }

    public class Invoice
    {
        public Invoice()
        {
            paymentDetail = new PaymentDetail();
        }
        public string fileName { get; set; }
        public string fileXml { get; set; }
        //public long holderCode { get; set; }
        public int participantDestination { get; set; }
        public string expirationDate { get; set; }
        public string department { get; set; }
        public string province { get; set; }
        public string district { get; set; }
        public string addressSupplier { get; set; }
        public string acqDepartment { get; set; }
        public string acqProvince { get; set; }
        public string acqDistrict { get; set; }
        public string addressAcquirer { get; set; }
        public int typePayment { get; set; }
        public long? NumberQuota { get; set; }
        public string deliverDateAcq { get; set; }
        public string? acceptedDate { get; set; }
        public string paymentDate { get; set; }
        public decimal netAmount { get; set; }
        public string? otherOne { get; set; }
        public string? otherTwo { get; set; }
        public PaymentDetail paymentDetail { get; set; }
        public int constancyEmission { get; set; }
        public string? additionalFieldOne { get; set; }
        public string? additionalFieldTwo { get; set; }
        public int holderCode { get; set; }
    }
    public class InvoiceUnHolder
    {
        public InvoiceUnHolder()
        {
            paymentDetail = new PaymentDetail();
        }
        public string fileName { get; set; }
        public string fileXml { get; set; }
        //public long holderCode { get; set; }
        public int participantDestination { get; set; }
        public string expirationDate { get; set; }
        public string department { get; set; }
        public string province { get; set; }
        public string district { get; set; }
        public string addressSupplier { get; set; }
        public string acqDepartment { get; set; }
        public string acqProvince { get; set; }
        public string acqDistrict { get; set; }
        public string addressAcquirer { get; set; }
        public int typePayment { get; set; }

        public string deliverDateAcq { get; set; }
        public string acceptedDate { get; set; }
        public string paymentDate { get; set; }
        public decimal netAmount { get; set; }
        public string otherOne { get; set; }
        public string otherTwo { get; set; }
        public PaymentDetail paymentDetail { get; set; }
        public int constancyEmission { get; set; }
        public string additionalFieldOne { get; set; }
        public string additionalFieldTwo { get; set; }
    }
    public class InvoiceDetail
    {
        public InvoiceDetail()
        {
            invoice = new List<Invoice>();
        }
        public List<Invoice> invoice { get; set; }

    }
    public class InvoiceDetailHolder
    {
        public InvoiceDetailHolder()
        {
            invoice = new List<InvoiceUnHolder>();
        }
        public List<InvoiceUnHolder> invoice { get; set; }
    }


    public class Request4012new
    {
       public InvoiceRoot request4012 { get; set; }
    }
    public class Request4012new2
    {
        public InvoiceRoot2 request4012 { get; set; }
    }
    public class Request4012Holder
    {
        public InvoiceRootHolder request4012 { get; set; }
    }
    public class InvoiceRoot
    {

        public InvoiceRoot()
        {
            processDetail = new ProcessDetail();
            invoiceDetail = new InvoiceDetail();
        }


        public ProcessDetail? processDetail { get; set; }
        public InvoiceDetail? invoiceDetail { get; set; }
    }
    public class InvoiceRootHolder
    {
        public InvoiceRootHolder()
        {
            processDetail = new ProcessDetail();
            invoiceDetail = new InvoiceDetailHolder();
        }

        public ProcessDetail processDetail { get; set; }
        public InvoiceDetailHolder invoiceDetail { get; set; }
    }


    public class OperacionesComentariosAllDto
    {
        public int nIdOperaciones { get; set; }
        public DateTime dFechaCreacion { get; set; }
        public int nIdEvaluacionOperaciones { get; set; }
        public int nIdCatalogoEstado { get; set; }
        public string NombreCatalogoEstado { get; set; }
        public string ComentarioEvaluacion { get; set; }

    }
    public class OperacionesUpdateDto
    {
        public int IdOperaciones { get; set; }
        public int IdGirador { get; set; }
        public int IdAdquiriente { get; set; }
        public int IdInversionista { get; set; }
        public int IdTipoMoneda { get; set; }
        public int IdGiradorDireccion { get; set; }
        public int IdAdquirienteDireccion { get; set; }
        public decimal TEM { get; set; }
        public decimal PorcentajeFinanciamiento { get; set; }
        public decimal PorcentajeRetencion { get; set; }
        public decimal MontoOperacion { get; set; }
        public decimal DescContrato { get; set; }
        public decimal DescFactura { get; set; }
        public decimal DescCobranza { get; set; }
        public string UsuarioActualizacion { get; set; }
        public decimal InteresMoratorio { get; set; }

        public int IdCategoria { get; set; }
        public string SustentoComercial { get; set; }
        public string MotivoTransaccion { get; set; }
        public int Plazo { get; set; }
        public int IdSolEvalOperacion { get; set; }

    }


    public class OperacionesReturnMassive
    {
        public int IdOperacion { get; set; }
    }
    public class OperacionesInsertMasiveDto
    {

        public string RucGirador { get; set; }
        public string RucAdquiriente { get; set; }
        //public int IdInversionista { get; set; }
        //public int IdTipoMoneda { get; set; }
        public string DOIInversionista { get; set; }
        public string Moneda { get; set; }

        public decimal TEM { get; set; }
        public decimal PorcentajeFinanciamiento { get; set; }
        public decimal PorcentajeRetencion { get; set; }

        public decimal MontoOperacion { get; set; }
        public decimal DescContrato { get; set; }
        public decimal DescFactura { get; set; }
        public decimal DescCobranza { get; set; }

    }

    public class OperacionesInsertDto
    {
        public int IdGirador { get; set; }
        public int IdAdquiriente { get; set; }
        public int IdInversionista { get; set; }
        public int IdTipoMoneda { get; set; }
        public int IdGiradorDireccion { get; set; }
        public int IdAdquirienteDireccion { get; set; }
        public decimal TEM { get; set; }
        public decimal PorcentajeFinanciamiento { get; set; }
        public decimal PorcentajeRetencion { get; set; }
        public decimal MontoOperacion { get; set; }
        public decimal DescContrato { get; set; }
        public decimal DescFactura { get; set; }
        public decimal DescCobranza { get; set; }
        public string UsuarioCreador { get; set; }
        public decimal InteresMoratorio { get; set; }

        //*************Ini-09-01-2023-RCARRILLO******//
        public int IdCategoria { get; set; }
        public string SustentoComercial { get; set; }
        public string MotivoTransaccion { get; set; }
        public int Plazo { get; set; }
        public int CantidadFactura { get; set; }
        public int IdSolEvalOperacion { get; set; }
        //*************Fin-09-01-2023-RCARRILLO******//

    }

    public class OperacionesGetByIdDto
    {
        public int nIdOperaciones { get; set; }
        public string nNroOperacion { get; set; }
        public int nEstado { get; set; }
        public string NombreEstado { get; set; }
        public int nIdGirador { get; set; }
        public string cFormatoDocumento { get; set; }
        public string cRazonSocialGirador { get; set; }
        public string cRegUnicoEmpresaGirador { get; set; }
        public decimal nPorcentajeRetencion { get; set; }

        public int nIdAdquiriente { get; set; }
        public string cRazonSocialAdquiriente { get; set; }
        public string cRegUnicoEmpresaAdquiriente { get; set; }
        public int nIdGiradorDireccion { get; set; }
        public string DireccionGirador { get; set; }

        public int nIdAdquirienteDireccion { get; set; }
        public string DireccionAdquiriente { get; set; }

        public decimal nTEM { get; set; }
        public decimal nPorcentajeFinanciamiento { get; set; }
        public decimal nMontoOperacion { get; set; }
        public decimal nDescContrato { get; set; }
        public decimal nDescFactura { get; set; }
        public decimal nDescCobranza { get; set; }
        public int nIdTipoMoneda { get; set; }
        public List<string> SerieDocumentoPais { get; set; }

        public string Moneda { get; set; }

        public decimal InteresMoratorio { get; set; }


        public int IdCategoria { get; set; }
        public string SustentoComercial { get; set; }
        public string MotivoTransaccion { get; set; }
        public int Plazo { get; set; }

        public int IdSolEvalOperacion { get; set; }

        public string cDesCategoria { get; set; }

        public int nIdModalidad { get; set; }
        public string cModalidad { get; set; }
        public int nIdFondeador { get; set; }
        public string cFondeador { get; set; }

        public string dFechaTransferenciaCavali { get; set; }
        public string dFechaDesembolso { get; set; }
        public string dFechaCobranza { get; set; }
    }
    public class OperacionesRequestDataTableDto
    {
        public int Pageno { get; set; }
        public string FilterNroOperacion { get; set; }
        public string FilterRazonGirador { get; set; }
        public string FilterRazonAdquiriente { get; set; }
        public string FilterFecCrea { get; set; }
        public string Estado { get; set; }
        public string Usuario { get; set; }
        public int PageSize { get; set; }
        public string Sorting { get; set; }
        public string SortOrder { get; set; }
    }


    public class OperacionesResponseDataTable
    {
        public int nIdOperaciones { get; set; }
        public string nNroOperacion { get; set; }
        public string cRazonSocialGirador { get; set; }
        public string cRazonSocialAdquiriente { get; set; }
        public DateTime dFechaCreacion { get; set; }
        public string nEstado { get; set; }
        public string NombreEstado { get; set; }
        public int nAprobadoRiesgo { get; set; }
        public int nEditar { get; set; }

        public int TotalRecords { get; set; }

    }

    public class ReportesGiradorOperacionesDTO
    {
        public int nNroOperacion { get; set; }
        public string? Girador { get; set; }
        public string? Aceptante { get; set; }
        public string? NroFactura { get; set; }
        public decimal? nMontoOperacion { get; set; }
        public string? Estado { get; set; }
        public DateTime? dFechaDesembolso { get; set; }
        public DateTime? dFechaCobranza { get; set; }
        public DateTime? dFechaVencimiento { get; set; }
        public DateTime? dFechaCreacionOperacion { get; set; }
        public string? cMoneda { get; set; }
        public decimal? ImporteNetoFactura { get; set; }
        public string? nPorcentajeFinanciamiento { get; set; }
        public string? nTEM { get; set; }
        public string? ComisionCobranza { get; set; }
        public int? nNroDocumento { get; set; }
        public int? nDiasAdelanto { get; set; }
        public decimal? nImporteaFinanciar { get; set; }
        public string? nTasaAnual { get; set; }
        public string? Interes { get; set; }
        public decimal? CostoComisionCobranza { get; set; }
        public decimal? CostoRegistroFactura { get; set; }
        public decimal? CostoElaboracionContrato { get; set; }
        public decimal? nIgv { get; set; }
        public decimal? MontoaDesembolsarGirador { get; set; }
        public DateTime? dFechaAceptante { get; set; }
        public int TotalRecords { get; set; }
        public string? interesMoratorio { get; set; }
        public decimal? devolucionTotalGirador { get; set; }
        public decimal? planCobertura { get; set; }
        public decimal? retencion { get; set; }
        public decimal? devolucionEstimadaGirador { get; set; }
        public string? interesCompuestoGirador { get; set; }
        public decimal? desenbolsoProtectum { get; set; }
        public decimal? desenbolsoPalante { get; set; }
        public string? Adquirente { get; set; }
        public decimal? nComisionEstructuracionTotal { get; set; }
        public DateTime? dFechaPagoNegociado { get; set; }


        public string? EstadoFactura { get; set; }
        public string? EstadoOperacion { get; set; }
        public string? UsuarioCreador { get; set; }
        public string? Comentario { get; set; }

    }

    public class OperacionesDeleteDto
    {
        public int IdOperaciones { get; set; }
        public string UsuarioActualizacion { get; set; }
    }

    public class OperacionesUpdateEstadoDto
    {
        public int IdOperaciones { get; set; }
        public int Estado { get; set; }
        public string UsuarioActualizacion { get; set; }
    }

    public class OperacionesGetByidReporteCavaliDto
    {
        public string tipo_Comprobante { get; set; }
        public string ruc_Proveedor { get; set; }
        public string serie { get; set; }
        public string numeracion { get; set; }
        public string fecha_Vencimiento { get; set; }
        public string departamento_Proveedor { get; set; }
        public string provincia_Proveedor { get; set; }
        public string distrito_Proveedor { get; set; }
        public string domicilio_Proveedor { get; set; }
        public string departamento_Adq { get; set; }
        public string provincia_Adq { get; set; }
        public string distrito_Adq { get; set; }
        public string domicilio_Adquiriente { get; set; }
        public string tipo_Pago { get; set; }
        public string nro_Cuota { get; set; }
        public string fecha_Cominuacion_Adq { get; set; }
        public string fecha_Aceptacion { get; set; }
        public string fecha_Pago { get; set; }
        public string importe_Neto_Pendiente_Pago { get; set; }
        public string clausulas_Especiales { get; set; }
        public string observaciones { get; set; }
        public string monto_Neto_Cuota_1 { get; set; }
        public string fecha_Pago_Cuota_1 { get; set; }
        public string monto_Neto_Cuota_2 { get; set; }
        public string fecha_Pago_Cuota_2 { get; set; }
        public string monto_Neto_Cuota_3 { get; set; }
        public string fecha_Pago_Cuota_3 { get; set; }
        public string monto_Neto_Cuota_4 { get; set; }
        public string fecha_Pago_Cuota_4 { get; set; }
        public string monto_Neto_Cuota_5 { get; set; }
        public string fecha_Pago_Cuota_5 { get; set; }
        public string monto_Neto_Cuota_6 { get; set; }
        public string fecha_Pago_Cuota_6 { get; set; }
        public string monto_Neto_Cuota_7 { get; set; }
        public string fecha_Pago_Cuota_7 { get; set; }
        public string monto_Neto_Cuota_8 { get; set; }
        public string fecha_Pago_Cuota_8 { get; set; }
        public string monto_Neto_Cuota_9 { get; set; }
        public string fecha_Pago_Cuota_9 { get; set; }
        public string monto_Neto_Cuota_10 { get; set; }
        public string fecha_Pago_Cuota_10 { get; set; }
        public string monto_Neto_Cuota_11 { get; set; }
        public string fecha_Pago_Cuota_11 { get; set; }
        public string monto_Neto_Cuota_12 { get; set; }
        public string fecha_Pago_Cuota_12 { get; set; }
        public string monto_Neto_Cuota_13 { get; set; }
        public string fecha_Pago_Cuota_13 { get; set; }
        public string monto_Neto_Cuota_14 { get; set; }
        public string fecha_Pago_Cuota_14 { get; set; }
        public string monto_Neto_Cuota_15 { get; set; }
        public string fecha_Pago_Cuota_15 { get; set; }
        public string monto_Neto_Cuota_16 { get; set; }
        public string fecha_Pago_Cuota_16 { get; set; }
        public string monto_Neto_Cuota_17 { get; set; }
        public string fecha_Pago_Cuota_17 { get; set; }
        public string monto_Neto_Cuota_18 { get; set; }
        public string fecha_Pago_Cuota_18 { get; set; }
        public string monto_Neto_Cuota_19 { get; set; }
        public string fecha_Pago_Cuota_19 { get; set; }
        public string monto_Neto_Cuota_20 { get; set; }
        public string fecha_Pago_Cuota_20 { get; set; }
        public string monto_Neto_Cuota_21 { get; set; }
        public string fecha_Pago_Cuota_21 { get; set; }
        public string monto_Neto_Cuota_22 { get; set; }
        public string fecha_Pago_Cuota_22 { get; set; }
        public string monto_Neto_Cuota_23 { get; set; }
        public string fecha_Pago_Cuota_23 { get; set; }
        public string monto_Neto_Cuota_24 { get; set; }
        public string fecha_Pago_Cuota_24 { get; set; }


    }

    #region Enviar con Palante(829) 

    public class ProcessDetail2
    {
        public string processNumber { get; set; }
        public int flagRegisterProcess { get; set; }
        public int flagAcvProcess { get; set; }
        public int flagTransferProcess { get; set; }
        public int invoiceCount { get; set; }
    }

    public class Payment2
    {
        public int number { get; set; }
        public double netAmount { get; set; }
        public string paymentDate { get; set; }
    }

    public class PaymentDetail2
    {
        public PaymentDetail2()
        {
            payment = new List<Payment2>();
        }
        public List<Payment2> payment { get; set; }
    }

    public class Invoice2
    {
        public Invoice2()
        {
            paymentDetail = new PaymentDetail2();
        }
        public string fileName { get; set; }
        public string fileXml { get; set; }
        public string expirationDate { get; set; }
        public string department { get; set; }
        public string province { get; set; }
        public string district { get; set; }
        public string addressSupplier { get; set; }
        public string acqDepartment { get; set; }
        public string acqProvince { get; set; }
        public string acqDistrict { get; set; }
        public string addressAcquirer { get; set; }
        public int typePayment { get; set; }
        public int holderCode { get; set; }
        public int participantDestination { get; set; }

        public string deliverDateAcq { get; set; }
        public string acceptedDate { get; set; }
        public string paymentDate { get; set; }
        public decimal netAmount { get; set; }
        public string otherOne { get; set; }
        public string otherTwo { get; set; }
        public PaymentDetail2 paymentDetail { get; set; }
        public int constancyEmission { get; set; }
        public string additionalFieldOne { get; set; }
        public string additionalFieldTwo { get; set; }
    }

    public class InvoiceDetail2
    {
        public InvoiceDetail2()
        {
            invoice = new List<Invoice2>();
        }
        public List<Invoice2> invoice { get; set; }
    }

    public class InvoiceRoot2
    {

        public InvoiceRoot2()
        {
            processDetail = new ProcessDetail2();
            invoiceDetail = new InvoiceDetail2();
        }


        public ProcessDetail2 processDetail { get; set; }
        public InvoiceDetail2 invoiceDetail { get; set; }
    }



    #endregion

    public class SolicitudEvaluacionesOperacionesInsertDto
    {
        public int IdGirador { get; set; }
        public int IdAdquiriente { get; set; }
        public int IdCategoria { get; set; }
        public int IdGiradorDireccion { get; set; }
        public int IdAdquirienteDireccion { get; set; }
        public string MotivoTransaccion { get; set; }
        public string SustentoComercial { get; set; }
        public string UsuarioCreador { get; set; }

    }
}
