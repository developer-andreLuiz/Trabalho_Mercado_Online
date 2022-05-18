using System;
using System.Collections.Generic;

#nullable disable

namespace Trabalho_Mercado_Online.Models
{
    public partial class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int Nivel { get; set; }
        public int? Cargo { get; set; }
        public decimal? Salario { get; set; }
        public decimal? SalarioBonus { get; set; }
        public decimal? ValeCompra { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Informacao { get; set; }
        public int Habilitado { get; set; }

        public virtual FuncionarioCargo CargoNavigation { get; set; }
    }
}
