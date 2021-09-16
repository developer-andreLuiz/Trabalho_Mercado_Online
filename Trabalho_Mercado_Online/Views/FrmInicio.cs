using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Trabalho_Mercado_Online.Views
{
    public partial class FrmInicio : Form
    {
        FrmPrincipal frmPrincipal = null;
        public FrmInicio( FrmPrincipal frm)
        {
            InitializeComponent();
            frmPrincipal = frm;
        }

       
    }
}
