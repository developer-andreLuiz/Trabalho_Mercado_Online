using System;
using System.Collections.Generic;
using System.Text;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Helpers
{
    class ListasBancoHelper
    {
        public List<Produto> Produto { get; set; }
        public List<ProdutoCategorium> ProdutoCategoria { get; set; }
        public List<ProdutoCodigoBarra> ProdutoCodigoBarra { get; set; }
        public List<CategoriaNivel1> CategoriaNivel1 { get; set; }
        public List<CategoriaNivel2> CategoriaNivel2 { get; set; }
        public List<CategoriaNivel3> CategoriaNivel3 { get; set; }
    }
}
