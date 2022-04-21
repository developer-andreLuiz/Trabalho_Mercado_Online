using System;
using System.Collections.Generic;

#nullable disable

namespace Trabalho_Mercado_Online.Models
{
    public partial class ProdutoLoja
    {
        public int Id { get; set; }
        public int Produto { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Validade { get; set; }
        public int Prateleira { get; set; }
        public int Quantidade { get; set; }
        public int Funcionario { get; set; }
        public int? ConferenciaValidade { get; set; }
        public int? ConferenciaBalanco { get; set; }
    }
}
