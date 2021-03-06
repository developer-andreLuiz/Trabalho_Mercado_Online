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
using System.Drawing.Printing;

namespace Trabalho_Mercado_Online.Views.Dados
{
    public partial class FrmDadosProdutos : Form
    {
        #region Variaveis 
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
            List<ProdutosDataGridHelper_Model> ListaGrid = new List<ProdutosDataGridHelper_Model>();
            List<Produto> ListaProdutos = new List<Produto>();



            bool descricao = !String.IsNullOrEmpty(txtDescricao.Text);
            bool promocao = chkPromocao.Checked;
            bool igualaProduto = chkIgualaProduto.Checked;
            bool faltaEditar = chkFaltaEditar.Checked;
            bool editado = chkEditado.Checked;
            bool habilitado = chkHabilitado.Checked;

            bool categoria = chkCategoria.Checked;
            bool semCategoria = chkSemCategoria.Checked;

            bool categoriaNivel1 = chkCategoriaNivel1.Checked && cbNivel1.SelectedValue != null ? true : false;
            bool categoriaNivel2 = chkCategoriaNivel2.Checked && cbNivel2.SelectedValue != null ? true : false;
            bool categoriaNivel3 = chkCategoriaNivel3.Checked && cbNivel3.SelectedValue != null ? true : false;
            //Sem Filtro
            ListaProdutos.AddRange(GlobalHelper.Listas.Produto);

            if (descricao)
            {
                string txt = StringHelper.FormatarStringMaiusculo(txtDescricao.Text);
                var listTxt = txt.Split(" ");
                foreach (var item in listTxt)
                {
                    var lt = ListaProdutos.FindAll(x => StringHelper.FormatarStringMaiusculo(x.Descricao).Contains(item, StringComparison.InvariantCultureIgnoreCase));
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
            if (habilitado)
            {
                var lt = ListaProdutos.FindAll(x => x.Habilitado == true);
                ListaProdutos = lt;
            }
            if (semCategoria)
            {
                foreach (var item in GlobalHelper.Listas.ProdutoCategoria)
                {
                    Produto p = new Produto();
                    p = ListaProdutos.Find(x => x.Id == item.Produto);
                    ListaProdutos.Remove(p);
                }
            }
            if (categoria)
            {
                //Apenas Nivel 1
                if (categoriaNivel1 == true && categoriaNivel2 == false && categoriaNivel3 ==false)
                {
                    int valor1 = int.Parse(cbNivel1.SelectedValue.ToString());
                    var ltCateorias = GlobalHelper.Listas.ProdutoCategoria.FindAll(x => x.CategoriaNivel1 == valor1 && x.CategoriaNivel2 == 0 && x.CategoriaNivel3 == 0 && x.CategoriaNivel4 == 0);
                    List<Produto> ListaBase = new List<Produto>();
                    ListaBase.AddRange(ListaProdutos);
                    foreach (var item in ListaBase)
                    {
                        var itemcategoria = ltCateorias.Find(x => x.Produto == item.Id);
                        if (itemcategoria == null)
                        {
                            ListaProdutos.Remove(item);
                        }
                    }
                }
                
                //Apenas Nivel 1 e 2
                if (categoriaNivel1 == true && categoriaNivel2 == true && categoriaNivel3 == false)
                {
                    int valor1 = int.Parse(cbNivel1.SelectedValue.ToString());
                    int valor2 = int.Parse(cbNivel2.SelectedValue.ToString());
                    var ltCateorias = GlobalHelper.Listas.ProdutoCategoria.FindAll(x => x.CategoriaNivel1 == valor1 && x.CategoriaNivel2 == valor2 && x.CategoriaNivel3 == 0 && x.CategoriaNivel4 == 0);
                    List<Produto> ListaBase = new List<Produto>();
                    ListaBase.AddRange(ListaProdutos);
                    foreach (var item in ListaBase)
                    {
                        var itemcategoria = ltCateorias.Find(x => x.Produto == item.Id);
                        if (itemcategoria == null)
                        {
                            ListaProdutos.Remove(item);
                        }
                    }
                }
                
                //Apenas Nivel 1, 2 e 3
                if (categoriaNivel1 == true && categoriaNivel2 == true && categoriaNivel3 == true)
                {
                    int valor1 = int.Parse(cbNivel1.SelectedValue.ToString());
                    int valor2 = int.Parse(cbNivel2.SelectedValue.ToString());
                    int valor3 = int.Parse(cbNivel3.SelectedValue.ToString());
                    var ltCateorias = GlobalHelper.Listas.ProdutoCategoria.FindAll(x => x.CategoriaNivel1 == valor1 && x.CategoriaNivel2 == valor2 && x.CategoriaNivel3 == valor3 && x.CategoriaNivel4 == 0);
                    List<Produto> ListaBase = new List<Produto>();
                    ListaBase.AddRange(ListaProdutos);
                    foreach (var item in ListaBase)
                    {
                        var itemcategoria = ltCateorias.Find(x => x.Produto == item.Id);
                        if (itemcategoria == null)
                        {
                            ListaProdutos.Remove(item);
                        }
                    }
                }
               

            }

            #region Formatação dos Dados Grid
            foreach (var obj in ListaProdutos)
            {
                ProdutosDataGridHelper_Model produtosDataGrid = new ProdutosDataGridHelper_Model();
                produtosDataGrid.Id = obj.Id.ToString();
                produtosDataGrid.Descricao = obj.Descricao + " " + obj.Gramatura + " " + obj.Embalagem;
                produtosDataGrid.Iguala = obj.IgualaProduto.ToString();
                produtosDataGrid.Custo = "R$" + obj.CustoUnitario.ToString("F2");
                produtosDataGrid.Venda = "R$" + obj.ValorVenda.ToString("F2");
                produtosDataGrid.Promoção = "R$" + obj.ValorPromocao.ToString("F2");
                string margem = string.Empty;
                if (obj.ValorPromocao > 0)
                {
                    decimal lucro = obj.ValorPromocao - obj.CustoUnitario;
                    decimal margemD = (lucro / obj.CustoUnitario) * 100;
                    margem = margemD.ToString("F2");
                }
                else
                {
                    decimal lucro = obj.ValorVenda - obj.CustoUnitario;
                    decimal margemD = (lucro / obj.CustoUnitario) * 100;
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
            dataGridView.Columns[1].Width = 390;

            dataGridView.Columns[2].Width = 70;
            dataGridView.Columns[3].Width = 80;
            dataGridView.Columns[4].Width = 80;
            dataGridView.Columns[5].Width = 80;
            dataGridView.Columns[6].Width = 80;


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
                btnExibirCategoria.Visible = true;
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
                btnExibirCategoria.Visible = false;
                lblSelecionados.Visible = false;
                btnAbrirProdutos.Visible = false;
            }
            #endregion
        }
        public void FiltrarCategorias(int categoria)
        {
            List<ProdutosDataGridHelper_Model> ListaGrid = new List<ProdutosDataGridHelper_Model>();
            List<Produto> ListaProdutos = new List<Produto>();
            bool descricao = !String.IsNullOrEmpty(txtDescricao.Text);
            bool promocao = chkPromocao.Checked;
            bool igualaProduto = chkIgualaProduto.Checked;
            bool faltaEditar = chkFaltaEditar.Checked;
            bool editado = chkEditado.Checked;
            bool habilitado = chkHabilitado.Checked;

            //Sem Filtro
            ListaProdutos.AddRange(GlobalHelper.Listas.Produto);
            if (descricao)
            {
                string txt = StringHelper.FormatarStringMaiusculo(txtDescricao.Text);
                var listTxt = txt.Split(" ");
                foreach (var item in listTxt)
                {
                    var lt = ListaProdutos.FindAll(x => StringHelper.FormatarStringMaiusculo(x.Descricao).Contains(item, StringComparison.InvariantCultureIgnoreCase));
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
                var lt = ListaProdutos.FindAll(x => x.Peso.Equals("00000") == false);
                ListaProdutos = lt;
            }
            if (habilitado)
            {
                var lt = ListaProdutos.FindAll(x => x.Habilitado == true);
                ListaProdutos = lt;
            }
            if (categoria==1)
            {
                if (cbNivel1.SelectedValue != null)
                {
                    int valor1 = int.Parse(cbNivel1.SelectedValue.ToString());
                    var ltCateorias = GlobalHelper.Listas.ProdutoCategoria.FindAll(x => x.CategoriaNivel1 == valor1);
                    List<Produto> ListaBase = new List<Produto>();
                    ListaBase.AddRange(ListaProdutos);
                    foreach (var item in ListaBase)
                    {
                        var itemcategoria = ltCateorias.Find(x => x.Produto == item.Id);
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
                    var ltCateorias = GlobalHelper.Listas.ProdutoCategoria.FindAll(x => x.CategoriaNivel2 == valor2);
                    List<Produto> ListaBase = new List<Produto>();
                    ListaBase.AddRange(ListaProdutos);
                    foreach (var item in ListaBase)
                    {
                        var itemcategoria = ltCateorias.Find(x => x.Produto == item.Id);
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
                    var ltCateorias = GlobalHelper.Listas.ProdutoCategoria.FindAll(x => x.CategoriaNivel3 == valor3);
                    List<Produto> ListaBase = new List<Produto>();
                    ListaBase.AddRange(ListaProdutos);
                    foreach (var item in ListaBase)
                    {
                        var itemcategoria = ltCateorias.Find(x => x.Produto == item.Id);
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
                ProdutosDataGridHelper_Model produtosDataGrid = new ProdutosDataGridHelper_Model();
                produtosDataGrid.Id = obj.Id.ToString();
                produtosDataGrid.Descricao = obj.Descricao + " " + obj.Gramatura + " " + obj.Embalagem;
                produtosDataGrid.Iguala = obj.IgualaProduto.ToString();
                produtosDataGrid.Custo = "R$" + obj.CustoUnitario.ToString("F2");
                produtosDataGrid.Venda = "R$" + obj.ValorVenda.ToString("F2");
                produtosDataGrid.Promoção = "R$" + obj.ValorPromocao.ToString("F2");
                string margem = string.Empty;
                if (obj.ValorPromocao > 0)
                {
                    decimal lucro = obj.ValorPromocao - obj.CustoUnitario;
                    decimal margemD = (lucro / obj.CustoUnitario) * 100;
                    margem = margemD.ToString("F2");
                }
                else
                {
                    decimal lucro = obj.ValorVenda - obj.CustoUnitario;
                    decimal margemD = (lucro / obj.CustoUnitario) * 100;
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
            dataGridView.Columns[1].Width = 390;

            dataGridView.Columns[2].Width = 70;
            dataGridView.Columns[3].Width = 80;
            dataGridView.Columns[4].Width = 80;
            dataGridView.Columns[5].Width = 80;
            dataGridView.Columns[6].Width = 80;
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
            GlobalHelper.Listas.Produto = ProdutoController.GetAll();
            GlobalHelper.Listas.ProdutoCategoria = ProdutoCategoriaController.GetAll();
            GlobalHelper.Listas.ProdutoCodigoBarra = ProdutoCodigoBarraController.GetAll();
            GlobalHelper.Listas.CategoriaNivel1 = CategoriaNivel1Controller.GetAll();
            GlobalHelper.Listas.CategoriaNivel2 = CategoriaNivel2Controller.GetAll();
            GlobalHelper.Listas.CategoriaNivel3 = CategoriaNivel3Controller.GetAll();

            
        }
        //Combo Box
        void ComboCategoriasNivel1()
        {
            cbNivel1.DataSource = null;
            cbNivel1.DisplayMember = "Nome";
            cbNivel1.ValueMember = "Id";
            cbNivel1.DataSource = GlobalHelper.Listas.CategoriaNivel1;

        }
        void ComboCategoriasNivel2()
        {
            cbNivel2.DataSource = null;
            cbNivel3.DataSource = null;
            if (cbNivel1.SelectedValue != null)
            {
                int id_Nivel1 = int.Parse(cbNivel1.SelectedValue.ToString());
                List<CategoriaNivel2> lista = new List<CategoriaNivel2>();
                lista = GlobalHelper.Listas.CategoriaNivel2.FindAll(x => x.CategoriaNivel1 == id_Nivel1);
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
                List<CategoriaNivel3> lista = new List<CategoriaNivel3>();
                lista = GlobalHelper.Listas.CategoriaNivel3.FindAll(x => x.CategoriaNivel1 == id_Nivel1 && x.CategoriaNivel2 == id_Nivel2);
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
        public FrmDadosProdutos()
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
                    if (!chkTravarFiltro.Checked)
                    {
                        Filtrar();
                    }
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
                    if (!chkTravarFiltro.Checked)
                    {
                        Filtrar();
                    }
                }
            }
        }
        private void cbNivel3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNivel3.DataSource != null)
            {
                if (chkCategoria.Checked)
                {
                    if (!chkTravarFiltro.Checked)
                    {
                        Filtrar();
                    }
                }
            }
        }
        //Filtros
        private void chkTravarFiltro_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkTravarFiltro.Checked)
            {
                Filtrar();
            }
        }
        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {
            if (!chkTravarFiltro.Checked)
            {
                Filtrar();
            }
        }
        private void chkPromocao_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkTravarFiltro.Checked)
            {
                Filtrar();
            }
        }
        private void chkIgualaProduto_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkTravarFiltro.Checked)
            {
                Filtrar();
            }
        }
        private void chkFaltaEditar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFaltaEditar.Checked)
            {
                chkEditado.Checked = false;
            }
            if (!chkTravarFiltro.Checked)
            {
                Filtrar();
            }
        }
        private void chkEditado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEditado.Checked)
            {
                chkFaltaEditar.Checked = false;
            }
            if (!chkTravarFiltro.Checked)
            {
                Filtrar();
            }
        }
        private void chkHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkTravarFiltro.Checked)
            {
                Filtrar();
            }
        }
        private void chkCategoria_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCategoria.Checked)
            {
                chkSemCategoria.Checked = false;
            }
            if (!chkTravarFiltro.Checked)
            {
                Filtrar();
            }
           
        }
        private void chkSemCategoria_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSemCategoria.Checked)
            {
                chkCategoria.Checked = false;
            }
            if (!chkTravarFiltro.Checked)
            {
                Filtrar();
            }
        }
        private void chkCategoriaNivel2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCategoriaNivel2.Checked == false)
            {
                chkCategoriaNivel3.Checked = false;
            }
            if (chkCategoria.Checked)
            {
                if (!chkTravarFiltro.Checked)
                {
                    Filtrar();
                }
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
                if (!chkTravarFiltro.Checked)
                {
                    Filtrar();
                }
            }
        }
        //Buttons
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmDadosProduto(new Produto(),new List<int>()));
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
                openChildForm(new FrmDadosProduto(new Produto(), lista));
            }
            else
            {
                MessageBox.Show("Nehum Produto Selecionado");
            }
        }
        private void btnExibirCategoria_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count > 0)
            {
                List<int> listId = new List<int>();
                List<ProdutosCategoriaDataGridHelper_Model> ListaGrid = new List<ProdutosCategoriaDataGridHelper_Model>();

                foreach (DataGridViewRow item in dataGridView.Rows)
                {
                    listId.Add(int.Parse(item.Cells[0].Value.ToString()));
                }

                foreach (var itemListId in listId)
                {
                    var listProdutoCategoria = GlobalHelper.Listas.ProdutoCategoria.FindAll(x => x.Produto == itemListId);

                    foreach (var itemProdutoCategoria in listProdutoCategoria)
                    {
                        ProdutosCategoriaDataGridHelper_Model p = new ProdutosCategoriaDataGridHelper_Model();
                        p.Id = itemListId.ToString();
                        var produto = GlobalHelper.Listas.Produto.Find(x => x.Id == itemListId);
                        try
                        {
                            p.Descricao = produto.Descricao + " " + produto.Gramatura + " " + produto.Embalagem;

                            try
                            {
                                p.Categoria_Nivel1 = GlobalHelper.Listas.CategoriaNivel1.Find(x => x.Id == itemProdutoCategoria.CategoriaNivel1).Nome;
                            }
                            catch
                            {
                                p.Categoria_Nivel1 = "";
                            }

                            try
                            {
                                p.Categoria_Nivel2 = GlobalHelper.Listas.CategoriaNivel2.Find(x => x.Id == itemProdutoCategoria.CategoriaNivel2).Nome;
                            }
                            catch
                            {
                                p.Categoria_Nivel2 = "";
                            }

                            try
                            {
                                p.Categoria_Nivel3 = GlobalHelper.Listas.CategoriaNivel3.Find(x => x.Id == itemProdutoCategoria.CategoriaNivel3).Nome;
                            }
                            catch
                            {
                                p.Categoria_Nivel3 = "";
                            }

                            ListaGrid.Add(p);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }

                dataGridView.DataSource = ListaGrid;


                #region Formatação dos Dados Grid



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
                dataGridView.Columns[1].Width = 390;

                dataGridView.Columns[2].HeaderText = "Nivel 1";
                dataGridView.Columns[3].HeaderText = "Nivel 2";
                dataGridView.Columns[4].HeaderText = "Nivel 3";

                dataGridView.Columns[2].Width = 130;
                dataGridView.Columns[3].Width = 130;
                dataGridView.Columns[4].Width = 130;
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
                    Produto p = GlobalHelper.Listas.Produto.Find(x => x.Id == id);
                    p.ValorPromocao = 0;
                    ProdutoController.Gravar(p);
                }
                GlobalHelper.Listas.Produto = ProdutoController.GetAll();
                Filtrar();
                MessageBox.Show("Promoções Apagadas");
            }
        }
        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count>0)
            {
                DialogResult dialog = MessageBox.Show("Deseja Habilitar estes Produtos?", "ATENÇÂO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridView.SelectedRows.Count; i++)
                    {
                        var valor = dataGridView.SelectedRows[i].Cells[0].Value;

                        int id = int.Parse(valor.ToString());
                        Produto p = GlobalHelper.Listas.Produto.Find(x => x.Id == id);
                        p.Habilitado = true;
                        ProdutoController.Gravar(p);
                    }
                    GlobalHelper.Listas.Produto = ProdutoController.GetAll();
                    Filtrar();
                    MessageBox.Show("Produtos Habilitados.");
                }
            }
            else
            {
                MessageBox.Show("Sem produto Selecionado","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           
        }
        private void btnPrint_Click(object sender, EventArgs e)
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
            string[] textoParaImpressao = new string[listaNome.Count];
            if (lista.Count > 0)
            {
                DialogResult dialog = MessageBox.Show("Deseja Imprimir Lista de Produtos", "Imprimir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    ListaImprimir = string.Empty;
                    for (int i = 0; i < listaNome.Count; i++)
                    {
                        textoParaImpressao[i] = i + 1 + "-" + listaNome[i];
                    }

                    PrintDocument doc = new ImprimirDocumentoHelper(textoParaImpressao);
                    doc.PrintPage += this.Doc_PrintPage;
                    PrintDialog dialogo = new PrintDialog();
                    dialogo.Document = doc;
                    //  Se o usuário clicar em OK , imprime o documento
                    if (dialogo.ShowDialog() == DialogResult.OK)
                    {
                        doc.Print();
                    }
                }
            }
            else
            {
                MessageBox.Show("Nehum Produto Selecionado");
            }
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            int nivel = 0;
            
            int nivel1 = 0;
            int nivel2 = 0;
            int nivel3 = 0;
            int nivel4 = 0;
            
            string Nome1 = "Vazio";
            string Nome2 = "Vazio";
            string Nome3 = "Vazio";

            if (chkCategoriaNivel1.Checked && cbNivel1.SelectedValue != null)
            {
                nivel = 1;
                nivel1 = int.Parse(cbNivel1.SelectedValue.ToString());
                Nome1 = GlobalHelper.Listas.CategoriaNivel1.Find(x => x.Id == nivel1).Nome;
            }
            if (chkCategoriaNivel2.Checked && cbNivel2.SelectedValue != null)
            {
                nivel = 2;
                nivel2 = int.Parse(cbNivel2.SelectedValue.ToString());
                Nome2 = GlobalHelper.Listas.CategoriaNivel2.Find(x => x.Id == nivel2).Nome;
            }
            if (chkCategoriaNivel3.Checked && cbNivel3.SelectedValue != null)
            {
                nivel = 3;
                nivel3 = int.Parse(cbNivel3.SelectedValue.ToString());
                Nome3 = GlobalHelper.Listas.CategoriaNivel3.Find(x => x.Id == nivel3).Nome;
            }
          
            //Controle de Redundancia 
            if (nivel1 == 0)
            {
                MessageBox.Show("Nehuma Categoria Selecionada,Não Inserido!", "Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (nivel == 1)
            {
                List<ProdutoCategorium> lista = new List<ProdutoCategorium>();
                lista = GlobalHelper.Listas.ProdutoCategoria.FindAll(x => x.CategoriaNivel1 == nivel1 && x.CategoriaNivel2 > 0);
                if (lista.Count > 0)
                {
                    MessageBox.Show("Existe produto viculado no próximo nivel, Desvicule Antes, Não Inserido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (nivel == 2)
            {
                List<ProdutoCategorium> lista = new List<ProdutoCategorium>();
                lista = GlobalHelper.Listas.ProdutoCategoria.FindAll(x => x.CategoriaNivel1 == nivel1 && x.CategoriaNivel2 == 0);
                if (lista.Count > 0)
                {
                    MessageBox.Show("Existe produto viculado em nivel Anterior, Desvicule Antes, Não Inserido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lista = GlobalHelper.Listas.ProdutoCategoria.FindAll(x => x.CategoriaNivel1 == nivel1 && x.CategoriaNivel2 == nivel2 && x.CategoriaNivel3 > 0);
                if (lista.Count > 0)
                {
                    MessageBox.Show("Existe produto viculado no próximo nivel, Desvicule Antes, Não Inserido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (nivel == 3)
            {
                List<ProdutoCategorium> lista = new List<ProdutoCategorium>();
                lista = GlobalHelper.Listas.ProdutoCategoria.FindAll(x => x.CategoriaNivel1 == nivel1 && x.CategoriaNivel2 == 0);
                if (lista.Count > 0)
                {
                    MessageBox.Show("Existe produto viculado em nivel Anterior, Desvicule Antes, Não Inserido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                lista = GlobalHelper.Listas.ProdutoCategoria.FindAll(x => x.CategoriaNivel1 == nivel1 && x.CategoriaNivel2 == nivel2 && x.CategoriaNivel3 == 0);
                if (lista.Count > 0)
                {
                    MessageBox.Show("Existe produto viculado em nivel Anterior, Desvicule Antes, Não Inserido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
            string pergunta = $"Deseja inserir os Produtos nas Categorias:{Environment.NewLine}Categoria Nivel1: {Nome1}.{Environment.NewLine}Categoria Nivel2: {Nome2}.{Environment.NewLine}Categoria Nivel3: {Nome3}.";
            DialogResult dialog = MessageBox.Show(pergunta, "ATENÇÂO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                for (int i = 0; i < dataGridView.SelectedRows.Count; i++)
                {
                    var valor = dataGridView.SelectedRows[i].Cells[0].Value;
                    int id = int.Parse(valor.ToString());
                    ProdutoCategorium p = GlobalHelper.Listas.ProdutoCategoria.Find(x => x.Produto == id && x.CategoriaNivel1 == nivel1 && x.CategoriaNivel2 == nivel2 && x.CategoriaNivel3 == nivel3);
                    if (p == null)
                    {
                        p = new ProdutoCategorium();
                        p.Id = 0;
                        p.Produto = id;
                        p.CategoriaNivel1 = nivel1;
                        p.CategoriaNivel2 = nivel2;
                        p.CategoriaNivel3 = nivel3;
                        p.CategoriaNivel4 = nivel4;
                        ProdutoCategoriaController.Gravar(p);
                    }

                }
                GlobalHelper.Listas.ProdutoCategoria = ProdutoCategoriaController.GetAll();
                //Filtrar();
                chkTravarFiltro.Checked = false;
                MessageBox.Show("Atualizado");
            }
        }
        private void btnRemover_Click(object sender, EventArgs e)
        {
            int nivel1 = 0;
            int nivel2 = 0;
            int nivel3 = 0;
            int nivel4 = 0;
            string Nome1 = "Vazio";
            string Nome2 = "Vazio";
            string Nome3 = "Vazio";

            if (chkCategoriaNivel1.Checked)
            {
                if (cbNivel1.SelectedValue != null)
                {
                    nivel1 = int.Parse(cbNivel1.SelectedValue.ToString());
                    Nome1 = GlobalHelper.Listas.CategoriaNivel1.Find(x => x.Id == nivel1).Nome;
                }
            }

            if (chkCategoriaNivel2.Checked)
            {
                if (cbNivel2.SelectedValue != null)
                {
                    nivel2 = int.Parse(cbNivel2.SelectedValue.ToString());
                    Nome2 = GlobalHelper.Listas.CategoriaNivel2.Find(x => x.Id == nivel2).Nome;
                }
            }

            if (chkCategoriaNivel3.Checked)
            {
                if (cbNivel3.SelectedValue != null)
                {
                    nivel3 = int.Parse(cbNivel3.SelectedValue.ToString());
                    Nome3 = GlobalHelper.Listas.CategoriaNivel3.Find(x => x.Id == nivel3).Nome;
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


                        ProdutoCategorium p = GlobalHelper.Listas.ProdutoCategoria.Find(x => x.Produto == id && x.CategoriaNivel1 == nivel1 && x.CategoriaNivel2 == nivel2 && x.CategoriaNivel3 == nivel3 && x.CategoriaNivel4 == nivel4);
                        if (p != null)
                        {
                            ProdutoCategoriaController.Deletar(p);
                        }

                    }
                    GlobalHelper.Listas.ProdutoCategoria = ProdutoCategoriaController.GetAll();
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
            chkTravarFiltro.Checked = false;
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
                openChildForm(new FrmDadosProduto(GlobalHelper.Listas.Produto.Find(x => x.Id == id),new List<int>()));
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
                            ProdutoCodigoBarra p = GlobalHelper.Listas.ProdutoCodigoBarra.Find(x => x.CodigoBarra.Equals(txt));
                            if (p != null)
                            {
                                openChildForm(new FrmDadosProduto(GlobalHelper.Listas.Produto.Find(x => x.Id == p.Produto),new List<int>()));
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
                            Produto p = GlobalHelper.Listas.Produto.Find(x => x.Id == valor);
                            if (p != null)
                            {
                                openChildForm(new FrmDadosProduto(p, new List<int>()));
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
        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Recupera o documento que enviou este evento.
            ImprimirDocumentoHelper doc = (ImprimirDocumentoHelper)sender;

            // Define a fonte e determina a altura da linha
            using (Font fonte = new Font("Verdana", 10))
            {
                float alturaLinha = fonte.GetHeight(e.Graphics);

                // Cria as variáveis para tratar a posição na página
                float x = e.MarginBounds.Left;
                float y = e.MarginBounds.Top;

                // Incrementa o contador de página para refletir
                // a página que esta sendo impressa
                doc.NumeroPagina += 1;

                // Imprime toda a informação que cabe na página
                // O laço termina quando a próxima linha
                // iria passar a borda da margem ou quando não
                // houve mais linhas a imprimir
                while ((y + alturaLinha) < e.MarginBounds.Bottom &&
                  doc.Offset <= doc.Texto.GetUpperBound(0))
                {
                    e.Graphics.DrawString(doc.Texto[doc.Offset], fonte,
                      Brushes.Black, x, y);

                    // move para a proxima linha
                    doc.Offset += 1;

                    // Move uma linha para baixo (proxima linha)
                    y += alturaLinha;
                }

                if (doc.Offset < doc.Texto.GetUpperBound(0))
                {
                    // Havendo ainda pelo menos mais uma página.
                    // Sinaliza o evento para disparar novamente
                    e.HasMorePages = true;
                }
                else
                {
                    // A impressão terminou
                    doc.Offset = 0;
                }
            }
        }
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(ListaImprimir, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 50, 50);
        }
        #endregion

        
    }
}
