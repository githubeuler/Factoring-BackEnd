using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.DTOs.Documentos
{
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
}
