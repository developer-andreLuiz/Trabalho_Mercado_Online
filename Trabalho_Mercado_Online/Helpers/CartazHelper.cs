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
       
        public static Bitmap Cartaz(string Linha1, string Linha2, string Linha3, string valor)
        {
            try
            {
                //definições
                Point A3 = new Point(7016, 9920);
                Bitmap cartaz = new Bitmap(A3.X, A3.Y, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);

                List<int> ListFont1 = new List<int>();
                List<int> ListFont2 = new List<int>();
                List<int> ListFont3 = new List<int>();
                List<int> ListValor = new List<int>();
                #region ListFont1
                ListFont1.Add(1);
                ListFont1.Add(2400);
                ListFont1.Add(2400);
                ListFont1.Add(2400);
                ListFont1.Add(2400);
                ListFont1.Add(2100);
                ListFont1.Add(1800);
                ListFont1.Add(1700);
                ListFont1.Add(1400);
                ListFont1.Add(1300);
                ListFont1.Add(1150);
                ListFont1.Add(1050);
                ListFont1.Add(950);
                ListFont1.Add(900);
                ListFont1.Add(830);
                ListFont1.Add(790);
                ListFont1.Add(740);
                ListFont1.Add(700);
                ListFont1.Add(650);
                ListFont1.Add(610);
                ListFont1.Add(590);
                #endregion
                #region ListFont2
                ListFont2.Add(1);
                ListFont2.Add(800);
                ListFont2.Add(800);
                ListFont2.Add(800);
                ListFont2.Add(800);
                ListFont2.Add(800);
                ListFont2.Add(800);
                ListFont2.Add(800);
                ListFont2.Add(800);
                ListFont2.Add(800);
                ListFont2.Add(800);
                ListFont2.Add(800);
                ListFont2.Add(800);
                ListFont2.Add(800);
                ListFont2.Add(800);
                ListFont2.Add(700);
                ListFont2.Add(700);
                ListFont2.Add(500);
                ListFont2.Add(500);
                ListFont2.Add(500);
                ListFont2.Add(500);
                #endregion
                #region ListFont3
                ListFont3.Add(1);
                ListFont3.Add(700);
                ListFont3.Add(700);
                ListFont3.Add(700);
                ListFont3.Add(700);
                ListFont3.Add(700);
                ListFont3.Add(700);
                ListFont3.Add(700);
                ListFont3.Add(700);
                ListFont3.Add(700);
                ListFont3.Add(700);
                ListFont3.Add(700);
                ListFont3.Add(700);
                ListFont3.Add(700);
                ListFont3.Add(700);
                ListFont3.Add(700);
                ListFont3.Add(700);
                ListFont3.Add(500);
                ListFont3.Add(500);
                ListFont3.Add(500);
                ListFont3.Add(500);
                #endregion
                #region ListValor
                ListValor.Add(1);
                ListValor.Add(3500);
                ListValor.Add(3500);
                ListValor.Add(3500);
                ListValor.Add(3500);
                ListValor.Add(2800);
                #endregion



                Font fontLinha1 = new Font("Bahnschrift Condensed", ListFont1[Linha1.Length], FontStyle.Bold);
                Font fontLinha2 = new Font("Bahnschrift Condensed", ListFont2[Linha2.Length], FontStyle.Bold);
                Font fontLinha3 = new Font("Bahnschrift Condensed", ListFont3[Linha3.Length], FontStyle.Bold);
                Font fontValor = new Font("Bahnschrift Condensed", ListValor[valor.Length], FontStyle.Bold);

                Graphics desenho = Graphics.FromImage(cartaz);
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Near;
                if (background_cartaz == null)
                {
                    background_cartaz = new Bitmap(Properties.Resources.background_poster_7016x9920);
                }


                //ações
                desenho.Clear(Color.White);
                desenho.DrawImage(background_cartaz, 0, 0, A3.X, A3.Y);

                desenho.DrawString(Linha1, fontLinha1, new SolidBrush(Color.Black), 3508, 600, stringFormat);
                desenho.DrawString(Linha2, fontLinha2, new SolidBrush(Color.Black), 3508, 3100, stringFormat);
                desenho.DrawString(Linha3, fontLinha3, new SolidBrush(Color.Black), 3508, 4000, stringFormat);

                desenho.DrawString(valor, fontValor, new SolidBrush(Color.Black), 3508, 5500, stringFormat);




                return cartaz;
            }
            catch { return null; }
           
        }
    }
}
