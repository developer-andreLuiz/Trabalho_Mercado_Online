using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_Mercado_Online.Access.Models
{
    class Access_Produtos_Model
    {
        public string Referencia { get; set; }
        public string Descricao { get; set; }
        public string embalagem { get; set; }
        public string CustoUnitario { get; set; }
        public string ValorVenda { get; set; }
        public string ValorPromocao { get; set; }
        public int Codigo { get; set; }
        public string Numero { get; set; }
        public string grama { get; set; }
        public string iguala { get; set; }
        public string categoria { get; set; }
        public string subcategoria { get; set; }
        public string IgualaCx { get; set; }
        public string ChCaixa { get; set; }
        public string Quant_fardo { get; set; }
        public Access_Produtos_Model()
        {
            Referencia = string.Empty;
            Descricao = string.Empty;
            embalagem = string.Empty;
            CustoUnitario = "0";
            ValorVenda = "0";
            ValorPromocao = "0";
            Codigo = 0;
            Numero = string.Empty;
            grama = string.Empty;
            iguala = string.Empty;
            categoria = string.Empty;
            subcategoria = string.Empty;
            IgualaCx = string.Empty;
            ChCaixa = string.Empty;
            Quant_fardo = string.Empty;
        }
    }
}
