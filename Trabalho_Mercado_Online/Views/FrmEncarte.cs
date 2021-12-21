using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Trabalho_Mercado_Online.Models;
using Trabalho_Mercado_Online.Controllers;
using Trabalho_Mercado_Online.Helpers;

namespace Trabalho_Mercado_Online.Views
{
    public partial class FrmEncarte : Form
    {
        #region Variaveis
        int posLista = 0;
        bool Novo = false;
        bool Editar = false;
        List<Encarte> ListaEncarte_Banco = EncarteController.GetAll();
        List<EncarteItem> ListaEncarteItens_Banco = EncarteItemController.GetAll();
        List<EncarteItemHelper> ListaProdutos = new List<EncarteItemHelper>();
        
        Bitmap ImgTop1 = ImagemHelper.ImagemUrl("https://aplicativo.blob.core.windows.net/encarte/top1.jpg", 3508, 1014);
        Bitmap ImgTop2 = ImagemHelper.ImagemUrl("https://aplicativo.blob.core.windows.net/encarte/top2.jpg", 3508, 1014);
        Bitmap ImgTop3 = ImagemHelper.ImagemUrl("https://aplicativo.blob.core.windows.net/encarte/top3.jpg", 3508, 1014);
        Bitmap ImgTop4 = ImagemHelper.ImagemUrl("https://aplicativo.blob.core.windows.net/encarte/top4.jpg", 3508, 1014);
        Bitmap ImgTop5 = ImagemHelper.ImagemUrl("https://aplicativo.blob.core.windows.net/encarte/top5.jpg", 3508, 1014);
        
        Bitmap ImgBot1 = ImagemHelper.ImagemUrl("https://aplicativo.blob.core.windows.net/encarte/bot1.jpg", 3508, 1014);
        Bitmap ImgBot2 = ImagemHelper.ImagemUrl("https://aplicativo.blob.core.windows.net/encarte/bot2.jpg", 3508, 1014);
        Bitmap ImgBot3 = ImagemHelper.ImagemUrl("https://aplicativo.blob.core.windows.net/encarte/bot3.jpg", 3508, 1014);
        Bitmap ImgBot4 = ImagemHelper.ImagemUrl("https://aplicativo.blob.core.windows.net/encarte/bot4.jpg", 3508, 1014);
        Bitmap ImgBot5 = ImagemHelper.ImagemUrl("https://aplicativo.blob.core.windows.net/encarte/bot5.jpg", 3508, 1014);
        //
        private Form activeForm = null;
        #endregion

        #region Funções
        void OpenForm()
        {
            CarregarGrid();
            cbTipo.SelectedIndex = 0;
            InterfaceEncarte(false);
            InterfaceProduto(false);
            InterfaceBtnProduto(false);
            AlimentarListaVazia();
          
            btnCancelarEncarte.Enabled = false;
            btnSalvarEncarte.Enabled = false;

        }
        private void openChildForm(Form ChildForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(ChildForm);
            panelMain.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }
        void AtualizarLista_Banco()
        {
            ListaEncarte_Banco = EncarteController.GetAll();
            ListaEncarteItens_Banco = EncarteItemController.GetAll();
        }
        void CarregarGrid()
        {
            if (ListaEncarte_Banco.Count>0)
            {
                List<Encarte> lista = new List<Encarte>();
                lista.AddRange(ListaEncarte_Banco);
                if (txtPesquisar.Text.Length > 0)
                {
                    string txt = StringHelper.FormatarStringMaiusculo(txtPesquisar.Text);
                    var listTxt = txt.Split(" ");
                    foreach (var item in listTxt)
                    {
                        var lt = lista.FindAll(x => StringHelper.FormatarStringMaiusculo(x.Nome).Contains(item, StringComparison.InvariantCultureIgnoreCase));
                        lista = lt;
                    }
                }
                dataGridView.DataSource = null;
                dataGridView.DataSource = lista;
                dataGridView.Columns[0].Width = 50;
            }
        }
        void Limpar()
        {
            posLista = 0;
            lblId.Text = "0";
          
            
            txtNomeEncarte.Text = string.Empty;
            dateTimePicker.Value = DateTime.Now;
           
           
           
            picProduto.BackgroundImage = null;
            txtNomeProduto.Text = string.Empty;
            txtValorProduto.Text = string.Empty;
            
            AtualizarLista_Banco();
            CarregarGrid();
           
        }
        void InterfaceEncarte(Boolean b)
        {
            txtNomeEncarte.Enabled = b;
            dateTimePicker.Enabled = b;
            //cbTipo.Enabled = b;
            
        }
        void InterfaceProduto(Boolean b)
        {
            picProduto.Enabled = b;
            txtNomeProduto.Enabled = b;
            txtValorProduto.Enabled = b;
            btnConfirmarProduto.Enabled = b;
            btnDeletarProduto.Enabled = b;
        }
        void InterfaceBtnProduto(Boolean b)
        {
            btnImg0.Enabled = b;
            btnImg1.Enabled = b;
            btnImg2.Enabled = b;
            btnImg3.Enabled = b;
            btnImg4.Enabled = b;
            btnImg5.Enabled = b;
            btnImg6.Enabled = b;
            btnImg7.Enabled = b;
            btnImg8.Enabled = b;
            btnImg9.Enabled = b;
            btnImg10.Enabled = b;
            btnImg11.Enabled = b;
            btnImg12.Enabled = b;
            btnImg13.Enabled = b;
            btnImg14.Enabled = b;
            btnImg15.Enabled = b;
            btnImg16.Enabled = b;
            btnImg17.Enabled = b;
            btnImg18.Enabled = b;
            btnImg19.Enabled = b;
        }
        void LimparBtnProduto()
        {
            btnImg0.BackgroundImage = null;
            btnImg1.BackgroundImage = null;
            btnImg2.BackgroundImage = null;
            btnImg3.BackgroundImage = null;
            btnImg4.BackgroundImage = null;
            btnImg5.BackgroundImage = null;
            btnImg6.BackgroundImage = null;
            btnImg7.BackgroundImage = null;
            btnImg8.BackgroundImage = null;
            btnImg9.BackgroundImage = null;
            btnImg10.BackgroundImage = null;
            btnImg11.BackgroundImage = null;
            btnImg12.BackgroundImage = null;
            btnImg13.BackgroundImage = null;
            btnImg14.BackgroundImage = null;
            btnImg15.BackgroundImage = null;
            btnImg16.BackgroundImage = null;
            btnImg17.BackgroundImage = null;
            btnImg18.BackgroundImage = null;
            btnImg19.BackgroundImage = null;
        }
        void AlimentarListaVazia()
        {
            ListaProdutos = new List<EncarteItemHelper>();
            for (int i = 0; i < 20; i++)
            {
                EncarteItemHelper item = new EncarteItemHelper();
                item.Nome = string.Empty;
                item.Valor = string.Empty;
                item.Img = null;
                ListaProdutos.Add(item);
            }
        }
        void ExibirEncarte(Encarte encarte)
        {
            lblId.Text = encarte.Id.ToString();
            txtNomeEncarte.Text = encarte.Nome;
            dateTimePicker.Value = Convert.ToDateTime(encarte.Validade);

            posLista = 0;
            var list = ListaEncarteItens_Banco.FindAll(x=>x.IdEncarte== encarte.Id);
            ListaProdutos = new List<EncarteItemHelper>();
            int b = 0;
            foreach (var item in list)
            {
                EncarteItemHelper encarteItem = new EncarteItemHelper();
                encarteItem.Nome = item.Produto;
                encarteItem.Valor = item.Valor;
                encarteItem.Img = ImagemHelper.ImagemUrl(item.Img, 660, 610);
                ListaProdutos.Add(encarteItem);

                Panel btn = (Panel)this.Controls.Find("btnImg" + b, true)[0];
                btn.BackgroundImage = encarteItem.Img;
                b++;

            }
            if (encarte.Tipo.Equals("FRENTE"))
            {
                picEncarte.BackgroundImage = EncarteHelper.EncarteFrente(ImgTop1, dateTimePicker.Value.ToShortDateString(), ListaProdutos);
                cbTipo.SelectedIndex = 0;
            }
            else
            {
                picEncarte.BackgroundImage = EncarteHelper.EncarteVerso(ImgBot1, dateTimePicker.Value.ToShortDateString(), ListaProdutos);
                cbTipo.SelectedIndex = 1;
            }

        }
        #endregion

       
        public FrmEncarte()
        {
            InitializeComponent();
            OpenForm();
        }
        private void btnNovoEncarte_Click(object sender, EventArgs e)
        {
            Limpar();
            LimparBtnProduto();
            InterfaceEncarte(true);
            InterfaceBtnProduto(true);
            posLista = 0;
            Novo = true;
            Editar = false;
            AlimentarListaVazia();
            btnNovoEncarte.Enabled = false;
            btnEditarEncarte.Enabled = false;
            btnCancelarEncarte.Enabled = true;
            btnSalvarEncarte.Enabled = true;

            if (cbTipo.SelectedIndex==0)
            {
                picEncarte.BackgroundImage = EncarteHelper.EncarteFrente(ImgTop1, dateTimePicker.Value.ToShortDateString(), ListaProdutos);
            }
            else
            {
                picEncarte.BackgroundImage = EncarteHelper.EncarteVerso(ImgBot1, dateTimePicker.Value.ToShortDateString(), ListaProdutos);
            }
           
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            InterfaceEncarte(true);
            InterfaceBtnProduto(true);
            InterfaceEncarte(true);
            posLista = 0;
            Novo = false;
            Editar = true;
            btnNovoEncarte.Enabled = false;
            btnEditarEncarte.Enabled = false;
            btnCancelarEncarte.Enabled = true;
            btnSalvarEncarte.Enabled = true;
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNomeEncarte.Text.Trim().Length>0)
            {
                bool banco = false;
                DialogResult dialog = MessageBox.Show("Deseja Salvar este Encarte no Banco ?", "Banco de Dados", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    banco = true;
                }
                Novo = false;
                Editar = false;
                txtPesquisar.Text = string.Empty;
                //função de salvar
                SaveFileDialog sf = new SaveFileDialog();
                sf.Filter = "jpg(*.jpg)|*.jpg";
                sf.Title = "Salvar um arquivo de imagem";
                sf.FileName = txtNomeEncarte.Text.ToUpper();
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    if (cbTipo.SelectedIndex == 0)
                    {
                        ((Image)EncarteHelper.EncarteFrente(ImgTop1, dateTimePicker.Value.ToShortDateString(), ListaProdutos)).Save(sf.FileName);
                    }
                    else
                    {
                        ((Image)EncarteHelper.EncarteVerso(ImgBot1, dateTimePicker.Value.ToShortDateString(), ListaProdutos)).Save(sf.FileName);
                    }
                }
                //banco de dados 
                if (banco)
                {
                    Encarte encarte = new Encarte();
                    encarte.Nome = txtNomeEncarte.Text.ToUpper();
                    //encarte.Tipo = cbTipo.Text.ToUpper();
                    encarte.Validade = dateTimePicker.Value.ToShortDateString();
                    encarte = EncarteController.Gravar(encarte);

                    foreach (var item in ListaProdutos)
                    {
                        EncarteItem encarteItem = new EncarteItem();
                        encarteItem.IdEncarte = encarte.Id;
                        encarteItem.Produto = item.Nome;
                        encarteItem.Valor = item.Valor;
                        encarteItem = EncarteItemController.Gravar(encarteItem);
                        if (item.Img != null)
                        {
                            ImagemHelper.SaveImg((Image)item.Img);
                            string path = System.IO.Directory.GetCurrentDirectory() + "\\Image.jpg";
                            BlobStorageHelper.Upload("encarte", encarteItem.Id.ToString(), path);
                        }
                    }
                    Limpar();
                    LimparBtnProduto();
                    ExibirEncarte(encarte);

                }
                InterfaceBtnProduto(false);
                InterfaceEncarte(false);
                InterfaceProduto(false);
                btnNovoEncarte.Enabled = true;
                btnEditarEncarte.Enabled = true;
                btnCancelarEncarte.Enabled = false;
                btnSalvarEncarte.Enabled = false;

                MessageBox.Show("Finalizado");
            }
            else
            {
                MessageBox.Show("Encarte sem Nome","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (Novo || Editar)
            {
                if (cbTipo.SelectedIndex == 0)
                {
                    picEncarte.BackgroundImage = EncarteHelper.EncarteFrente(ImgTop1, dateTimePicker.Value.ToShortDateString(), ListaProdutos);
                }
                else
                {
                    picEncarte.BackgroundImage = EncarteHelper.EncarteVerso(ImgBot1, dateTimePicker.Value.ToShortDateString(), ListaProdutos);
                }
            }
                
        }
        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Novo || Editar)
            {
                if (cbTipo.SelectedIndex == 0)
                {
                    picEncarte.BackgroundImage = EncarteHelper.EncarteFrente(ImgTop1, dateTimePicker.Value.ToShortDateString(), ListaProdutos);
                }
                else
                {
                    picEncarte.BackgroundImage = EncarteHelper.EncarteVerso(ImgBot1, dateTimePicker.Value.ToShortDateString(), ListaProdutos);
                }
            }
           
        }
        private void btnImg_Click(object sender, EventArgs e)
        {
            posLista = int.Parse(((Panel)sender).Name.Replace("btnImg", ""));
           
            if (ListaProdutos.Count > posLista)
            {

                txtNomeProduto.Text = ListaProdutos[posLista].Nome;
                txtValorProduto.Text = ListaProdutos[posLista].Valor;
                picProduto.BackgroundImage = ListaProdutos[posLista].Img;
                InterfaceProduto(true);
                txtNomeProduto.Focus();
                DialogResult dialog = MessageBox.Show("Buscar Imagem Pc ?", "Local de Buscar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    using (OpenFileDialog open = new OpenFileDialog())
                    {
                        open.Filter = "Image Files(*.jpg;*.png;)|*.jpg;*.png";
                        if (open.ShowDialog() == DialogResult.OK)
                        {
                            Image img = Image.FromFile(open.FileName);
                            Image ImgNewSize = ImagemHelper.ResizeImage(img, 660, 610);



                            picProduto.BackgroundImage = null;
                            picProduto.BackgroundImage = ImgNewSize;
                            txtNomeProduto.Text = open.SafeFileName.Replace(".jpg", "");

                        }
                    }
                }
                

            }
        }
        private void btnConfirmarProduto_Click(object sender, EventArgs e)
        {
            if (txtNomeProduto.Text.Trim().Length>0 && txtValorProduto.Text.Trim().Length > 0 && picProduto.BackgroundImage!=null)
            {
                EncarteItemHelper item = new EncarteItemHelper();
                item.Nome = txtNomeProduto.Text;
                item.Valor = txtValorProduto.Text;
                item.Img = (Bitmap)picProduto.BackgroundImage;
                Panel btn = (Panel)this.Controls.Find("btnImg"+posLista, true)[0];

                btn.BackgroundImage = picProduto.BackgroundImage;
                ListaProdutos[posLista] = item;
                InterfaceProduto(false);
                txtNomeProduto.Text = string.Empty;
                txtValorProduto.Text = string.Empty;
                picProduto.BackgroundImage = null;
                if (cbTipo.SelectedIndex == 0)
                {
                    picEncarte.BackgroundImage = EncarteHelper.EncarteFrente(ImgTop1, dateTimePicker.Value.ToShortDateString(), ListaProdutos);
                }
                else
                {
                    picEncarte.BackgroundImage = EncarteHelper.EncarteVerso(ImgBot1, dateTimePicker.Value.ToShortDateString(), ListaProdutos);
                }

            }
            else
            {
                MessageBox.Show("Verifique os Dados (Nome/Valor/Imagem).","Dados Faltando",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void btnDeletarProduto_Click(object sender, EventArgs e)
        {
            ListaProdutos[posLista].Nome = string.Empty;
            ListaProdutos[posLista].Valor = string.Empty;
            ListaProdutos[posLista].Img = null;
            Panel btn = (Panel)this.Controls.Find("btnImg" + posLista, true)[0];
            btn.BackgroundImage = null;
            InterfaceProduto(false);
            txtNomeProduto.Text = string.Empty;
            txtValorProduto.Text = string.Empty;
            picProduto.BackgroundImage = null;
            if (cbTipo.SelectedIndex == 0)
            {
                picEncarte.BackgroundImage = EncarteHelper.EncarteFrente(ImgTop1, dateTimePicker.Value.ToShortDateString(), ListaProdutos);
            }
            else
            {
                picEncarte.BackgroundImage = EncarteHelper.EncarteVerso(ImgBot1, dateTimePicker.Value.ToShortDateString(), ListaProdutos);
            }
        }
        private void picProduto_DoubleClick(object sender, EventArgs e)
        {
            openChildForm(new FrmPesquisarImagem(this));
        }
        private void picEncarte_DoubleClick(object sender, EventArgs e)
        {
            if (picEncarte.BackgroundImage != null)
            {
                FrmEncartePreview f = new FrmEncartePreview((Bitmap)picEncarte.BackgroundImage);
                f.ShowDialog();
            }
        }
        private void btnCancelarEncarte_Click(object sender, EventArgs e)
        {
            Novo = false;
            Editar = false;
            Limpar();
            LimparBtnProduto();
            InterfaceEncarte(true);
            InterfaceBtnProduto(true);
            posLista = 0;
            picEncarte.BackgroundImage = null;
            AlimentarListaVazia();
            btnNovoEncarte.Enabled = true;
            btnEditarEncarte.Enabled = true;
            btnCancelarEncarte.Enabled = false;
            btnSalvarEncarte.Enabled = false;

        }
        private void dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Encarte encarte = new Encarte();
            encarte.Id = int.Parse(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            encarte.Nome = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            encarte.Validade = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            encarte.Tipo = int.Parse(dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString());
            encarte.Frente = int.Parse(dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString());

            Novo = false;
            Editar = false;
            Limpar();
            LimparBtnProduto();
            InterfaceBtnProduto(false);
            InterfaceEncarte(false);
            InterfaceProduto(false);
            btnNovoEncarte.Enabled = true;
            btnEditarEncarte.Enabled = true;
            btnCancelarEncarte.Enabled = false;
            btnSalvarEncarte.Enabled = false;
            ExibirEncarte(encarte);
            btnNovoEncarte.Enabled = true;
            btnEditarEncarte.Enabled = true;
            btnCancelarEncarte.Enabled = false;
            btnSalvarEncarte.Enabled = false;
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count>0)
            {

                Encarte encarte = new Encarte();
                encarte.Id = int.Parse(dataGridView.SelectedRows[0].Cells[0].Value.ToString());
                encarte.Nome = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
                encarte.Validade = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
                //encarte.Tipo = dataGridView.SelectedRows[0].Cells[3].Value.ToString();

            }
        }
    }
}
