using System;
using System.Collections.Generic;

#nullable disable

namespace Trabalho_Mercado_Online.Models
{
    public partial class ProdutoCategorium
    {
        public int Id { get; set; }
        public int CodigoProduto { get; set; }
        public int CategoriaNivel1 { get; set; }
        public int CategoriaNivel2 { get; set; }
        public int CategoriaNivel3 { get; set; }
        public int CategoriaNivel4 { get; set; }
        public int Ordem { get; set; }
    }
}
