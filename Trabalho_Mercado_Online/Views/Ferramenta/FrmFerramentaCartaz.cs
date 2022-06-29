using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabalho_Mercado_Online.Helpers;

namespace Trabalho_Mercado_Online.Views.Ferramenta
{
    public partial class FrmFerramentaCartaz : Form
    {
        #region Variaveis
        #endregion
        #region Funções
        void ExibirCartaz()
        {
            picCartaz.BackgroundImage = CartazHelper.Cartaz(txtNome.Text, txtDescricao.Text, txtComplemento.Text, txtValor.Text);
        }
        void ExportarImagem()
        {
            Bitmap bitmapOriginal = new Bitmap(picCartaz.BackgroundImage);
            //Point A3 = new Point(7016, 9920);
            Bitmap bitmapTop1 = bitmapOriginal.Clone(new Rectangle(0,0,3508,4960), bitmapOriginal.PixelFormat);

            Bitmap bitmapTop2 = bitmapOriginal.Clone(new Rectangle(3508, 0, 3508, 4960), bitmapOriginal.PixelFormat);
           
            Bitmap bitmapBot1 = bitmapOriginal.Clone(new Rectangle(0, 4960, 3508, 4960), bitmapOriginal.PixelFormat);

            Bitmap bitmapBot2 = bitmapOriginal.Clone(new Rectangle(3508, 4960, 3508, 4960), bitmapOriginal.PixelFormat);
            
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                bitmapTop1.Save(dialog.FileName + "1.jpg");
                bitmapTop2.Save(dialog.FileName + "2.jpg");
                bitmapBot1.Save(dialog.FileName + "3.jpg");
                bitmapBot2.Save(dialog.FileName + "4.jpg");
            }



        }
        #endregion
        #region Eventos
        public FrmFerramentaCartaz()
        {
            InitializeComponent();

        }
        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            if (chkVizualizacao.Checked)
            {
                ExibirCartaz();
            }
           
        }
        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {
            if (chkVizualizacao.Checked)
            {
                ExibirCartaz();
            }
        }
        private void txtComplemento_TextChanged(object sender, EventArgs e)
        {
            if (chkVizualizacao.Checked)
            {
                ExibirCartaz();
            }
        }
        private void txtValorProduto_TextChanged(object sender, EventArgs e)
        {
            if (chkVizualizacao.Checked)
            {
                ExibirCartaz();
            }
        }
        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            ExibirCartaz();
        }
        private void chkVizualizacao_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVizualizacao.Checked)
            {
                ExibirCartaz();
            }
        }
        private void btnSalvarEncarte_Click(object sender, EventArgs e)
        {
            try
            {
                ExportarImagem();
            }
            catch(Exception EX) { MessageBox.Show(EX.Message); }
        }
        private void btnCancelarEncarte_Click(object sender, EventArgs e)
        {
            txtNome.Text = String.Empty;
            txtDescricao.Text = String.Empty;
            txtComplemento.Text = String.Empty;
            txtValor.Text = String.Empty;
            picCartaz.BackgroundImage = null;
        }



        #endregion

     
    }
}
