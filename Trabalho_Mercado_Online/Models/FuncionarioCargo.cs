using System;
using System.Collections.Generic;

#nullable disable

namespace Trabalho_Mercado_Online.Models
{
    public partial class FuncionarioCargo
    {
        public FuncionarioCargo()
        {
            Funcionarios = new HashSet<Funcionario>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
