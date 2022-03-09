using System;
using System.Collections.Generic;

#nullable disable

namespace Trabalho_Mercado_Online.Models
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime? Nascimento { get; set; }
        public string Telefone { get; set; }
        public string AparelhoId { get; set; }
        public decimal Saldo { get; set; }
        public int Habilitado { get; set; }
    }
}
