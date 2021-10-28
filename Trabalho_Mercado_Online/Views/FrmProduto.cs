using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Trabalho_Mercado_Online.Helpers;
using Trabalho_Mercado_Online.Models;
using Trabalho_Mercado_Online.Controllers;
using System.Speech.Synthesis;


namespace Trabalho_Mercado_Online.Views
{
    public partial class FrmProduto : Form
    {
        #region Variaveis 
        bool novo = false;
        bool editar = false;
        public string pathImagem = string.Empty;
        int ultimoProduto = 0;
        List<int> ListaId = new List<int>();
        private static SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        private Form activeForm = null;
        #endregion

        #region Funções 
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
        //Fala
        void Falar()
        {
            synthesizer.SpeakAsyncCancelAll();
            synthesizer.SpeakAsync(txtPronuncia.Text);
            synthesizer.Volume = 100;
            synthesizer.Rate = 1;
        }

        //Dados
        Retorno CapturarDados(Produtos obj)
        {
            Retorno retorno = new Retorno();

            obj.Id = int.Parse(lblId.Text);
            if (txtDescricao.Text.Length > 0)
            {
                obj.Descricao = txtDescricao.Text.ToUpper();
            }
            else
            {
                retorno.Evento = false;
                retorno.Mensagem = "Produto sem Descrição";
                txtDescricao.Focus();
                return retorno;
            }

            if (txtPronuncia.Text.Length > 0)
            {
                obj.Pronuncia = txtPronuncia.Text;
            }
            else
            {
                retorno.Evento = false;
                retorno.Mensagem = "Produto sem Pronuncia";
                txtPronuncia.Focus();
                return retorno;
            }

            obj.Img = "" + obj.Id; 
            obj.CodigoLoja = lblCodigoLoja.Text;

            if (Double.TryParse(txtCusto.Text, out double v1))
            {
                obj.CustoUnitario = double.Parse(txtCusto.Text);
            }
            else
            {
                retorno.Evento = false;
                retorno.Mensagem = "Custo Incoreto";
                txtCusto.Focus();
                return retorno;
            }

            if (Double.TryParse(txtVenda.Text, out double v2))
            {
                obj.ValorVenda = double.Parse(txtVenda.Text);
            }
            else
            {
                retorno.Evento = false;
                retorno.Mensagem = "Valor de Venda Incoreto";
                txtVenda.Focus();
                return retorno;
            }

            if (Double.TryParse(txtPromocao.Text, out double v3))
            {
                obj.ValorPromocao = double.Parse(txtPromocao.Text);
            }
            else
            {
                retorno.Evento = false;
                retorno.Mensagem = "Valor de Promoção Incoreto";
                txtPromocao.Focus();
                return retorno;
            }

            if (txtGramatura.Text.Length > 0 && cbGramatura.Text.Length > 0)
            {
                obj.Gramatura = txtGramatura.Text + cbGramatura.Text;
            }
            else
            {
                retorno.Evento = false;
                retorno.Mensagem = "Valores de Gramatura Incoretos";
                txtGramatura.Focus();
                return retorno;
            }

            if (cbEmbalagem.Text.Length > 0)
            {
                obj.Embalagem = cbEmbalagem.Text;
            }
            else
            {
                retorno.Evento = false;
                retorno.Mensagem = "Valor de Embalagem Incoreto";
                cbEmbalagem.Focus();
                return retorno;
            }

            if (novo==true)
            {
                if (pathImagem.Length == 0)
                {
                    retorno.Evento = false;
                    retorno.Mensagem = "Produto sem Imagem";
                    return retorno;
                }

                if (txtCodigoBarra.Text.Length > 0)
                {
                    if (Global.Listas.ProdutosCodigoBarra.FindAll(x => x.CodigoBarra.Equals(txtCodigoBarra.Text.Trim())).Count > 0)
                    {
                        retorno.Evento = false;
                        retorno.Mensagem = "Codigo de Barra já Cadastrado";
                        txtCodigoBarra.Text = string.Empty;
                        txtCodigoBarra.Focus();
                        return retorno;
                    }

                }
                else
                {
                    retorno.Evento = false;
                    retorno.Mensagem = "Produto sem Código de Barra";
                    txtCodigoBarra.Focus();
                    return retorno;
                }
            }
           

           

            obj.Peso = lblPeso.Text;

            obj.IgualaProduto = int.Parse(nUDIgualaProduto.Value.ToString());
          

            obj.ItensCaixa = int.Parse(nUDItensCaixa.Value.ToString());
            obj.Volume = int.Parse(nUDVolume.Value.ToString());
            obj.Validade = chkValidade.Checked;
            obj.Informacao = txtInformacao.Text;

            return retorno;
        }//erro
        void ExibirDados(Produtos obj)
        {
            Limpar();
            lblId.Text = obj.Id.ToString();
            lblCodigoLoja.Text = obj.CodigoLoja;

            txtDescricao.Text = obj.Descricao;
            txtPronuncia.Text = obj.Pronuncia;

            txtCusto.Text = obj.CustoUnitario.ToString("F2");

            txtVenda.Text = obj.ValorVenda.ToString("F2");
            double lucroV = obj.ValorVenda - obj.CustoUnitario;
            double margemV = (lucroV / obj.CustoUnitario) * 100;
            string margemVV = margemV.ToString("F2");
            txtVendaMargem.Text = margemVV;



            txtPromocao.Text = obj.ValorPromocao.ToString("F2");
            double lucroP = obj.ValorPromocao - obj.CustoUnitario;
            double margemP = (lucroP / obj.CustoUnitario) * 100;
            string margemPP = margemP.ToString("F2");
            txtPromocaoMargem.Text = margemPP;

            #region Gramatura
            if (obj.Gramatura.Contains("Kg"))
            {
                cbGramatura.SelectedIndex = 0;
            }
            if (obj.Gramatura.Contains("gr"))
            {
                cbGramatura.SelectedIndex = 1;
            }
            if (obj.Gramatura.Contains("Lt"))
            {
                cbGramatura.SelectedIndex = 2;
            }
            if (obj.Gramatura.Contains("ml"))
            {
                cbGramatura.SelectedIndex = 3;
            }
            if (obj.Gramatura.Contains("Und"))
            {
                cbGramatura.SelectedIndex = 4;
            }
            #endregion

            txtGramatura.Text = obj.Gramatura.Replace("Kg", "").Replace("gr", "").Replace("Lt", "").Replace("ml", "").Replace("Und", "");

            #region Embalagem
            if (obj.Embalagem.Contains("PCT"))
            {
                cbEmbalagem.SelectedIndex = 0;
            }
            if (obj.Embalagem.Contains("UND"))
            {
                cbEmbalagem.SelectedIndex = 1;
            }
            if (obj.Embalagem.Contains("CX"))
            {
                cbEmbalagem.SelectedIndex = 2;
            }
            if (obj.Embalagem.Contains("PESO"))
            {
                cbEmbalagem.SelectedIndex = 3;
            }
            #endregion

            lblPeso.Text = obj.Peso;

            chkValidade.Checked = true;

            nUDIgualaProduto.Value = obj.IgualaProduto;
            lblUltimoIguala.Text = RetornoUltimoIguala();
            nUDItensCaixa.Value = obj.ItensCaixa;
            nUDVolume.Value = obj.Volume;

            txtInformacao.Text = obj.Informacao;

            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            
            pictureBox.ImageLocation = obj.Img;
            CarregarGrid(obj.Id);


        }
        void CarregarGrid(int id_Local)
        {
            var lista = new List<CodigoDeBarraGrid>();
            var listaCodigos = Global.Listas.ProdutosCodigoBarra.FindAll(x => x.CodigoProduto == id_Local);

            foreach (var item in listaCodigos)
            {
                lista.Add(new CodigoDeBarraGrid { id = item.Id, codigoBarra = item.CodigoBarra });
            }
            dataGridView.DataSource = lista;
            dataGridView.Columns[0].Width = 50;
        }
        string RetornoUltimoIguala()
        {
            int r = 0;
            foreach (var item in Global.Listas.Produtos)
            {
                if (item.IgualaProduto>r)
                {
                    r = item.IgualaProduto;
                }
            }
            return r.ToString();
        }

        //Layout
        void AberturaForm()
        {
            novo = false;
            editar = false;
            txtDescricao.Focus();

            btnNovo.Enabled = true;
            btnEditar.Enabled = true;
            btnGravar.Enabled = false;
            btnDeletar.Text = "    Deletar";

            txtDescricao.Enabled = false;
            txtPronuncia.Enabled = false;
            txtCusto.Enabled = false;
            txtVenda.Enabled = false;
            txtVendaMargem.Enabled = false;
            txtPromocao.Enabled = false;
            txtPromocaoMargem.Enabled = false;
            cbGramatura.Enabled = false;
            txtGramatura.Enabled = false;
            cbEmbalagem.Enabled = false;

            chkValidade.Enabled = false;
            nUDIgualaProduto.Enabled = false;
            lblUltimoIguala.Enabled = false;
            nUDItensCaixa.Enabled = false;
            nUDVolume.Enabled = false;
            txtInformacao.Enabled = false;
            btnCodigoBarra.Visible = false;
            btnInserirImagem.Enabled = false;
            btnPesquisarImagem.Enabled = false;
            btnOuvir.Enabled = false;
        }
        void BtnGravarLayout()
        {
            btnNovo.Enabled = true;
            btnEditar.Enabled = true;
            btnGravar.Enabled = false;
            btnDeletar.Text = "    Deletar";

            txtDescricao.Enabled = false;
            txtPronuncia.Enabled = false;
            txtCusto.Enabled = false;
            txtVenda.Enabled = false;
            txtVendaMargem.Enabled = false;
            txtPromocao.Enabled = false;
            txtPromocaoMargem.Enabled = false;
            cbGramatura.Enabled = false;
            txtGramatura.Enabled = false;
            cbEmbalagem.Enabled = false;

            chkValidade.Enabled = false;
            nUDIgualaProduto.Enabled = false;
            lblUltimoIguala.Enabled = false;
            nUDItensCaixa.Enabled = false;
            nUDVolume.Enabled = false;
            txtInformacao.Enabled = false;
            btnCodigoBarra.Visible = false;
            btnInserirImagem.Enabled = false;
            btnPesquisarImagem.Enabled = false;
            btnOuvir.Enabled = false;
        }
        void BtnNovoLayout()
        {
            novo = true;
            editar = false;

            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnGravar.Enabled = true;
            btnDeletar.Text = "  Cancelar";

            txtDescricao.Enabled = true;
            txtPronuncia.Enabled = true;
            txtCusto.Enabled = true;
            txtVenda.Enabled = true;
            txtVendaMargem.Enabled = true;
            txtPromocao.Enabled = true;
            txtPromocaoMargem.Enabled = true;
            cbGramatura.Enabled = true;
            txtGramatura.Enabled = true;
            cbEmbalagem.Enabled = true;

            chkValidade.Enabled = true;
            nUDIgualaProduto.Enabled = true;
            lblUltimoIguala.Enabled = true;
            nUDItensCaixa.Enabled = true;
            nUDVolume.Enabled = true;
            txtInformacao.Enabled = true;
            btnCodigoBarra.Visible = false;
            btnInserirImagem.Enabled = true;
            btnPesquisarImagem.Enabled = true;
            btnOuvir.Enabled = true;
        }
        void BtnEditarLayout()
        {
            novo = false;
            editar = true;

            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnGravar.Enabled = true;
            btnDeletar.Text = "  Cancelar";

            txtDescricao.Enabled = true;
            txtPronuncia.Enabled = true;
            txtCusto.Enabled = true;
            txtVenda.Enabled = true;
            txtVendaMargem.Enabled = true;
            txtPromocao.Enabled = true;
            txtPromocaoMargem.Enabled = true;
            cbGramatura.Enabled = true;
            txtGramatura.Enabled = true;
            cbEmbalagem.Enabled = true;

            chkValidade.Enabled = true;
            nUDIgualaProduto.Enabled = true;
            lblUltimoIguala.Enabled = true;
            nUDItensCaixa.Enabled = true;
            nUDVolume.Enabled = true;
            txtInformacao.Enabled = true;
           
            btnCodigoBarra.Visible = true;
            btnInserirImagem.Enabled = true;
            btnPesquisarImagem.Enabled = true;
            btnOuvir.Enabled = true;
        }
        void Limpar()
        {
            pathImagem = string.Empty;
            novo = false;
            editar = false;

            lblId.Text = "0";
            lblCodigoLoja.Text = "0";

            txtDescricao.Text = string.Empty;
            txtPronuncia.Text = string.Empty;
            txtCodigoBarra.Text = string.Empty;

            txtCusto.Text = string.Empty;
            txtVenda.Text = string.Empty;
            txtVendaMargem.Text = string.Empty;
            txtPromocao.Text = string.Empty;
            txtPromocaoMargem.Text = string.Empty;

            cbGramatura.SelectedIndex = 0;
            txtGramatura.Text = string.Empty;

            cbEmbalagem.SelectedIndex = 0;
            lblPeso.Text = "00000";

            chkValidade.Checked = true;

            nUDIgualaProduto.Value = 0;
            lblUltimoIguala.Text = RetornoUltimoIguala();
            nUDItensCaixa.Value = 0;
            nUDVolume.Value = 0;

            txtInformacao.Text = string.Empty;

            txtPesquisar.Text = string.Empty;

            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureBox.ImageLocation = null;
            pictureBox.Image = null;
            pictureBox.BackgroundImage = null;
            
            dataGridView.DataSource = new List<CodigoDeBarraGrid>();
        }
        #endregion

        #region Eventos 
        public FrmProduto(Produtos obj,List<int>ListaIdLocal)
        {
            InitializeComponent();
            AberturaForm();
            Limpar();
           
            if (ListaIdLocal.Count>0)
            {
                ListaId.AddRange(ListaIdLocal);
                ListaId.Sort((x,y) => x.CompareTo(y));
                Produtos p = Global.Listas.Produtos.Find(x=>x.Id==ListaId[0]);
                lblListaItens.Visible = true;
                lblListaItens.Text = ListaId.Count+ " Itens na Lista";
                ExibirDados(p);
                CarregarGrid(p.Id);
                if (ListaIdLocal.Count == 1)
                {
                    lblListaItens.Visible = false;
                }
                else
                {
                    txtPesquisar.Visible = false;
                    btnPesquisar.Visible = false;
                    lblAviso.Visible = false;
                }
            }
            else
            {
                if (obj.Id > 0)
                {
                    ExibirDados(obj);
                    CarregarGrid(obj.Id);
                }
                else
                {
                    novo = true;
                    BtnNovoLayout();
                }
            }
        }

        //Btns
        private void btnNovo_Click(object sender, EventArgs e)
        {
            Limpar();
            BtnNovoLayout();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            ultimoProduto = int.Parse(lblId.Text);
            pathImagem = string.Empty;
            if (ultimoProduto>0)
            {
                BtnEditarLayout();
            }
            else
            {
                MessageBox.Show("Sem Registro para Editar");
            }
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            Produtos p = new Produtos();
            ProdutosCodigoBarra pCB = new ProdutosCodigoBarra();
            var retorno = CapturarDados(p);
            if (retorno.Evento)
            {
                p = ProdutosController.Gravar(p);
                
                BlobStorage.Upload("produtos",p.Id.ToString(),pathImagem);

                if (novo)
                {
                    pCB.CodigoBarra = txtCodigoBarra.Text.Trim();
                    pCB.CodigoProduto = p.Id;
                    ProdutosCodigoBarraController.Gravar(pCB);
                    Global.Listas.ProdutosCodigoBarra = ProdutosCodigoBarraController.GetAll();
                }
               
                
                Global.Listas.Produtos = ProdutosController.GetAll();
               
                ExibirDados(p);
                BtnGravarLayout();
                
                MessageBox.Show("Atualizado", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(retorno.Mensagem, "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (btnDeletar.Text.Equals("  Cancelar"))
            {
                DialogResult dialog = MessageBox.Show("Esta em processo de edição, deseja sair ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    AberturaForm();
                    Limpar();
                    if (Global.Listas.Produtos.Count>0)
                    {
                        if (ultimoProduto>0)
                        {
                            var p = Global.Listas.Produtos.Find(x => x.Id == ultimoProduto);
                            ExibirDados(p);
                        }
                        else
                        {
                            var p = Global.Listas.Produtos[0];
                            ExibirDados(p);
                        }
                    }
                }
            }
            else
            {
                int idDeletar = int.Parse(lblId.Text);
                if (idDeletar > 0)
                {
                    DialogResult dialog = MessageBox.Show("ATENÇÃO! Deseja Deletar o Produto? é irreversível.", "Perigo!", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (dialog == DialogResult.Yes)
                    {
                        dialog = MessageBox.Show("ATENÇÃO! Tem Certeza? O Registro será Deletado.", "Perigo!", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                        if (dialog == DialogResult.Yes)
                        {
                            var p = Global.Listas.Produtos.Find(x => x.Id == int.Parse(lblId.Text));
                            ProdutosController.Deletar(p);
                            BlobStorage.Deletar("produtos", p.Id.ToString());

                            if (ListaId.Count>0)
                            {
                                var li = ListaId.FindAll(x => x == p.Id);
                                if (li.Count>0)
                                {
                                    ListaId.Remove(p.Id);
                                }
                            }
                            var listaCategorias = Global.Listas.ProdutosCategoria.FindAll(x => x.CodigoProduto == p.Id);
                            foreach (var item in listaCategorias)
                            {
                                ProdutosCategoriaController.Deletar(item);
                            }

                            var listaCodigoBarra = Global.Listas.ProdutosCodigoBarra.FindAll(x => x.CodigoProduto == p.Id);
                            foreach (var item in listaCodigoBarra)
                            {
                                ProdutosCodigoBarraController.Deletar(item);
                            }
                            Global.Listas.Produtos = ProdutosController.GetAll();
                            Global.Listas.ProdutosCategoria = ProdutosCategoriaController.GetAll();
                            Global.Listas.ProdutosCodigoBarra = ProdutosCodigoBarraController.GetAll();
                            Limpar();
                            AberturaForm();
                            if (Global.Listas.Produtos.Count > 0)
                            {
                                ExibirDados(Global.Listas.Produtos[0]);
                            }
                            MessageBox.Show("Atualizado", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Sem Registro para Deletar");
                }
                
            }
        }
        private void btnInserirImagem_Click(object sender, EventArgs e)
        {
            pathImagem = string.Empty;
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg;*.png;)|*.jpg;*.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pathImagem = open.FileName;
                Image img = Image.FromFile(pathImagem);
                Image ImgNewSize = ImagemService.ResizeImage(img, 1000, 1200);
                ImagemService.SaveImg(ImgNewSize);
                
                pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                pictureBox.Image = null;
                pictureBox.BackgroundImage = null;
                pathImagem = System.IO.Directory.GetCurrentDirectory() + "\\Image.jpg";
                pictureBox.ImageLocation = pathImagem;
            }
        }
        private void btnPesquisarImagem_Click(object sender, EventArgs e)
        {
            pathImagem = string.Empty;
            openChildForm(new FrmPesquisarImagem(this,txtDescricao.Text));
        }

        //Margem Venda
        private void txtCusto_Leave(object sender, EventArgs e)
        {
            double teste = 0;
            if (Double.TryParse(txtCusto.Text, out teste) == false)
            {
                txtCusto.Text = "0,00";
            }
            else
            {
                double txt = Double.Parse(txtCusto.Text);
                txtCusto.Text = txt.ToString("F2");
            }

            if (Double.TryParse(txtCusto.Text, out teste) && Double.TryParse(txtVenda.Text, out teste))
            {
                double lucro = double.Parse(txtVenda.Text) - double.Parse(txtCusto.Text);
                double margemD = (lucro / double.Parse(txtCusto.Text)) * 100;
                string margem = margemD.ToString("F2");
                txtVendaMargem.Text = margem;
                double txt = Double.Parse(txtCusto.Text);
                txtCusto.Text = txt.ToString("F2");
            }
            if (Double.TryParse(txtCusto.Text, out teste) && Double.TryParse(txtPromocao.Text, out teste))
            {
                double lucro = double.Parse(txtPromocao.Text) - double.Parse(txtCusto.Text);
                double margemD = (lucro / double.Parse(txtCusto.Text)) * 100;
                string margem = margemD.ToString("F2");
                txtPromocaoMargem.Text = margem;
                double txt = Double.Parse(txtCusto.Text);
                txtCusto.Text = txt.ToString("F2");
            }
        }
        private void txtVenda_Leave(object sender, EventArgs e)
        {
            double teste = 0;
            if (Double.TryParse(txtVenda.Text, out teste) && Double.TryParse(txtCusto.Text, out teste))
            {
                double lucro = double.Parse(txtVenda.Text) - double.Parse(txtCusto.Text);
                double margemD = (lucro / double.Parse(txtCusto.Text)) * 100;
                string margem = margemD.ToString("F2");
                txtVendaMargem.Text = margem;
            }
            else
            {
                txtVenda.Text = "0,00";
                txtVendaMargem.Text = "0,00";
            }
        }
        private void txtVendaMargem_Leave(object sender, EventArgs e)
        {
            if (Double.TryParse(txtVendaMargem.Text, out Double v1) && Double.TryParse(txtCusto.Text, out Double v2))
            {
                double custo = double.Parse(txtCusto.Text);
                double margemD = double.Parse(txtVendaMargem.Text) / 100;
                double vendaD = custo + (custo * margemD);


                string venda = vendaD.ToString("F2");
                txtVenda.Text = venda;

            }
            else
            {
                txtVenda.Text = "0,00";
                txtVendaMargem.Text = "0,00";
            }
        }

        //Margem Promoção
        private void txtPromocao_Leave(object sender, EventArgs e)
        {
            double teste = 0;
            if (Double.TryParse(txtPromocao.Text, out teste) && Double.TryParse(txtCusto.Text, out teste))
            {
                double lucro = double.Parse(txtPromocao.Text) - double.Parse(txtCusto.Text);
                double margemD = (lucro / double.Parse(txtCusto.Text)) * 100;
                string margem = margemD.ToString("F2");
                txtPromocaoMargem.Text = margem;
            }
            else
            {
                txtPromocao.Text = "0,00";
                txtPromocaoMargem.Text = "0,00";
            }
        }
        private void txtPromocaoMargem_Leave(object sender, EventArgs e)
        {
            if (Double.TryParse(txtPromocaoMargem.Text, out Double v1) && Double.TryParse(txtCusto.Text, out Double v2))
            {
                double custo = double.Parse(txtCusto.Text);
                double margemD = double.Parse(txtPromocaoMargem.Text) / 100;
                double vendaD = custo + (custo * margemD);


                string venda = vendaD.ToString("F2");
                txtPromocao.Text = venda;

            }
            else
            {
                txtPromocao.Text = "0,00";
                txtPromocaoMargem.Text = "0,00";
            }
        }

        //Datagrid
        private void dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (editar)
            {
                int id = 0;
                try
                {
                    id = int.Parse(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
                catch { }
                if (id > 0)
                {
                    var dialog = MessageBox.Show("Deseja Deletar este Registro ?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        var valor = Global.Listas.ProdutosCodigoBarra.Find(x => x.Id == id);
                        ProdutosCodigoBarraController.Deletar(valor);
                        Global.Listas.ProdutosCodigoBarra = ProdutosCodigoBarraController.GetAll();
                        int codigo_produto = int.Parse(lblId.Text);
                        CarregarGrid(codigo_produto);
                        MessageBox.Show("Atualizado", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void btnCodigoBarra_Click(object sender, EventArgs e)
        {
            if (editar)
            {
                if (txtCodigoBarra.Text.Length > 5)
                {
                    ProdutosCodigoBarra p = new ProdutosCodigoBarra();
                    p.CodigoBarra = txtCodigoBarra.Text;
                    p.CodigoProduto = int.Parse(lblId.Text);


                    var teste = Global.Listas.ProdutosCodigoBarra.FindAll(x => x.CodigoBarra.Equals(p.CodigoBarra));
                    if (teste.Count == 0)
                    {
                        ProdutosCodigoBarraController.Gravar(p);
                        Global.Listas.ProdutosCodigoBarra = ProdutosCodigoBarraController.GetAll();
                        CarregarGrid(p.CodigoProduto);
                        MessageBox.Show("Atualizado", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Codigo de Barra ja Cadastrado", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Codigo de Barra Incorreto", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtCodigoBarra.Text = string.Empty;
            }
        }

        //Pesquisa
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (txtPesquisar.Text.Length > 5)
            {
                ProdutosCodigoBarra pCodigoBarra = new ProdutosCodigoBarra();
                pCodigoBarra = Global.Listas.ProdutosCodigoBarra.Find(x => x.CodigoBarra.Equals(txtPesquisar.Text));
                if (pCodigoBarra != null)
                {
                    bool continuar = true;
                    if (novo || editar)
                    {
                        DialogResult dialog = MessageBox.Show("Esta em processo de edição, deseja sair ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialog == DialogResult.No)
                        {
                            continuar = false;
                        }
                    }
                    if (continuar)
                    {
                        Limpar();
                        AberturaForm();
                        var produto = Global.Listas.Produtos.Find(x => x.Id == pCodigoBarra.CodigoProduto);
                        ExibirDados(produto);
                    }
                }
                else
                {
                    MessageBox.Show("Produto não Encontrado", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                if (txtPesquisar.Text.Length > 0)
                {
                    if (int.TryParse(txtPesquisar.Text, out int v1))
                    {
                        int codigo = int.Parse(txtPesquisar.Text);
                        var produto = Global.Listas.Produtos.Find(x => x.Id == codigo);
                        if (produto != null)
                        {
                            bool continuar = true;
                            if (novo || editar)
                            {
                                DialogResult dialog = MessageBox.Show("Esta em processo de edição, deseja sair ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dialog == DialogResult.No)
                                {
                                    continuar = false;
                                }
                            }
                            if (continuar)
                            {
                                Limpar();
                                AberturaForm();
                                ExibirDados(produto);
                              
                            }
                        }
                        else
                        {
                            MessageBox.Show("Produto não Encontrado", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Formato Incorreto", "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            txtPesquisar.Text = string.Empty;
        }
        private void txtPesquisar_KeyPress(object sender, KeyPressEventArgs e)
        {
            var tecla = e.KeyChar;
            if (tecla.ToString().Equals("\r"))
            {
                btnPesquisar.PerformClick();
            }
        }

        //Voz
        private void btnOuvir_Click(object sender, EventArgs e)
        {
            if (txtPronuncia.Text.Length > 0)
            {
                Falar();
            }
        }


        //Passagem de Produtos
        private void btnPrimeiroRegistro_Click(object sender, EventArgs e)
        {
            bool continuar = true;
            if (novo || editar)
            {
                DialogResult dialog = MessageBox.Show("Esta em processo de edição, deseja sair ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                {
                    continuar = false;
                }
            }
            if (continuar && Global.Listas.Produtos.Count>0)
            {
                var ListaProdutos = new List<Produtos>();
                ListaProdutos.AddRange(Global.Listas.Produtos);
                ListaProdutos.Sort((x,y)=>x.Id.CompareTo(y.Id));
                Limpar();
                AberturaForm();
                if (ListaId.Count > 1)
                {
                    ExibirDados(ListaProdutos.Find(x=>x.Id==ListaId[0]));
                }
                else
                {
                    ExibirDados(ListaProdutos[0]);
                }
            }
        }
        private void btnRegristroAnterior_Click(object sender, EventArgs e)
        {
            bool continuar = true;
            if (novo || editar)
            {
                DialogResult dialog = MessageBox.Show("Esta em processo de edição, deseja sair ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                {
                    continuar = false;
                }
            }
            if (continuar && Global.Listas.Produtos.Count > 0)
            {
                var ListaProdutos = new List<Produtos>();
                ListaProdutos.AddRange(Global.Listas.Produtos);
                ListaProdutos.Sort((x, y) => x.Id.CompareTo(y.Id));
                int idAtual = int.Parse(lblId.Text);
                Limpar();
                AberturaForm();
                if (ListaId.Count > 1)
                {
                    int indexAtual = ListaId.FindIndex(x=>x == idAtual);
                    if (indexAtual > 0)
                    {
                        indexAtual--;
                        ExibirDados(ListaProdutos.Find(x => x.Id == ListaId[indexAtual]));
                    }
                    else
                    {
                        ExibirDados(ListaProdutos.Find(x => x.Id == ListaId[indexAtual]));
                    }
                }
                else
                {
                    
                    if (idAtual > 0 == false)
                    {
                        ExibirDados(ListaProdutos[0]);
                    }
                    else
                    {
                        int indexAtual = ListaProdutos.FindIndex(x => x.Id == idAtual);
                        if (indexAtual > 0)
                        {
                            indexAtual--;
                            ExibirDados(ListaProdutos[indexAtual]);
                        }
                        else
                        {
                            ExibirDados(ListaProdutos[0]);
                        }

                    }
                }
            }
        }
        private void btnProximoRegistro_Click(object sender, EventArgs e)
        {
            bool continuar = true;
            if (novo || editar)
            {
                DialogResult dialog = MessageBox.Show("Esta em processo de edição, deseja sair ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                {
                    continuar = false;
                }
            }
            if (continuar && Global.Listas.Produtos.Count > 0)
            {
                var ListaProdutos = new List<Produtos>();
                ListaProdutos.AddRange(Global.Listas.Produtos);
                ListaProdutos.Sort((x, y) => x.Id.CompareTo(y.Id));
                int idAtual = int.Parse(lblId.Text);
                Limpar();
                AberturaForm();
                if (ListaId.Count > 1)
                {
                    int indexAtual = ListaId.FindIndex(x => x == idAtual);
                    
                    if (indexAtual < ListaId.Count -1)
                    {
                        indexAtual++;
                        ExibirDados(ListaProdutos.Find(x => x.Id == ListaId[indexAtual]));
                    }
                    else
                    {
                        ExibirDados(ListaProdutos.Find(x => x.Id == ListaId[indexAtual]));
                    }
                }
                else
                {
                    if (idAtual>0==false)
                    {
                        ExibirDados(ListaProdutos[0]);
                    }
                    else
                    {
                        int indexAtual = ListaProdutos.FindIndex(x=>x.Id== idAtual);
                        if (indexAtual<ListaProdutos.Count-1)
                        {
                            indexAtual++;
                            ExibirDados(ListaProdutos[indexAtual]);
                        }
                        else
                        {
                            ExibirDados(ListaProdutos[indexAtual]);
                        }

                    }
                }
            }
        }
        private void btnUltimoRegistro_Click(object sender, EventArgs e)
        {
            bool continuar = true;
            if (novo || editar)
            {
                DialogResult dialog = MessageBox.Show("Esta em processo de edição, deseja sair ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                {
                    continuar = false;
                }
            }
            if (continuar && Global.Listas.Produtos.Count > 0)
            {

                var ListaProdutos = new List<Produtos>();
                ListaProdutos.AddRange(Global.Listas.Produtos);
                ListaProdutos.Sort((x, y) => x.Id.CompareTo(y.Id));
                Limpar();
                AberturaForm();
                if (ListaId.Count > 1)
                {
                    ExibirDados(ListaProdutos.Find(x => x.Id == ListaId[ListaId.Count-1]));
                }
                else
                {
                    
                    ExibirDados(ListaProdutos[ListaProdutos.Count-1]);
                }
            }
        }

        #endregion

        
    }
}
