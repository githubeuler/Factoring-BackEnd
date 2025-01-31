﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.DTOs.MenuAcciones
{
    public class MenuAccionesResponseDto
    {
        public int nIdMenuDetalle { get; set; }
        public int nIdMenu { get; set; }
        public string cModulo { get; set; }
        public int nNivel { get; set; }
        public string cMenu { get; set; }
        public bool cActualizar { get; set; }
        public bool cConsultar { get; set; }
        public bool cEliminar { get; set; }
        public bool cInsertar { get; set; }

    }
}
