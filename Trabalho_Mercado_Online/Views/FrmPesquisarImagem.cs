using MMLib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Trabalho_Mercado_Online.Helpers;

namespace Trabalho_Mercado_Online.Views
{
    public partial class FrmPesquisarImagem : Form
    {
        #region Variaveis
        FrmProduto frmProduto;

        #endregion

        #region Funções
        void BuscarCaminhoPastaImagem()
        {
            while (string.IsNullOrEmpty(Global.CaminhoPastaImagem))
            {
                using (var fbd = new FolderBrowserDialog())
                {

                    fbd.Description = "Pasta das Imagens HD";
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        Global.CaminhoPastaImagem = fbd.SelectedPath;

                    }

                }
            }
            lblCaminhoPasta.Text = Global.CaminhoPastaImagem;
        }
        void CarregarBancoImagem()
        {
            if (Global.ListaImagem.Count == 0)
            {
                try
                {
                    var ListaBruta = new List<string>();
                    foreach (string line in System.IO.File.ReadLines(@"Imagens.txt"))
                    {
                        ListaBruta.Add(line);
                    }
                    foreach (var item in ListaBruta)
                    {

                        string frase = item;
                        frase = frase.Replace(");", "");
                        frase = frase.Replace("'", "");
                        frase = frase.Replace("INSERT INTO \"tbl_eans_260_codbar\" VALUES (", "");

                        var obj = frase.Split(",");

                        Imagem img = new Imagem();

                        img.codbar = obj[0];
                        img.produto = obj[1];
                        img.produto_upper = obj[2];
                        img.produto_acento = obj[3];
                        img.foto_png = obj[4];
                        img.foto_webp = obj[5];
                        img.marca = obj[6];
                        img.img_gtin = obj[7];
                        img.categoria = obj[8];

                        Global.ListaImagem.Add(img);
                    }




                }
                catch { }
            }
            lblTotalLista.Text = Global.ListaImagem.Count.ToString();
        }
        void CarregarGrid()
        {
            List<Imagem> Lista = new List<Imagem>();

            //sem Filtro
            Lista.AddRange(Global.ListaImagem);

            if (txtProduto.Text.Length > 0)
            {
                string txt = txtProduto.Text.RemoveDiacritics();
                var listTxt = txt.Split(" ");

                foreach (var item in listTxt)
                {
                    var lt = Lista.FindAll(x => x.produto.RemoveDiacritics().Contains(item, StringComparison.InvariantCultureIgnoreCase));
                    Lista = lt;
                }
            }


            dataGridView.DataSource = null;
            dataGridView.DataSource = Lista;

            if (Lista.Count > 0)
            {
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].Width = 550;
                dataGridView.Columns[2].Visible = false;
                dataGridView.Columns[3].Visible = false;
                dataGridView.Columns[4].Visible = false; //png
                dataGridView.Columns[5].Visible = false;
                dataGridView.Columns[6].Visible = false;
                dataGridView.Columns[7].Visible = false;
                dataGridView.Columns[8].Visible = false;
            }
            else
            {
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].Visible = false;
                dataGridView.Columns[2].Visible = false;
                dataGridView.Columns[3].Visible = false;
                dataGridView.Columns[4].Visible = false;
                dataGridView.Columns[5].Visible = false;
                dataGridView.Columns[6].Visible = false;
                dataGridView.Columns[7].Visible = false;
                dataGridView.Columns[8].Visible = false;
            }


            lblItensGrid.Text = Lista.Count.ToString();
        }
        #endregion

        #region Eventos
        public FrmPesquisarImagem(FrmProduto frm, string txt)
        {

            InitializeComponent();
            frmProduto = frm;
            txtProduto.Text = txt;
            BuscarCaminhoPastaImagem();
            CarregarBancoImagem();
            CarregarGrid();
        }
        public FrmPesquisarImagem()
        {

            InitializeComponent();
            BuscarCaminhoPastaImagem();
            CarregarBancoImagem();
            CarregarGrid();
            btnSelecionar.Text = "   Exportar";
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCaminhoPasta_Click(object sender, EventArgs e)
        {
            Global.CaminhoPastaImagem = string.Empty;
            BuscarCaminhoPastaImagem();
        }
        private void txtProduto_TextChanged(object sender, EventArgs e)
        {
            CarregarGrid();
        }
        private void dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (string.IsNullOrEmpty(Global.CaminhoPastaImagem) == false)
            {
                try
                {
                    string pathImg = Global.CaminhoPastaImagem + "\\" + dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                    Image image = Image.FromFile(pathImg);
                    pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                    pictureBox.BackgroundImage = ImagemService.ResizeImage(image, 1000, 1200);
                }
                catch { }
            }
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
            #endregion



        }
    }
}
