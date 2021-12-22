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
using System.Threading;

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
        private Form activeForm = null;
        #endregion

        #region Funções
        //Inicial
        void OpenForm()
        {
            AtualizarLista_Banco();
            CarregarGrid();
            cbFrente.SelectedIndex = 1;
           
            InterfaceEncarte(false);
            InterfaceProduto(false);
            InterfacePnlsProduto(false);
            AlimentarListaVazia();

            btnNovoEncarte.Enabled = true;
            btnEditarEncarte.Enabled = true;
            btnCancelarEncarte.Enabled = false;
            btnSalvarEncarte.Enabled = false;
        }
        //Banco
        void AtualizarLista_Banco()
        {
            ListaEncarte_Banco = EncarteController.GetAll();
            ListaEncarteItens_Banco = EncarteItemController.GetAll();
        }
        void CarregarGrid()
        {
            if (ListaEncarte_Banco.Count > 0)
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
                dataGridView.Columns[0].Width = 30;
                dataGridView.Columns[1].Width = 170;
                dataGridView.Columns[2].Width = 70;
                dataGridView.Columns[3].Width = 50;
                dataGridView.Columns[4].Width = 50;
            }
        }
        //Tela
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
        //Controle
        void Limpar()
        {
            //Variaveis
            posLista = 0;
            
            //Encarte
            txtNomeEncarte.Text = string.Empty;
            dateTimePicker.Value = DateTime.Now;
            cbFrente.SelectedIndex = 1;
            rbGeral.Enabled = true;
            rbSacolao.Enabled = false;
            rbBiscoito.Enabled = false;
            rbAcougue.Enabled = false;
            rbFinaldeSemana.Enabled = false;

            //Pesquisa
            txtPesquisar.Text = string.Empty;

            //Produto
            picProduto.BackgroundImage = null;
            txtNomeProduto.Text = string.Empty;
            txtValorProduto.Text = string.Empty;

            //PnlsProduto
            LimparPnlsProduto();
            picEncarte.BackgroundImage = null;

            //Geral
            AlimentarListaVazia();
            //AtualizarLista_Banco();
            //CarregarGrid();
        }
        //Esta dentro de limpar
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
            //Reseta Varivel
            posLista = 0;

            //Interface
            txtNomeEncarte.Text = encarte.Nome;
            dateTimePicker.Value = Convert.ToDateTime(encarte.Validade);
            cbFrente.SelectedIndex = encarte.Frente;
            //Caminha Imagem
            string PathTop = $"https://aplicativo.blob.core.windows.net/encarte/top{encarte.Tipo}.jpg";
            string PathBot = $"https://aplicativo.blob.core.windows.net/encarte/bot{encarte.Tipo}.jpg";

            //Banco de Dados
            var list = ListaEncarteItens_Banco.FindAll(x => x.IdEncarte == encarte.Id);
            ListaProdutos = new List<EncarteItemHelper>();

            //Preencher os Pnls
            int pnlCount = 0;
            foreach (var item in list)
            {
                EncarteItemHelper encarteItem = new EncarteItemHelper();
                encarteItem.Nome = item.Produto;
                encarteItem.Valor = item.Valor;
                encarteItem.Img = ImagemHelper.ImagemUrl(item.Img, 660, 610);
                ListaProdutos.Add(encarteItem);

                Panel pnl = (Panel)this.Controls.Find("pnlImg" + pnlCount, true)[0];
                pnl.BackgroundImage = encarteItem.Img;
                pnlCount++;

            }

            //Define Cor
            SolidBrush solid= new SolidBrush(Color.Black);
            switch (encarte.Tipo)
            {
                case 1: rbGeral.Checked = true; solid = new SolidBrush(Color.FromArgb(0, 0, 0)); break;
                case 2: rbSacolao.Checked = true; solid = new SolidBrush(Color.FromArgb(37, 171, 46)); break;
                case 3: rbBiscoito.Checked = true; solid = new SolidBrush(Color.FromArgb(171, 100, 36)); break;
                case 4: rbAcougue.Checked = true; solid = new SolidBrush(Color.FromArgb(254, 17, 0)); break;
                case 5: rbFinaldeSemana.Checked = true; solid = new SolidBrush(Color.FromArgb(49, 191, 253)); break;
            }


            //Define Verso
            if (encarte.Frente==1)
            {
                Bitmap BitImg = ImagemHelper.ImagemUrl(PathTop,3508,1014);
                picEncarte.BackgroundImage = EncarteHelper.EncarteFrente(BitImg, dateTimePicker.Value.ToShortDateString(), ListaProdutos, solid);
            }
            else
            {
                Bitmap BitImg = ImagemHelper.ImagemUrl(PathBot, 3508, 1014);
                picEncarte.BackgroundImage = EncarteHelper.EncarteVerso(BitImg, dateTimePicker.Value.ToShortDateString(), ListaProdutos, solid);
            }

        }
        //Imagem do encarte
        void AtualizarEncarte()
        {
            if (Novo || Editar)
            {
                int valor = 0;
                SolidBrush solid = new SolidBrush(Color.Black);
                if (rbGeral.Checked)
                {
                    valor = 1;
                    solid = new SolidBrush(Color.FromArgb(0, 0, 0));
                }
                if (rbSacolao.Checked)
                {
                    valor = 2;
                    solid = new SolidBrush(Color.FromArgb(37, 171, 46));
                }
                if (rbBiscoito.Checked)
                {
                    valor = 3;
                    solid = new SolidBrush(Color.FromArgb(171, 100, 36));
                }
                if (rbAcougue.Checked)
                {
                    valor = 4;
                    solid = new SolidBrush(Color.FromArgb(254, 17, 0));
                }
                if (rbFinaldeSemana.Checked)
                {
                    valor = 5;
                    solid = new SolidBrush(Color.FromArgb(49, 191, 253));
                }



                string PathTop = $"https://aplicativo.blob.core.windows.net/encarte/top{valor}.jpg";
                string PathBot = $"https://aplicativo.blob.core.windows.net/encarte/bot{valor}.jpg";
                if (cbFrente.SelectedIndex == 1)
                {
                    Bitmap BitImg = ImagemHelper.ImagemUrl(PathTop, 3508, 1014);
                    picEncarte.BackgroundImage = EncarteHelper.EncarteFrente(BitImg, dateTimePicker.Value.ToShortDateString(), ListaProdutos, solid);
                }
                else
                {
                    Bitmap BitImg = ImagemHelper.ImagemUrl(PathBot, 3508, 1014);
                    picEncarte.BackgroundImage = EncarteHelper.EncarteVerso(BitImg, dateTimePicker.Value.ToShortDateString(), ListaProdutos, solid);
                }
            }
        }
        //Interface
        void InterfaceEncarte(Boolean b)
        {
            txtNomeEncarte.Enabled = b;
            dateTimePicker.Enabled = b;
            cbFrente.Enabled = b;
            rbGeral.Enabled = b;
            rbSacolao.Enabled = b;
            rbBiscoito.Enabled = b;
            rbAcougue.Enabled = b;
            rbFinaldeSemana.Enabled = b;

        }
        void InterfaceProduto(Boolean b)
        {
            picProduto.Enabled = b;
            txtNomeProduto.Enabled = b;
            txtValorProduto.Enabled = b;
            btnConfirmarProduto.Enabled = b;
            btnDeletarProduto.Enabled = b;
        }
        void InterfacePnlsProduto(Boolean b)
        {
            pnlImg0.Enabled = b;
            pnlImg1.Enabled = b;
            pnlImg2.Enabled = b;
            pnlImg3.Enabled = b;
            pnlImg4.Enabled = b;
            pnlImg5.Enabled = b;
            pnlImg6.Enabled = b;
            pnlImg7.Enabled = b;
            pnlImg8.Enabled = b;
            pnlImg9.Enabled = b;
            pnlImg10.Enabled = b;
            pnlImg11.Enabled = b;
            pnlImg12.Enabled = b;
            pnlImg13.Enabled = b;
            pnlImg14.Enabled = b;
            pnlImg15.Enabled = b;
            pnlImg16.Enabled = b;
            pnlImg17.Enabled = b;
            pnlImg18.Enabled = b;
            pnlImg19.Enabled = b;
            if (b==true)
            {
                pnlImg0.BackColor = Color.FromArgb(223, 240, 254);
                pnlImg1.BackColor = Color.FromArgb(223, 240, 254);
                pnlImg2.BackColor = Color.FromArgb(223, 240, 254);
                pnlImg3.BackColor = Color.FromArgb(223, 240, 254);
                pnlImg4.BackColor = Color.FromArgb(223, 240, 254);
                pnlImg5.BackColor = Color.FromArgb(223, 240, 254);
                pnlImg6.BackColor = Color.FromArgb(223, 240, 254);
                pnlImg7.BackColor = Color.FromArgb(223, 240, 254);
                pnlImg8.BackColor = Color.FromArgb(223, 240, 254);
                pnlImg9.BackColor = Color.FromArgb(223, 240, 254);
                pnlImg10.BackColor = Color.FromArgb(223, 240, 254);
                pnlImg11.BackColor = Color.FromArgb(223, 240, 254);
                pnlImg12.BackColor = Color.FromArgb(223, 240, 254);
                pnlImg13.BackColor = Color.FromArgb(223, 240, 254);
                pnlImg14.BackColor = Color.FromArgb(223, 240, 254);
                pnlImg15.BackColor = Color.FromArgb(223, 240, 254);
                pnlImg16.BackColor = Color.FromArgb(223, 240, 254);
                pnlImg17.BackColor = Color.FromArgb(223, 240, 254);
                pnlImg18.BackColor = Color.FromArgb(223, 240, 254);
                pnlImg19.BackColor = Color.FromArgb(223, 240, 254);
            }
            else
            {
                pnlImg0.BackColor = Color.White;
                pnlImg1.BackColor = Color.White;
                pnlImg2.BackColor = Color.White;
                pnlImg3.BackColor = Color.White;
                pnlImg4.BackColor = Color.White;
                pnlImg5.BackColor = Color.White;
                pnlImg6.BackColor = Color.White;
                pnlImg7.BackColor = Color.White;
                pnlImg8.BackColor = Color.White;
                pnlImg9.BackColor = Color.White;
                pnlImg10.BackColor = Color.White;
                pnlImg11.BackColor = Color.White;
                pnlImg12.BackColor = Color.White;
                pnlImg13.BackColor = Color.White;
                pnlImg14.BackColor = Color.White;
                pnlImg15.BackColor = Color.White;
                pnlImg16.BackColor = Color.White;
                pnlImg17.BackColor = Color.White;
                pnlImg18.BackColor = Color.White;
                pnlImg19.BackColor = Color.White;
            }
        }
        //Esta dentro de limpar
        void LimparPnlsProduto()
        {
            pnlImg0.BackgroundImage = null;
            pnlImg1.BackgroundImage = null;
            pnlImg2.BackgroundImage = null;
            pnlImg3.BackgroundImage = null;
            pnlImg4.BackgroundImage = null;
            pnlImg5.BackgroundImage = null;
            pnlImg6.BackgroundImage = null;
            pnlImg7.BackgroundImage = null;
            pnlImg8.BackgroundImage = null;
            pnlImg9.BackgroundImage = null;
            pnlImg10.BackgroundImage = null;
            pnlImg11.BackgroundImage = null;
            pnlImg12.BackgroundImage = null;
            pnlImg13.BackgroundImage = null;
            pnlImg14.BackgroundImage = null;
            pnlImg15.BackgroundImage = null;
            pnlImg16.BackgroundImage = null;
            pnlImg17.BackgroundImage = null;
            pnlImg18.BackgroundImage = null;
            pnlImg19.BackgroundImage = null;
        }
        #endregion

       
        //Form
        public FrmEncarte()
        {
            InitializeComponent();
            OpenForm();
        }
       
        //Botões
        private void btnNovoEncarte_Click(object sender, EventArgs e)
        {
            Novo = true;
            Editar = false;
            Limpar();
            InterfaceEncarte(true);
            InterfacePnlsProduto(true);

            btnNovoEncarte.Enabled = false;
            btnEditarEncarte.Enabled = false;
            btnCancelarEncarte.Enabled = true;
            btnSalvarEncarte.Enabled = true;
            txtNomeEncarte.Focus();
            AtualizarEncarte();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtNomeEncarte.Text.Length>0)
            {
                Novo = false;
                Editar = true;
                InterfaceEncarte(true);
                InterfacePnlsProduto(true);
                btnNovoEncarte.Enabled = false;
                btnEditarEncarte.Enabled = false;
                btnCancelarEncarte.Enabled = true;
                btnSalvarEncarte.Enabled = true;
                txtNomeEncarte.Focus();
                AtualizarEncarte();
            }
            else
            {
                MessageBox.Show("Selecione o Encarte antes de Editar!","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void btnCancelarEncarte_Click(object sender, EventArgs e)
        {
            Novo = false;
            Editar = false;
            Limpar();
            InterfaceEncarte(false);
            InterfaceProduto(false);
            InterfacePnlsProduto(false);
            AlimentarListaVazia();
            btnNovoEncarte.Enabled = true;
            btnEditarEncarte.Enabled = true;
            btnCancelarEncarte.Enabled = false;
            btnSalvarEncarte.Enabled = false;
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNomeEncarte.Text.Trim().Length > 0)
            {
                bool banco = false;
                Encarte encarte = new Encarte();
                DialogResult dialog = MessageBox.Show("Deseja Salvar este Encarte no Banco?", "Banco de Dados", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                    AtualizarEncarte();
                    using (Bitmap img = new Bitmap(picEncarte.BackgroundImage))
                    {
                        img.Save(sf.FileName);
                    }
                }
               
                //Banco e Imagem online
                if (banco)
                {
                    //inserido em tabela encarte
                    encarte = new Encarte();
                    encarte.Nome = txtNomeEncarte.Text.ToUpper();
                    encarte.Validade = dateTimePicker.Value.ToShortDateString();
                    encarte.Frente = cbFrente.SelectedIndex;
                    if (rbGeral.Checked)
                    {
                        encarte.Tipo = 1;
                    }
                    if (rbSacolao.Checked)
                    {
                        encarte.Tipo = 2;
                    }
                    if (rbBiscoito.Checked)
                    {
                        encarte.Tipo = 3;
                    }
                    if (rbAcougue.Checked)
                    {
                        encarte.Tipo = 4;
                    }
                    if (rbFinaldeSemana.Checked)
                    {
                        encarte.Tipo = 5;
                    }
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
                            Thread.Sleep(200);
                            string path = System.IO.Directory.GetCurrentDirectory() + "\\Image.jpg";
                            BlobStorageHelper.Upload("encarte", encarteItem.Id.ToString(), path);
                        }
                    }

                    
                }
                Limpar();
                AtualizarLista_Banco();
                CarregarGrid();
                InterfaceEncarte(false);
                InterfaceProduto(false);
                InterfacePnlsProduto(false);
                ExibirEncarte(encarte);
                btnNovoEncarte.Enabled = true;
                btnEditarEncarte.Enabled = true;
                btnCancelarEncarte.Enabled = false;
                btnSalvarEncarte.Enabled = false;
                MessageBox.Show("Finalizado");
            }
            else
            {
                MessageBox.Show("Encarte sem Nome", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
       
        //Interface
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            AtualizarEncarte();
        }
        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarEncarte();
        }
        private void rbGeral_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarEncarte();
        }
        private void rbSacolao_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarEncarte();
        }
        private void rbBiscoito_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarEncarte();
        }
        private void rbAcougue_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarEncarte();
        }
        private void rbFinaldeSemana_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarEncarte();
        }

        //Produto
        private void pnlImg_DoubleClick(object sender, EventArgs e)
        {
            posLista = int.Parse(((Panel)sender).Name.Replace("pnlImg", ""));

            if (ListaProdutos.Count > posLista)
            {

                txtNomeProduto.Text = ListaProdutos[posLista].Nome;
                txtValorProduto.Text = ListaProdutos[posLista].Valor;
                picProduto.BackgroundImage = ListaProdutos[posLista].Img;
                InterfaceProduto(true);
                txtNomeProduto.Focus();
                DialogResult dialog = MessageBox.Show("Buscar Imagem no Computador ?", "Buscar Imagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                            txtNomeProduto.Text = open.SafeFileName.Replace(".jpg", "").Replace(".png","");
                            txtValorProduto.Focus();
                        }
                    }
                }


            }
        }
        private void picProduto_DoubleClick(object sender, EventArgs e)
        {
            openChildForm(new FrmPesquisarImagem(this));
        }
        private void btnConfirmarProduto_Click(object sender, EventArgs e)
        {
            if (txtNomeProduto.Text.Trim().Length > 0 && txtValorProduto.Text.Trim().Length > 0 && picProduto.BackgroundImage != null)
            {
                EncarteItemHelper item = new EncarteItemHelper();
                item.Nome = txtNomeProduto.Text;
                item.Valor = txtValorProduto.Text;
                item.Img = (Bitmap)picProduto.BackgroundImage;
                Panel pnl = (Panel)this.Controls.Find("pnlImg" + posLista, true)[0];

                pnl.BackgroundImage = picProduto.BackgroundImage;
                ListaProdutos[posLista] = item;
                InterfaceProduto(false);
                txtNomeProduto.Text = string.Empty;
                txtValorProduto.Text = string.Empty;
                picProduto.BackgroundImage = null;
                AtualizarEncarte();

            }
            else
            {
                MessageBox.Show("Verifique os Dados (Nome/Valor/Imagem).", "Dados Faltando", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeletarProduto_Click(object sender, EventArgs e)
        {
            ListaProdutos[posLista].Nome = string.Empty;
            ListaProdutos[posLista].Valor = string.Empty;
            ListaProdutos[posLista].Img = null;
            Panel pnl = (Panel)this.Controls.Find("pnlImg" + posLista, true)[0];
            pnl.BackgroundImage = null;
            InterfaceProduto(false);
            txtNomeProduto.Text = string.Empty;
            txtValorProduto.Text = string.Empty;
            picProduto.BackgroundImage = null;
            AtualizarEncarte();
        }
        private void picEncarte_DoubleClick(object sender, EventArgs e)
        {
            if (picEncarte.BackgroundImage != null)
            {
                FrmEncartePreview f = new FrmEncartePreview((Bitmap)picEncarte.BackgroundImage);
                f.ShowDialog();
            }
        }

        //DataGrid
        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            CarregarGrid();
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
            InterfaceEncarte(false);
            InterfaceProduto(false);
            InterfacePnlsProduto(false);
            ExibirEncarte(encarte);
            MessageBox.Show("Encarte Baixado");
            btnNovoEncarte.Enabled = true;
            btnEditarEncarte.Enabled = true;
            btnCancelarEncarte.Enabled = false;
            btnSalvarEncarte.Enabled = false;


        }
        private void btnDeletarEncarte_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DialogResult dialog = MessageBox.Show("Deseja Apagar este Encarte no Banco ?", "Banco de Dados", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    Encarte encarte = new Encarte();
                    encarte.Id = int.Parse(dataGridView.SelectedRows[0].Cells[0].Value.ToString());
                    encarte.Nome = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
                    encarte.Validade = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
                    encarte.Tipo = int.Parse(dataGridView.SelectedRows[0].Cells[3].Value.ToString());
                    encarte.Frente = int.Parse(dataGridView.SelectedRows[0].Cells[4].Value.ToString());
                    var lista = ListaEncarteItens_Banco.FindAll(x => x.IdEncarte == encarte.Id);
                    EncarteController.Deletar(encarte);
                    foreach (var item in lista)
                    {
                        BlobStorageHelper.Deletar("encarte", item.Id.ToString());
                        EncarteItemController.Deletar(item);
                    }
                    Novo = false;
                    Editar = false;
                    Limpar();
                    
                    InterfaceEncarte(false);
                    InterfaceProduto(false);
                    InterfacePnlsProduto(false);
                    AlimentarListaVazia();
                    btnNovoEncarte.Enabled = true;
                    btnEditarEncarte.Enabled = true;
                    btnCancelarEncarte.Enabled = false;
                    btnSalvarEncarte.Enabled = false;

                    AtualizarLista_Banco();
                    CarregarGrid();
                    MessageBox.Show("Encarte Apagado");
                }
            }
        }

       
    }
}
