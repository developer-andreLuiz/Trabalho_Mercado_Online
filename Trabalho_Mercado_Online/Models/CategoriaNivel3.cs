using System;
using System.Collections.Generic;

#nullable disable

namespace Trabalho_Mercado_Online.Models
{
    public partial class CategoriaNivel3
    {
        public CategoriaNivel3()
        {
            CategoriaNivel4s = new HashSet<CategoriaNivel4>();
            ProdutoCategoria = new HashSet<ProdutoCategorium>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Img { get; set; }
        public int Ordem { get; set; }
        public int CategoriaNivel1 { get; set; }
        public int CategoriaNivel2 { get; set; }

        public virtual CategoriaNivel2 CategoriaNivel2Navigation { get; set; }
        public virtual ICollection<CategoriaNivel4> CategoriaNivel4s { get; set; }
        public virtual ICollection<ProdutoCategorium> ProdutoCategoria { get; set; }
    }
}
