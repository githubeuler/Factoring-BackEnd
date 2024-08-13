using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.DTOs.DocumentosAceptante
{
    public class DocumentosAceptanteInsertDto
    {
        public int IdTipoDocumento { get; set; }
        public string Ruta { get; set; }
        public int IdAceptante { get; set; }
        public string NombreDocumento { get; set; }
    }
}
