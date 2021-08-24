using System;
using System.Collections.Generic;

#nullable disable

namespace Trabalho_Mercado_Online.Models
{
    public partial class Municipio
    {
        public int Id { get; set; }
        public string CodigoEstado { get; set; }
        public string CodigoMunicipio { get; set; }
        public string NomeMunicipio { get; set; }
    }
}
