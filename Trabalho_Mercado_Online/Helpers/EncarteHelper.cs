using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Trabalho_Mercado_Online.Helpers
{
    class EncarteHelper
    {
        public static Bitmap EncarteFrente(Bitmap ImgTop, String DtInicio, String DtValidade,List<EncarteItemHelper>ListaProdutosLocal, SolidBrush solid)
        {
            Point A3 = new Point(3508, 4961);
            Bitmap Encarte = new Bitmap(A3.X, A3.Y);
            List<Point> Lt_Pos_Img = new List<Point>();
            Font fontTxt = new Font("Bahnschrift", 55, FontStyle.Bold);
            Font fontProduto = new Font("Bahnschrift", 34, FontStyle.Bold);
            Font fontPreco = new Font("Bahnschrift", 72, FontStyle.Bold);
            #region Passagem de Valores Lt_Pos_Img
            //x(235) + 790
            //y(1180) + 740
            int ajusteX = 0;
            int ajusteY = -740;

            //Fileira de 1-4
            Lt_Pos_Img.Add(new Point(240 + ajusteX, 1180 + ajusteY));
            Lt_Pos_Img.Add(new Point(1030 + ajusteX, 1180 + ajusteY));
            Lt_Pos_Img.Add(new Point(1820 + ajusteX, 1180 + ajusteY));
            Lt_Pos_Img.Add(new Point(2610 + ajusteX, 1180 + ajusteY));
            //Fileira de 5-8
            Lt_Pos_Img.Add(new Point(240 + ajusteX, 1920 + ajusteY));
            Lt_Pos_Img.Add(new Point(1030 + ajusteX, 1920 + ajusteY));
            Lt_Pos_Img.Add(new Point(1820 + ajusteX, 1920 + ajusteY));
            Lt_Pos_Img.Add(new Point(2610 + ajusteX, 1920 + ajusteY));
            //Fileira de 9-12
            Lt_Pos_Img.Add(new Point(240 + ajusteX, 2660 + ajusteY));
            Lt_Pos_Img.Add(new Point(1030 + ajusteX, 2660 + ajusteY));
            Lt_Pos_Img.Add(new Point(1820 + ajusteX, 2660 + ajusteY));
            Lt_Pos_Img.Add(new Point(2610 + ajusteX, 2660 + ajusteY));
            //Fileira de 13-16
            Lt_Pos_Img.Add(new Point(240 + ajusteX, 3400 + ajusteY));
            Lt_Pos_Img.Add(new Point(1030 + ajusteX, 3400 + ajusteY));
            Lt_Pos_Img.Add(new Point(1820 + ajusteX, 3400 + ajusteY));
            Lt_Pos_Img.Add(new Point(2610 + ajusteX, 3400 + ajusteY));
            //Fileira de 17-20
            Lt_Pos_Img.Add(new Point(240 + ajusteX, 4140 + ajusteY));
            Lt_Pos_Img.Add(new Point(1030 + ajusteX, 4140 + ajusteY));
            Lt_Pos_Img.Add(new Point(1820 + ajusteX, 4140 + ajusteY));
            Lt_Pos_Img.Add(new Point(2610 + ajusteX, 4140 + ajusteY));
            //Fileira de 21-24
            Lt_Pos_Img.Add(new Point(240 + ajusteX, 4880 + ajusteY));
            Lt_Pos_Img.Add(new Point(1030 + ajusteX, 4880 + ajusteY));
            Lt_Pos_Img.Add(new Point(1820 + ajusteX, 4880 + ajusteY));
            Lt_Pos_Img.Add(new Point(2610 + ajusteX, 4880 + ajusteY));


            #endregion
            Graphics desenho = Graphics.FromImage(Encarte);
            desenho.Clear(Color.White);
            desenho.DrawImage(ImgTop, 0, 0, ImgTop.Width, ImgTop.Height);
            desenho.FillRectangle(solid, new Rectangle(0,4765,3508,197));
            desenho.DrawString($"OFERTAS VÁLIDAS DE {DtInicio} ATÉ O DIA {DtValidade}  ENQUANTO DURAREM NOSSOS ESTOQUES", fontTxt, new SolidBrush(Color.White), 100, 4830);
          

            for (int i = 0; i < ListaProdutosLocal.Count; i++)
            {
                EncarteItemHelper encarteItemHelper = new EncarteItemHelper();
                encarteItemHelper.Nome = ListaProdutosLocal[i].Nome;
                encarteItemHelper.Valor = ListaProdutosLocal[i].Valor;
                encarteItemHelper.Img = ListaProdutosLocal[i].Img;
                if (encarteItemHelper.Nome.Length>0)
                {
                    desenho.DrawString(encarteItemHelper.Nome, fontProduto, new SolidBrush(Color.Black), Lt_Pos_Img[i].X, Lt_Pos_Img[i].Y - 90);
                    desenho.DrawImage(encarteItemHelper.Img, Lt_Pos_Img[i].X, Lt_Pos_Img[i].Y, encarteItemHelper.Img.Width, encarteItemHelper.Img.Height);
                    desenho.FillRectangle(solid, new Rectangle(Lt_Pos_Img[i].X + 390, Lt_Pos_Img[i].Y + 470, 270, 140));
                    desenho.DrawString(encarteItemHelper.Valor, fontPreco, new SolidBrush(Color.White), Lt_Pos_Img[i].X + 375, Lt_Pos_Img[i].Y + 500);
                }
            }
            
            Encarte.Save("C:\\Users\\Public\\Pictures\\F.jpg");
            return Encarte;
        }
        public static Bitmap EncarteVerso(Bitmap ImgBoT, String DtInicio, String DtValidade, List<EncarteItemHelper> ListaProdutosLocal, SolidBrush solid)
        {
            Point A3 = new Point(3508, 4961);
            Bitmap Encarte = new Bitmap(A3.X, A3.Y);
            List<Point> Lt_Pos_Img = new List<Point>();
            Font fontTxt = new Font("Bahnschrift", 55, FontStyle.Bold);
            Font fontProduto = new Font("Bahnschrift", 34, FontStyle.Bold);
            Font fontPreco = new Font("Bahnschrift", 72, FontStyle.Bold);
            #region Passagem de Valores Lt_Pos_Img
            //x(235) + 790
            //y(1180) + 740
            int ajusteX = 0;
            int ajusteY = -60;
            //Fileira de 1-4    
            Lt_Pos_Img.Add(new Point(240 + ajusteX, 360 + ajusteY));
            Lt_Pos_Img.Add(new Point(1030 + ajusteX, 360 + ajusteY));
            Lt_Pos_Img.Add(new Point(1820 + ajusteX, 360 + ajusteY));
            Lt_Pos_Img.Add(new Point(2610 + ajusteX, 360 + ajusteY));
            //Fileira de 5-8
            Lt_Pos_Img.Add(new Point(240 + ajusteX, 1100 + ajusteY));
            Lt_Pos_Img.Add(new Point(1030 + ajusteX, 1100 + ajusteY));
            Lt_Pos_Img.Add(new Point(1820 + ajusteX, 1100 + ajusteY));
            Lt_Pos_Img.Add(new Point(2610 + ajusteX, 1100 + ajusteY));
            //Fileira de 9-12
            Lt_Pos_Img.Add(new Point(240 + ajusteX, 1840 + ajusteY));
            Lt_Pos_Img.Add(new Point(1030 + ajusteX, 1840 + ajusteY));
            Lt_Pos_Img.Add(new Point(1820 + ajusteX, 1840 + ajusteY));
            Lt_Pos_Img.Add(new Point(2610 + ajusteX, 1840 + ajusteY));
            //Fileira de 13-16
            Lt_Pos_Img.Add(new Point(240 + ajusteX, 2580 + ajusteY));
            Lt_Pos_Img.Add(new Point(1030 + ajusteX, 2580 + ajusteY));
            Lt_Pos_Img.Add(new Point(1820 + ajusteX, 2580 + ajusteY));
            Lt_Pos_Img.Add(new Point(2610 + ajusteX, 2580 + ajusteY));
            //Fileira de 17-20
            Lt_Pos_Img.Add(new Point(240 + ajusteX, 3320 + ajusteY));
            Lt_Pos_Img.Add(new Point(1030 + ajusteX, 3320 + ajusteY));
            Lt_Pos_Img.Add(new Point(1820 + ajusteX, 3320 + ajusteY));
            Lt_Pos_Img.Add(new Point(2610 + ajusteX, 3320 + ajusteY));
            //Fileira de 21-24
            Lt_Pos_Img.Add(new Point(240 + ajusteX, 4060 + ajusteY));
            Lt_Pos_Img.Add(new Point(1030 + ajusteX, 4060 + ajusteY));
            Lt_Pos_Img.Add(new Point(1820 + ajusteX, 4060 + ajusteY));
            Lt_Pos_Img.Add(new Point(2610 + ajusteX, 4060 + ajusteY));
            
            #endregion
            Graphics desenho = Graphics.FromImage(Encarte);
            desenho.Clear(Color.White);
            desenho.DrawImage(ImgBoT, 0, 4621, ImgBoT.Width, ImgBoT.Height);
            //Valor Mudar cor
            desenho.FillRectangle(solid, new Rectangle(0, 0, 3508, 197));
            desenho.DrawString($"OFERTAS VÁLIDAS DE {DtInicio} ATÉ O DIA {DtValidade}  ENQUANTO DURAREM NOSSOS ESTOQUES", fontTxt, new SolidBrush(Color.White), 40, 65);

            for (int i = 0; i < ListaProdutosLocal.Count; i++)
            {
                EncarteItemHelper encarteItemHelper = new EncarteItemHelper();
                encarteItemHelper.Nome = ListaProdutosLocal[i].Nome;
                encarteItemHelper.Valor = ListaProdutosLocal[i].Valor;
                encarteItemHelper.Img = ListaProdutosLocal[i].Img;
                if (encarteItemHelper.Nome.Length > 0)
                {
                    desenho.DrawString(encarteItemHelper.Nome, fontProduto, new SolidBrush(Color.Black), Lt_Pos_Img[i].X, Lt_Pos_Img[i].Y - 90);
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
