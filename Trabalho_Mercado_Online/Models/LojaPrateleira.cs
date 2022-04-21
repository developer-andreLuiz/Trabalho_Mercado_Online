using System;
using System.Collections.Generic;

#nullable disable

namespace Trabalho_Mercado_Online.Models
{
    public partial class LojaPrateleira
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public int EstanteLoja { get; set; }
        public int Livre { get; set; }
    }
}
