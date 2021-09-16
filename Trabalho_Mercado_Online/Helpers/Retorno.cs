using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_Mercado_Online.Helpers
{
    public class Retorno
    {
        public String Mensagem { get; set; }
        public bool Evento { get; set; }
        public Retorno()
        {
            Mensagem = string.Empty;
            Evento = true;
        }
    }
   

}
