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
    public partial class FrmDadosFuncionarios : Form
    {
        #region Variaveis
        private Form activeForm = null;
        List<FuncionarioCargo> ListaFuncionarioCargo = new List<FuncionarioCargo>();
        List<Funcionario> ListaFuncionario= new List<Funcionario>();
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
        public void AtualizarDados()
        {
            ListaFuncionarioCargo = FuncionarioCargoController.GetAll();
            ListaFuncionario = FuncionarioController.GetAll();
        }
        void ComboFuncionarioCargo()
        {
            cbCargo.DataSource = null;
            cbCargo.DisplayMember = "Nome";
            cbCargo.ValueMember = "Id";
            cbCargo.DataSource = ListaFuncionarioCargo;
        }
        void LimparFiltro()
        {
            txtNome.Text=String.Empty;
            chkCargo.Checked=false;
            chkHabilitado.Checked=true;    
        }
        void Filtrar()
        {
            dataGridView.DataSource = null;
            List<FuncionariosDataGridHelper_Model> ListaGrid = new List<FuncionariosDataGridHelper_Model>();
            List<Funcionario> ListaFuncionarioLocal = new List<Funcionario>();
           
            bool nome = !String.IsNullOrEmpty(txtNome.Text);
            bool cargo = chkCargo.Checked;
            bool habilitado = chkHabilitado.Checked;

            //sem Filtro
            ListaFuncionarioLocal.AddRange(ListaFuncionario);

            if (nome)
            {
                string txt = StringHelper.FormatarStringMaiusculo(txtNome.Text);
                var listTxt = txt.Split(" ");
                foreach (var item in listTxt)
                {
                    var lt = ListaFuncionarioLocal.FindAll(x => StringHelper.FormatarStringMaiusculo(x.Nome).Contains(item, StringComparison.InvariantCultureIgnoreCase));
                    ListaFuncionarioLocal = lt;
                }
            }

            if (cargo)
            {
                if (cbCargo.SelectedValue != null)
                {
                    int valor = int.Parse(cbCargo.SelectedValue.ToString());
                    var lt = ListaFuncionarioLocal.FindAll(x => x.Cargo == valor);
                    ListaFuncionarioLocal = lt;
                }
            }
          
            if (habilitado)
            {
                var lt = ListaFuncionarioLocal.FindAll(x => x.Habilitado == true);
                ListaFuncionarioLocal = lt;
            }
            else
            {
                var lt = ListaFuncionarioLocal.FindAll(x => x.Habilitado == false);
                ListaFuncionarioLocal = lt;
            }
            
            #region Formatação dos Dados Grid
            foreach (var item in ListaFuncionarioLocal)
            {
                FuncionariosDataGridHelper_Model obj = new FuncionariosDataGridHelper_Model();
                obj.Id = item.Id.ToString();
                obj.Nome = item.Nome;
                ListaGrid.Add(obj);
            }
            dataGridView.DataSource = ListaGrid;
            if (ListaGrid.Count>0)
            {
                dataGridView.Columns[0].Width = 100;
                dataGridView.Columns[1].Width = 750;
            }
            lblTotal.Text = $"Total: {ListaGrid.Count}";
            #endregion
        }
        #endregion

        #region Eventos
        public FrmDadosFuncionarios()
        {
            InitializeComponent();
            LimparFiltro();
            AtualizarDados();
            ComboFuncionarioCargo();
            Filtrar();
        }
        //Filtro
        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }
        private void chkHabilitado_CheckedChanged(object sender, EventArgs e)
        {
            Filtrar();
        }
        private void chkCargo_CheckedChanged(object sender, EventArgs e)
        {
            Filtrar();
        }
        private void cbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtrar();
        }
        private void btnLimparFiltro_Click(object sender, EventArgs e)
        {
            LimparFiltro();
        }
      
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
                openChildForm(new FrmDadosFuncionario(ListaFuncionario.Find(x => x.Id == id)));
            }
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmDadosFuncionario(null));
        }

        #endregion


    }
}
