using System;
using System.Collections.Generic;

#nullable disable

namespace Trabalho_Mercado_Online.Models
{
    public partial class EncarteItem
    {
        public int Id { get; set; }
        public int IdEncarte { get; set; }
        public string Img { get; set; }
        public string Produto { get; set; }
        public string Valor { get; set; }
    }
}
