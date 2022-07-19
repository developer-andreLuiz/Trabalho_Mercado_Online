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

        List<Point> ListPosTxt = new List<Point>() 
        {
            new Point(0,0),
            new Point(0,0),
            new Point(0,0),
            new Point(0,0)
        };
        List<int> ListFontSize = new List<int>()
        {
            100,
            100,
            100,
            100
        };

        #endregion
       
        #region Funções
        void ExibirImagem()
        {
            picCartaz.BackgroundImage = CartazHelper.Cartaz(txtNome.Text, txtDescricao.Text, txtComplemento.Text, txtValor.Text, ListPosTxt, ListFontSize);
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
     

        #endregion
       
        #region Eventos
        public FrmFerramentaCartaz()
        {
            InitializeComponent();
        }

        //Interface
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

        //Visualização
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

        //Btns
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

        //Ajuste
        private void nUDHorizontal_ValueChanged(object sender, EventArgs e)
        {
            if (rbNome.Checked)
            {
                int pos = 0;
                ListPosTxt[pos] = new Point((int)nUDHorizontal.Value, ListPosTxt[pos].Y);
            }
            if (rbDescicao.Checked)
            {
                int pos = 1;
                ListPosTxt[pos] = new Point((int)nUDHorizontal.Value, ListPosTxt[pos].Y);
            }
            if (rbComplemento.Checked)
            {
                int pos = 2;
                ListPosTxt[pos] = new Point((int)nUDHorizontal.Value, ListPosTxt[pos].Y);
            }
            if (rbValor.Checked)
            {
                int pos = 3;
                ListPosTxt[pos] = new Point((int)nUDHorizontal.Value, ListPosTxt[pos].Y);
            }
            if (chkVizualizacao.Checked)
            {
                ExibirImagem();
            }
        }
        private void nUDVertical_ValueChanged(object sender, EventArgs e)
        {
            if (rbNome.Checked)
            {
                int pos = 0;
                ListPosTxt[pos] = new Point(ListPosTxt[pos].X, (int)nUDVertical.Value);
            }
            if (rbDescicao.Checked)
            {
                int pos = 1;
                ListPosTxt[pos] = new Point(ListPosTxt[pos].X, (int)nUDVertical.Value);
            }
            if (rbComplemento.Checked)
            {
                int pos = 2;
                ListPosTxt[pos] = new Point(ListPosTxt[pos].X, (int)nUDVertical.Value);
            }
            if (rbValor.Checked)
            {
                int pos = 3;
                ListPosTxt[pos] = new Point(ListPosTxt[pos].X, (int)nUDVertical.Value);
            }
            if (chkVizualizacao.Checked)
            {
                ExibirImagem();
            }
        }
        private void nUDFonte_ValueChanged(object sender, EventArgs e)
        {
            if (rbNome.Checked)
            {
                int pos = 0;
                ListFontSize[pos] = (int)nUDFonte.Value > 0 ? (int)nUDFonte.Value : 1;

            }
            if (rbDescicao.Checked)
            {
                int pos = 1;
                ListFontSize[pos] = (int)nUDFonte.Value > 0 ? (int)nUDFonte.Value : 1;
            }
            if (rbComplemento.Checked)
            {
                int pos = 2;
                ListFontSize[pos] = (int)nUDFonte.Value > 0 ? (int)nUDFonte.Value : 1;
            }
            if (rbValor.Checked)
            {
                int pos = 3;
                ListFontSize[pos] = (int)nUDFonte.Value > 0 ? (int)nUDFonte.Value : 1;
            }
            if (chkVizualizacao.Checked)
            {
                ExibirImagem();
            }
        }

        private void rbNome_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNome.Checked)
            {
                int pos = 0;
                nUDHorizontal.Value = ListPosTxt[pos].X;
                nUDVertical.Value = ListPosTxt[pos].Y;
                nUDFonte.Value = ListFontSize[pos];
            }
        }
        private void rbDescicao_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDescicao.Checked)
            {
                int pos = 1;
                nUDHorizontal.Value = ListPosTxt[pos].X;
                nUDVertical.Value = ListPosTxt[pos].Y;
                nUDFonte.Value = ListFontSize[pos];
            }
        }
        private void rbComplemento_CheckedChanged(object sender, EventArgs e)
        {
            if (rbComplemento.Checked)
            {
                int pos = 2;
                nUDHorizontal.Value = ListPosTxt[pos].X;
                nUDVertical.Value = ListPosTxt[pos].Y;
                nUDFonte.Value = ListFontSize[pos];
            }
        }
        private void rbValor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbValor.Checked)
            {
                int pos = 3;
                nUDHorizontal.Value = ListPosTxt[pos].X;
                nUDVertical.Value = ListPosTxt[pos].Y;
                nUDFonte.Value = ListFontSize[pos];
            }
        }





        #endregion


    }
}
