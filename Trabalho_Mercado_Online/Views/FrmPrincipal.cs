using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Trabalho_Mercado_Online.DAO;
using System.Linq;
using Trabalho_Mercado_Online.Views_Access;

namespace Trabalho_Mercado_Online.Views
{
    public partial class FrmPrincipal : Form
    {

        #region Variaveis 
        int x, y;
        Point Point = new Point();
        bool move = false;
        private Form activeForm = null;
        #endregion
        
        #region Funções 
        void DesignerPersonalizado()
        {
            panelBasedeDadosSubMenu.Visible = false;
            panelFerramentasSubMenu.Visible = false;
            panelAccessSubMenu.Visible = false;
            panelMenuLateral.Focus();
        }
        void EsconderSubMenu()
        {
            if (panelBasedeDadosSubMenu.Visible)
            {
                panelBasedeDadosSubMenu.Visible = false;
            }
            if (panelFerramentasSubMenu.Visible)
            {
                panelFerramentasSubMenu.Visible = false;
            }
            if (panelAccessSubMenu.Visible)
            {
                panelAccessSubMenu.Visible = false;
            }
        }
        void ExibirMenu(Panel subMenu)
        {
            if (subMenu.Visible==false)
            {
                EsconderSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
            panelMenuLateral.Focus();
        }
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

        //Inicio do form
        public FrmPrincipal()
        {
            InitializeComponent();
            DesignerPersonalizado();
            openChildForm(new FrmInicio(this));
        }
       
        //interface sub menu
        private void btnBasedeDados_Click(object sender, EventArgs e)
        {
            ExibirMenu(panelBasedeDadosSubMenu);

        }
        private void btnFerramentas_Click(object sender, EventArgs e)
        {
            ExibirMenu(panelFerramentasSubMenu);

        }
        private void btnAccess_Click(object sender, EventArgs e)
        {
            ExibirMenu(panelAccessSubMenu);

        }
        
        //interface formulario
        private void panelLogo_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                x = Control.MousePosition.X - this.Location.X;
                y = Control.MousePosition.Y - this.Location.Y;
            }
            catch { }
        }
        private void panelLogo_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point = Control.MousePosition;
                    Point.X -= x;
                    Point.Y -= y;
                    this.Location = Point;
                    move = true;
                    Application.DoEvents();
                }
            }
            catch { }
        }
        private void panelLogoImagem_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                x = Control.MousePosition.X - this.Location.X;
                y = Control.MousePosition.Y - this.Location.Y;
            }
            catch { }
        }
        private void panelLogoImagem_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point = Control.MousePosition;
                    Point.X -= x;
                    Point.Y -= y;
                    this.Location = Point;
                    move = true;
                    Application.DoEvents();
                }
            }
            catch { }
        }
        private void lblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                x = Control.MousePosition.X - this.Location.X;
                y = Control.MousePosition.Y - this.Location.Y;
            }
            catch { }
        }
        private void lblTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point = Control.MousePosition;
                    Point.X -= x;
                    Point.Y -= y;
                    this.Location = Point;
                    move = true;
                    Application.DoEvents();
                }
            }
            catch { }
        }

        //Abrir Inicio
        private void panelLogoImagem_Click(object sender, EventArgs e)
        {
            if (move == false)
            {
                openChildForm(new FrmInicio(this));
                EsconderSubMenu();
            }
            else
            {
                move = false;
            }
        }
        private void lblTitulo_Click(object sender, EventArgs e)
        {
            if (move == false)
            {
                openChildForm(new FrmInicio(this));
                EsconderSubMenu();
            }
            else
            {
                move = false;
            }
        }
        private void panelLogo_Click(object sender, EventArgs e)
        {
            if (move == false)
            {
                openChildForm(new FrmInicio(this));
                EsconderSubMenu();
            }
            else
            {
                move = false;
            }
        }

        //Botoes do menu Base de Dados
        private void btnProdutos_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmProdutos());
        }
        private void btnCategoriasNivel1_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmCategorias_Nivel_1());
        }
        private void btnCategoriasNivel2_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmCategorias_Nivel_2());
        }
        private void btnCategoriasNivel3_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmCategorias_Nivel_3());
        }

        //Botoes do menu Ferramentas
        private void btnImagens_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmPesquisarImagem());
        }

        //Botoes do menu Access
        private void btnAlimentarProdutos_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmAlimentarProdutosAccess());
        }

        private void btnProdutosAccess_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmProdutosAccess());
        }

        

        //Botoes de Sair
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
