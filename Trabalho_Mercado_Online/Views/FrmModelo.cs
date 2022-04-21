using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Trabalho_Mercado_Online.Views
{
    public partial class FrmModelo : Form
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
        public FrmModelo()
        {
            InitializeComponent();
        }
        #endregion

    }
}
