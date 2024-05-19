﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factoring.Application.DTOs.Catalogo
{
    public class CatalogoListDto
    {
        public int Tipo { get; set; }
        public int Codigo { get; set; }
        public string Valor { get; set; }
        public int CodigoParametro { get; set; }
    }

    public class CatalogoResponseListDto
    {
        public int nId { get; set; }
        public string cNombre { get; set; }
    }

    public class CatalogoResponseSingleForCodDto
    {
        public string nCodigo { get; set; }
        public string cNombre { get; set; }
        public string cValor { get; set; }
        public int nEstado { get; set; }
    }

}

