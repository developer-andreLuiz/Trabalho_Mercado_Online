using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Trabalho_Mercado_Online.Helpers
{
    class UrlService
    {
        public string Url { get; set; }
        public bool Verificada { get; set; }
        public Bitmap Img { get; set; }
        public bool Exibida { get; set; }


        public UrlService(string url)
        {
            Url = url;
            Verificada = false;
            Img = null;
            Exibida = false;
        }
    }
}
