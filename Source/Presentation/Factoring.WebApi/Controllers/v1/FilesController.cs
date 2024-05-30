using Factoring.Application.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static Factoring.Application.DTOs.Files.FilesDto;

namespace Factoring.WebApi.Controllers.v1
{
    [Authorize]
    [ApiVersion("1.0")]
    public class FilesController : BaseApiController
    {
        private readonly IConfiguration _configuration;
        public FilesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost("files-masivo")]
        public async Task<IActionResult> SendFilesMasivo([FromForm] List<IFormFile> files)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(_configuration["UrlBaseApiFiles"].ToString());

                    //byte[] data;
                    //using (var br = new BinaryReader(model.Attachment.OpenReadStream()))
                    //    data = br.ReadBytes((int)model.Attachment.OpenReadStream().Length);

                    //ByteArrayContent bytes = new ByteArrayContent(data);


                    //MultipartFormDataContent multiContent = new MultipartFormDataContent();

                    //multiContent.Add(bytes, "Attachment", model.Attachment.FileName);
                    //multiContent.Add(new StringContent(model.Filename), "Filename");
                    //var result = await client.PostAsync("Upload/upload-single-file", multiContent);

                    //var json = await result.Content.ReadAsStringAsync();
                    return Ok("hola");

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }


        [HttpPost("send-test")]
        public IActionResult SendTest(IFormFile file)
        {

            using (var sr = new StreamReader(file.OpenReadStream()))
            {
                var data = sr.ReadLine();
            }
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> SendFiles([FromForm] FilesUploadDto model)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(_configuration["UrlBaseApiFiles"].ToString());
                    client.MaxResponseContentBufferSize = 9999999;
                    client.Timeout = TimeSpan.FromMinutes(Convert.ToInt32("15"));
                    byte[] data;
                    //byte[] data = new byte[1000000];
                    using (var br = new BinaryReader(model.Attachment.OpenReadStream()))
                        data = br.ReadBytes((int)model.Attachment.OpenReadStream().Length);

                    ByteArrayContent bytes = new ByteArrayContent(data);


                    MultipartFormDataContent multiContent = new MultipartFormDataContent();

                    multiContent.Add(bytes, "Attachment", model.Attachment.FileName);
                    multiContent.Add(new StringContent(model.Filename), "Filename");
                    multiContent.Add(new StringContent(model.NombreSeccion), "NombreSeccion");
                    var result = await client.PostAsync("Upload/upload-single-file", multiContent);

                    var json = await result.Content.ReadAsStringAsync();
                    return Ok(JsonConvert.DeserializeObject<Response<string>>(json));

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }


        [HttpGet("getbase64-file")]
        public async Task<IActionResult> GetFileBase64(string filename)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    string extension = filename.Split(".")[1];

                    filename = $"{filename.Split(".")[0]}.{extension.ToLower()}";

                    client.BaseAddress = new Uri(_configuration["UrlBaseApiFiles"].ToString());
                    var result = await client.PostAsync($"Upload/download-file?fileName={filename}", null);
                    byte[] fileBytes = await result.Content.ReadAsByteArrayAsync();
                    return Ok(Convert.ToBase64String(fileBytes));

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }


        [HttpPost("download-file")]
        public async Task<IActionResult> DownloadFiles(string filename)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    string extension = filename.Split(".")[1];

                    //filename = $"{filename.Split(".")[0]}.{extension.ToLower()}";

                    client.BaseAddress = new Uri(_configuration["UrlBaseApiFiles"].ToString());
                    client.MaxResponseContentBufferSize = 9999999;
                    var result = await client.PostAsync($"Upload/download-file?fileName={System.Net.WebUtility.UrlEncode(filename)}", null);
                    byte[] fileBytes = await result.Content.ReadAsByteArrayAsync();

                    string[] words = filename.Split(@"\");
                    for (int i = 1; i < words.Length; i++)
                    {
                        if (i == words.Length - 1)
                        {
                            filename = words[i].ToString();
                        }
                    }
                    var contentType = GetContentType(filename);
                    return File(fileBytes, contentType);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        [HttpPost("delete-file")]
        public async Task<IActionResult> DeleteFiles([FromForm] FilesDeleteDto model)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(_configuration["UrlBaseApiFiles"].ToString());
                    client.MaxResponseContentBufferSize = 9999999;
                    client.Timeout = TimeSpan.FromMinutes(Convert.ToInt32("15"));

                    MultipartFormDataContent multiContent = new MultipartFormDataContent();

                    multiContent.Add(new StringContent(model.FilePath), "FilePath");

                    var result = await client.PostAsync("Upload/delete-file", multiContent);

                    var json = await result.Content.ReadAsStringAsync();
                    return Ok(JsonConvert.DeserializeObject<Response<string>>(json));

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        private string GetContentType(string filename)
        {
            string extension = filename.Split(".")[1].ToLower();
            switch (extension)
            {
                case "pdf":
                    return "application/pdf";
                case "png":
                    return "image/png";

                case "xml":
                    return "text/xml";

                case "jpg":
                    return "image/jpg";

                case "docx":
                    return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

                default:
                    return "error";
            }
        }

    }
}
