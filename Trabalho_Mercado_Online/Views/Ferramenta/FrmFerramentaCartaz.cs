using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
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
        Bitmap bitmapImprimir= null;
        Bitmap bitmapTop1 = null;
        Bitmap bitmapTop2 = null;
        Bitmap bitmapBot1 = null;
        Bitmap bitmapBot2 = null;
        #endregion
        #region Funções
        void ExibirImagem()
        {
            if (txtComplemento.Text.Trim().Length>0)
            {
                picCartaz.BackgroundImage = CartazHelper.CartazLinha3(txtNome.Text, txtDescricao.Text, txtComplemento.Text, txtValor.Text);
            }
            else
            {
                picCartaz.BackgroundImage = CartazHelper.CartazLinha2(txtNome.Text, txtDescricao.Text, txtValor.Text);
            }
           
        }
        void SalvarImagem()
        {
            Bitmap bitmapOriginal = new Bitmap(picCartaz.BackgroundImage);
            //Point A3 = new Point(7016, 9920);
            bitmapTop1 = bitmapOriginal.Clone(new Rectangle(0,0,3508,4960), bitmapOriginal.PixelFormat);

            bitmapTop2 = bitmapOriginal.Clone(new Rectangle(3508, 0, 3508, 4960), bitmapOriginal.PixelFormat);
           
            bitmapBot1 = bitmapOriginal.Clone(new Rectangle(0, 4960, 3508, 4960), bitmapOriginal.PixelFormat);

            bitmapBot2 = bitmapOriginal.Clone(new Rectangle(3508, 4960, 3508, 4960), bitmapOriginal.PixelFormat);
            
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                bitmapTop1.Save(dialog.FileName + "1.jpg");
                bitmapTop2.Save(dialog.FileName + "2.jpg");
                bitmapBot1.Save(dialog.FileName + "3.jpg");
                bitmapBot2.Save(dialog.FileName + "4.jpg");
            }



        }
        void ImprimirImagem()
        {
            Bitmap bitmapOriginal = new Bitmap(picCartaz.BackgroundImage);
            bitmapImprimir = null;
            bitmapTop1 = bitmapOriginal.Clone(new Rectangle(0, 0, 3508, 4960), bitmapOriginal.PixelFormat);

            bitmapTop2 = bitmapOriginal.Clone(new Rectangle(3508, 0, 3508, 4960), bitmapOriginal.PixelFormat);

            bitmapBot1 = bitmapOriginal.Clone(new Rectangle(0, 4960, 3508, 4960), bitmapOriginal.PixelFormat);

            bitmapBot2 = bitmapOriginal.Clone(new Rectangle(3508, 4960, 3508, 4960), bitmapOriginal.PixelFormat);

            
            PaperSize paperSize = new PaperSize("A3", 3508, 4960);
            printDocument.DefaultPageSettings.PaperSize = paperSize;
            
            bitmapImprimir = bitmapTop1;
            printDocument.Print();
            bitmapImprimir = bitmapTop2;
            printDocument.Print();
            bitmapImprimir = bitmapBot1;
            printDocument.Print();
            bitmapImprimir = bitmapBot2;
            printDocument.Print();

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
                ExibirImagem();
            }
           
        }
        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {
            if (chkVizualizacao.Checked)
            {
                ExibirImagem();
            }
        }
        private void txtComplemento_TextChanged(object sender, EventArgs e)
        {
            if (chkVizualizacao.Checked)
            {
                ExibirImagem();
            }
        }
        private void txtValorProduto_TextChanged(object sender, EventArgs e)
        {
            if (chkVizualizacao.Checked)
            {
                ExibirImagem();
            }
        }
        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            ExibirImagem();
        }
        private void chkVizualizacao_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVizualizacao.Checked)
            {
                ExibirImagem();
            }
        }





        #endregion

       

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNome.Text = String.Empty;
            txtDescricao.Text = String.Empty;
            txtComplemento.Text = String.Empty;
            txtValor.Text = String.Empty;
            picCartaz.BackgroundImage = null;
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                SalvarImagem();
            }
            catch { }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                ImprimirImagem();
            }
            catch { }
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmapImprimir,0,0);
        }
    }
}
