using System;
using System.Collections.Generic;
using System.Text;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Helpers
{
    class ListasBanco
    {
        public List<Produtos> Produtos { get; set; }
        public List<ProdutosCategoria> ProdutosCategoria { get; set; }
        public List<ProdutosCodigoBarra> ProdutosCodigoBarra { get; set; }
        public List<CategoriasNivel1> CategoriasNivel1 { get; set; }
        public List<CategoriasNivel2> CategoriasNivel2 { get; set; }
        public List<CategoriasNivel3> CategoriasNivel3 { get; set; }
    }
}
