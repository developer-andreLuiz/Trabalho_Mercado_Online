using System;
using System.Collections.Generic;

#nullable disable

namespace Trabalho_Mercado_Online.Models
{
    public partial class Carrinho
    {
        public int Id { get; set; }
        public int Usuario { get; set; }
        public int Produto { get; set; }
        public int Quantidade { get; set; }

        public virtual Produto ProdutoNavigation { get; set; }
    }
}
