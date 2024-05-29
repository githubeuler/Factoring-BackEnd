using Microsoft.AspNetCore.Http;

namespace Factoring.Application.DTOs.Files
{
    public class FilesDto
    {
        public class FilesUploadDto
        {
            public string? Filename { get; set; }
            public IFormFile? Attachment { get; set; }
            public string? NombreSeccion { get; set; }
        }


        public class FilesDownloadDto
        {
            public string? Filename { get; set; }
        }

        public class FilesDeleteDto
        {
            public string? FilePath { get; set; }
        }
    }
}
