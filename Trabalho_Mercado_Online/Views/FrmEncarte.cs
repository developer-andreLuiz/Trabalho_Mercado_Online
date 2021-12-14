using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Trabalho_Mercado_Online.Models;
using Trabalho_Mercado_Online.Controllers;
using Trabalho_Mercado_Online.Helpers;

namespace Trabalho_Mercado_Online.Views
{
    public partial class FrmEncarte : Form
    {
        #region Variaveis
       
        List<Encarte> ListaEncarte = new List<Encarte>();
        List<EncarteItem> ListaEncarteItens = new List<EncarteItem>();
        private Form activeForm = null;
        #endregion

        #region Funções
        void OpenForm()
        {
           
            AtualizarLista();
            CarregarGrid();
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
        void AtualizarLista()
        {
            ListaEncarte = EncarteController.GetAll();
            ListaEncarteItens = EncarteItemController.GetAll();
        }
        void CarregarGrid()
        {
            if (ListaEncarte.Count>0)
            {
                List<Encarte> lista = new List<Encarte>();
                lista.AddRange(ListaEncarte);
                //if (txtPesquisar.Text.Length>0)
                //{
                //    string txt = StringService.FormatarStringMaiusculo(txtPesquisar.Text);
                //    var listTxt = txt.Split(" ");
                //    foreach (var item in listTxt)
                //    {
                //        var lt = lista.FindAll(x => StringService.FormatarStringMaiusculo(x.Nome).Contains(item, StringComparison.InvariantCultureIgnoreCase));
                //        lista = lt;
                //    }
                //}
                //dataGridView.DataSource = null;
                //dataGridView.DataSource = lista;
            }
        }
        #endregion

        #region Eventos
        public FrmEncarte()
        {
            InitializeComponent();
            OpenForm();
        }
        private void btnImagensOnline_Click(object sender, EventArgs e)
        {
            Bitmap ImgTop = (Bitmap)ImagemHelper.ResizeImage(new Bitmap("C:\\Users\\Public\\Pictures\\top.jpg"), 3508, 1014);
            picEncarte.BackgroundImage = EncarteHelper.EncarteFrente(ImgTop,DateTime.Now.ToShortDateString());
        }
        #endregion


    }
}
