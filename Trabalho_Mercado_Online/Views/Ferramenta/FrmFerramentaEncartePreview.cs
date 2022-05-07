using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Trabalho_Mercado_Online.Helpers;

namespace Trabalho_Mercado_Online.Views.Ferramenta
{
    public partial class FrmFerramentaEncartePreview : Form
    {
        public FrmFerramentaEncartePreview(Bitmap Img)
        {
            InitializeComponent();
            pictureBox1.BackgroundImage = Img;
        }
    }
}
