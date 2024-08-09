using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.DTOs.Aceptante
{
    public class AceptanteGetByIdDto
    {
        public int nIdAdquiriente { get; set; }
        public int nIdPais { get; set; }
        public string cFormatoUbigeo { get; set; }
        public string cNombrePais { get; set; }
        public string cRegUnicoEmpresa { get; set; }
        public string cRazonSocial { get; set; }
        public int nIdSector { get; set; }
        public string cNombreSector { get; set; }
        public int nIdGrupoEconomico { get; set; }
        public string cNombreGrupoEconomico { get; set; }
        public int nEstado { get; set; }
        public string NombreEstado { get; set; }
        public List<string> FormatoUbigeoPais { get; set; }
    }
}
