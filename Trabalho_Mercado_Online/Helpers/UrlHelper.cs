using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Trabalho_Mercado_Online.Helpers
{
    class UrlHelper
    {
        public string Url { get; set; }
        public bool Verificada { get; set; }
        public Bitmap Img { get; set; }
        public bool Exibida { get; set; }


        public UrlHelper(string url)
        {
            Url = url;
            Verificada = false;
            Img = null;
            Exibida = false;
        }
    }
}
