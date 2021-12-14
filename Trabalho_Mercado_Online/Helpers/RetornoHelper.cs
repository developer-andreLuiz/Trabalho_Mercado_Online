using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_Mercado_Online.Helpers
{
    public class RetornoHelper
    {
        public String Mensagem { get; set; }
        public bool Evento { get; set; }
        public RetornoHelper()
        {
            Mensagem = string.Empty;
            Evento = true;
        }
    }
   

}
