using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Trabalho_Mercado_Online.Views.Armazenamento
{
    public partial class FrmArmazenamentoLojaProduto : Form
    {
        #region Variaveis 
        //Open Form
        private Form activeForm = null;
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
        #endregion
        #region Eventos 
        public FrmArmazenamentoLojaProduto()
        {
            InitializeComponent();
        }
        private void txtInformacao_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOuvir_Click(object sender, EventArgs e)
        {

        }

        #endregion


    }
}
