using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Trabalho_Mercado_Online.Helpers
{
    class EncarteHelper
    {
        
        public static Bitmap EncarteFrente(Bitmap ImgTop, String DtValidade)
        {
            //nome produto ate 30 caracteres
            Point A3 = new Point(3508, 4961);
            Bitmap Encarte = new Bitmap(A3.X, A3.Y);
            List<Point> Lt_Pos_Img = new List<Point>();
            Font fontTxt = new Font("Bahnschrift", 65, FontStyle.Bold);
            Font fontProduto = new Font("Bahnschrift", 34, FontStyle.Bold);
            Font fontPreco = new Font("Bahnschrift", 72, FontStyle.Bold);
           
            #region Passagem de Valores Lt_Pos_Img
            //x(235) + 790
            //y(1180) + 740
            //Fileira de 1-4    
            Lt_Pos_Img.Add(new Point(240, 1180));
            Lt_Pos_Img.Add(new Point(1030, 1180));
            Lt_Pos_Img.Add(new Point(1820, 1180));
            Lt_Pos_Img.Add(new Point(2610, 1180));
            //Fileira de 5-8
            Lt_Pos_Img.Add(new Point(240, 1920));
            Lt_Pos_Img.Add(new Point(1030, 1920));
            Lt_Pos_Img.Add(new Point(1820, 1920));
            Lt_Pos_Img.Add(new Point(2610, 1920));
            //Fileira de 9-12
            Lt_Pos_Img.Add(new Point(240, 2660));
            Lt_Pos_Img.Add(new Point(1030, 2660));
            Lt_Pos_Img.Add(new Point(1820, 2660));
            Lt_Pos_Img.Add(new Point(2610, 2660));
            //Fileira de 13-16
            Lt_Pos_Img.Add(new Point(240, 3400));
            Lt_Pos_Img.Add(new Point(1030, 3400));
            Lt_Pos_Img.Add(new Point(1820, 3400));
            Lt_Pos_Img.Add(new Point(2610, 3400));
            //Fileira de 17-20
            Lt_Pos_Img.Add(new Point(240, 4140));
            Lt_Pos_Img.Add(new Point(1030, 4140));
            Lt_Pos_Img.Add(new Point(1820, 4140));
            Lt_Pos_Img.Add(new Point(2610, 4140));

            #endregion
           
            Graphics desenho = Graphics.FromImage(Encarte);
            desenho.Clear(Color.White);
            desenho.DrawImage(ImgTop, 0, 0, ImgTop.Width, ImgTop.Height);
            desenho.FillRectangle(new SolidBrush(Color.Red), new Rectangle(0,4765,3508,197));
            desenho.DrawString($"OFERTAS VÁLIDAS ATÉ O DIA {DtValidade} OU ENQUANTO DURAREM NOSSOS ESTOQUES", fontTxt, new SolidBrush(Color.White), 40, 4830);

            foreach (var item in Lt_Pos_Img)
            {
                //Nome do Produto para Digitar
                EncarteItemHelper encarteItemHelper = new EncarteItemHelper();
                encarteItemHelper.Nome= "Nome do Produto para Digitar";
                encarteItemHelper.Valor = "999,99";
                encarteItemHelper.Img = new Bitmap("C:\\Users\\Public\\Pictures\\1.jpg");

                desenho.DrawString(encarteItemHelper.Nome, fontProduto, new SolidBrush(Color.Black), item.X, item.Y-80);
                desenho.DrawImage(encarteItemHelper.Img, item.X, item.Y, encarteItemHelper.Img.Width, encarteItemHelper.Img.Height);
                desenho.FillRectangle(new SolidBrush(Color.FromArgb(255, 255, 0, 0)), new Rectangle(item.X+390, item.Y+470, 270, 140));
                desenho.DrawString(encarteItemHelper.Valor, fontPreco, new SolidBrush(Color.White), item.X + 375, item.Y + 500);
            }
            





            Encarte.Save("C:\\Users\\Public\\Pictures\\F.jpg");
            return Encarte;
        }

    }
}
