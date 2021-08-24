using System;
using System.Collections.Generic;

#nullable disable

namespace Trabalho_Mercado_Online.Models
{
    public partial class TbCarrinho
    {
        public int Id { get; set; }
        public int CodigoCliente { get; set; }
        public int CodigoProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
