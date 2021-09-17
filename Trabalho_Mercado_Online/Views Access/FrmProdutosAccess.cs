using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Trabalho_Mercado_Online.Helpers;
using Trabalho_Mercado_Online.Controllers;

namespace Trabalho_Mercado_Online.Views_Access
{
    public partial class FrmProdutosAccess : Form
    {
        #region Variaveis
        #endregion
        #region Funções
        void AtualizarProduto()
        {
            Global.Listas.Produtos = ProdutosController.GetAll();
            Global.Listas.ProdutosCodigoBarra = ProdutosCodigoBarraController.GetAll();
        }
        void Filtrar()
        {

        }
        #endregion
        #region Eventos
        public FrmProdutosAccess()
        {
            InitializeComponent();
        }
        #endregion

    }
}
