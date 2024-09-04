using Dapper;
using Factoring.Application.DTOs.Account.Response;
using Factoring.Application.DTOs.Cavali;
using Factoring.Application.DTOs.Cavali.Cavali4012;
using Factoring.Application.DTOs.Operaciones;
using Factoring.Application.Interfaces.Service;
using Factoring.Application.Wrappers;
using Factoring.Persistence.Data;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Persistence.Externo
{
    public class CavaliServiceAsync : ICavaliServiceAsync
    {

        private IConfiguration _configuration;
        private readonly IConnectionFactory _connectionFactory;
        public CavaliServiceAsync(IConfiguration configuration,
            IConnectionFactory connectionFactory)
        {
            _configuration = configuration;
            _connectionFactory = connectionFactory;
        }
        public async Task<Response<AuthenticationResponseDto>> AuthenticationApi()
        {
            try
            {
                var client = new HttpClient();
                client.Timeout = TimeSpan.FromMinutes(15);

                client.BaseAddress = new Uri(_configuration["UrlBaseCavali"].ToString());
                client.DefaultRequestHeaders
                      .Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var user = new
                {
                    Username = _configuration["UserApiCavaliExtern"].ToString(),
                    Password = _configuration["PassApiCavaliExtern"].ToString()
                };
                var us = JsonConvert.SerializeObject(user);
                var requestContent = new StringContent(us, Encoding.UTF8, _configuration["ContentTypeRequest"].ToString());
                var response = await client.PostAsync("login", requestContent);
                var json = await response.Content.ReadAsStringAsync();
                
                return JsonConvert.DeserializeObject<Response<AuthenticationResponseDto>>(json);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<ResultCavaliToken> AuthTokenCavali()
        {
            var resultTokenCavali = new ResponseTokenCavali4012();
            var resultGeneral = new ResultCavaliToken();

            try
            {
                string json = string.Empty;

                var client = new HttpClient();
                client.BaseAddress = new Uri(_configuration["ApiCavali:auth"].ToString());
                client.DefaultRequestHeaders
                      .Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var requestContent = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("client_id", _configuration["ApiCavali:client_id"].ToString()),
                new KeyValuePair<string, string>("client_secret", _configuration["ApiCavali:client_secret"].ToString()),
                new KeyValuePair<string, string>("grant_type",_configuration["ApiCavali:grant_type"].ToString()),
            });

                var response = await client.PostAsync(_configuration["ApiCavali:auth"].ToString(), requestContent);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    json = await response.Content.ReadAsStringAsync();
                    resultTokenCavali = JsonConvert.DeserializeObject<ResponseTokenCavali4012>(json);
                    resultGeneral.AuthResultToken = resultTokenCavali;
                    resultGeneral.Status = (int)response.StatusCode;
                    resultGeneral.Error = false;
                }
                else
                {
                    resultGeneral.Status = (int)response.StatusCode;
                    resultGeneral.Message = await response.Content.ReadAsStringAsync();
                    resultGeneral.Error = true;
                }
            }
            catch (Exception ex)
            {
                resultGeneral.Error = true;
                resultGeneral.Message = ex.Message;
            }
            return resultGeneral;
        }
        public async Task<ResultCavaliInvoice4012> SendNewInvoice4012(Request4012 invoice, string token)
        {

            var resultInvoice = new ResponseInvoiceToWholeProcess();
            var resultGeneral = new ResultCavaliInvoice4012();

            try
            {
                var myClient = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
                myClient.DefaultRequestHeaders.Accept.Clear();
                myClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                myClient.DefaultRequestHeaders.Add("x-api-key", _configuration["ApiCavali:apikey"].ToString());
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(invoice);
                json = json.Replace("invoices", "invoice");
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                string url = _configuration["ApiCavali:uri"].ToString();

                var result = await myClient.PostAsync($"{url}/invoice-to-whole-process", content).ConfigureAwait(false);
                string responseBody = await result.Content.ReadAsStringAsync();


                ResponseInvoiceToWholeProcess responseReverse = JsonConvert.DeserializeObject<ResponseInvoiceToWholeProcess>(responseBody);

                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    json = await result.Content.ReadAsStringAsync();
                    resultInvoice = JsonConvert.DeserializeObject<ResponseInvoiceToWholeProcess>(json);
                    resultGeneral.ResultResponseInvoice = resultInvoice;
                    resultGeneral.Status = (int)result.StatusCode;
                    resultGeneral.Error = false;
                }

            }
            catch (Exception ex)
            {

                resultGeneral.Error = true;
                resultGeneral.Message = ex.Message;
            }
            return resultGeneral;

        }
        public async Task<Response<ResponseCavaliInvoice4012>> SendInvoice4012(InvoiceRoot invoiceRoot, InvoiceRoot2 invoiceRoot2, string token)
        {
            var client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(_configuration["UrlBaseCavali"].ToString());

                client.DefaultRequestHeaders
                      .Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                string us = string.Empty;

                if (invoiceRoot == null)
                {
                    Request4012new2 request = new()
                    {
                        request4012 = invoiceRoot2
                    };
                     us = JsonConvert.SerializeObject(request);
                }
                else
                {
                    Request4012new request = new()
                    {
                        request4012 = invoiceRoot
                    };
                    us = JsonConvert.SerializeObject(request);
                }


                var requestContent = new StringContent(us, Encoding.UTF8, _configuration["ContentTypeRequest"].ToString());
                var response = await client.PostAsync("Cavali/invoice-to-whole-process", requestContent);
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response<ResponseCavaliInvoice4012>>(json);
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public async Task<Response<ResponseCavaliInvoice4012>> SendInvoice4012Holder(InvoiceRootHolder invoiceRoot, InvoiceRoot2 invoiceRoot2, string token)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(_configuration["UrlBaseCavali"].ToString());

            client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            string us = string.Empty;

            if (invoiceRoot == null)
            {
                Request4012new2 request = new()
                {
                    request4012 = invoiceRoot2
                };
                us = JsonConvert.SerializeObject(request);
            }
            else
            {
                Request4012Holder request = new()
                {
                    request4012 = invoiceRoot
                };
                us = JsonConvert.SerializeObject(request);
            }

//
            var requestContent = new StringContent(us, Encoding.UTF8, _configuration["ContentTypeRequest"].ToString());
            var response = await client.PostAsync("Cavali/invoice-to-whole-process", requestContent);
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<ResponseCavaliInvoice4012>>(json);
        }
        public async Task<Response<Response4008>> SendRemove4008(Request4008 removeCavali, string token)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(_configuration["UrlBaseCavali"].ToString());

            client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            string us = string.Empty;
            Request4008Cab requestDto = new()
            {
                request4008 = removeCavali
            };
            us = JsonConvert.SerializeObject(requestDto);

            var requestContent = new StringContent(us, Encoding.UTF8, _configuration["ContentTypeRequest"].ToString());
            var response = await client.PostAsync("Cavali/remove", requestContent);
            var json = await response.Content.ReadAsStringAsync();
            //ar json = await response.Content.ReadAsStringAsync();
            //return JsonConvert.DeserializeObject<Response<ResponseCavaliInvoice4012>>(json);
            return JsonConvert.DeserializeObject<Response<Response4008>>(json);
            //return response4008;
        }
        public async Task<Response4007> SendRedeem4007(Request4007 removeCavali, string token)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri(_configuration["UrlBaseCavali"].ToString());

            client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            string us = string.Empty;
            us = JsonConvert.SerializeObject(removeCavali);
            var requestContent = new StringContent(us, Encoding.UTF8, _configuration["ContentTypeRequest"].ToString());
            var response = await client.PostAsync("Cavali/redeem", requestContent);
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response4007>(json);
        }
        public async Task<bool> InsertOperacionFacturaResCavali(InsertaOperacionesFacturasResCavaliDto entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_Inserta_OperacionesFacturasResCavali";
                var parameters = new DynamicParameters();
                parameters.Add("@p_cseries", entity.cseries);
                parameters.Add("@p_nnumeration", entity.nnumeration);
                parameters.Add("@p_nsunatResponse", entity.nsunatResponse);
                parameters.Add("@p_nacqResponse", entity.nacqResponse);
                parameters.Add("@p_cacqResponseDate", entity.cacqResponseDate);
                parameters.Add("@p_cacvDate", entity.cacvDate);
                parameters.Add("@p_ctransferAccountDate", entity.ctransferAccountDate);
                parameters.Add("@p_cretireDate", entity.cretireDate);
                parameters.Add("@p_credeemDate", entity.credeemDate);
                parameters.Add("@p_ninvoiceState", entity.ninvoiceState);
                parameters.Add("@p_cadditionalField2", entity.cadditionalField2);
                parameters.Add("@p_cstateProcess", entity.cstateProcess);
                parameters.Add("@p_cUsuarioCreador", entity.cUsuarioCreador);
                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
        }
        public async Task<bool> InsertResponse4012ResCavali(InsertPrepareData4016 entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "pe_InsertPrepareData4016";
                var parameters = new DynamicParameters();
                parameters.Add("@ActionType", entity.ActionType);
                parameters.Add("@StateType", entity.StateType);
                parameters.Add("@DateType", entity.DateType);
                parameters.Add("@StartDate", entity.StartDate);
                parameters.Add("@EndDate", entity.EndDate);
                parameters.Add("@ProcessNumber", entity.ProcessNumber);
                parameters.Add("@ProcessId", entity.ProcessId);
                parameters.Add("@Estado", entity.Estado);
                parameters.Add("@TramaEnvio4012", entity.TramaEnvio4012);
                parameters.Add("@TramaRespuesta4012", entity.TramaRespuesta4012);

                await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
        }
        public async Task<Response4016> SendInvoice4016(Request4016 parametro, string token)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_configuration["UrlBaseCavali"].ToString());
            client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var param = JsonConvert.SerializeObject(parametro);
            var requestContent = new StringContent(param, Encoding.UTF8, _configuration["ContentTypeRequest"].ToString());
            var response = await client.PostAsync("Cavali/invoice", requestContent);
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response4016>(json);
        }
        public async Task<Response<AuthenticationResponse>> AuthenticationApiSGC()
        {
            try
            {
                var client = new HttpClient();
                client.Timeout = TimeSpan.FromMinutes(15);

                client.BaseAddress = new Uri(_configuration["UrlBaseoSGC"].ToString());
                client.DefaultRequestHeaders
                      .Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var user = new
                {
                    username = _configuration["UserApiSGCExtern"].ToString(),
                    password = _configuration["PassApiSGCExtern"].ToString(),
                    nIdSistema = _configuration["SistemaSGC"].ToString()
                };
                var us = JsonConvert.SerializeObject(user);
                var requestContent = new StringContent(us, Encoding.UTF8, _configuration["ContentTypeRequest"].ToString());
                var response = await client.PostAsync("v1/AuthenticationExtern", requestContent);
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Response<AuthenticationResponse>>(json);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
