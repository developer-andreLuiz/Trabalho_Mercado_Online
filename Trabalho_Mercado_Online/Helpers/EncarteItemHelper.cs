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
                if (value.Length>0)
                {
                    _nome = value.ToUpper();
                }
                else
                {
                    _nome = value;
                }
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
                if (value.Length > 0)
                {
                    _valor = StringHelper.CentralizarString(value, 6);
                }
                else
                {
                    _valor = value;
                }
                    
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
                else
                {
                    _img = value;
                }
                
            }
        }
    }
}
