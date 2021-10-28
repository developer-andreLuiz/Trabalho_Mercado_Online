using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace Trabalho_Mercado_Online.Helpers
{
    static class ImagemService
    {
        public static Image ResizeImage(Image ImgLocal, int LarguraLocal, int AlturaLocal)
        {
            Image img = new Bitmap(ImgLocal);
            Bitmap imageFinal = new Bitmap(LarguraLocal, AlturaLocal);//tamanho da imagem
            bool aumentar = false;
            bool diminuir = false;
            if (ImgLocal.Width > LarguraLocal || ImgLocal.Height > AlturaLocal)
            {
                diminuir = true;
            }
            if (diminuir)
            {
                img = DiminuirImage(img, LarguraLocal, AlturaLocal);
            }
     
            
            
            
            
            
            
            if (ImgLocal.Width < LarguraLocal || ImgLocal.Height < AlturaLocal)
            {
                aumentar = true;
            }
            if (aumentar)
            {
                img = AumentarImage(img, LarguraLocal, AlturaLocal);
            }
            Graphics desenho = Graphics.FromImage(imageFinal);
            desenho.Clear(Color.White);
            int posx = (LarguraLocal - img.Width) / 2;
            int posy = (AlturaLocal - img.Height) / 2;
            desenho.DrawImage(img, posx, posy);
            return imageFinal;
        }
        public static void SaveImg(Image ImgLocal)
        {
            DeleteImg();
            string path = System.IO.Directory.GetCurrentDirectory() + "\\Image.jpg";

            Bitmap bitmap = (Bitmap)ImgLocal;
            bitmap.Save(path,ImageFormat.Jpeg);
        
        }
        public static void DeleteImg()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "\\Image.jpg";
            bool result = File.Exists(path);
            if (result == true)
            {
                File.Delete(path);
            }

        }
        
        static Image DiminuirImage(Image ImgLocal, int LarguraLocal, int AlturaLocal)
        {
            int larguraImg = ImgLocal.Width;
            int alturaImg = ImgLocal.Height;

            while (larguraImg > LarguraLocal || alturaImg > AlturaLocal)
            {
                larguraImg = larguraImg - (larguraImg / 100);
                alturaImg = alturaImg - (alturaImg / 100);
            }
            Bitmap imgFinal = new Bitmap(ImgLocal, new Size(larguraImg, alturaImg));
            return imgFinal;
        }
        static Image AumentarImage(Image ImgLocal, int LarguraLocal, int AlturaLocal)
        {   
            int larguraImg = ImgLocal.Width;
            int alturaImg = ImgLocal.Height;

            while (larguraImg < LarguraLocal && alturaImg < AlturaLocal)
            {
                larguraImg = (larguraImg / 100) + larguraImg;
                alturaImg = (alturaImg / 100) + alturaImg;
            }

            Bitmap imgFinal = new Bitmap(ImgLocal, new Size(larguraImg, alturaImg));
            return imgFinal;
        }
    }
}
