using Factoring.Application.DTOs.Account.Response;
using Factoring.Application.DTOs.Cavali;
using Factoring.Application.DTOs.Cavali.Cavali4012;
using Factoring.Application.DTOs.Operaciones;
using Factoring.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.Interfaces.Service
{
    public interface ICavaliServiceAsync
    {
        Task<Response<AuthenticationResponseDto>> AuthenticationApi();
        Task<Response<ResponseCavaliInvoice4012>> SendInvoice4012(InvoiceRoot invoiceRoot, InvoiceRoot2 invoiceRoot2, string token);
        Task<Response<ResponseCavaliInvoice4012>> SendInvoice4012Holder(InvoiceRootHolder invoiceRoot, InvoiceRoot2 invoiceRoot2, string token);
        Task<bool> InsertOperacionFacturaResCavali(InsertaOperacionesFacturasResCavaliDto entity);
        Task<bool> InsertResponse4012ResCavali(InsertPrepareData4016 entity);
        Task<Response4016> SendInvoice4016(Request4016 parametro, string token);
        Task<ResultCavaliToken> AuthTokenCavali();
        Task<ResultCavaliInvoice4012> SendNewInvoice4012(Request4012 invoice, string token);
        //Task<Response4008> SendRemove4008(Request4008 removeCavali, string token);
        Task<Response<Response4008>> SendRemove4008(Request4008 removeCavali, string token);
        Task<Response4007> SendRedeem4007(Request4007 removeCavali, string token);
        Task<Response<AuthenticationResponse>> AuthenticationApiSGC();
    }
}
