using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Trabalho_Mercado_Online.Controllers;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Views.Dados
{
    public partial class FrmDadosFuncionarioCargo : Form
    {
        #region Variaveis
        List<FuncionarioCargo> ListaFuncionarioCargo = new List<FuncionarioCargo>();
        #endregion

        #region Funções
        public void AtualizarDados()
        {
            ListaFuncionarioCargo = FuncionarioCargoController.GetAll();
        }
        void ComboFuncionarioCargo()
        {
            cbFuncionarioCargo.DataSource = null;
            cbFuncionarioCargo.DisplayMember = "Nome";
            cbFuncionarioCargo.ValueMember = "Id";
            cbFuncionarioCargo.DataSource = ListaFuncionarioCargo;
        }
        void AtualizarTela()
        {
            AtualizarDados();
            lblTotalGeralFuncionarioCargo.Text = $"Total: {ListaFuncionarioCargo.Count}";
            ComboFuncionarioCargo();
        }
        void LimparForm()
        {
            lblId.Text = String.Empty;
            txtNome.Text = String.Empty;
        }

        //Interface
        void Inicioform()
        {
            txtNome.Enabled = false;

            btnNovo.Enabled = true;
            btnEditar.Enabled = true;

            btnGravar.Enabled = false;
         
        }
        void NovoEditarform()
        {
            txtNome.Enabled = true;

            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnGravar.Enabled = true;
           
        }
        void ExibirDados(FuncionarioCargo obj)
        {
            lblId.Text = obj.Id.ToString();
            txtNome.Text = obj.Nome.ToString();
        }
       
        #endregion

        #region Eventos
        public FrmDadosFuncionarioCargo()
        {
            InitializeComponent();
            AtualizarDados();
            AtualizarTela();
            Inicioform();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparForm();
            NovoEditarform();
            btnDeletar.Text = "    Cancelar";
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (lblId.Text.Length>0)
            {
                NovoEditarform();
                btnDeletar.Text = "    Cancelar";
            }
            else
            {
                MessageBox.Show("Nenhum Cargo Selecionado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (lblId.Text.Length==0)//novo
            {
                //verificar nome
                if (txtNome.Text.Length == 0)
                {
                    MessageBox.Show("Sem Nome para Adicionar ?", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //verificar duplicidade
                foreach (var item in ListaFuncionarioCargo)
                {
                    if (item.Nome.ToUpper().Trim().Equals(txtNome.Text.ToUpper().Trim()))
                    {
                        MessageBox.Show("Cargo já Adicionado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                //Inserir
                FuncionarioCargo obj = new FuncionarioCargo();
                obj.Nome = txtNome.Text.ToUpper().Trim();
                FuncionarioCargoController.Inserir(obj);

                //Atualizar dados
                LimparForm();
                Inicioform();
                AtualizarTela();
                btnDeletar.Text = "     Deletar";
                MessageBox.Show("Inserido", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else//atualizar
            {
                //verificar nome
                if (txtNome.Text.Length == 0)
                {
                    MessageBox.Show("Sem Nome para Adicionar ?", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //verificar duplicidade
                foreach (var item in ListaFuncionarioCargo)
                {
                    if (item.Nome.ToUpper().Trim().Equals(txtNome.Text.ToUpper().Trim()) && item.Id!=int.Parse(lblId.Text))
                    {
                        MessageBox.Show("Cargo já Adicionado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                //Atualizar
                FuncionarioCargo obj = new FuncionarioCargo();
                obj.Nome = txtNome.Text.ToUpper().Trim();
                obj.Id = int.Parse(lblId.Text);
                FuncionarioCargoController.Atualizar(obj);


                //Atualizar dados
                LimparForm();
                Inicioform();
                AtualizarTela();
                btnDeletar.Text = "     Deletar";
                MessageBox.Show("Atualizado", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (txtNome.Enabled)//cancelar
            {
                DialogResult r = MessageBox.Show("Cancelar alteração neste Regstro ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    LimparForm();
                    AtualizarTela();
                    Inicioform();
                    btnDeletar.Text = "     Deletar";
                }
            }
            else//Deletar
            {
                DialogResult r = MessageBox.Show("Deseja apagar este Cargo ?","Atenção",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (r==DialogResult.Yes)
                {
                    if (lblId.Text.Length == 0)
                    {
                        Inicioform();
                        MessageBox.Show("Não tem Registro para Deletar", "Erro ao Deletar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int id = int.Parse(lblId.Text);
                    FuncionarioCargoController.Deletar(ListaFuncionarioCargo.Find(x => x.Id == id));
                    Inicioform();
                    AtualizarTela();
                    MessageBox.Show("Deletado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
           
        }
        private void cbFuncionarioCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtNome.Enabled == false && cbFuncionarioCargo.Text.Length>0)
            {
                ExibirDados(ListaFuncionarioCargo.Find(x=>x.Id==int.Parse(cbFuncionarioCargo.SelectedValue.ToString())));
            }
        }
        #endregion


    }
}
