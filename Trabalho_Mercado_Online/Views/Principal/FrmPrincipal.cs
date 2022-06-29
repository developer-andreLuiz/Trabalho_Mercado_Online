using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Trabalho_Mercado_Online.DAO;
using System.Linq;
using Trabalho_Mercado_Online.Views.Access;
using Trabalho_Mercado_Online.Helpers;
using Trabalho_Mercado_Online.Views.Ferramenta;
using Trabalho_Mercado_Online.Views.Armazenamento;
using Trabalho_Mercado_Online.Views.Dados;

namespace Trabalho_Mercado_Online.Views.Principal
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
        #region Classes Aux
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs myMenu)
            {
                if (!myMenu.Item.Selected)
                {
                    base.OnRenderMenuItemBackground(myMenu);
                }
                else
                {
                    Rectangle menuRectangle = new Rectangle(Point.Empty, myMenu.Item.Size);

                    //Fill Color


                    myMenu.Graphics.FillRectangle(Brushes.SteelBlue, menuRectangle);

                    //// Border Color
                    //myMenu.Graphics.DrawRectangle(Pens.Lime, 1, 0, menuRectangle.Width - 2, menuRectangle.Height - 1);
                }
            }
        }
        private class MyColors : ProfessionalColorTable
        {
            public override Color ToolStripDropDownBackground
            {
                get { return Color.Black; }
            }

            public override Color MenuItemPressedGradientBegin
            {
                get { return Color.SteelBlue; }
            }

            public override Color MenuItemPressedGradientEnd
            {
                get { return Color.SteelBlue; }
            }
        }
        #endregion
        #region Eventos 
        
        //Inicio do Form
        public FrmPrincipal()
        {
            InitializeComponent();
            menuStrip.Renderer = new MyRenderer();
            openChildForm(new FrmPrincipalInicio(this));
        }
        
        //Interface Form
        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                x = Control.MousePosition.X - this.Location.X;
                y = Control.MousePosition.Y - this.Location.Y;
            }
            catch { }
        }
        private void panelTop_MouseMove(object sender, MouseEventArgs e)
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
        private void panelTopLogo_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                x = Control.MousePosition.X - this.Location.X;
                y = Control.MousePosition.Y - this.Location.Y;
            }
            catch { }
        }
        private void panelTopLogo_MouseMove(object sender, MouseEventArgs e)
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
        private void lblTopNome_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                x = Control.MousePosition.X - this.Location.X;
                y = Control.MousePosition.Y - this.Location.Y;
            }
            catch { }
        }
        private void lblTopNome_MouseMove(object sender, MouseEventArgs e)
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
        private void lblTopDelivery_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                x = Control.MousePosition.X - this.Location.X;
                y = Control.MousePosition.Y - this.Location.Y;
            }
            catch { }
        }
        private void lblTopDelivery_MouseMove(object sender, MouseEventArgs e)
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
        
        //Botoes Form
       
        //Inicio
        private void panelTopLogo_Click(object sender, EventArgs e)
        {
            if (move == false)
            {
                openChildForm(new FrmPrincipalInicio(this));
            }
            else
            {
                move = false;
            }
        }
        private void lblTopNome_Click(object sender, EventArgs e)
        {
            if (move == false)
            {
                openChildForm(new FrmPrincipalInicio(this));
            }
            else
            {
                move = false;
            }
        }
        private void panelTop_Click(object sender, EventArgs e)
        {
            if (move == false)
            {
                openChildForm(new FrmPrincipalInicio(this));
            }
            else
            {
                move = false;
            }
        }
        private void lblTopDelivery_Click(object sender, EventArgs e)
        {
            if (move == false)
            {
                openChildForm(new FrmPrincipalInicio(this));
            }
            else
            {
                move = false;
            }
        }
        
        //Dados
        private void dadosProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmDadosProdutos());
        }
      
        private void dadosCategoria1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmDadosCategoria_Nivel_1());
        }
        private void dadosCategoria2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmDadosCategoria_Nivel_2());
        }
        private void dadosCategoria3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmDadosCategoria_Nivel_3());
        }
       
        private void dadosFuncionarioFuncionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmDadosFuncionarios());
        }
        private void dadosFuncionarioCargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmDadosFuncionarioCargo());
        }

        //Armazenamento
        
        //Loja
        private void armazenamentoLojaProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmArmazenamentoLojaProduto());
        }
        private void armazenamentoLojaEstruturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmArmazenamentoLojaEstrutura());
        }
        //Estoque
        private void armazenamentoEstoqueProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void armazenamentoEstoqueEstruturaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //Ferramenta
        private void ferramentaEncarteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmFerramentaEncarte());
        }
        private void ferramentaCartazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmFerramentaCartaz());
        }
        private void ferramentaImagemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmFerramentaPesquisarImagem());
        }

        //Access
        private void accessAlimentarProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmAccessAlimentarProdutoAccess());
        }
        private void accessProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmAccessProdutosAccess());
        }

        


        //Sair
        private void btnSair_Click(object sender, EventArgs e)
        {
            GlobalHelper.FinalizarThread();
            Application.Exit();
        }

        #endregion
    }
}