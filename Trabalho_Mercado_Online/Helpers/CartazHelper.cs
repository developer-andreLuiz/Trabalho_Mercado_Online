using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Mercado_Online.Helpers
{
    class CartazHelper
    {
        static Bitmap background_cartaz;

       
        public static Bitmap Cartaz(string Linha1, string Linha2, string Linha3, string valor, List<Point>ListPosTxt, List<int>ListFontSize)
        {
            try
            {
                //Definições
                Point A3 = new Point(7016, 9920);
                Bitmap cartaz = new Bitmap(A3.X, A3.Y, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);

               

                Font fontNome = new Font("Bahnschrift Condensed", ListFontSize[0], FontStyle.Bold);
                Font fontDescricao = new Font("Bahnschrift Condensed", ListFontSize[1], FontStyle.Bold);
                Font fontComplemento = new Font("Bahnschrift Condensed", ListFontSize[2], FontStyle.Bold);
                Font fontValor = new Font("Bahnschrift Condensed",  ListFontSize[3], FontStyle.Bold);

                Graphics desenho = Graphics.FromImage(cartaz);

                //StringFormat stringFormat = new StringFormat();
                //stringFormat.Alignment = StringAlignment.Center;
                //stringFormat.LineAlignment = StringAlignment.Near;
                //if (background_cartaz == null)
                //{
                //    background_cartaz = new Bitmap(Properties.Resources.background_poster_7016x9920);
                //}


                //Ações
                desenho.Clear(Color.White);
                //desenho.DrawImage(background_cartaz, 0, 0, A3.X, A3.Y);

                desenho.DrawString(Linha1, fontNome       , new SolidBrush(Color.Black), ListPosTxt[0].X, ListPosTxt[0].Y);
                desenho.DrawString(Linha2, fontDescricao  , new SolidBrush(Color.Black), ListPosTxt[1].X, ListPosTxt[1].Y);
                desenho.DrawString(Linha3, fontComplemento, new SolidBrush(Color.Black), ListPosTxt[2].X, ListPosTxt[2].Y);
                desenho.DrawString(valor , fontValor      , new SolidBrush(Color.Black), ListPosTxt[3].X, ListPosTxt[3].Y);




                return cartaz;
            }
            catch { return null; }
           
        }
        
    }
}
