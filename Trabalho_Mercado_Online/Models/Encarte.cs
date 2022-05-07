﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Trabalho_Mercado_Online.Models
{
    public partial class Encarte
    {
        public Encarte()
        {
            EncarteItems = new HashSet<EncarteItem>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public DateTime Validade { get; set; }
        public int Tipo { get; set; }
        public int Frente { get; set; }

        public virtual ICollection<EncarteItem> EncarteItems { get; set; }
    }
}
