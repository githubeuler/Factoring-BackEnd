using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.DTOs.MenuAcciones
{
    public class PerfilRequestDto
    {
        public int Pageno { get; set; }
        public int PageSize { get; set; }
        public string Sorting { get; set; }
        public string SortOrder { get; set; }
        public string cNombrePerfil { get; set; }

    }
}
