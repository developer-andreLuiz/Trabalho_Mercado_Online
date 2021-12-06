using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Trabalho_Mercado_Online.Views
{
    public partial class FrmEncarte : Form
    {
        #region Variaveis
        //2480 x 3508 tamanho A4  Panel 6x menor
        bool Editando = false;
        Label NomeProduto = null;
        Label ValorProduto = null;

        #endregion

        #region Funções
        void EncarteA4()
        {
            panelMid.Controls.Clear();
            int x = 135;
            int y = 90;

            int Linha = 0;
            int Coluna = 0;

            for (int i = 1; i < 16; i++)
            {
                Label lblProduto = new Label();
                lblProduto.Name = "lblProduto" + i;
                lblProduto.Text = "Produto Produto Produto";
                lblProduto.Font = new Font("Arial", 8, FontStyle.Regular);
                lblProduto.Size = new Size(130, 12);
                lblProduto.Click += lblProduto_Click;
                lblProduto.TextAlign = ContentAlignment.MiddleCenter;
                lblProduto.BackColor = Color.White;
                lblProduto.ForeColor = Color.Black;
                panelMid.Controls.Add(lblProduto);
                lblProduto.Location = new Point(7 + (Coluna * x), 5 + (Linha * y));

                Label lblValor = new Label();
                lblValor.Name = "lblValor" + i;
                lblValor.Text = "00,00";
                lblValor.Font = new Font("Arial", 10, FontStyle.Bold);
                lblValor.Size = new Size(53, 16);
                lblValor.Click += lblValor_Click;
                lblProduto.TextAlign = ContentAlignment.MiddleCenter;
                lblValor.BackColor = Color.Red;
                lblValor.ForeColor = Color.White;
                panelMid.Controls.Add(lblValor);
                lblValor.Location = new Point(76 + (Coluna * x), 74 + (Linha * y));

                Panel pnlImg = new Panel();
                pnlImg.Name = "pnlImg" + i;
                pnlImg.Size = new Size(125, 80);
                pnlImg.Click += pnlImg_Click;
                pnlImg.BackColor = Color.Black;
                pnlImg.BackgroundImageLayout = ImageLayout.Stretch;
                panelMid.Controls.Add(pnlImg);
                pnlImg.Location = new Point(7 + (Coluna * x), 10 + (Linha * y));



                Coluna++;
                if (Coluna == 3)
                {
                    Coluna = 0;
                    Linha++;
                }
            }

            Label lblEndereço = new Label();

            lblEndereço.Text = "Endereço: Rua Alfredo Bahiense, 79 - Boaçu, São Gonçalo";
            lblEndereço.Font = new Font("Arial", 8, FontStyle.Bold);
            lblEndereço.TextAlign = ContentAlignment.MiddleCenter;
            lblEndereço.Size = new Size(411, 20);
            lblEndereço.BackColor = Color.Red;
            lblEndereço.ForeColor = Color.White;
            panelMid.Controls.Add(lblEndereço);
            lblEndereço.Location = new Point(0, 457);
        }
        void EncarteA3()
        {

        }
        #endregion

        #region Eventos
        public FrmEncarte()
        {
            InitializeComponent();
        }

        #endregion
        private void lblProduto_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.TextAlign=ContentAlignment.MiddleCenter;
            NomeProduto = lbl;
            txtProduto.Text = lbl.Text;
            txtProduto.Focus();
          
        }
        private void lblValor_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            ValorProduto = lbl;
            txtValor.Text = lbl.Text;
            txtValor.Focus();
        }
        private void pnlImg_Click(object sender, EventArgs e)
        {
            //Button btn = (Button)sender;
            //ImagemOriginal = new Bitmap(btn.BackgroundImage);
            //pictureBox.BackgroundImage = btn.BackgroundImage;
        }













        private void btnPesquisar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {

        }

        private void txtProduto_TextChanged(object sender, EventArgs e)
        {
            if (NomeProduto!=null)
            {
                NomeProduto.Text = txtProduto.Text;
               
            }
        }
        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            if (ValorProduto != null)
            {
                ValorProduto.Text = txtValor.Text;
            }
        }
        private void cbTipoEncarte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Editando==false)
            {
                if (cbTipoEncarte.Text.Equals("A4"))
                {
                    EncarteA4();
                }
            }
        }
    }
}
