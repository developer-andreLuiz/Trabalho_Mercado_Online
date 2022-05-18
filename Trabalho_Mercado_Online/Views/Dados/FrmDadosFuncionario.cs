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

namespace Trabalho_Mercado_Online.Views.Dados
{
    public partial class FrmDadosFuncionario : Form
    {
        #region Variaveis
        List<FuncionarioCargo> ListaFuncionarioCargo = new List<FuncionarioCargo>();
        List<Funcionario> ListaFuncionario = new List<Funcionario>();
        #endregion

        #region Funções
        //Dados
        RetornoHelper CapturarDados(Funcionario obj)
        {
            RetornoHelper retorno = new RetornoHelper();

            //Id
            if (lblId.Text.Length>0)
            {
                obj.Id = int.Parse(lblId.Text);
            }
            
            //Nome
            if (txtNome.Text.Length > 0)
            {
                obj.Nome = txtNome.Text.ToUpper().Trim();
            }
            else
            {
                retorno.Evento = false;
                retorno.Mensagem = "Funcionário sem Nome.";
                txtNome.Focus();
                return retorno;
            }

            //Senha
            if (txtSenha.Text.Length > 3)
            {
                if (lblId.Text.Length == 0)//Novo
                {
                    foreach (var item in ListaFuncionario)
                    {
                        if (item.Senha.Trim().Equals(txtSenha.Text.Trim()))
                        {
                            retorno.Evento = false;
                            retorno.Mensagem = "Senha ja cadastrada digite uma nova.";
                            txtSenha.Focus();
                            return retorno;
                        }
                    }
                    obj.Senha= txtSenha.Text.Trim();
                }
                else//Atualizar
                {
                    //verificar duplicidade
                    foreach (var item in ListaFuncionario)
                    {
                        if (item.Senha.Trim().Equals(txtSenha.Text.Trim()) && item.Id != int.Parse(lblId.Text))
                        {
                            retorno.Evento = false;
                            retorno.Mensagem = "Senha ja cadastrada digite uma nova.";
                            txtSenha.Focus();
                            return retorno;
                        }
                    }
                    obj.Senha = txtSenha.Text.Trim();
                }
            }
            else
            {
                retorno.Evento = false;
                retorno.Mensagem = "Digite uma Senha entre 4 a 8 caracteres.";
                txtSenha.Focus();
                return retorno;
            }

            //Nivel
            obj.Nivel = (int)nUDNivel.Value;

            //cargo
            if (cbCargo.Text.Length>0)
            {
                obj.Cargo = (int)cbCargo.SelectedValue;
            }
            else
            {
                retorno.Evento = false;
                retorno.Mensagem = "Sem Cargo Selecionado, Caso não tenha cargo cadatrado cadastre primeiro.";
                cbCargo.Focus();
                return retorno;
            }

            //salario
            if (decimal.TryParse(txtSalario.Text, out decimal v1))
            {
                obj.Salario = v1;
            }
            else
            {
                retorno.Evento = false;
                retorno.Mensagem = "Salário Incoreto";
                txtSalario.Focus();
                return retorno;
            }

            //salario bonus
            if (decimal.TryParse(txtSalarioBonus.Text, out decimal v2))
            {
                obj.SalarioBonus = v2;
            }
            else
            {
                retorno.Evento = false;
                retorno.Mensagem = "Salário Bonus Incoreto";
                txtSalarioBonus.Focus();
                return retorno;
            }

            //vale compra
            if (decimal.TryParse(txtValeCompra.Text, out decimal v3))
            {
                obj.ValeCompra = v3;
            }
            else
            {
                retorno.Evento = false;
                retorno.Mensagem = "Vale Compra Incoreto";
                txtValeCompra.Focus();
                return retorno;
            }

            //telefone
            if (txtTelefone.Text.Length==11)
            {
                obj.Telefone = txtTelefone.Text;
            }
            else
            {
                retorno.Evento = false;
                retorno.Mensagem = "Formato Telefone Incoreto";
                txtTelefone.Focus();
                return retorno;
            }

            //endereco
            obj.Endereco = txtEndereco.Text.ToUpper().Trim();

            //informacao
            obj.Informacao = txtInformacao.Text.ToUpper().Trim();
            
            //habilitado
            obj.Habilitado = chkHabilitado.Checked? 1:0;


            return retorno;
        }
        void ExibirDados(Funcionario obj)
        {
            Limpar();
            lblId.Text = obj.Id.ToString();
            txtNome.Text = obj.Nome;
            txtSenha.Text = obj.Senha;
            nUDNivel.Value= obj.Nivel;
            cbCargo.SelectedValue= obj.Cargo;
            txtSalario.Text = obj.Salario.ToString();
            txtSalarioBonus.Text = obj.SalarioBonus.ToString();
            txtValeCompra.Text = obj.ValeCompra.ToString();
            chkHabilitado.Checked = obj.Habilitado == 1 ? true : false;
            txtTelefone.Text = obj.Telefone;
            txtEndereco.Text = obj.Endereco;
            txtInformacao.Text = obj.Informacao;
        }
        public void AtualizarDados()
        {
            
            ListaFuncionario = FuncionarioController.GetAll();
        }
        void ComboFuncionarioCargo()
        {
            cbCargo.DataSource = null;
            cbCargo.DisplayMember = "Nome";
            cbCargo.ValueMember = "Id";
            cbCargo.DataSource = ListaFuncionarioCargo;
        }
        //Layout
        void ControleInterface(bool b)
        {
            txtNome.Enabled= b;
            txtSenha.Enabled = b;
            nUDNivel.Enabled = b;
            cbCargo.Enabled = b;
            txtSalario.Enabled = b;
            txtSalarioBonus.Enabled = b;
            txtValeCompra.Enabled = b;
            chkHabilitado.Enabled = b;
            txtTelefone.Enabled = b;
            txtEndereco.Enabled = b;
            txtInformacao.Enabled = b;
        }
        void AberturaForm()
        {
            txtNome.Focus();
            btnNovo.Enabled = true;
            btnEditar.Enabled = true;
            btnGravar.Enabled = false;
            btnDeletar.Text = "    Deletar";
            ControleInterface(false);
        }
        void BtnGravarLayout()
        {
            btnNovo.Enabled = true;
            btnEditar.Enabled = true;
            btnGravar.Enabled = false;
            btnDeletar.Text = "    Deletar";
            ControleInterface(false);
        }
        void NovoEditarLayout()
        {
            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnGravar.Enabled = true;
            btnDeletar.Text = "  Cancelar";
            ControleInterface(true);
        }
      
        void Limpar()
        {
            lblId.Text = String.Empty;
            txtNome.Text = String.Empty;
            txtSenha.Text = String.Empty;
            nUDNivel.Value = 1;
            if (ListaFuncionarioCargo.Count>0)
            {
                cbCargo.SelectedIndex=0;
            }
            txtSalario.Text = "0.00";
            txtSalarioBonus.Text = "0.00";
            txtValeCompra.Text = "0.00";
            chkHabilitado.Checked = true;
            txtTelefone.Text = String.Empty;
            txtEndereco.Text = String.Empty;
            txtInformacao.Text = String.Empty;
        }
        #endregion

        #region Eventos
        public FrmDadosFuncionario(Funcionario? funcionario)
        {
            InitializeComponent();
            AberturaForm();
            ListaFuncionarioCargo = FuncionarioCargoController.GetAll();
            AtualizarDados();
            ComboFuncionarioCargo();
            Limpar();
            if (funcionario!=null)
            {
                ExibirDados(funcionario);
            }
            else
            {
                NovoEditarLayout();
            }
        }
        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !(char.IsControl(e.KeyChar)))
            {

                e.Handled = true;
            }
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            Limpar();
            NovoEditarLayout();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (lblId.Text.Length > 0)
            {
                NovoEditarLayout();
            }
            else
            {
                MessageBox.Show("Nenhum Funcionário Selecionado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = new Funcionario();
            RetornoHelper retornoHelper = CapturarDados(funcionario);
            if (retornoHelper.Evento)
            {
                if (lblId.Text.Length == 0)
                {
                    funcionario = FuncionarioController.Inserir(funcionario);
                }
                else
                {
                    funcionario = FuncionarioController.Atualizar(funcionario);
                }


                AberturaForm();
                AtualizarDados();
                ExibirDados(funcionario);
                MessageBox.Show("Sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(retornoHelper.Mensagem,"Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (txtNome.Enabled)//cancelar
            {
                DialogResult r = MessageBox.Show("Cancelar alteração neste Regstro ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    if (lblId.Text.Length > 0)//atualizando
                    {
                        int id = Convert.ToInt32(lblId.Text);
                        ExibirDados(ListaFuncionario.Find(x => x.Id == id));
                    }
                    else//novo
                    {
                        if (ListaFuncionario.Count > 0)//se tem registro exibe o primeiro
                        {
                            ExibirDados(ListaFuncionario[0]);
                        }
                        else
                        {
                            Limpar();
                        }
                    }
                    AberturaForm();
                }
            }
            else//Deletar
            {
                DialogResult r = MessageBox.Show("Deseja apagar este Registro ?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    if (lblId.Text.Length == 0)//novo
                    {
                        AberturaForm();
                        MessageBox.Show("Não tem Registro para Deletar", "Erro ao Deletar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //Deletando
                    int id = int.Parse(lblId.Text);
                    FuncionarioController.Deletar(ListaFuncionario.Find(x => x.Id == id));
                    AtualizarDados();
                    if (ListaFuncionario.Count > 0)//se tem registro exibe o primeiro
                    {
                        ExibirDados(ListaFuncionario[0]);
                    }
                    else
                    {
                        Limpar();
                    }
                    AberturaForm();
                    MessageBox.Show("Deletado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnPrimeiroRegistro_Click(object sender, EventArgs e)
        {
            if (ListaFuncionario.Count>1)
            {
                if (txtNome.Enabled)
                {
                    DialogResult dialogResult = MessageBox.Show("Sair da Edição ?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (dialogResult==DialogResult.No)
                    {
                        return;
                    }
                }
                AberturaForm();
                ExibirDados(ListaFuncionario[0]);

            }
        }
        private void btnUltimoRegistro_Click(object sender, EventArgs e)
        {
            if (ListaFuncionario.Count > 1)
            {
                if (txtNome.Enabled)
                {
                    DialogResult dialogResult = MessageBox.Show("Sair da Edição ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                AberturaForm();
                ExibirDados(ListaFuncionario[ListaFuncionario.Count-1]);

            }
        }
        private void btnAnteriorRegristro_Click(object sender, EventArgs e)
        {
            if (ListaFuncionario.Count > 1)
            {
                if (txtNome.Enabled)
                {
                    DialogResult dialogResult = MessageBox.Show("Sair da Edição ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                AberturaForm();
                if (lblId.Text.Length==0)
                {
                    ExibirDados(ListaFuncionario[0]);
                }
                else
                {
                    int index = ListaFuncionario.FindIndex(x => x.Id == int.Parse(lblId.Text));
                    if (index == 0)
                    {
                        ExibirDados(ListaFuncionario[index]);
                    }
                    else
                    {
                        ExibirDados(ListaFuncionario[index-1]);
                    }
                }


            }
        }
        private void btnProximoRegistro_Click(object sender, EventArgs e)
        {
            if (ListaFuncionario.Count > 1)
            {
                if (txtNome.Enabled)
                {
                    DialogResult dialogResult = MessageBox.Show("Sair da Edição ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                AberturaForm();
                if (lblId.Text.Length == 0)
                {
                    ExibirDados(ListaFuncionario[0]);
                }
                else
                {
                    int index = ListaFuncionario.FindIndex(x => x.Id == int.Parse(lblId.Text));


                    if (index == ListaFuncionario.Count-1)
                    {
                        ExibirDados(ListaFuncionario[index]);
                    }
                    else
                    {
                        ExibirDados(ListaFuncionario[index + 1]);
                    }
                }
            }
        }
        #endregion


    }
}
