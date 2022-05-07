using System;
using System.Collections.Generic;

#nullable disable

namespace Trabalho_Mercado_Online.Models
{
    public partial class LojaEstante
    {
        public LojaEstante()
        {
            LojaPrateleiras = new HashSet<LojaPrateleira>();
        }

        public int Id { get; set; }
        public int ProdutoVariado { get; set; }

        public virtual ICollection<LojaPrateleira> LojaPrateleiras { get; set; }
    }
}
