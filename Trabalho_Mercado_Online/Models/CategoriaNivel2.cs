using System;
using System.Collections.Generic;

#nullable disable

namespace Trabalho_Mercado_Online.Models
{
    public partial class CategoriaNivel2
    {
        public CategoriaNivel2()
        {
            CategoriaNivel3s = new HashSet<CategoriaNivel3>();
            ProdutoCategoria = new HashSet<ProdutoCategorium>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Img { get; set; }
        public int Ordem { get; set; }
        public int CategoriaNivel1 { get; set; }

        public virtual CategoriaNivel1 CategoriaNivel1Navigation { get; set; }
        public virtual ICollection<CategoriaNivel3> CategoriaNivel3s { get; set; }
        public virtual ICollection<ProdutoCategorium> ProdutoCategoria { get; set; }
    }
}
