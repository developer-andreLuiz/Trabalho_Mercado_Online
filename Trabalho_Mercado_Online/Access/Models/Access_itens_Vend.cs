using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_Mercado_Online.Access.Models
{
    class Access_itens_Vend
    {
        public int Codigo { get; set; }
        public int Quant { get; set; }
        public Access_itens_Vend()
        {
            Codigo = 0;
            Quant = 0;
        }
        public Access_itens_Vend(int codigo, int quant)
        {
            Codigo = codigo;
            Quant = quant;
        }
    }
}
