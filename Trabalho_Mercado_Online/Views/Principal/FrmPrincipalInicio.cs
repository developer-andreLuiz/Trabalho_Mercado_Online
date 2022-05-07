using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Trabalho_Mercado_Online.Views.Principal
{
    public partial class FrmPrincipalInicio : Form
    {
        FrmPrincipal frmPrincipal = null;
        bool animInicial = true;
        bool animFinal = false;
        //750; 470 final
        //750; 490 final
        // 744; 700
        public FrmPrincipalInicio(FrmPrincipal frm)
        {
            InitializeComponent();
            frmPrincipal = frm;
        }

        private void timerAnim_Tick(object sender, EventArgs e)
        {
            if (animInicial)
            {
                if (panelLogo.Location.Y != 450)
                {
                    panelLogo.Location = new Point(panelLogo.Location.X, panelLogo.Location.Y - 5);
                }
                else
                {
                    animInicial = false;
                    animFinal = true;
                }
            }
            if (animFinal)
            {
                if (panelLogo.Location.Y != 490)
                {
                    panelLogo.Location = new Point(panelLogo.Location.X, panelLogo.Location.Y + 5);
                   
                }
                else
                {
                    animInicial = false;
                    animFinal = false;
                    timerAnim.Enabled = false;
                }
            }

        }
    }
}
