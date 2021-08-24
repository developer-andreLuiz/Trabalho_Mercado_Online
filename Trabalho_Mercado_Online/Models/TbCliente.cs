using System;
using System.Collections.Generic;

#nullable disable

namespace Trabalho_Mercado_Online.Models
{
    public partial class TbCliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public decimal Saldo { get; set; }
        public bool? Habilitado { get; set; }
        public string CodigoEstado { get; set; }
        public string CodigoMunicipio { get; set; }
        public string CodigoBairro { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
    }
}
