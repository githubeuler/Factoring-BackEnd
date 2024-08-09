using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.DTOs.Cavali.Cavali4012
{
    public partial class ResponseInvoiceToWholeProcess
    {
        [JsonProperty("statusCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? StatusCode { get; set; }

        [JsonProperty("body", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Body Body { get; set; }
    }
    public partial class Body
    {
        [JsonProperty("processId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? ProcessId { get; set; }

        [JsonProperty("processCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string ProcessCode { get; set; }

        [JsonProperty("message", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
    }
    public class ResultCavaliInvoice4012
    {
        public bool Error { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public ResponseInvoiceToWholeProcess ResultResponseInvoice { get; set; }
    }
    public partial class Request4012
    {
        public Request4012()
        {
            ProcessDetail = new ProcessDetail4012();
            InvoiceDetail = new InvoiceDetail4012();
        }

        [JsonProperty("processDetail", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public ProcessDetail4012 ProcessDetail { get; set; }

        [JsonProperty("invoiceDetail")]
        public InvoiceDetail4012 InvoiceDetail { get; set; }
    }
    public partial class Request4008
    {
        public List<Invoice4008> invoice { get; set; }
    }
    public partial class Invoice4008
    {
        public long providerRuc { get; set; }
        public string series { get; set; }
        public long numeration { get; set; }
        public string authorizationNumber { get; set; }
        public string invoiceType { get; set; }
        public string additionalFieldOne { get; set; }
        public string additionalFieldTwo { get; set; }
    }
    public partial class Request4007
    {
        public List<Invoice4007> invoice { get; set; }
    }
    public partial class Invoice4007
    {
        public long providerRuc { get; set; }
        public string series { get; set; }
        public long numeration { get; set; }
        public string authorizationNumber { get; set; }
        public string invoiceType { get; set; }
        public string additionalFieldOne { get; set; }
        public string additionalFieldTwo { get; set; }
        public PaymentDetail4007 paymentDetail { get; set; }
    }
    public partial class PaymentDetail4007
    {
        public List<Payment4007> payment { get; set; }
    }
    public partial class Payment4007
    {
        public long? number { get; set; }

        public string effectiveDatePayment { get; set; }

    }
    public partial class InvoiceDetail4012
    {
        public InvoiceDetail4012()
        {
            invoice4012 = new List<Invoice4012>();
        }

        [JsonProperty("invoice", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<Invoice4012> invoice4012 { get; set; }
    }
    public partial class Invoice4012
    {
        [JsonProperty("fileName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string FileName { get; set; }

        [JsonProperty("fileXml", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string FileXml { get; set; }

        [JsonProperty("holderCode", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? HolderCode { get; set; }

        [JsonProperty("participantDestination", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? ParticipantDestination { get; set; }

        [JsonProperty("expirationDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string ExpirationDate { get; set; }

        [JsonProperty("department", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Department { get; set; }

        [JsonProperty("province", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Province { get; set; }

        [JsonProperty("district", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string District { get; set; }

        [JsonProperty("addressSupplier", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string AddressSupplier { get; set; }

        [JsonProperty("acqDepartment", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string AcqDepartment { get; set; }

        [JsonProperty("acqProvince", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string AcqProvince { get; set; }

        [JsonProperty("acqDistrict", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string AcqDistrict { get; set; }

        [JsonProperty("addressAcquirer", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string AddressAcquirer { get; set; }

        [JsonProperty("typePayment", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? TypePayment { get; set; }

        [JsonProperty("numberQuota", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? NumberQuota { get; set; }

        [JsonProperty("deliverDateAcq", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string DeliverDateAcq { get; set; }

        [JsonProperty("acceptedDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string AcceptedDate { get; set; }

        [JsonProperty("paymentDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentDate { get; set; }

        [JsonProperty("netAmount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? NetAmount { get; set; }

        [JsonProperty("otherOne", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string OtherOne { get; set; }

        [JsonProperty("otherTwo", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string OtherTwo { get; set; }

        [JsonProperty("paymentDetail", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public PaymentDetail4012 PaymentDetail { get; set; }

        [JsonProperty("constancyEmission", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? ConstancyEmission { get; set; }

        [JsonProperty("additionalFieldOne", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string AdditionalFieldOne { get; set; }

        [JsonProperty("additionalFieldTwo", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string AdditionalFieldTwo { get; set; }
    }
    public partial class PaymentDetail4012
    {
        [JsonProperty("payment", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<Payment> Payment { get; set; }
    }
    public partial class Payment
    {
        [JsonProperty("number", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Number { get; set; }

        [JsonProperty("netAmount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? NetAmount { get; set; }

        [JsonProperty("paymentDate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentDate { get; set; }
    }
    public partial class ProcessDetail4012
    {
        [JsonProperty("processNumber", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long ProcessNumber { get; set; }

        [JsonProperty("flagRegisterProcess", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? FlagRegisterProcess { get; set; }

        [JsonProperty("flagAcvProcess", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? FlagAcvProcess { get; set; }

        [JsonProperty("flagTransferProcess", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? FlagTransferProcess { get; set; }

        [JsonProperty("invoiceCount", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? InvoiceCount { get; set; }
    }
    public class ResultCavaliToken
    {
        public bool Error { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public ResponseTokenCavali4012 AuthResultToken { get; set; }
    }
    public partial class ResponseTokenCavali4012
    {
        [JsonProperty("access_token", Required = Required.Always)]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in", Required = Required.Always)]
        public long ExpiresIn { get; set; }

        [JsonProperty("token_type", Required = Required.Always)]
        public string TokenType { get; set; }
    }
}
