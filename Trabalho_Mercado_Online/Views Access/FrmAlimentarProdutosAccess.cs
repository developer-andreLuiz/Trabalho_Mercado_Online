using MMLib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Trabalho_Mercado_Online.Access;
using Trabalho_Mercado_Online.Access.Helpers;
using Trabalho_Mercado_Online.Controllers;
using Trabalho_Mercado_Online.Helpers;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Views_Access
{
    public partial class FrmAlimentarProdutosAccess : Form
    {
        #region Variaveis
        List<ProdutoAccess> Lista_Produtos = new List<ProdutoAccess>();
        List<ProdutoCodigoBarra> Lista_Codigos_Barras = new List<ProdutoCodigoBarra>();
        #endregion

        #region Funções
        void CarregarListasAccess()
        {
            var listaprodutos = BancoAccess.Produtos.GetAll();
            var listacodigobarra = BancoAccess.Prod_Codigo.GetAll();
            var listaitensVendidod = BancoAccess.Itens_Vend.GetAll();

            //codigo de barra
            foreach (var item in listaprodutos)
            {
                var pesquisa = Lista_Codigos_Barras.FindAll(x=> x.Codigo_Barra.Equals(item.Referencia));
                if (pesquisa.Count==0)
                {
                    Lista_Codigos_Barras.Add(new ProdutoCodigoBarra(item.Codigo.ToString(),item.Referencia));
                }
            }
            foreach (var item in listacodigobarra)
            {
                var pesquisa = Lista_Codigos_Barras.FindAll(x => x.Codigo_Barra.Equals(item.referencia));
                if (pesquisa.Count == 0)
                {
                    Lista_Codigos_Barras.Add(new ProdutoCodigoBarra(item.Codigo.ToString(), item.referencia));
                }
            }

            //produto
            foreach (var item in listaprodutos)
            {
                ProdutoAccess produto = new ProdutoAccess();
               
                produto.Descricao = item.Descricao;
                produto.embalagem = item.embalagem;
                produto.CustoUnitario = item.CustoUnitario.Replace("R$","");
                produto.ValorVenda = item.ValorVenda.Replace("R$", "");

                produto.ValorPromocao = item.ValorPromocao.Replace("R$", "");
                if (double.TryParse(produto.ValorPromocao, out double valor4)==false)
                {
                    produto.ValorPromocao = "0";
                }
               
                produto.Codigo = item.Codigo;
                produto.Numero = item.Numero;
                produto.grama = item.grama;

                if (int.TryParse(item.iguala, out int valor1))
                {
                    produto.iguala = int.Parse(item.iguala);
                }
                else
                {
                    produto.iguala = 0;
                }

               
                if (int.TryParse(item.categoria,out int valor2))
                {
                    produto.categoria = int.Parse(item.categoria);
                }
                else
                {
                    produto.categoria = 0;
                }

                if (int.TryParse(item.subcategoria, out int valor3))
                {
                    produto.subcategoria = int.Parse(item.subcategoria);
                }
                else
                {
                    produto.subcategoria = 0;
                }
            
                produto.IgualaCx = item.IgualaCx;
                produto.ChCaixa = item.ChCaixa;
                produto.Quant_fardo = item.Quant_fardo;
                var pesquisa = listaitensVendidod.FindAll(x=>x.Codigo==item.Codigo);
                if (pesquisa.Count>0)
                {
                    produto.quantidade_vendida = pesquisa[0].Quant;
                }
                else
                {
                    produto.quantidade_vendida = 0;
                }
                Lista_Produtos.Add(produto);
            }
        }
        void AtualizarListas()
        {

            Global.Listas.Produtos = ProdutosController.GetAll();
            Global.Listas.ProdutosCodigoBarra = ProdutosCodigoBarraController.GetAll();
        }
        public void Filtrar()
        {
            List<ProdutosDataGrid> ListaGrid = new List<ProdutosDataGrid>();
            List<ProdutoAccess> ListaProdutoAccess = new List<ProdutoAccess>();

            bool descricao = !String.IsNullOrEmpty(txtDescricao.Text);
            bool promocao = chkPromocao.Checked;
            bool igualaProduto = chkIgualaProduto.Checked;

            bool categoria = chkCategoria.Checked;
            bool semCategoria = chkSemCategoria.Checked;

            bool categoriaNivel1 = chkCategoriaNivel1.Checked;
            bool categoriaNivel2 = chkCategoriaNivel2.Checked;

            bool maisque = chkMaisQue.Checked;
            bool menosque = chkMenosQue.Checked;

            
            //Sem Filtro
            ListaProdutoAccess.AddRange(Lista_Produtos);

            if (descricao)
            {
                string txt = txtDescricao.Text.RemoveDiacritics();
                var listTxt = txt.Split(" ");
                foreach (var item in listTxt)
                {
                    var lt = ListaProdutoAccess.FindAll(x => x.Descricao.RemoveDiacritics().Contains(item, StringComparison.InvariantCultureIgnoreCase));
                    ListaProdutoAccess = lt;
                }
            }
          
            if (promocao)
            {
                var lt = ListaProdutoAccess.FindAll(x => double.Parse(x.ValorPromocao) > 0);
                ListaProdutoAccess = lt;
            }
           
            if (igualaProduto)
            {
                var lt = ListaProdutoAccess.FindAll(x => x.iguala > 0);
                ListaProdutoAccess = lt;
            }
          
            if (semCategoria)
            {
                var lt = ListaProdutoAccess.FindAll(x => x.categoria == 0);
                ListaProdutoAccess = lt;
            }
           
            if (categoria)
            {
                if (categoriaNivel1)
                {
                    if (cbNivel1.SelectedValue != null)
                    {
                        int valor1 = int.Parse(cbNivel1.SelectedValue.ToString());
                        var lt = ListaProdutoAccess.FindAll(x => x.categoria == valor1);
                        ListaProdutoAccess = lt;
                    }
                }

                if (categoriaNivel2)
                {
                    if (cbNivel2.SelectedValue != null)
                    {
                        int valor1 = int.Parse(cbNivel1.SelectedValue.ToString());
                        int valor2 = int.Parse(cbNivel2.SelectedValue.ToString());
                        var lt = ListaProdutoAccess.FindAll(x => x.categoria == valor1 && x.subcategoria==valor2);
                        ListaProdutoAccess = lt;

                    }
                }
                else
                {
                    if (cbNivel1.SelectedValue != null)
                    {
                        int valor1 = int.Parse(cbNivel1.SelectedValue.ToString());
                        var lt = ListaProdutoAccess.FindAll(x => x.categoria == valor1 && x.subcategoria == 0);
                        ListaProdutoAccess = lt;
                    }
                }

            }

            if (maisque)
            {
                var lt = ListaProdutoAccess.FindAll(x => x.quantidade_vendida >= nUDQuantidade.Value);
                ListaProdutoAccess = lt;
            }
        
            if (menosque)
            {
                var lt = ListaProdutoAccess.FindAll(x => x.quantidade_vendida <= nUDQuantidade.Value);
                ListaProdutoAccess = lt;
            }

            #region Formatação dos Dados Grid
            foreach (var obj in ListaProdutoAccess)
            {
                ProdutosDataGrid produtosDataGrid = new ProdutosDataGrid();
                produtosDataGrid.Id = obj.Codigo.ToString();
                produtosDataGrid.Descricao = obj.Descricao +" *"+obj.quantidade_vendida;
                produtosDataGrid.Iguala = obj.iguala.ToString();
                produtosDataGrid.Custo = "R$" + double.Parse(obj.CustoUnitario).ToString("F2");
                produtosDataGrid.Venda = "R$" + double.Parse(obj.ValorVenda).ToString("F2");
                produtosDataGrid.Promoção = "R$" + double.Parse(obj.ValorPromocao).ToString("F2");
                string margem = string.Empty;
              
                if (decimal.Parse(obj.ValorPromocao) > 0)
                {
                    double lucro = double.Parse(obj.ValorPromocao) - double.Parse(obj.CustoUnitario);
                    double margemD = (lucro / double.Parse(obj.CustoUnitario)) * 100;
                    margem = margemD.ToString("F2");
                }
                else
                {
                    double lucro = double.Parse(obj.ValorVenda) - double.Parse(obj.CustoUnitario);
                    double margemD = (lucro / double.Parse(obj.CustoUnitario)) * 100;
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
                btnAdicionar.Visible = true;
                
                btnSelecionarTudo.Enabled = true;
                btnSelecionarTudo.Visible = true;

                lblSelecionados.Visible = true;

            }
            else
            {
                btnAdicionar.Enabled = false;
                btnAdicionar.Visible = false;

                btnSelecionarTudo.Enabled = false;
                btnSelecionarTudo.Visible = false;

                lblSelecionados.Visible = false;
            }
            #endregion
        }

        //Combo Box
        void ComboCategoriasNivel1()
        {
            cbNivel1.DataSource = null;
            cbNivel1.DisplayMember = "nome";
            cbNivel1.ValueMember = "id_categoria";
            cbNivel1.DataSource = BancoAccess.Categoria.GetAll();

        }
        void ComboCategoriasNivel2()
        {
            cbNivel2.DataSource = null;
            if (cbNivel1.SelectedValue != null)
            {
                int id_Nivel1 = int.Parse(cbNivel1.SelectedValue.ToString());

                
               
                var lista = BancoAccess.Subcategoria.GetAll().FindAll(x => x.id_categoria == id_Nivel1);
               
                cbNivel2.DisplayMember = "nome";
                cbNivel2.ValueMember = "id_subcategoria";
                cbNivel2.DataSource = lista;

            }
        }
        void ComboCategorias()
        {
            ComboCategoriasNivel1();
            ComboCategoriasNivel2();
        }
        #endregion

        #region Eventos

        //Inicio Form
        public FrmAlimentarProdutosAccess()
        {
            InitializeComponent();
            CarregarListasAccess();
            AtualizarListas();
            ComboCategorias();
            Filtrar();
            
        }
       
        //Filtros
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
                if (chkCategoria.Checked && chkCategoriaNivel2.Checked)
                {
                    Filtrar();
                }
            }
        }
        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {
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
        private void chkPromocao_CheckedChanged(object sender, EventArgs e)
        {
            Filtrar();
        }
        private void chkIgualaProduto_CheckedChanged(object sender, EventArgs e)
        {
            Filtrar();
        }
        private void chkCategoriaNivel2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCategoria.Checked)
            {
                Filtrar();
            }
        }
        private void chkMaisQue_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMaisQue.Checked)
            {
                chkMenosQue.Checked = false;
            }
            Filtrar();
        }
        private void chkMenosQue_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMenosQue.Checked)
            {
                chkMaisQue.Checked = false;
            }
            Filtrar();
        }
        private void nUDQuantidade_ValueChanged(object sender, EventArgs e)
        {
            Filtrar();
        }
        
        //Btns
        private void btnLimparFiltro_Click(object sender, EventArgs e)
        {
            chkCategoria.Checked = false;
            chkSemCategoria.Checked = false;
            chkCategoriaNivel2.Checked = false;
            chkMaisQue.Checked = false;
            chkMenosQue.Checked = false;
            nUDQuantidade.Value = 0;
            chkIgualaProduto.Checked = false;
            chkPromocao.Checked = false;
            txtDescricao.Text = string.Empty;

            txtDescricao.Focus();

            Filtrar();
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
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string pergunta = $"Deseja inserir os Produtos na Base de Dados Online?";

            DialogResult dialog = MessageBox.Show(pergunta, "ATENÇÂO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                AtualizarListas();
                var ListaProdutosGrid = new List<string>();
                for (int i = 0; i < dataGridView.SelectedRows.Count; i++)
                {
                    var valor = dataGridView.SelectedRows[i].Cells[0].Value.ToString();
                    ListaProdutosGrid.Add(valor);
                }
                foreach (var produtoselecionado in ListaProdutosGrid)
                {
                    //produto encontrado o access
                    var produto_access = Lista_Produtos.Find(x => x.Codigo == int.Parse(produtoselecionado));
                   
                    //Todos os Codigo deste produto
                    var listacodigosproduto = Lista_Codigos_Barras.FindAll(x=>x.Codigo.Equals(produto_access.Codigo.ToString()));
                    var pesquisaProduto = Global.Listas.Produtos.FindAll(x=>x.CodigoLoja.Equals(produtoselecionado));
                    
                    Produtos produto_Online = new Produtos();
                    //inserir produto
                    if (pesquisaProduto.Count==0)
                    {
                        produto_Online.Id = 0;
                        produto_Online.Descricao = produto_access.Descricao;
                        produto_Online.Pronuncia = produto_access.Descricao;
                        produto_Online.Img = string.Empty;
                        produto_Online.CodigoLoja = produto_access.Codigo.ToString();
                        produto_Online.CustoUnitario = double.Parse(produto_access.CustoUnitario);
                        produto_Online.ValorVenda = double.Parse(produto_access.ValorVenda);
                        produto_Online.ValorPromocao = double.Parse(produto_access.ValorPromocao);
                      
                        produto_Online.Gramatura = produto_access.grama;
                        produto_Online.Embalagem = produto_access.embalagem;
                        produto_Online.Peso = "00000";
                        
                        
                        produto_Online.IgualaProduto = 0;
                        
                        produto_Online.ItensCaixa = int.Parse(produto_access.Numero);
                        produto_Online.Volume = 0;
                        
                        produto_Online.Validade = true;
                        produto_Online.Informacao = string.Empty;

                        produto_Online=ProdutosController.Gravar(produto_Online);
                        Global.Listas.Produtos.Add(produto_Online);
                    }
                    else
                    {
                        produto_Online = pesquisaProduto[0];
                    }

                    ////inserir codigo de barra
                    //foreach (var item in listacodigosproduto)
                    //{
                    //    var pesquisaCodigoBarra = Global.Listas.ProdutosCodigoBarra.FindAll(x => x.CodigoBarra.Equals(item.Codigo_Barra));
                    //    if (pesquisaCodigoBarra.Count==0)
                    //    {
                    //        if (produto_Online.Id>0)
                    //        {
                    //            ProdutosCodigoBarra produtosCodigoBarra = new ProdutosCodigoBarra();
                    //            produtosCodigoBarra.CodigoBarra = item.Codigo_Barra;
                    //            produtosCodigoBarra.CodigoProduto = produto_Online.Id;
                    //            produtosCodigoBarra = ProdutosCodigoBarraController.Gravar(produtosCodigoBarra);
                    //            Global.Listas.ProdutosCodigoBarra.Add(produtosCodigoBarra);
                                
                    //        }
                    //    }
                    //}
                }
               
                MessageBox.Show("Atualizado");
            }
        }

        #endregion

        private void btnAtualizarCodigos_Click(object sender, EventArgs e)
        {
            //string pergunta = $"Deseja Atualizar os Codigos de Barra na Base de Dados Online?";

            //DialogResult dialog = MessageBox.Show(pergunta, "ATENÇÂO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dialog == DialogResult.Yes)
            //{
            //    AtualizarListas();
            //    foreach(var produto in Global.Listas.Produtos)
            //    {
            //        var lista_codigos_produto = Lista_Codigos_Barras.FindAll(x=>x.Codigo.Equals(produto.CodigoLoja));
                    
            //        foreach (var item in lista_codigos_produto)
            //        {
            //            var pesquisaCodigoBarra = Global.Listas.ProdutosCodigoBarra.FindAll(x => x.CodigoBarra.Equals(item.Codigo_Barra));
                       
            //            if (pesquisaCodigoBarra.Count == 0)
            //            {
            //                ProdutosCodigoBarra produtosCodigoBarra = new ProdutosCodigoBarra();
            //                produtosCodigoBarra.CodigoBarra = item.Codigo_Barra;
            //                produtosCodigoBarra.CodigoProduto = produto.Id;

            //                produtosCodigoBarra = ProdutosCodigoBarraController.Gravar(produtosCodigoBarra);
            //                Global.Listas.ProdutosCodigoBarra.Add(produtosCodigoBarra);
            //            }
            //        }

            //    }
            //    MessageBox.Show("Atualizado");
            //}
        }
    }
}
