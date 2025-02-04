using Factoring.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.DTOs.MenuAcciones
{
    public class ModuloDTO
    {
        public int? nIdMenu { get; set; }
        public int? nIdRol { get; set; }
        public string? cRol { get; set; }
        public string? filter_Acciones { get; set; }
    }
}