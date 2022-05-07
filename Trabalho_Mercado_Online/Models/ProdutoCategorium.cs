using System;
using System.Collections.Generic;

#nullable disable

namespace Trabalho_Mercado_Online.Models
{
    public partial class ProdutoCategorium
    {
        public int Id { get; set; }
        public int Produto { get; set; }
        public int CategoriaNivel1 { get; set; }
        public int? CategoriaNivel2 { get; set; }
        public int? CategoriaNivel3 { get; set; }
        public int? CategoriaNivel4 { get; set; }
        public int Ordem { get; set; }

        public virtual CategoriaNivel1 CategoriaNivel1Navigation { get; set; }
        public virtual CategoriaNivel2 CategoriaNivel2Navigation { get; set; }
        public virtual CategoriaNivel3 CategoriaNivel3Navigation { get; set; }
        public virtual CategoriaNivel4 CategoriaNivel4Navigation { get; set; }
        public virtual Produto ProdutoNavigation { get; set; }
    }
}
