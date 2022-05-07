using System;
using System.Collections.Generic;

#nullable disable

namespace Trabalho_Mercado_Online.Models
{
    public partial class LojaPrateleira
    {
        public LojaPrateleira()
        {
            ProdutoLojas = new HashSet<ProdutoLoja>();
        }

        public int Id { get; set; }
        public int LojaEstante { get; set; }
        public int Livre { get; set; }
        public int Codigo { get; set; }

        public virtual LojaEstante LojaEstanteNavigation { get; set; }
        public virtual ICollection<ProdutoLoja> ProdutoLojas { get; set; }
    }
}
