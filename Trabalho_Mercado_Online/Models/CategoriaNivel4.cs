using System;
using System.Collections.Generic;

#nullable disable

namespace Trabalho_Mercado_Online.Models
{
    public partial class CategoriaNivel4
    {
        public CategoriaNivel4()
        {
            ProdutoCategoria = new HashSet<ProdutoCategorium>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Img { get; set; }
        public int Ordem { get; set; }
        public int CategoriaNivel1 { get; set; }
        public int CategoriaNivel2 { get; set; }
        public int CategoriaNivel3 { get; set; }

        public virtual CategoriaNivel3 CategoriaNivel3Navigation { get; set; }
        public virtual ICollection<ProdutoCategorium> ProdutoCategoria { get; set; }
    }
}
