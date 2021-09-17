using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_Mercado_Online.Access.Helpers
{
    class ProdutoCodigoBarra
    {
        public string Codigo { get; set; }
        public string Codigo_Barra { get; set; }

        public ProdutoCodigoBarra(string codigo, string codigo_barra)
        {
            Codigo = codigo;
            Codigo_Barra = codigo_barra;
        }
    }
}
