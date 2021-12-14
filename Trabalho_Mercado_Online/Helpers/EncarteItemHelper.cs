using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Trabalho_Mercado_Online.Helpers
{
    class EncarteItemHelper
    {
        private string _nome;
        private string _valor;
        private Bitmap _img;

        public string Nome 
        {
            get 
            {
                return _nome;
            }
            set 
            {
                _nome = StringHelper.CentralizarString(value,28);
            } 
        }
        public string Valor 
        {
            get
            {
                return _valor;
            }
            set
            {
                _valor = StringHelper.CentralizarString(value, 6);
            }
        }
        public Bitmap Img
        {
            get
            {
                return _img;
            }
            set
            {
                if (value!=null)
                {
                    _img = (Bitmap)ImagemHelper.ResizeImage(value, 660, 610);
                }
                
            }
        }
    }
}
