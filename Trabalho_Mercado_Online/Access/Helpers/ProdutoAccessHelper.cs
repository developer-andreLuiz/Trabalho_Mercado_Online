using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_Mercado_Online.Access.Helpers
{
    class ProdutoAccessHelper
    {
       
        public string Descricao { get; set; }
        public string embalagem { get; set; }
        public string CustoUnitario { get; set; }
        public string ValorVenda { get; set; }
        public string ValorPromocao { get; set; }
        public int Codigo { get; set; }
        public string Numero { get; set; }
        public string grama { get; set; }
        public int iguala { get; set; }
        public int categoria { get; set; }
        public int subcategoria { get; set; }
        public string IgualaCx { get; set; }
        public string ChCaixa { get; set; }
        public string Quant_fardo { get; set; }
        public int quantidade_vendida { get; set; }
        public ProdutoAccessHelper()
        {
            
            Descricao = string.Empty;
            embalagem = string.Empty;
            CustoUnitario = "0";
            ValorVenda = "0";
            ValorPromocao = "0";
            Codigo = 0;
            Numero = string.Empty;
            grama = string.Empty;
            iguala = 0;
            categoria = 0;
            subcategoria = 0;
            IgualaCx = string.Empty;
            ChCaixa = string.Empty;
            Quant_fardo = string.Empty;
            quantidade_vendida = 0;
        }
    }
}
