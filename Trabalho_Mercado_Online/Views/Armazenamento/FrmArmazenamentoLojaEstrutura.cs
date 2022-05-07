using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Trabalho_Mercado_Online.Controllers;
using Trabalho_Mercado_Online.Helpers;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Views.Armazenamento
{
    public partial class FrmArmazenamentoLojaEstrutura : Form
    {

        #region Variaveis 
        List<LojaEstante>ListaEstante = new List<LojaEstante>();
        List<LojaPrateleira> ListaPrateleira = new List<LojaPrateleira>();
        #endregion

        #region Funções 
        public void AtualizarDados()
        {
            ListaEstante = LojaEstanteController.GetAll();
            ListaPrateleira = LojaPrateleiraController.GetAll();
        }
        void ComboEstante()
        {
            cbEstante.DataSource = null;
            cbEstante.DisplayMember = "Id";
            cbEstante.ValueMember = "Id";
            cbEstante.DataSource = ListaEstante;

        }
        void ComboPrateleira()
        {
            cbPrateleira.DataSource = null;
            if (cbEstante.SelectedValue!=null)
            {
                int id_estante = int.Parse(cbEstante.SelectedValue.ToString());
                List<LojaPrateleira> lista = new List<LojaPrateleira>();

                lista = ListaPrateleira.FindAll(x => x.LojaEstante == id_estante);
                lblTotalAtualPrateleira.Text= $"Total: {lista.Count}";
                cbPrateleira.DisplayMember = "Codigo";
                cbPrateleira.ValueMember = "Id";
                cbPrateleira.DataSource = lista;
            }
          

        }
        void AtualizarTela()
        {
            lblTotalGeralEstante.Text = $"Total: {ListaEstante.Count}";
            lblTotalGeralPrateleira.Text = $"Total: {ListaPrateleira.Count}";
            ComboEstante();
            ComboPrateleira();
        }
        void LimparForm()
        {
            nUPEstante.Value = 1;
            nUPPrateleira.Value = 1;
            chkEstanteProdutoVariado.Checked = true;
            chkPrateleiraLivre.Checked = true;
        }
        #endregion

        #region Eventos 
        //Form
        public FrmArmazenamentoLojaEstrutura()
        {
            InitializeComponent();
            AtualizarDados();
            AtualizarTela();
            LimparForm();
        }
        //ComboBox
        private void cbEstante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEstante.SelectedValue != null)
            {
                LojaEstante lojaEstante = ListaEstante.Find(x=>x.Id==int.Parse(cbEstante.SelectedValue.ToString()));
                chkEstanteProdutoVariado.Checked = lojaEstante.ProdutoVariado > 0 ? true:false;
                ComboPrateleira();
            }
            else
            {
                lblTotalAtualPrateleira.Text = $"Total: 0";
                AtualizarDados();
                AtualizarTela();
            }
        }
        private void cbPrateleira_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPrateleira.SelectedValue != null)
            {
                LojaPrateleira lojaPrateleira = ListaPrateleira.Find(x => x.Id == int.Parse(cbPrateleira.SelectedValue.ToString()));
                chkPrateleiraLivre.Checked = lojaPrateleira.Livre > 0 ? true : false;
               
            }
        }
        //Estante 
        private void btnEstanteAdicionar_Click(object sender, EventArgs e)
        {
            int valor = ListaEstante.Count;
            LojaEstante lojaEstante = new LojaEstante();
            for (int i = 0; i < Convert.ToInt32(nUPEstante.Value); i++)
            {
                valor++;
                lojaEstante.Id = valor;
                lojaEstante.ProdutoVariado = chkEstanteProdutoVariado.Checked == true ? 1 : 0;
                LojaEstanteController.Inserir(lojaEstante);
            }
            AtualizarDados();
            AtualizarTela();
            LimparForm();
            MessageBox.Show("Registro Inserido", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnEstanteRemover_Click(object sender, EventArgs e)
        {
            if (cbEstante.Text.Length > 0)
            {
                int valor = ListaEstante.Count;
                int rep = Convert.ToInt32(nUPEstante.Value);
                if (rep <= valor)
                {
                    DialogResult dialog = MessageBox.Show("Deletar registro de Estantes ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        for (int i = 0; i < rep; i++)
                        {
                            LojaEstante lojaEstante = new LojaEstante();
                            lojaEstante = ListaEstante.Find(x => x.Id == valor);
                            LojaEstanteController.Deletar(lojaEstante);
                            valor--;
                        }
                        AtualizarDados();
                        AtualizarTela();
                        LimparForm();
                        MessageBox.Show("Registro Removido", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    LimparForm();
                    MessageBox.Show("Itens para apagar maior que registros", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                LimparForm();
                MessageBox.Show("Sem Estantes para Deletar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEstanteSalvar_Click(object sender, EventArgs e)
        {
            if (cbEstante.Text.Length>0)
            {
                LojaEstante lojaEstante = new LojaEstante();
                lojaEstante.Id = Convert.ToInt32(cbEstante.Text);
                lojaEstante.ProdutoVariado = chkEstanteProdutoVariado.Checked == true ? 1 : 0;
                LojaEstanteController.Atualizar(lojaEstante);
                AtualizarDados();
                AtualizarTela();
                LimparForm();
                MessageBox.Show("Registro Atualizado","Sucesso",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                LimparForm();
                MessageBox.Show("Estante não Selecionada","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        //Prateleira
        private void btnPrateleiraAdicionar_Click(object sender, EventArgs e)
        {
            if (cbEstante.Text.Length>0)
            {
                int estante = int.Parse(cbEstante.Text);
                int valor = ListaPrateleira.FindAll(x=>x.LojaEstante==estante).Count;
                for (int i = 0; i < Convert.ToInt32(nUPPrateleira.Value); i++)
                {
                    LojaPrateleira lojaPrateleira = new LojaPrateleira();
                    valor++;
                    lojaPrateleira.LojaEstante = estante;
                    lojaPrateleira.Livre = 1;
                    lojaPrateleira.Codigo = valor;
                    LojaPrateleiraController.Gravar(lojaPrateleira);
                }
                AtualizarDados();
                AtualizarTela();
                LimparForm();
                MessageBox.Show("Registro Inserido", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sem estante selecionada", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        
        }
        private void btnPrateleiraRemover_Click(object sender, EventArgs e)
        {
            if (cbEstante.Text.Length > 0 && cbPrateleira.Text.Length > 0)
            {

                int valor = ListaPrateleira.FindAll(x => x.LojaEstante == Convert.ToInt32(cbEstante.Text)).Count;
                int rep = Convert.ToInt32(nUPPrateleira.Value);
                if (rep <= valor)
                {
                    DialogResult dialog = MessageBox.Show("Deletar registro de Prateleiras ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        for (int i = 0; i < rep; i++)
                        {
                            LojaPrateleira lojaPrateleira = new LojaPrateleira();
                            lojaPrateleira = ListaPrateleira.Find(x => x.LojaEstante == Convert.ToInt32(cbEstante.Text) && x.Codigo == valor);
                            LojaPrateleiraController.Deletar(lojaPrateleira);
                            valor--;
                        }
                        AtualizarDados();
                        AtualizarTela();
                        LimparForm();
                        MessageBox.Show("Registro Removido", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    LimparForm();
                    MessageBox.Show("Itens para apagar maior que registros", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            {
                LimparForm();
                MessageBox.Show("Sem Estante ou Prateleira para Deletar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnPrateleiraSalvar_Click(object sender, EventArgs e)
        {
            if (cbEstante.Text.Length > 0 && cbPrateleira.Text.Length>0)
            {
                LojaPrateleira lojaPrateleira = new LojaPrateleira();
                lojaPrateleira=ListaPrateleira.Find(x => x.LojaEstante == Convert.ToInt32(cbEstante.Text) && x.Codigo == Convert.ToInt32(cbPrateleira.Text));
                lojaPrateleira.Livre= chkPrateleiraLivre.Checked == true ? 1 : 0;

                LojaPrateleiraController.Gravar(lojaPrateleira);
                AtualizarDados();
                AtualizarTela();
                LimparForm();
                MessageBox.Show("Registro Atualizado", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LimparForm();
                MessageBox.Show("Prateleira não Selecionada", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

    }
}
