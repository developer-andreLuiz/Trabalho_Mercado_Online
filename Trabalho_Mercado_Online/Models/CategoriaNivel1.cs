using System;
using System.Collections.Generic;

#nullable disable

namespace Trabalho_Mercado_Online.Models
{
    public partial class CategoriaNivel1
    {
        public CategoriaNivel1()
        {
            CategoriaNivel2s = new HashSet<CategoriaNivel2>();
            ProdutoCategoria = new HashSet<ProdutoCategorium>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Img { get; set; }
        public int Ordem { get; set; }

        public virtual ICollection<CategoriaNivel2> CategoriaNivel2s { get; set; }
        public virtual ICollection<ProdutoCategorium> ProdutoCategoria { get; set; }
    }
}
