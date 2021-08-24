using System;
using System.Collections.Generic;

#nullable disable

namespace Trabalho_Mercado_Online.Models
{
    public partial class TbCategoriasNivel2
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Img { get; set; }
        public int Ordem { get; set; }
        public int CategoriaNivel1 { get; set; }
    }
}
