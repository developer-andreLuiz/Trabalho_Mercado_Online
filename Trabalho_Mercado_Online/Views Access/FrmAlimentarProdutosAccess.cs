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
        void Filtrar()
        {

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
        
        //Btns
        private void btnLimparFiltro_Click(object sender, EventArgs e)
        {
            chkCategoria.Checked = false;
            chkSemCategoria.Checked = false;
            chkCategoriaNivel2.Checked = false;

            chkIgualaProduto.Checked = false;
            chkPromocao.Checked = false;
            txtDescricao.Text = string.Empty;

            txtDescricao.Focus();

            Filtrar();
        }












        #endregion


    }
}
