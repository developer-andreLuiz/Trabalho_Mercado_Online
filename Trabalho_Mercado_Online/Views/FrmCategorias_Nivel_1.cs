using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Trabalho_Mercado_Online.Controllers;
using Trabalho_Mercado_Online.Helpers;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Views
{
    public partial class FrmCategorias_Nivel_1 : Form
    {
        #region Variaveis
        bool novo = false;
        bool editar = false;
        string pathImagem = string.Empty;
        int ultimo = 0;
        #endregion

        #region Funções
        //Interface
        void Limpar()
        {
            pathImagem = string.Empty;
            novo = false;
            editar = false;

            txtNome.Text = string.Empty;
            lblId.Text = "0";
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.ImageLocation = null;
            pictureBox.Image = null;
            pictureBox.BackgroundImage = null;
        }
        void InterfaceAbrir()
        {
            editar = false;
            novo = false;
            txtNome.Enabled = false;
            btnImg.Enabled = false;
            cbCategoriasNivel1.Enabled = true;
            btnNovo.Enabled = true;
            btnEditar.Enabled = true;
            btnGravar.Enabled = false;
            btnDeletar.Text = "    Deletar";
            btnAtualizarLista.Enabled = true;
        }
        void InterfaceNovo()
        {
            Limpar();
            editar = false;
            novo = true;
            txtNome.Focus();
            txtNome.Enabled = true;
            btnImg.Enabled = true;
            cbCategoriasNivel1.Enabled = false;
            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnGravar.Enabled = true;
            btnDeletar.Text = "  Cancelar";
            btnAtualizarLista.Enabled = false;
        }
        void InterfaceEditar()
        {
            editar = true;
            novo = false;
            txtNome.Enabled = true;
            btnImg.Enabled = true;
            cbCategoriasNivel1.Enabled = false;
            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnGravar.Enabled = true;
            btnDeletar.Text = "  Cancelar";
            btnAtualizarLista.Enabled = false;
        }
        void InterfaceGravar()
        {
            editar = false;
            novo = false;
            txtNome.Enabled = false;
            btnImg.Enabled = false;
            cbCategoriasNivel1.Enabled = true;
            btnNovo.Enabled = true;
            btnEditar.Enabled = true;
            btnGravar.Enabled = false;
            btnDeletar.Text = "    Deletar";
            btnAtualizarLista.Enabled = true;
        }

        //Dados
        void ExibirDados(CategoriasNivel1 obj)
        {
            lblId.Text = obj.Id.ToString();
            txtNome.Text = obj.Nome;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.ImageLocation = obj.Img;
        }
        RetornoHelper CapturarDados(CategoriasNivel1 obj)
        {
            RetornoHelper retorno = new RetornoHelper();
            obj.Id = int.Parse(lblId.Text);
            if (txtNome.Text.Length > 0)
            {
                obj.Nome = txtNome.Text.ToUpper();
            }
            else
            {
                retorno.Evento = false;
                retorno.Mensagem = "Registro sem Nome";
                txtNome.Focus();
                return retorno;
            }
            obj.Img = "" + obj.Id;
            if (novo == true && pathImagem.Length == 0)
            {
                retorno.Evento = false;
                retorno.Mensagem = "Produto sem Imagem";
                return retorno;
            }
            return retorno;
        }
        void CarregarComboBoxNivel1()
        {
            cbCategoriasNivel1.DataSource = null;
            cbCategoriasNivel1.DisplayMember = "Nome";
            cbCategoriasNivel1.ValueMember = "Id";
            cbCategoriasNivel1.DataSource = Global.Listas.CategoriasNivel1;
        }
        void CarregarListView()
        {
            if (Global.Listas.CategoriasNivel1.Count > 0)
            {
                listView.Items.Clear();
                var list = new List<CategoriasNivel1>();
                foreach (var item in Global.Listas.CategoriasNivel1)
                {
                    list.Add(item);
                }
                   
                list.Sort((x, y) => x.Ordem.CompareTo(y.Ordem));


                foreach (var item in list)
                {
                    ListViewItem itemList = new ListViewItem(item.Nome);
                    itemList.SubItems.Add(item.Id.ToString());
                    itemList.SubItems.Add(item.Ordem.ToString());
                    itemList.SubItems.Add(item.Img);
                    listView.Items.Add(itemList);
                }
            }
        }
        void CarregarAparelho()
        {
            panel.Controls.Clear();
            int quantidade = 0;
            int linha = 0;
           
            int xImparLabel = 40;
            int xParLabel = 160;

            int xImparPic = 7;
            int xParPic = 146;

            foreach (ListViewItem item in listView.Items)
            {
                bool impar = false;
                quantidade++;
                int resto = 0;
                if (quantidade < 2)
                {
                    impar = true;
                }
                else
                {
                    resto = quantidade % 2;
                    if (resto == 0)
                    {
                        impar = false;
                    }
                    else
                    {
                        impar = true;
                    }
                }
              
                if (quantidade > 1)
                {
                    if (impar)
                    {
                        linha = (quantidade / 2) + 1;
                    }
                    else
                    {
                        linha = quantidade / 2;
                    }
                }
                else
                {
                    linha = 1;
                }

                PictureBox pic = new PictureBox();
                Label lbl = new Label();

                pic.BorderStyle = BorderStyle.FixedSingle;
                pic.Size = new Size(133, 79);
                pic.SizeMode = PictureBoxSizeMode.StretchImage;

                pic.ImageLocation = item.SubItems[3].Text;
                lbl.Text = item.Text.Replace(" ", "");

                lbl.TextAlign = ContentAlignment.TopLeft;
                panel.Controls.Add(pic);
                panel.Controls.Add(lbl);

                int altura = 0;
                if (linha == 1)
                {
                    altura = 5;
                }
                else
                {
                    altura = 5 + ((linha - 1) * 105);
                }
                if (impar)
                {
                    pic.Location = new Point(xImparPic, altura);//buscar pos
                    lbl.Location = new Point(xImparLabel, pic.Location.Y + 80);//buscar pos
                }
                else
                {
                    pic.Location = new Point(xParPic, altura);//buscar pos
                    lbl.Location = new Point(xParLabel, pic.Location.Y + 80);//buscar pos
                }
            }
        }
        #endregion

        #region Eventos
        public FrmCategorias_Nivel_1()
        {
            InitializeComponent();
            Global.AtualizarCategorasNivel1();
            InterfaceAbrir();
            CarregarComboBoxNivel1();
            CarregarListView();
            CarregarAparelho();
            if (Global.Listas.CategoriasNivel1.Count>0)
            {
                ExibirDados(Global.Listas.CategoriasNivel1[0]);
            }
        }
        private void cbCategoriasNivel1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!novo && !editar)
            {
                if (cbCategoriasNivel1.DataSource != null)
                {
                    ExibirDados(Global.Listas.CategoriasNivel1.Find(x => x.Id == int.Parse(cbCategoriasNivel1.SelectedValue.ToString())));
                }
            }
            
        }
        private void btnImg_Click(object sender, EventArgs e)
        {
            pathImagem = string.Empty;
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg;*.png;)|*.jpg;*.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pathImagem = open.FileName;
                Image img = Image.FromFile(pathImagem);
                Image ImgNewSize = ImagemHelper.ResizeImage(img, 550, 310);
                ImagemHelper.SaveImg(ImgNewSize);

                pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                pictureBox.Image = null;
                pictureBox.BackgroundImage = null;
                pathImagem = System.IO.Directory.GetCurrentDirectory() + "\\Image.jpg";
                pictureBox.ImageLocation = pathImagem;
            }
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            Limpar();
            InterfaceNovo();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            ultimo= int.Parse(lblId.Text);
            pathImagem = string.Empty;
            if (ultimo>0)
            {
                InterfaceEditar();
            }
            else
            {
                MessageBox.Show("Sem Registro para Editar");
            }
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            CategoriasNivel1 obj = new CategoriasNivel1();
            var retorno = CapturarDados(obj);
            if (retorno.Evento)
            {
                obj = CategoriasNivel1Controller.Gravar(obj);
                if (pathImagem.Length>0)
                {
                    BlobStorageHelper.Upload("categoriasnivel1", obj.Id.ToString(), pathImagem);
                }
                Limpar();
                Global.AtualizarCategorasNivel1();
                CarregarComboBoxNivel1();
                CarregarListView();
                CarregarAparelho();
                ExibirDados(obj);
                InterfaceGravar();
                MessageBox.Show("Atualizado", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(retorno.Mensagem, "Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (btnDeletar.Text.Equals("  Cancelar"))
            {
                DialogResult dialog = MessageBox.Show("Esta em processo de edição, deseja sair ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    Limpar();
                    InterfaceAbrir();

                    if (Global.Listas.CategoriasNivel1.Count > 0)
                    {
                        if (ultimo > 0)
                        {
                            var p = Global.Listas.CategoriasNivel1.Find(x => x.Id == ultimo);
                            ExibirDados(p);
                        }
                        else
                        {
                            ExibirDados(Global.Listas.CategoriasNivel1[0]);
                        }
                    }
                }
            }
            else
            {
                int idDeletar = int.Parse(lblId.Text);
                if (idDeletar>0)
                {
                    DialogResult dialog = MessageBox.Show("ATENÇÃO! Deseja Deletar o Registro? é irreversível.", "Perigo!", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (dialog == DialogResult.Yes)
                    {
                        dialog = MessageBox.Show("ATENÇÃO! Tem Certeza? O Registro será Deletado.", "Perigo!", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                        if (dialog == DialogResult.Yes)
                        {
                            
                            Global.AtualizarProdutosCategoria();
                            Global.AtualizarCategorasNivel1();
                            Global.AtualizarCategorasNivel2();
                            Global.AtualizarCategorasNivel3();

                            var cat = Global.Listas.CategoriasNivel1.Find(x => x.Id == idDeletar);
                            
                            //Deletar em Categoria Nivel 1
                            CategoriasNivel1Controller.Deletar(cat);
                            BlobStorageHelper.Deletar("categoriasnivel1", cat.Id.ToString());

                            //Deletar em Categoria Nivel 2
                            var ListaNivel2 = Global.Listas.CategoriasNivel2.FindAll(x => x.CategoriaNivel1 == cat.Id);
                            foreach (var item in ListaNivel2)
                            {
                                CategoriasNivel2Controller.Deletar(item);
                                BlobStorageHelper.Deletar("categoriasnivel2", item.Id.ToString());
                            }

                            //Deletar em Categoria Nivel 3
                            var ListaNivel3 = Global.Listas.CategoriasNivel3.FindAll(x => x.CategoriaNivel1 == cat.Id);
                            foreach (var item in ListaNivel3)
                            {
                                CategoriasNivel3Controller.Deletar(item);
                                BlobStorageHelper.Deletar("categoriasnivel3", item.Id.ToString());
                            }

                            //Deletar em Produto Categoria
                            var ListaProdutoCategoria = Global.Listas.ProdutosCategoria.FindAll(x => x.CategoriaNivel1 == cat.Id);
                            foreach (var item in ListaProdutoCategoria)
                            {
                                ProdutosCategoriaController.Deletar(item);
                            }


                            Limpar();
                            InterfaceAbrir();
                            Global.AtualizarCategorasNivel1();
                            CarregarComboBoxNivel1();
                            CarregarListView();
                            CarregarAparelho();
                            if(Global.Listas.CategoriasNivel1.Count > 0)
                            {
                                ExibirDados(Global.Listas.CategoriasNivel1[0]);
                            }
                            MessageBox.Show("Atualizado", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Sem Registro para Deletar");
                }
            }
        }
        
        //List View
        private void listView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            listView.DoDragDrop(listView.SelectedItems, DragDropEffects.Link);
        }
        private void listView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Link;
        }
        private void listView_DragDrop(object sender, DragEventArgs e)
        {
            if (listView.SelectedItems.Count == 0) { return; }
            Point pt = listView.PointToClient(new Point(e.X, e.Y));
            ListViewItem itemDrag = listView.GetItemAt(pt.X, pt.Y);
            if (itemDrag == null) { return; }
            int itemDragIndex = itemDrag.Index;
            ListViewItem[] sel = new ListViewItem[listView.SelectedItems.Count];
            for (int i = 0; i < listView.SelectedItems.Count; i++)
            {
                sel[i] = listView.SelectedItems[i];
            }
            for (int i = 0; i < sel.GetLength(0); i++)
            {
                ListViewItem item = sel[i];
                int ItemIndex = itemDragIndex;

                if (ItemIndex == item.Index) { return; }

                if (item.Index < ItemIndex)
                {
                    ItemIndex++;
                }
                else { ItemIndex = itemDragIndex + 1; }

                ListViewItem insertItem = (ListViewItem)item.Clone();
                listView.Items.Insert(ItemIndex, insertItem);
                listView.Items.Remove(item);

            }

            CarregarAparelho();
        }
        private void btnAtualizarLista_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in listView.Items)
                {
                    var cat = Global.Listas.CategoriasNivel1.Find(a => a.Id == int.Parse(item.SubItems[1].Text));
                    cat.Ordem= item.Index + 1;
                    CategoriasNivel1Controller.Gravar(cat);
                }
                Global.AtualizarCategorasNivel1();
                CarregarListView();
                CarregarAparelho();
                MessageBox.Show("Atualizado");

            }
            catch { }
        }
        #endregion
    }
}
