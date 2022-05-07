using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Trabalho_Mercado_Online.Helpers;
using Trabalho_Mercado_Online.Controllers;

namespace Trabalho_Mercado_Online.Views.Access
{
    public partial class FrmAccessProdutosAccess : Form
    {
        #region Variaveis
        WebBrowser Navegador = new WebBrowser();
        #endregion
        #region Funções
        void AtualizarProduto()
        {
            GlobalHelper.Listas.Produto = ProdutoController.GetAll();
            GlobalHelper.Listas.ProdutoCodigoBarra = ProdutoCodigoBarraController.GetAll();
        }
        void Filtrar()
        {

        }
        #endregion
        #region Eventos
        public FrmAccessProdutosAccess()
        {
            InitializeComponent();
         
            this.Controls.Add(Navegador);
            Navegador.Size = new Size(500, 500);
            Navegador.Location = new Point(170, 100);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            
            Navegador.Navigate("www.gloogle.com.br");
        }
    }
}
