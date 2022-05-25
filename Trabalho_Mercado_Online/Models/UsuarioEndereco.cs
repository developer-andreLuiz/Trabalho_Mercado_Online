using System;
using System.Collections.Generic;

#nullable disable

namespace Trabalho_Mercado_Online.Models
{
    public partial class UsuarioEndereco
    {
        public int Id { get; set; }
        public int Usuario { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }
        public int? Principal { get; set; }
        public string Complemento { get; set; }
        public string Referencia { get; set; }

        public virtual Usuario UsuarioNavigation { get; set; }
    }
}
