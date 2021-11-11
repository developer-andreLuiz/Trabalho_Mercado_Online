using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Trabalho_Mercado_Online.Helpers;

namespace Trabalho_Mercado_Online.Views
{
    public partial class FrmPesquisarImagem : Form
    {
        #region Variaveis
        FrmProduto frmProduto;
        WebBrowser Navegador = new WebBrowser();
        List<UrlService> ListaUrls = new List<UrlService>();
        Bitmap ImagemOriginal;
        bool breakThread = false;

        //variaveis de edição de imagens
        private Point RectStartPoint;
        private Rectangle retangulo = new Rectangle();
        private Brush brush = new SolidBrush(Color.FromArgb(128, 72, 145, 220));
        #endregion

        #region Funções
        void InitNavegador()
        {
            Navegador.DocumentCompleted += Navegador_DocumentCompleted;
            this.Controls.Add(Navegador);
            Navegador.Size = new Size(4000, 4000);
            Navegador.Location = new Point(0,0);
            //Navegador.Navigate("www.gloogle.com.br");
        }
        void CarregarImagens()
        {
            int vertical = panelImagens.VerticalScroll.Value;
            Point current = panelImagens.AutoScrollPosition;
            Point scrolled = new Point(current.X, -current.Y);
            
            int itensGrid = 0;
            panelImagens.Controls.Clear();
            int linha = 0;
            int coluna = 0;
            foreach (var item in ListaUrls.FindAll(x => x.Img != null))
            {
                Button btn = new Button();
                btn.Text = string.Empty;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.Size = new Size(160, 192);
                btn.BackgroundImage = item.Img;
                btn.Click += btn_Click;
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                panelImagens.Controls.Add(btn);

                int x = 3 + (coluna * 3) + (coluna * 160);
                int y = 3 + (linha * 3) + (linha * 192);
                btn.Location = new Point(x, y);
                coluna++;
                if (coluna==4)
                {
                    coluna = 0; 
                    linha++;
                }
                item.Exibida = true;
                itensGrid++;
            }
            itensGrid = ListaUrls.FindAll(x => x.Exibida).Count;
            lblItensGrid.Text = itensGrid.ToString();
            
            panelImagens.VerticalScroll.Value = vertical;
            panelImagens.AutoScrollPosition = scrolled;
        }
        Bitmap ImagemUrl(string url)
        {
            try
            {
               
                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                Bitmap bitmap2 = new Bitmap(responseStream);
                Bitmap bitmap3 = (Bitmap)ImagemService.ResizeImage(bitmap2,1000,1200);

                request.Abort();
                response.Close();
                response.Dispose();
                responseStream.Dispose();
                bitmap2.Dispose();

                return bitmap3;
            }
            catch
            {
                return null;
            }
        }
        void BaixarImagens20Imagens()
        {
            int max = 0;
            foreach (var item in ListaUrls.FindAll(x => x.Verificada == false))
            {
                if (breakThread)
                {
                    break;
                }
                item.Verificada = true;
                item.Img = ImagemUrl(item.Url);
              
                if (item.Img!=null)
                {
                    max++;
                }
                if (max==20)
                {
                    break;
                }
            }
        }
        void BaixarImagens8Imagens()
        {
            int max = 8;
            foreach (var item in ListaUrls.FindAll(x => x.Verificada == false))
            {
                if (breakThread)
                {
                    break;
                }
                item.Verificada = true;
                item.Img = ImagemUrl(item.Url);
                if (item.Img != null)
                {
                    max++;
                }
                if (max == 20)
                {
                    break;
                }
            }
        }
        #endregion

        #region Eventos
        public FrmPesquisarImagem(FrmProduto frm, string txt, string imgTemp)
        {
            InitializeComponent();
            frmProduto = frm;
            txtProduto.Text = txt;
            panelImagens.MouseWheel += panelImagens_MouseWheel;
            panelImagens.MouseWheel += panelImagens_MouseWheel;
            if (imgTemp!=null)
            {
                ImagemOriginal = ImagemUrl(imgTemp);
                if (ImagemOriginal!=null)
                {
                    Bitmap b = new Bitmap(ImagemOriginal);
                    pictureBox.BackgroundImage = b;
                }
               
            }
            InitNavegador();
        }
        public FrmPesquisarImagem()
        {
            InitializeComponent();
            btnSelecionar.Text = "   Exportar";
            panelImagens.MouseWheel += panelImagens_MouseWheel;
            InitNavegador();
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ImagemOriginal = new Bitmap(btn.BackgroundImage);
            pictureBox.BackgroundImage = btn.BackgroundImage;
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (btnSelecionar.Text.Equals("    Selecionar"))
            {
                if (pictureBox.BackgroundImage != null)
                {
                    frmProduto.pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                    frmProduto.pictureBox.Image = null;
                    frmProduto.pictureBox.BackgroundImage = null;
                    ImagemService.SaveImg(pictureBox.BackgroundImage);
                    frmProduto.pathImagem = System.IO.Directory.GetCurrentDirectory() + "\\Image.jpg";
                    frmProduto.pictureBox.ImageLocation = frmProduto.pathImagem;

                    this.Close();
                }
            }
            else
            {
                
                SaveFileDialog sf = new SaveFileDialog();
                sf.Filter = "jpg(*.jpg)|*.jpg";
                sf.Title = "Salvar um arquivo de imagem";
                sf.FileName = txtProduto.Text;
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    if (pictureBox.BackgroundImage!=null)
                    {
                        pictureBox.BackgroundImage.Save(sf.FileName);
                    }
                }
            }
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            btnLimpar.PerformClick();

            panelImagens.Controls.Clear();
            ListaUrls = new List<UrlService>();
            lblTotalLista.Text = "0";
            string url1 = "https://www.bing.com/images/search?q=";
            string url2 = string.Empty;
            string url3 = "&first=1&tsc=ImageHoverTitle";
            string url = string.Empty;
            if (txtProduto.Text.Length > 0)
            {
                string texto = StringService.FormatarStringMinusculo(txtProduto.Text);
                txtProduto.Text = texto;
                var t = texto.Trim().Split(' ');
                foreach (var item in t)
                {
                    url2 = url2 + "+" + item;
                }

                url = url1 + url2 + url3;
                breakThread = false;
                Navegador.Navigate(url);
            }
           
        }
        private void txtProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            var Tecla = ((byte)e.KeyChar);
            if (Tecla == 13)
            {
                btnPesquisar.PerformClick();
            }

        }
       
        private void panelImagens_MouseWheel(object sender, MouseEventArgs e)
        {
            VScrollProperties vsp = panelImagens.VerticalScroll;
            int scrollmax = vsp.Maximum - vsp.LargeChange + 1;
            if (vsp.Value== scrollmax)
            {
                Thread t = new Thread(BaixarImagens8Imagens);
                t.Start();
            }

        }
        private void panelImagens_Scroll(object sender, ScrollEventArgs e)
        {
            VScrollProperties vsp = panelImagens.VerticalScroll;
            int scrollmax = vsp.Maximum - vsp.LargeChange + 1;
            if (vsp.Value == scrollmax)
            {
                Thread t = new Thread(BaixarImagens8Imagens);
                t.Start();
            }
        }
        private void Navegador_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string htmlString = string.Empty;
            htmlString = Navegador.DocumentText;
            string referencia = "\"murl\":\"";
            if (htmlString.Contains(referencia))
            {
                string corte1 = htmlString.Substring(htmlString.IndexOf(referencia));
                string[] stringReferencia = new string[] { referencia };
                string[] cortes = corte1.Split(stringReferencia, StringSplitOptions.None);
                foreach (var item in cortes)
                {
                    if (item.Length > 5)
                    {
                        string final = item.Substring(0, item.IndexOf("\""));
                        if (ListaUrls.FindAll(x => x.Url.Equals(final)).Count == 0)
                        {

                            ListaUrls.Add(new UrlService(final));
                        }
                    }
                }
            }
            lblTotalLista.Text = ListaUrls.Count.ToString();
            Thread t = new Thread(BaixarImagens20Imagens);
            t.Start();
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
           
            breakThread = true;
        }
        private void timerImagens_Tick(object sender, EventArgs e)
        {
            if (ListaUrls.FindAll(x => x.Img != null && x.Exibida == false).Count != 0)
            {
                CarregarImagens();
            }
        }

        //Edição Imagem
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBox.BackgroundImage != null)
            {
                RectStartPoint = e.Location;
                Invalidate();
            }

        }
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox.BackgroundImage != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point tempEndPoint = e.Location;
                    retangulo.Location = new Point(Math.Min(RectStartPoint.X, tempEndPoint.X), Math.Min(RectStartPoint.Y, tempEndPoint.Y));
                    retangulo.Size = new Size(Math.Abs(RectStartPoint.X - tempEndPoint.X), Math.Abs(RectStartPoint.Y - tempEndPoint.Y));
                    pictureBox.Invalidate();
                }
            }

        }
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBox.BackgroundImage != null)
            {
                if (retangulo != null && retangulo.Width > 0 && retangulo.Height > 0)
                {
                    e.Graphics.FillRectangle(brush, retangulo);
                }
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (pictureBox.BackgroundImage != null && retangulo.Width != 0 && retangulo.Height != 0)
            {
                try
                {
                    int multplicador = ImagemOriginal.Height / pictureBox.Height;

                    Bitmap bitmap = new Bitmap(ImagemOriginal);

                    Rectangle rect = new Rectangle();
                    rect.Location = new Point(retangulo.Location.X * multplicador, retangulo.Location.Y * multplicador);
                    rect.Width = retangulo.Width * multplicador;
                    rect.Height = retangulo.Height * multplicador;

                    retangulo = new Rectangle();

                    Bitmap cropped = bitmap.Clone(rect, bitmap.PixelFormat);

                    Bitmap imgFinal = (Bitmap)ImagemService.ResizeImage(cropped, 1000, 1200);
                    pictureBox.BackgroundImage = imgFinal;

                }
                catch { btnDesfazer.PerformClick(); }
            }
        }
        private void btnDesfazer_Click(object sender, EventArgs e)
        {
            if (pictureBox.BackgroundImage != null)
            {
                Bitmap b = new Bitmap(ImagemOriginal);
                pictureBox.BackgroundImage = b;
                retangulo = new Rectangle();
            }
        }
        #endregion










    }
}
