using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.DTOs.Cavali
{
    public class CavaliDto
    {
    }
    public class CavaliAuthResponseDto
    {
        public bool Error { get; set; }
        public string? Message { get; set; }
        public string? Valores { get; set; }
    }
    public class Body
    {
        public int? processId { get; set; }
        public string? processCode { get; set; }
        public string? message { get; set; }
    }
    public class Valores
    {
        public Valores()
        {
            body = new Body();
            statusCode = 0;
        }
        public int? statusCode { get; set; }
        public Body? body { get; set; }
    }
    public class ResponseCavaliInvoice4012
    {
        public ResponseCavaliInvoice4012()
        {
            Valores = new Valores();
        }

        public bool Error { get; set; }
        public string? Mensaje { get; set; }
        public Valores? Valores { get; set; }
    }
    public class Response4008
    {
        public Response4008()
        {
            Valores = new Valores();
        }

        public bool Error { get; set; }
        public string? Mensaje { get; set; }
        public Valores? Valores { get; set; }
    }
    public class Response4007
    {
        public Response4007()
        {
            Valores = new Valores();
        }

        public string? Errors { get; set; }
        public bool Succeeded { get; set; }
        public string? Message { get; set; }
        public Valores? Valores { get; set; }
    }
    public class SerieNumero
    {
        public string? Serie { get; set; }
        public int? Numero { get; set; }
    }
    public class InsertaOperacionesFacturasResCavaliDto
    {
        public string? cseries { get; set; }
        public int? nnumeration { get; set; }
        public int? nsunatResponse { get; set; }
        public string? nacqResponse { get; set; }
        public string? cacqResponseDate { get; set; }
        public string? cacvDate { get; set; }
        public string? ctransferAccountDate { get; set; }
        public string? cretireDate { get; set; }
        public string? credeemDate { get; set; }
        public int? ninvoiceState { get; set; }
        public string? cadditionalField2 { get; set; }
        public string? cstateProcess { get; set; }
        public string? cUsuarioCreador { get; set; }
    }
    public class InsertPrepareData4016
    {
        public int? ActionType { get; set; }
        public int? StateType { get; set; }
        public int? DateType { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public long? ProcessNumber { get; set; }
        public long? ProcessId { get; set; }
        public int? Estado { get; set; }
        public string? TramaEnvio4012 { get; set; }
        public string? TramaRespuesta4012 { get; set; }
    }
    public partial class Request4016
    {
        public Invoice4016? Invoice4016 { get; set; }
    }
    public class Invoice4016
    {
        public long? ActionType { get; set; }
        public long? StateType { get; set; }
        public long? DateType { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public long? IssuerRuc { get; set; }
        public long? AcquirerRuc { get; set; }
        public long? ParticipantCode { get; set; }
        public string? Series { get; set; }
        public long? Numeration { get; set; }
        public long? ProcessNumber { get; set; }
        public long? ProcessId { get; set; }
        public long? CreateUserType { get; set; }
        public long? CreateUserCode { get; set; }

    }
    public class Response4016
    {
        public Response4016()
        {
            Valores = new Valores();
        }

        public bool? Error { get; set; }
        public string? Mensaje { get; set; }
        public Valores? Valores { get; set; }
    }
}
