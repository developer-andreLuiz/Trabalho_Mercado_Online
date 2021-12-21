using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Trabalho_Mercado_Online.Helpers
{
    class EncarteHelper
    {
        public static Bitmap EncarteFrente(Bitmap ImgTop, String DtValidade,List<EncarteItemHelper>ListaProdutosLocal, SolidBrush solid)
        {
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
            desenho.FillRectangle(solid, new Rectangle(0,4765,3508,197));
            desenho.DrawString($"OFERTAS VÁLIDAS ATÉ O DIA {DtValidade} OU ENQUANTO DURAREM NOSSOS ESTOQUES", fontTxt, new SolidBrush(Color.White), 40, 4830);

            for (int i = 0; i < ListaProdutosLocal.Count; i++)
            {
                EncarteItemHelper encarteItemHelper = new EncarteItemHelper();
                encarteItemHelper.Nome = ListaProdutosLocal[i].Nome;
                encarteItemHelper.Valor = ListaProdutosLocal[i].Valor;
                encarteItemHelper.Img = ListaProdutosLocal[i].Img;
                if (encarteItemHelper.Nome.Length>0)
                {
                    desenho.DrawString(encarteItemHelper.Nome, fontProduto, new SolidBrush(Color.Black), Lt_Pos_Img[i].X, Lt_Pos_Img[i].Y - 80);
                    desenho.DrawImage(encarteItemHelper.Img, Lt_Pos_Img[i].X, Lt_Pos_Img[i].Y, encarteItemHelper.Img.Width, encarteItemHelper.Img.Height);
                    desenho.FillRectangle(solid, new Rectangle(Lt_Pos_Img[i].X + 390, Lt_Pos_Img[i].Y + 470, 270, 140));
                    desenho.DrawString(encarteItemHelper.Valor, fontPreco, new SolidBrush(Color.White), Lt_Pos_Img[i].X + 375, Lt_Pos_Img[i].Y + 500);
                }
            }
            
            
            
           
            Encarte.Save("C:\\Users\\Public\\Pictures\\F.jpg");
            return Encarte;
        }
        public static Bitmap EncarteVerso(Bitmap ImgBoT, String DtValidade, List<EncarteItemHelper> ListaProdutosLocal, SolidBrush solid)
        {
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
            Lt_Pos_Img.Add(new Point(240, 360));
            Lt_Pos_Img.Add(new Point(1030, 360));
            Lt_Pos_Img.Add(new Point(1820, 360));
            Lt_Pos_Img.Add(new Point(2610, 360));
            //Fileira de 5-8
            Lt_Pos_Img.Add(new Point(240, 1100));
            Lt_Pos_Img.Add(new Point(1030, 1100));
            Lt_Pos_Img.Add(new Point(1820, 1100));
            Lt_Pos_Img.Add(new Point(2610, 1100));
            //Fileira de 9-12
            Lt_Pos_Img.Add(new Point(240, 1840));
            Lt_Pos_Img.Add(new Point(1030, 1840));
            Lt_Pos_Img.Add(new Point(1820, 1840));
            Lt_Pos_Img.Add(new Point(2610, 1840));
            //Fileira de 13-16
            Lt_Pos_Img.Add(new Point(240, 2580));
            Lt_Pos_Img.Add(new Point(1030, 2580));
            Lt_Pos_Img.Add(new Point(1820, 2580));
            Lt_Pos_Img.Add(new Point(2610, 2580));
            //Fileira de 17-20
            Lt_Pos_Img.Add(new Point(240, 3320));
            Lt_Pos_Img.Add(new Point(1030, 3320));
            Lt_Pos_Img.Add(new Point(1820, 3320));
            Lt_Pos_Img.Add(new Point(2610, 3320));
            #endregion
            Graphics desenho = Graphics.FromImage(Encarte);
            desenho.Clear(Color.White);
            desenho.DrawImage(ImgBoT, 0, 3947, ImgBoT.Width, ImgBoT.Height);
            //Valor Mudar cor
            desenho.FillRectangle(solid, new Rectangle(0, 0, 3508, 197));
            desenho.DrawString($"OFERTAS VÁLIDAS ATÉ O DIA {DtValidade} OU ENQUANTO DURAREM NOSSOS ESTOQUES", fontTxt, new SolidBrush(Color.White), 40, 65);

            for (int i = 0; i < ListaProdutosLocal.Count; i++)
            {
                EncarteItemHelper encarteItemHelper = new EncarteItemHelper();
                encarteItemHelper.Nome = ListaProdutosLocal[i].Nome;
                encarteItemHelper.Valor = ListaProdutosLocal[i].Valor;
                encarteItemHelper.Img = ListaProdutosLocal[i].Img;
                if (encarteItemHelper.Nome.Length > 0)
                {
                    desenho.DrawString(encarteItemHelper.Nome, fontProduto, new SolidBrush(Color.Black), Lt_Pos_Img[i].X, Lt_Pos_Img[i].Y - 80);
                    desenho.DrawImage(encarteItemHelper.Img, Lt_Pos_Img[i].X, Lt_Pos_Img[i].Y, encarteItemHelper.Img.Width, encarteItemHelper.Img.Height);
                    //Valor Mudar cor
                    desenho.FillRectangle(solid, new Rectangle(Lt_Pos_Img[i].X + 390, Lt_Pos_Img[i].Y + 470, 270, 140));
                    desenho.DrawString(encarteItemHelper.Valor, fontPreco, new SolidBrush(Color.White), Lt_Pos_Img[i].X + 375, Lt_Pos_Img[i].Y + 500);
                }
            }

            Encarte.Save("C:\\Users\\Public\\Pictures\\V.jpg");
            return Encarte;
        }
    }
}
