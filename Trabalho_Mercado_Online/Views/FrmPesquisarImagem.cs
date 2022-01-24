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
        //formulario para passar imagem para produto
        FrmProduto frmProduto = null;
        //formulario para passar imagem para encarte
        FrmEncarte frmEncarte = null;
        
        WebBrowser Navegador = new WebBrowser();
        List<UrlHelper> ListaUrls = new List<UrlHelper>();
        Bitmap ImagemOriginal;
       
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
        void BaixarImagens20Imagens()
        {
            int max = 0;
            foreach (var item in ListaUrls.FindAll(x => x.Verificada == false))
            {
                if (Global.Break_Thread)
                {
                    break;
                }
                item.Verificada = true;
                item.Img = ImagemHelper.ImagemUrl(item.Url, 1000, 1200);
              
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
                if (Global.Break_Thread)
                {
                    break;
                }
                item.Verificada = true;
                item.Img = ImagemHelper.ImagemUrl(item.Url, 1000, 1200);
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
        public FrmPesquisarImagem(FrmProduto frm)
        {
            InitializeComponent();
            Global.FinalizarThread();
            panelImagens.MouseWheel += panelImagens_MouseWheel;
            InitNavegador();
            
            frmProduto = frm;
            txtProduto.Text = frm.txtDescricao.Text;
            string imgTemp = frm.pictureBox.ImageLocation;
            if (imgTemp != null)
            {
                ImagemOriginal = ImagemHelper.ImagemUrl(imgTemp, 1000, 1200);
                if (ImagemOriginal != null)
                {
                    Bitmap b = new Bitmap(ImagemOriginal);
                    pictureBoxImagem.BackgroundImage = b;
                }
            }
        }
        public FrmPesquisarImagem(FrmEncarte frm)
        {
            InitializeComponent();
            Global.FinalizarThread();
            panelImagens.MouseWheel += panelImagens_MouseWheel;
            InitNavegador();
            frmEncarte = frm;
            txtProduto.Text = frm.txtNomeProduto.Text;

            pictureBoxImagem.Size = new Size(200,179);
            if (frm.picProduto.BackgroundImage!=null)
            {
                ImagemOriginal = (Bitmap)frm.picProduto.BackgroundImage;
                pictureBoxImagem.BackgroundImage = frm.picProduto.BackgroundImage;
            }
            



        }
        public FrmPesquisarImagem()
        {
            InitializeComponent();
            Global.FinalizarThread();
            pictureBoxImagem.Size = new Size(200, 179);
            panelImagens.MouseWheel += panelImagens_MouseWheel;
            InitNavegador();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            
            if (frmProduto!=null)
            {
                ImagemOriginal = new Bitmap(btn.BackgroundImage);
                pictureBoxImagem.BackgroundImage = btn.BackgroundImage;
            }
            else
            {
                ImagemOriginal = (Bitmap)ImagemHelper.ResizeImage(btn.BackgroundImage, 660, 610);
                pictureBoxImagem.BackgroundImage = ImagemHelper.ResizeImage(btn.BackgroundImage,660,610);
            }
        }
        
        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (pictureBoxImagem.BackgroundImage != null)
            {
                //Apenas baixar imagem
                if (frmProduto == null && frmEncarte == null)
                {
                    SaveFileDialog sf = new SaveFileDialog();
                    sf.Filter = "jpg(*.jpg)|*.jpg";
                    sf.Title = "Salvar um arquivo de imagem";
                    sf.FileName = txtProduto.Text;
                    if (sf.ShowDialog() == DialogResult.OK)
                    {
                        pictureBoxImagem.BackgroundImage.Save(sf.FileName);
                        chkRotEsquerda.Checked = false;
                        chkRotDireita.Checked = false;
                        nUD.Value = 1;
                    }
                }
                else
                {
                    //Produto
                    if (frmProduto != null)
                    {
                        frmProduto.pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                        frmProduto.pictureBox.Image = null;
                        frmProduto.pictureBox.BackgroundImage = null;
                        ImagemHelper.SaveImg(pictureBoxImagem.BackgroundImage);
                        frmProduto.pathImagem = System.IO.Directory.GetCurrentDirectory() + "\\Image.jpg";
                        frmProduto.pictureBox.ImageLocation = frmProduto.pathImagem;
                        this.Close();
                    }
                    //Encarte
                    if (frmEncarte != null)
                    {
                        DialogResult dialog = MessageBox.Show("Deseja Salvar Esta Imagem?", "Salvar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.Yes)
                        {
                            SaveFileDialog sf = new SaveFileDialog();
                            sf.Filter = "jpg(*.jpg)|*.jpg";
                            sf.Title = "Salvar um arquivo de imagem";
                            sf.FileName = txtProduto.Text;
                            if (sf.ShowDialog() == DialogResult.OK)
                            {
                                pictureBoxImagem.BackgroundImage.Save(sf.FileName);
                                chkRotEsquerda.Checked = false;
                                chkRotDireita.Checked = false;
                                nUD.Value = 1;
                            }
                        }
                        frmEncarte.picProduto.BackgroundImage = pictureBoxImagem.BackgroundImage;
                        this.Close();
                    }



                }
            }
            Global.FinalizarThread();
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            btnLimpar.PerformClick();
            panelImagens.Controls.Clear();
            ListaUrls = new List<UrlHelper>();
            lblTotalLista.Text = "0";
            string url1 = "https://www.bing.com/images/search?q=";
            string url2 = string.Empty;
            string url3 = "&first=1&tsc=ImageHoverTitle";
            string url = string.Empty;
            if (txtProduto.Text.Length > 0)
            {
                string texto = StringHelper.FormatarStringMinusculo(txtProduto.Text);
                txtProduto.Text = texto;
                var t = texto.Trim().Split(' ');
                foreach (var item in t)
                {
                    url2 = url2 + "+" + item;
                }
                url = url1 + url2 + url3;
                Global.FinalizarThread();
                Global.Break_Thread = false;
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
       
        //Carregamento de Imagens
        private void panelImagens_MouseWheel(object sender, MouseEventArgs e)
        {
            VScrollProperties vsp = panelImagens.VerticalScroll;
            int scrollmax = vsp.Maximum - vsp.LargeChange + 1;
            if (vsp.Value== scrollmax)
            {
                Thread thread = new Thread(BaixarImagens8Imagens);
                thread.IsBackground = true;
                thread.Name = "Imagem";
                thread.Start();
                Global.Lista_Thread_Imagem.Add(thread);
            }

        }
        private void panelImagens_Scroll(object sender, ScrollEventArgs e)
        {
            VScrollProperties vsp = panelImagens.VerticalScroll;
            int scrollmax = vsp.Maximum - vsp.LargeChange + 1;
            if (vsp.Value == scrollmax)
            {
                Thread thread = new Thread(BaixarImagens8Imagens);
                thread.IsBackground = true;
                thread.Name = "Imagem";
                thread.Start();
                Global.Lista_Thread_Imagem.Add(thread);
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

                            ListaUrls.Add(new UrlHelper(final));
                        }
                    }
                }
            }
            lblTotalLista.Text = ListaUrls.Count.ToString();
            Thread thread = new Thread(BaixarImagens20Imagens);
            thread.IsBackground = true;
            thread.Name = "Imagem";
            thread.Start();
            Global.Lista_Thread_Imagem.Add(thread);
          
        }
      
        private void btnLimpar_Click(object sender, EventArgs e)
        {
           
            Global.Break_Thread = true;
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
            if (pictureBoxImagem.BackgroundImage != null)
            {
                RectStartPoint = e.Location;
                Invalidate();
            }

        }
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBoxImagem.BackgroundImage != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point tempEndPoint = e.Location;
                    retangulo.Location = new Point(Math.Min(RectStartPoint.X, tempEndPoint.X), Math.Min(RectStartPoint.Y, tempEndPoint.Y));
                    retangulo.Size = new Size(Math.Abs(RectStartPoint.X - tempEndPoint.X), Math.Abs(RectStartPoint.Y - tempEndPoint.Y));
                    pictureBoxImagem.Invalidate();
                }
            }

        }
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (pictureBoxImagem.BackgroundImage != null)
            {
                if (retangulo != null && retangulo.Width > 0 && retangulo.Height > 0)
                {
                    e.Graphics.FillRectangle(brush, retangulo);
                }
            }
        }
        private void chkRotEsquerda_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRotEsquerda.Checked)
            {
                chkRotDireita.Checked = false;
            }
        }
        private void chkRotDireita_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRotDireita.Checked)
            {
                chkRotEsquerda.Checked = false;
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (pictureBoxImagem.BackgroundImage != null && retangulo.Width != 0 && retangulo.Height != 0)
            {
                try
                {
                    int larguraF = ImagemOriginal.Width;
                    int AlturaF = ImagemOriginal.Height;
                   
                    
                    //numero de x que o picturebox é menor que o original
                    double multplicadorx = (double)ImagemOriginal.Width / pictureBoxImagem.Width;
                    double multplicadory = (double)ImagemOriginal.Height / pictureBoxImagem.Height;
                    
                    //novo bitmap com imagem sem edição
                    Bitmap bitmapOriginal = new Bitmap(pictureBoxImagem.BackgroundImage);
                    
                    //retangulo de seleção para corte
                    Rectangle rect = new Rectangle();
                    double RecX = retangulo.Location.X * multplicadorx;
                    double RecY = retangulo.Location.Y * multplicadory;
                    rect.Location = new Point((int)RecX,(int)RecY);

                    double RecWid = retangulo.Width * multplicadorx;
                    double RecHei = retangulo.Height * multplicadory;

                    rect.Width = (int)RecWid;
                    rect.Height = (int)RecHei;
                    retangulo = new Rectangle();

                    Bitmap bitmapCortado = bitmapOriginal.Clone(rect, bitmapOriginal.PixelFormat);



                   

                    if (chkRotEsquerda.Checked)
                    {
                        bitmapCortado.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    }
                    chkRotEsquerda.Checked = false;
                    if (chkRotDireita.Checked)
                    {
                        bitmapCortado.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }
                    if (nUD.Value == 1)
                    {
                        Bitmap imgFinal = (Bitmap)ImagemHelper.ResizeImage(bitmapCortado, larguraF, AlturaF);
                        pictureBoxImagem.BackgroundImage = imgFinal;
                    }
                    else
                    {
                        int valor = int.Parse(nUD.Value.ToString());
                        if (rbLado.Checked)
                        {

                            Bitmap imgMult = new Bitmap(valor * bitmapCortado.Width, bitmapCortado.Height);
                            Graphics desenho = Graphics.FromImage(imgMult);
                            for (int i = 0; i < valor; i++)
                            {
                                desenho.DrawImage(bitmapCortado, i * bitmapCortado.Width, 0);
                            }

                            Bitmap imgFinal = (Bitmap)ImagemHelper.ResizeImage(imgMult, larguraF, AlturaF);
                          
                            pictureBoxImagem.BackgroundImage = imgFinal;
                        }
                        else
                        {
                            Bitmap imgMult = new Bitmap(bitmapCortado.Width, valor * bitmapCortado.Height);
                            Graphics desenho = Graphics.FromImage(imgMult);
                            for (int i = 0; i < valor; i++)
                            {
                                desenho.DrawImage(bitmapCortado, 0, i * bitmapCortado.Height);
                            }

                            Bitmap imgFinal = (Bitmap)ImagemHelper.ResizeImage(imgMult, larguraF, AlturaF);
                            pictureBoxImagem.BackgroundImage = imgFinal;
                        }
                    }
                    chkRotEsquerda.Checked = false;
                    chkRotDireita.Checked = false;
                    nUD.Value = 1;
                }
                catch { btnDesfazer.PerformClick(); }
            }
        }
        private void btnDesfazer_Click(object sender, EventArgs e)
        {
            if (pictureBoxImagem.BackgroundImage != null)
            {
                Bitmap b = new Bitmap(ImagemOriginal);
                pictureBoxImagem.BackgroundImage = b;
                retangulo = new Rectangle();
                chkRotEsquerda.Checked = false;
                chkRotDireita.Checked = false;
                nUD.Value = 1;
            }
        }

        #endregion

       
    }
}
