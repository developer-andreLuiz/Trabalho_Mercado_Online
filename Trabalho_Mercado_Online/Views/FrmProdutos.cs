using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Trabalho_Mercado_Online.Models;
using Trabalho_Mercado_Online.Helpers;
using Trabalho_Mercado_Online.Controllers;
using Trabalho_Mercado_Online.DAO;
using System.Globalization;
using System.Linq;

namespace Trabalho_Mercado_Online.Views
{
    public partial class FrmProdutos : Form
    {
        #region Variaveis 
        //Open Form
        private Form activeForm = null;
        string ListaImprimir = string.Empty;
        #endregion

        #region Funções
        //Form
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

        //Filtro
        public void Filtrar()
        {
            List<ProdutosDataGrid> ListaGrid = new List<ProdutosDataGrid>();
            List<Produto> ListaProdutos = new List<Produto>();

            bool descricao = !String.IsNullOrEmpty(txtDescricao.Text);
            bool promocao = chkPromocao.Checked;
            bool igualaProduto = chkIgualaProduto.Checked;
            bool faltaEditar = chkFaltaEditar.Checked;
            bool editado = chkEditado.Checked;

            bool categoria = chkCategoria.Checked;
            bool semCategoria = chkSemCategoria.Checked;

            bool categoriaNivel1 = chkCategoriaNivel1.Checked;
            bool categoriaNivel2 = chkCategoriaNivel2.Checked;
            bool categoriaNivel3 = chkCategoriaNivel3.Checked;
            //Sem Filtro
            ListaProdutos.AddRange(Global.Listas.Produto);

            if (descricao)
            {
                string txt = StringService.FormatarStringMaiusculo(txtDescricao.Text);
                var listTxt = txt.Split(" ");
                foreach (var item in listTxt)
                {
                    var lt = ListaProdutos.FindAll(x => StringService.FormatarStringMaiusculo(x.Descricao).Contains(item, StringComparison.InvariantCultureIgnoreCase));
                    ListaProdutos = lt;
                }
            }
            if (promocao)
            {
                var lt = ListaProdutos.FindAll(x => x.ValorPromocao > 0);
                ListaProdutos = lt;
            }
            if (igualaProduto)
            {
                var lt = ListaProdutos.FindAll(x => x.IgualaProduto > 0);
                ListaProdutos = lt;
            }
            if (faltaEditar)
            {
                var lt = ListaProdutos.FindAll(x => x.Peso.Equals("00000"));
                ListaProdutos = lt;
            }
            if (editado)
            {
                var lt = ListaProdutos.FindAll(x => x.Peso.Equals("00000")==false);
                ListaProdutos = lt;
            }
            if (semCategoria)
            {
                foreach (var item in Global.Listas.ProdutosCategoria)
                {
                    Produto p = new Produto();
                    p = ListaProdutos.Find(x => x.Id == item.CodigoProduto);
                    ListaProdutos.Remove(p);
                }
            }
            if (categoria)
            {
                if (categoriaNivel1)
                {
                    if (cbNivel1.SelectedValue != null)
                    {
                        int valor1 = int.Parse(cbNivel1.SelectedValue.ToString());
                        var ltCateorias = Global.Listas.ProdutosCategoria.FindAll(x => x.CategoriaNivel1 == valor1);
                        List<Produto> ListaBase = new List<Produto>();
                        ListaBase.AddRange(ListaProdutos);
                        foreach (var item in ListaBase)
                        {
                            var itemcategoria = ltCateorias.Find(x => x.CodigoProduto == item.Id);
                            if (itemcategoria == null)
                            {
                                ListaProdutos.Remove(item);
                            }
                        }
                    }
                }

                if (categoriaNivel2)
                {
                    if (cbNivel2.SelectedValue != null)
                    {
                        int valor1 = int.Parse(cbNivel1.SelectedValue.ToString());
                        int valor2 = int.Parse(cbNivel2.SelectedValue.ToString());
                        var ltCateorias = Global.Listas.ProdutosCategoria.FindAll(x => x.CategoriaNivel1 == valor1 && x.CategoriaNivel2 == valor2);
                        List<Produto> ListaBase = new List<Produto>();
                        ListaBase.AddRange(ListaProdutos);
                        foreach (var item in ListaBase)
                        {
                            var itemcategoria = ltCateorias.Find(x => x.CodigoProduto == item.Id);
                            if (itemcategoria == null)
                            {
                                ListaProdutos.Remove(item);
                            }
                        }
                    }
                }
                else
                {
                    if (cbNivel1.SelectedValue != null)
                    {
                        int valor1 = int.Parse(cbNivel1.SelectedValue.ToString());
                        var ltCateorias = Global.Listas.ProdutosCategoria.FindAll(x => x.CategoriaNivel1 == valor1 && x.CategoriaNivel2 == 0 && x.CategoriaNivel3 == 0);
                        List<Produto> ListaBase = new List<Produto>();
                        ListaBase.AddRange(ListaProdutos);
                        foreach (var item in ListaBase)
                        {
                            var itemcategoria = ltCateorias.Find(x => x.CodigoProduto == item.Id);
                            if (itemcategoria == null)
                            {
                                ListaProdutos.Remove(item);
                            }
                        }


                    }
                }

                if (categoriaNivel3)
                {
                    if (cbNivel3.SelectedValue != null)
                    {
                        int valor1 = int.Parse(cbNivel1.SelectedValue.ToString());
                        int valor2 = int.Parse(cbNivel2.SelectedValue.ToString());
                        int valor3 = int.Parse(cbNivel3.SelectedValue.ToString());
                        var ltCateorias = Global.Listas.ProdutosCategoria.FindAll(x => x.CategoriaNivel1 == valor1 && x.CategoriaNivel2 == valor2 && x.CategoriaNivel3 == valor3);
                        List<Produto> ListaBase = new List<Produto>();
                        ListaBase.AddRange(ListaProdutos);
                        foreach (var item in ListaBase)
                        {
                            var itemcategoria = ltCateorias.Find(x => x.CodigoProduto == item.Id);
                            if (itemcategoria == null)
                            {
                                ListaProdutos.Remove(item);
                            }
                        }


                    }
                }
                else
                {
                    if (categoriaNivel2 && cbNivel2.SelectedValue != null)
                    {
                        int valor1 = int.Parse(cbNivel1.SelectedValue.ToString());
                        int valor2 = int.Parse(cbNivel2.SelectedValue.ToString());
                        var ltCateorias = Global.Listas.ProdutosCategoria.FindAll(x => x.CategoriaNivel1 == valor1 && x.CategoriaNivel2 == valor2 && x.CategoriaNivel3 == 0);
                        List<Produto> ListaBase = new List<Produto>();
                        ListaBase.AddRange(ListaProdutos);
                        foreach (var item in ListaBase)
                        {
                            var itemcategoria = ltCateorias.Find(x => x.CodigoProduto == item.Id);
                            if (itemcategoria == null)
                            {
                                ListaProdutos.Remove(item);
                            }
                        }
                    }
                }

            }

            #region Formatação dos Dados Grid
            foreach (var obj in ListaProdutos)
            {
                ProdutosDataGrid produtosDataGrid = new ProdutosDataGrid();
                produtosDataGrid.Id = obj.Id.ToString();
                produtosDataGrid.Descricao = obj.Descricao + " " + obj.Gramatura + " " + obj.Embalagem;
                produtosDataGrid.Iguala = obj.IgualaProduto.ToString();
                produtosDataGrid.Custo = "R$" + obj.CustoUnitario.ToString("F2");
                produtosDataGrid.Venda = "R$" + obj.ValorVenda.ToString("F2");
                produtosDataGrid.Promoção = "R$" + obj.ValorPromocao.ToString("F2");
                string margem = string.Empty;
                if (obj.ValorPromocao > 0)
                {
                    double lucro = obj.ValorPromocao - obj.CustoUnitario;
                    double margemD = (lucro / obj.CustoUnitario) * 100;
                    margem = margemD.ToString("F2");
                }
                else
                {
                    double lucro = obj.ValorVenda - obj.CustoUnitario;
                    double margemD = (lucro / obj.CustoUnitario) * 100;
                    margem = margemD.ToString("F2");
                }


                produtosDataGrid.Margem = margem.ToString() + "%";
                ListaGrid.Add(produtosDataGrid);
            }
            dataGridView.DataSource = ListaGrid;
            switch (ListaGrid.Count)
            {
                case 0: lblRegistros.Text = $"Sem Registro"; break;
                case 1: lblRegistros.Text = $"1 Registro"; break;
                default: lblRegistros.Text = $"{ListaGrid.Count} Registros"; break;
            }
            switch (dataGridView.SelectedRows.Count)
            {
                case 0: lblSelecionados.Text = $"Nenhum Selecionado"; break;
                case 1: lblSelecionados.Text = $"1 Selecionado"; break;
                default: lblSelecionados.Text = $"{dataGridView.SelectedRows.Count} Selecionados"; break;
            }
            dataGridView.Columns[0].Width = 70;
            dataGridView.Columns[1].Width = 350;
            if (ListaGrid.Count > 0)
            {
                btnAdicionar.Enabled = true;
                btnRemover.Enabled = true;
                btnLimparPromocoes.Enabled = true;
                btnAbrirProdutos.Enabled = true;

                btnAdicionar.Visible = true;
                btnRemover.Visible = true;
                btnLimparPromocoes.Visible = true;
                btnSelecionarTudo.Visible = true;
                lblSelecionados.Visible = true;
                btnAbrirProdutos.Visible = true;

            }
            else
            {
                btnAdicionar.Enabled = false;
                btnRemover.Enabled = false;
                btnLimparPromocoes.Enabled = false;
                btnAbrirProdutos.Enabled = false;

                btnAdicionar.Visible = false;
                btnRemover.Visible = false;
                btnLimparPromocoes.Visible = false;
                btnSelecionarTudo.Visible = false;
                lblSelecionados.Visible = false;
                btnAbrirProdutos.Visible = false;
            }
            #endregion
        }
        public void FiltrarCategorias(int categoria)
        {
            List<ProdutosDataGrid> ListaGrid = new List<ProdutosDataGrid>();
            List<Produto> ListaProdutos = new List<Produto>();
           


            //Sem Filtro
            ListaProdutos.AddRange(Global.Listas.Produto);
           
            if (categoria==1)
            {
                if (cbNivel1.SelectedValue != null)
                {
                    int valor1 = int.Parse(cbNivel1.SelectedValue.ToString());
                    var ltCateorias = Global.Listas.ProdutosCategoria.FindAll(x => x.CategoriaNivel1 == valor1);
                    List<Produto> ListaBase = new List<Produto>();
                    ListaBase.AddRange(ListaProdutos);
                    foreach (var item in ListaBase)
                    {
                        var itemcategoria = ltCateorias.Find(x => x.CodigoProduto == item.Id);
                        if (itemcategoria == null)
                        {
                            ListaProdutos.Remove(item);
                        }
                    }
                }
            }
            if (categoria==2)
            {
                if (cbNivel2.SelectedValue != null)
                {
                   
                    int valor2 = int.Parse(cbNivel2.SelectedValue.ToString());
                    var ltCateorias = Global.Listas.ProdutosCategoria.FindAll(x => x.CategoriaNivel2 == valor2);
                    List<Produto> ListaBase = new List<Produto>();
                    ListaBase.AddRange(ListaProdutos);
                    foreach (var item in ListaBase)
                    {
                        var itemcategoria = ltCateorias.Find(x => x.CodigoProduto == item.Id);
                        if (itemcategoria == null)
                        {
                            ListaProdutos.Remove(item);
                        }
                    }
                }
            }
            if (categoria==3)
            {
                if (cbNivel3.SelectedValue != null)
                {

                    int valor3 = int.Parse(cbNivel3.SelectedValue.ToString());
                    var ltCateorias = Global.Listas.ProdutosCategoria.FindAll(x => x.CategoriaNivel3 == valor3);
                    List<Produto> ListaBase = new List<Produto>();
                    ListaBase.AddRange(ListaProdutos);
                    foreach (var item in ListaBase)
                    {
                        var itemcategoria = ltCateorias.Find(x => x.CodigoProduto == item.Id);
                        if (itemcategoria == null)
                        {
                            ListaProdutos.Remove(item);
                        }
                    }
                }
            }
            if (chkFaltaEditar.Checked)
            {
                var lt = ListaProdutos.FindAll(x => x.Peso.Equals("00000"));
                ListaProdutos = lt;
            }
            #region Formatação dos Dados Grid
            foreach (var obj in ListaProdutos)
            {
                ProdutosDataGrid produtosDataGrid = new ProdutosDataGrid();
                produtosDataGrid.Id = obj.Id.ToString();
                produtosDataGrid.Descricao = obj.Descricao + " " + obj.Gramatura + " " + obj.Embalagem;
                produtosDataGrid.Iguala = obj.IgualaProduto.ToString();
                produtosDataGrid.Custo = "R$" + obj.CustoUnitario.ToString("F2");
                produtosDataGrid.Venda = "R$" + obj.ValorVenda.ToString("F2");
                produtosDataGrid.Promoção = "R$" + obj.ValorPromocao.ToString("F2");
                string margem = string.Empty;
                if (obj.ValorPromocao > 0)
                {
                    double lucro = obj.ValorPromocao - obj.CustoUnitario;
                    double margemD = (lucro / obj.CustoUnitario) * 100;
                    margem = margemD.ToString("F2");
                }
                else
                {
                    double lucro = obj.ValorVenda - obj.CustoUnitario;
                    double margemD = (lucro / obj.CustoUnitario) * 100;
                    margem = margemD.ToString("F2");
                }


                produtosDataGrid.Margem = margem.ToString() + "%";
                ListaGrid.Add(produtosDataGrid);
            }
            dataGridView.DataSource = ListaGrid;
            switch (ListaGrid.Count)
            {
                case 0: lblRegistros.Text = $"Sem Registro"; break;
                case 1: lblRegistros.Text = $"1 Registro"; break;
                default: lblRegistros.Text = $"{ListaGrid.Count} Registros"; break;
            }
            switch (dataGridView.SelectedRows.Count)
            {
                case 0: lblSelecionados.Text = $"Nenhum Selecionado"; break;
                case 1: lblSelecionados.Text = $"1 Selecionado"; break;
                default: lblSelecionados.Text = $"{dataGridView.SelectedRows.Count} Selecionados"; break;
            }
            dataGridView.Columns[0].Width = 70;
            dataGridView.Columns[1].Width = 350;
            if (ListaGrid.Count > 0)
            {
                btnAdicionar.Enabled = true;
                btnRemover.Enabled = true;
                btnLimparPromocoes.Enabled = true;
                btnAbrirProdutos.Enabled = true;

                btnAdicionar.Visible = true;
                btnRemover.Visible = true;
                btnLimparPromocoes.Visible = true;
                btnSelecionarTudo.Visible = true;
                lblSelecionados.Visible = true;
                btnAbrirProdutos.Visible = true;

            }
            else
            {
                btnAdicionar.Enabled = false;
                btnRemover.Enabled = false;
                btnLimparPromocoes.Enabled = false;
                btnAbrirProdutos.Enabled = false;

                btnAdicionar.Visible = false;
                btnRemover.Visible = false;
                btnLimparPromocoes.Visible = false;
                btnSelecionarTudo.Visible = false;
                lblSelecionados.Visible = false;
                btnAbrirProdutos.Visible = false;
            }
            #endregion
        }


        //Listas
        public void AtualizarListas()
        {
            Global.Listas.Produto = ProdutoController.GetAll();
            Global.Listas.ProdutosCategoria = ProdutosCategoriaController.GetAll();
            Global.Listas.ProdutosCodigoBarra = ProdutosCodigoBarraController.GetAll();
            Global.Listas.CategoriasNivel1 = CategoriasNivel1Controller.GetAll();
            Global.Listas.CategoriasNivel2 = CategoriasNivel2Controller.GetAll();
            Global.Listas.CategoriasNivel3 = CategoriasNivel3Controller.GetAll();
        }

        //Combo Box
        void ComboCategoriasNivel1()
        {
            cbNivel1.DataSource = null;
            cbNivel1.DisplayMember = "Nome";
            cbNivel1.ValueMember = "Id";
            cbNivel1.DataSource = Global.Listas.CategoriasNivel1;

        }
        void ComboCategoriasNivel2()
        {
            cbNivel2.DataSource = null;
            if (cbNivel1.SelectedValue != null)
            {
                int id_Nivel1 = int.Parse(cbNivel1.SelectedValue.ToString());
                List<CategoriasNivel2> lista = new List<CategoriasNivel2>();
                lista = Global.Listas.CategoriasNivel2.FindAll(x => x.CategoriaNivel1 == id_Nivel1);
                cbNivel2.DisplayMember = "Nome";
                cbNivel2.ValueMember = "Id";
                cbNivel2.DataSource = lista;

            }
        }
        void ComboCategoriasNivel3()
        {
            cbNivel3.DataSource = null;
            if (cbNivel1.SelectedValue != null && cbNivel2.SelectedValue != null)
            {
                int id_Nivel1 = int.Parse(cbNivel1.SelectedValue.ToString());
                int id_Nivel2 = int.Parse(cbNivel2.SelectedValue.ToString());
                List<CategoriasNivel3> lista = new List<CategoriasNivel3>();
                lista = Global.Listas.CategoriasNivel3.FindAll(x => x.CategoriaNivel1 == id_Nivel1 && x.CategoriaNivel2 == id_Nivel2);
                cbNivel3.DisplayMember = "Nome";
                cbNivel3.ValueMember = "Id";
                cbNivel3.DataSource = lista;

            }
        }
        void ComboCategorias()
        {
            ComboCategoriasNivel1();
            ComboCategoriasNivel2();
            ComboCategoriasNivel3();
        }
        #endregion

        #region Eventos
        //Inicio Form
        public FrmProdutos()
        {
            InitializeComponent();
            AtualizarListas();
            ComboCategorias();
            Filtrar();
            txtDescricao.Focus();
        }

        //ComboBox
        private void cbNivel1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNivel1.SelectedValue != null)
            {
                ComboCategoriasNivel2();
                if (chkCategoria.Checked)
                {
                    Filtrar();
                }
            }
        }
        private void cbNivel2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNivel2.SelectedValue != null)
            {
                ComboCategoriasNivel3();
                if (chkCategoria.Checked)
                {
                    Filtrar();
                }
            }
        }
        private void cbNivel3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNivel3.DataSource != null)
            {
                if (chkCategoria.Checked)
                {
                    Filtrar();
                }
            }
        }

        //Filtros
        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }
        private void chkPromocao_CheckedChanged(object sender, EventArgs e)
        {
            Filtrar();
        }
        private void chkIgualaProduto_CheckedChanged(object sender, EventArgs e)
        {
            Filtrar();
        }
        private void chkFaltaEditar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFaltaEditar.Checked)
            {
                chkEditado.Checked = false;
            }
            Filtrar();
        }
        private void chkEditado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEditado.Checked)
            {
                chkFaltaEditar.Checked = false;
            }
            Filtrar();
        }
        private void chkCategoria_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCategoria.Checked)
            {
                chkSemCategoria.Checked = false;
            }
            Filtrar();
        }
        private void chkSemCategoria_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSemCategoria.Checked)
            {
                chkCategoria.Checked = false;
            }
            Filtrar();
        }
        private void chkCategoriaNivel2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCategoriaNivel2.Checked == false)
            {
                chkCategoriaNivel3.Checked = false;
            }
            if (chkCategoria.Checked)
            {
                Filtrar();
            }
        }
        private void chkCategoriaNivel3_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCategoriaNivel3.Checked == true)
            {
                chkCategoriaNivel2.Checked = true;
            }
            if (chkCategoria.Checked)
            {
                Filtrar();
            }
        }

        //Buttons
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmProduto(new Produto(),new List<int>()));
        }
        private void btnLimparPromocoes_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Deseja Apagar estas Promoções?", "ATENÇÂO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView.SelectedRows.Count; i++)
                {
                    var valor = dataGridView.SelectedRows[i].Cells[0].Value;

                    int id = int.Parse(valor.ToString());
                    Produto p = Global.Listas.Produto.Find(x => x.Id == id);
                    p.ValorPromocao = 0;
                    ProdutoController.Gravar(p);
                }
                Global.Listas.Produto = ProdutoController.GetAll();
                Filtrar();
                MessageBox.Show("Promoções Apagadas");
            }
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            int nivel1 = 0;
            int nivel2 = 0;
            int nivel3 = 0;
            string Nome1 = "Vazio";
            string Nome2 = "Vazio";
            string Nome3 = "Vazio";

            if (chkCategoriaNivel1.Checked)
            {
                if (cbNivel1.SelectedValue != null)
                {
                    nivel1 = int.Parse(cbNivel1.SelectedValue.ToString());
                    Nome1 = Global.Listas.CategoriasNivel1.Find(x => x.Id == nivel1).Nome;
                }
            }

            if (chkCategoriaNivel2.Checked)
            {
                if (cbNivel2.SelectedValue != null)
                {
                    nivel2 = int.Parse(cbNivel2.SelectedValue.ToString());
                    Nome2 = Global.Listas.CategoriasNivel2.Find(x => x.Id == nivel2).Nome;
                }
            }

            if (chkCategoriaNivel3.Checked)
            {
                if (cbNivel3.SelectedValue != null)
                {
                    nivel3 = int.Parse(cbNivel3.SelectedValue.ToString());
                    Nome3 = Global.Listas.CategoriasNivel3.Find(x => x.Id == nivel3).Nome;
                }
            }
            bool Continuar = true;
            if (nivel1 == 0)
            {
                Continuar = false;

            }

            if (Continuar)
            {
                string pergunta = $"Deseja inserir os Produtos nas Categorias:{Environment.NewLine}Categoria Nivel1: {Nome1}.{Environment.NewLine}Categoria Nivel2: {Nome2}.{Environment.NewLine}Categoria Nivel3: {Nome3}.";

                DialogResult dialog = MessageBox.Show(pergunta, "ATENÇÂO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridView.SelectedRows.Count; i++)
                    {
                        var valor = dataGridView.SelectedRows[i].Cells[0].Value;

                        int id = int.Parse(valor.ToString());
                        ProdutosCategorium p = Global.Listas.ProdutosCategoria.Find(x => x.CodigoProduto == id && x.CategoriaNivel1 == nivel1 && x.CategoriaNivel2 == nivel2 && x.CategoriaNivel3 == nivel3);
                        if (p == null)
                        {
                            p = new ProdutosCategorium();
                            p.Id = 0;
                            p.CodigoProduto = id;
                            p.CategoriaNivel1 = nivel1;
                            p.CategoriaNivel2 = nivel2;
                            p.CategoriaNivel3 = nivel3;
                            ProdutosCategoriaController.Gravar(p);
                        }

                    }
                    Global.Listas.ProdutosCategoria = ProdutosCategoriaController.GetAll();
                    Filtrar();
                    MessageBox.Show("Atualizado");
                }
            }
            else
            {
                MessageBox.Show("Nehuma Categoria Selecionada");
            }
        }
        private void btnRemover_Click(object sender, EventArgs e)
        {
            int nivel1 = 0;
            int nivel2 = 0;
            int nivel3 = 0;
            string Nome1 = "Vazio";
            string Nome2 = "Vazio";
            string Nome3 = "Vazio";

            if (chkCategoriaNivel1.Checked)
            {
                if (cbNivel1.SelectedValue != null)
                {
                    nivel1 = int.Parse(cbNivel1.SelectedValue.ToString());
                    Nome1 = Global.Listas.CategoriasNivel1.Find(x => x.Id == nivel1).Nome;
                }
            }

            if (chkCategoriaNivel2.Checked)
            {
                if (cbNivel2.SelectedValue != null)
                {
                    nivel2 = int.Parse(cbNivel2.SelectedValue.ToString());
                    Nome2 = Global.Listas.CategoriasNivel2.Find(x => x.Id == nivel2).Nome;
                }
            }

            if (chkCategoriaNivel3.Checked)
            {
                if (cbNivel3.SelectedValue != null)
                {
                    nivel3 = int.Parse(cbNivel3.SelectedValue.ToString());
                    Nome3 = Global.Listas.CategoriasNivel3.Find(x => x.Id == nivel3).Nome;
                }
            }
            bool Continuar = true;
            if (nivel1 == 0)
            {
                Continuar = false;

            }

            if (Continuar)
            {
                string pergunta = $"Deseja Desvincular estes Produtos das Categorias:{Environment.NewLine}Categoria Nive1: {Nome1}.{Environment.NewLine}Categoria Nive2: {Nome2}.{Environment.NewLine}Categoria Nive3: {Nome3}.";

                DialogResult dialog = MessageBox.Show(pergunta, "ATENÇÂO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridView.SelectedRows.Count; i++)
                    {
                        var valor = dataGridView.SelectedRows[i].Cells[0].Value;

                        int id = int.Parse(valor.ToString());


                        ProdutosCategorium p = Global.Listas.ProdutosCategoria.Find(x => x.CodigoProduto == id && x.CategoriaNivel1 == nivel1 && x.CategoriaNivel2 == nivel2 && x.CategoriaNivel3 == nivel3);
                        if (p != null)
                        {
                            ProdutosCategoriaController.Deletar(p);
                        }

                    }
                    Global.Listas.ProdutosCategoria = ProdutosCategoriaController.GetAll();
                    Filtrar();
                    MessageBox.Show("Atualizado");
                }
            }
            else
            {
                MessageBox.Show("Nehuma Categoria Selecionada");
            }
        }
        private void btnLimparFiltro_Click(object sender, EventArgs e)
        {
            chkCategoria.Checked = false;
            chkFaltaEditar.Checked = false;
            chkEditado.Checked = false;
            chkSemCategoria.Checked = false;
            chkCategoriaNivel2.Checked = false;
            chkCategoriaNivel3.Checked = false;
            chkIgualaProduto.Checked = false;
            chkPromocao.Checked = false;
            txtDescricao.Text = string.Empty;
            txtCodigoBarraCodigo.Text = string.Empty;
            txtDescricao.Focus();

            Filtrar();

        }
        private void btnSelecionarTudo_Click(object sender, EventArgs e)
        {
            dataGridView.SelectAll();
            switch (dataGridView.SelectedRows.Count)
            {
                case 0: lblSelecionados.Text = $"Nenhum Selecionado"; break;
                case 1: lblSelecionados.Text = $"1 Selecionado"; break;
                default: lblSelecionados.Text = $"{dataGridView.SelectedRows.Count} Selecionados"; break;
            }
        }
        private void btnAbrirProdutos_Click(object sender, EventArgs e)
        {
            List<int> lista = new List<int>();
            List<string> listaNome = new List<string>();
            for (int i = 0; i < dataGridView.SelectedRows.Count; i++)
            {
                var valor = dataGridView.SelectedRows[i].Cells[0].Value;
                var nome = dataGridView.SelectedRows[i].Cells[1].Value;
                int id = int.Parse(valor.ToString());
                lista.Add(id);
                listaNome.Add(nome.ToString());
            }
            if (lista.Count > 0)
            {
                DialogResult dialog = MessageBox.Show("Deseja Imprimir Lista de Produtos","Imprimir",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dialog==DialogResult.Yes)
                {
                    ListaImprimir = string.Empty;
                    foreach (var item in listaNome)
                    {
                        ListaImprimir += Environment.NewLine + item;
                    }
                    printDocument.Print();
                }





                openChildForm(new FrmProduto(new Produto(), lista));
            }
            else
            {
                MessageBox.Show("Nehum Produto Selecionado");
            }
        }
        //DataGrid
        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = 0;
            try
            {
                id = int.Parse(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            catch { }
            if (id > 0)
            {
                openChildForm(new FrmProduto(Global.Listas.Produto.Find(x => x.Id == id),new List<int>()));
            }
        }
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (lblSelecionados.Visible)
            {
                switch (dataGridView.SelectedRows.Count)
                {
                    case 0: lblSelecionados.Text = $"Nenhum Selecionado"; break;
                    case 1: lblSelecionados.Text = $"1 Selecionado"; break;
                    default: lblSelecionados.Text = $"{dataGridView.SelectedRows.Count} Selecionados"; break;
                }
            }
        }

        //Pesquisa
        private void txtCodigoBarraCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            var tecla = e.KeyChar;

            if (tecla.ToString().Equals("\r"))
            {
                if (txtCodigoBarraCodigo.Text.Trim().Length > 0)
                {
                    string txt = txtCodigoBarraCodigo.Text.Trim();
                    char[] charArr = txt.ToCharArray();
                    bool erro = false;
                    foreach (char ch in charArr)
                    {
                        try
                        {
                            int valor = int.Parse(ch.ToString());
                        }
                        catch { erro = true; break; }

                    }
                    if (erro == false)
                    {
                        if (txt.Length > 5)
                        {
                            ProdutosCodigoBarra p = Global.Listas.ProdutosCodigoBarra.Find(x => x.CodigoBarra.Equals(txt));
                            if (p != null)
                            {
                                openChildForm(new FrmProduto(Global.Listas.Produto.Find(x => x.Id == p.CodigoProduto),new List<int>()));
                            }
                            else
                            {
                                MessageBox.Show("Produto não Encontrado");
                                txtCodigoBarraCodigo.Text = string.Empty;
                            }
                        }
                        else
                        {
                            int valor = int.Parse(txt);
                            Produto p = Global.Listas.Produto.Find(x => x.Id == valor);
                            if (p != null)
                            {
                                openChildForm(new FrmProduto(p, new List<int>()));
                            }
                            else
                            {
                                MessageBox.Show("Produto não Encontrado");
                                txtCodigoBarraCodigo.Text = string.Empty;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Formato do codigo Incorreto");
                        txtCodigoBarraCodigo.Text = string.Empty;
                    }
                }

            }
        }
        private void btnBuscarCategoria1_Click(object sender, EventArgs e)
        {
            if (cbNivel1.SelectedValue != null)
            {
                chkCategoria.Checked = false;
               
                chkSemCategoria.Checked = false;
                chkCategoriaNivel2.Checked = false;
                chkCategoriaNivel3.Checked = false;
                chkIgualaProduto.Checked = false;
                chkPromocao.Checked = false;
                txtDescricao.Text = string.Empty;
                txtCodigoBarraCodigo.Text = string.Empty;
                txtDescricao.Focus();
                FiltrarCategorias(1);
            }
                
        }

        private void btnBuscarCategoria2_Click(object sender, EventArgs e)
        {
            if (cbNivel2.SelectedValue != null)
            {
                chkSemCategoria.Checked = false;
                chkCategoriaNivel2.Checked = false;
                chkCategoriaNivel3.Checked = false;
                chkIgualaProduto.Checked = false;
                chkPromocao.Checked = false;
                txtDescricao.Text = string.Empty;
                txtCodigoBarraCodigo.Text = string.Empty;
                txtDescricao.Focus();
                FiltrarCategorias(2);
            }
                
        }

        private void btnBuscarCategoria3_Click(object sender, EventArgs e)
        {
            if (cbNivel3.SelectedValue != null)
            {
                chkSemCategoria.Checked = false;
                chkCategoriaNivel2.Checked = false;
                chkCategoriaNivel3.Checked = false;
                chkIgualaProduto.Checked = false;
                chkPromocao.Checked = false;
                txtDescricao.Text = string.Empty;
                txtCodigoBarraCodigo.Text = string.Empty;
                txtDescricao.Focus();
                FiltrarCategorias(3);
            }
                
        }

        //Impressão
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(ListaImprimir, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 50, 50);
        }




        #endregion

       
    }
}
