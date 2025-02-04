using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.DTOs.MenuAcciones
{
   public class AccionesResponseDto
    {
        public int nIdRolMenuAccion { get; set; }
        public int IdMenu { get; set; }
        public int nIdAccion { get; set; }
        public string cNombreAccion { get; set; }
        public int nIdRol { get; set; }
        public int nExiste { get; set; }
        public int nActivo { get; set; }
    }
}
