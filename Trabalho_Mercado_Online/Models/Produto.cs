using System;
using System.Collections.Generic;

#nullable disable

namespace Trabalho_Mercado_Online.Models
{
    public partial class Produto
    {
        public Produto()
        {
            Carrinhos = new HashSet<Carrinho>();
            ProdutoCategoria = new HashSet<ProdutoCategorium>();
            ProdutoCodigoBarras = new HashSet<ProdutoCodigoBarra>();
            ProdutoLojas = new HashSet<ProdutoLoja>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Pronuncia { get; set; }
        public string Img { get; set; }
        public string CodigoLoja { get; set; }
        public decimal CustoUnitario { get; set; }
        public decimal ValorVenda { get; set; }
        public decimal ValorPromocao { get; set; }
        public string Gramatura { get; set; }
        public string Embalagem { get; set; }
        public string Peso { get; set; }
        public int IgualaProduto { get; set; }
        public int ItensCaixa { get; set; }
        public int Volume { get; set; }
        public bool Validade { get; set; }
        public string Informacao { get; set; }
        public bool Habilitado { get; set; }

        public virtual ICollection<Carrinho> Carrinhos { get; set; }
        public virtual ICollection<ProdutoCategorium> ProdutoCategoria { get; set; }
        public virtual ICollection<ProdutoCodigoBarra> ProdutoCodigoBarras { get; set; }
        public virtual ICollection<ProdutoLoja> ProdutoLojas { get; set; }
    }
}
