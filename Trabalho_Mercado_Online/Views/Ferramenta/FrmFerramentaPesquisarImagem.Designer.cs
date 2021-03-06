
namespace Trabalho_Mercado_Online.Views.Ferramenta
{
    partial class FrmFerramentaPesquisarImagem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkRotDireita = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkRotEsquerda = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.nUD = new System.Windows.Forms.NumericUpDown();
            this.rbCima = new System.Windows.Forms.RadioButton();
            this.rbLado = new System.Windows.Forms.RadioButton();
            this.btnDesfazer = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.panelImagens = new System.Windows.Forms.Panel();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.lblItensGrid = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalLista = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxImagem = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.timerImagens = new System.Windows.Forms.Timer(this.components);
            this.panelMain.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagem)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.btnClose);
            this.panelMain.Controls.Add(this.panel3);
            this.panelMain.Controls.Add(this.label3);
            this.panelMain.Controls.Add(this.panel1);
            this.panelMain.Controls.Add(this.btnDesfazer);
            this.panelMain.Controls.Add(this.btnEditar);
            this.panelMain.Controls.Add(this.btnLimpar);
            this.panelMain.Controls.Add(this.panelImagens);
            this.panelMain.Controls.Add(this.btnPesquisar);
            this.panelMain.Controls.Add(this.pictureBox1);
            this.panelMain.Controls.Add(this.label5);
            this.panelMain.Controls.Add(this.btnSelecionar);
            this.panelMain.Controls.Add(this.lblItensGrid);
            this.panelMain.Controls.Add(this.label6);
            this.panelMain.Controls.Add(this.lblTotalLista);
            this.panelMain.Controls.Add(this.label4);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.pictureBoxImagem);
            this.panelMain.Controls.Add(this.label2);
            this.panelMain.Controls.Add(this.txtProduto);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(900, 648);
            this.panelMain.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.BackgroundImage = global::Trabalho_Mercado_Online.Properties.Resources.icon_close_30x30;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(855, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(34, 32);
            this.btnClose.TabIndex = 580;
            this.btnClose.TabStop = false;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.chkRotDireita);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.chkRotEsquerda);
            this.panel3.Location = new System.Drawing.Point(689, 407);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 49);
            this.panel3.TabIndex = 579;
            // 
            // chkRotDireita
            // 
            this.chkRotDireita.AutoSize = true;
            this.chkRotDireita.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkRotDireita.Location = new System.Drawing.Point(120, 17);
            this.chkRotDireita.Name = "chkRotDireita";
            this.chkRotDireita.Size = new System.Drawing.Size(68, 20);
            this.chkRotDireita.TabIndex = 580;
            this.chkRotDireita.Text = "Direita";
            this.chkRotDireita.UseVisualStyleBackColor = true;
            this.chkRotDireita.CheckedChanged += new System.EventHandler(this.chkRotDireita_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 14);
            this.label9.TabIndex = 579;
            this.label9.Text = "Girar";
            // 
            // chkRotEsquerda
            // 
            this.chkRotEsquerda.AutoSize = true;
            this.chkRotEsquerda.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkRotEsquerda.Location = new System.Drawing.Point(15, 17);
            this.chkRotEsquerda.Name = "chkRotEsquerda";
            this.chkRotEsquerda.Size = new System.Drawing.Size(85, 20);
            this.chkRotEsquerda.TabIndex = 578;
            this.chkRotEsquerda.Text = "Esquerda";
            this.chkRotEsquerda.UseVisualStyleBackColor = true;
            this.chkRotEsquerda.CheckedChanged += new System.EventHandler(this.chkRotEsquerda_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(804, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 14);
            this.label3.TabIndex = 577;
            this.label3.Text = "Edição Imagem";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.nUD);
            this.panel1.Controls.Add(this.rbCima);
            this.panel1.Controls.Add(this.rbLado);
            this.panel1.Location = new System.Drawing.Point(689, 354);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 49);
            this.panel1.TabIndex = 576;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 14);
            this.label8.TabIndex = 578;
            this.label8.Text = "Duplicar";
            // 
            // nUD
            // 
            this.nUD.BackColor = System.Drawing.Color.White;
            this.nUD.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nUD.Location = new System.Drawing.Point(3, 17);
            this.nUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUD.Name = "nUD";
            this.nUD.Size = new System.Drawing.Size(58, 26);
            this.nUD.TabIndex = 573;
            this.nUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rbCima
            // 
            this.rbCima.AutoSize = true;
            this.rbCima.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rbCima.Location = new System.Drawing.Point(130, 19);
            this.rbCima.Name = "rbCima";
            this.rbCima.Size = new System.Drawing.Size(58, 20);
            this.rbCima.TabIndex = 575;
            this.rbCima.Text = "Cima";
            this.rbCima.UseVisualStyleBackColor = true;
            // 
            // rbLado
            // 
            this.rbLado.AutoSize = true;
            this.rbLado.Checked = true;
            this.rbLado.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rbLado.Location = new System.Drawing.Point(67, 19);
            this.rbLado.Name = "rbLado";
            this.rbLado.Size = new System.Drawing.Size(57, 20);
            this.rbLado.TabIndex = 574;
            this.rbLado.TabStop = true;
            this.rbLado.Text = "Lado";
            this.rbLado.UseVisualStyleBackColor = true;
            // 
            // btnDesfazer
            // 
            this.btnDesfazer.BackColor = System.Drawing.Color.White;
            this.btnDesfazer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDesfazer.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDesfazer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDesfazer.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDesfazer.ForeColor = System.Drawing.Color.Black;
            this.btnDesfazer.Image = global::Trabalho_Mercado_Online.Properties.Resources.icon_undo_30x30;
            this.btnDesfazer.Location = new System.Drawing.Point(689, 461);
            this.btnDesfazer.Name = "btnDesfazer";
            this.btnDesfazer.Size = new System.Drawing.Size(45, 37);
            this.btnDesfazer.TabIndex = 570;
            this.btnDesfazer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDesfazer.UseVisualStyleBackColor = false;
            this.btnDesfazer.Click += new System.EventHandler(this.btnDesfazer_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.White;
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEditar.ForeColor = System.Drawing.Color.Black;
            this.btnEditar.Image = global::Trabalho_Mercado_Online.Properties.Resources.icon_edit_Image_30x30;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(740, 461);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(149, 37);
            this.btnEditar.TabIndex = 568;
            this.btnEditar.Text = "Editar Imagem";
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.White;
            this.btnLimpar.BackgroundImage = global::Trabalho_Mercado_Online.Properties.Resources.icon_close_30x30;
            this.btnLimpar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimpar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLimpar.FlatAppearance.BorderSize = 0;
            this.btnLimpar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnLimpar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLimpar.ForeColor = System.Drawing.Color.White;
            this.btnLimpar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpar.Location = new System.Drawing.Point(650, 76);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(34, 32);
            this.btnLimpar.TabIndex = 561;
            this.btnLimpar.TabStop = false;
            this.btnLimpar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // panelImagens
            // 
            this.panelImagens.AutoScroll = true;
            this.panelImagens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelImagens.Location = new System.Drawing.Point(12, 114);
            this.panelImagens.Name = "panelImagens";
            this.panelImagens.Size = new System.Drawing.Size(673, 512);
            this.panelImagens.TabIndex = 0;
            this.panelImagens.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panelImagens_Scroll);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnPesquisar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPesquisar.ForeColor = System.Drawing.Color.White;
            this.btnPesquisar.Image = global::Trabalho_Mercado_Online.Properties.Resources.icon_search_24x24;
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(607, 76);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(37, 32);
            this.btnPesquisar.TabIndex = 558;
            this.btnPesquisar.TabStop = false;
            this.btnPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Trabalho_Mercado_Online.Properties.Resources.icon_img_30x30;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(18, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.TabIndex = 556;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label5.Location = new System.Drawing.Point(79, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(224, 29);
            this.label5.TabIndex = 557;
            this.label5.Text = "Pesquisar Imagem";
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSelecionar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnSelecionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecionar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSelecionar.ForeColor = System.Drawing.Color.White;
            this.btnSelecionar.Image = global::Trabalho_Mercado_Online.Properties.Resources.icon_send_file_40x40;
            this.btnSelecionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionar.Location = new System.Drawing.Point(692, 578);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(197, 50);
            this.btnSelecionar.TabIndex = 108;
            this.btnSelecionar.Text = "       Salvar";
            this.btnSelecionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelecionar.UseVisualStyleBackColor = false;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // lblItensGrid
            // 
            this.lblItensGrid.AutoSize = true;
            this.lblItensGrid.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblItensGrid.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblItensGrid.Location = new System.Drawing.Point(102, 629);
            this.lblItensGrid.Name = "lblItensGrid";
            this.lblItensGrid.Size = new System.Drawing.Size(13, 14);
            this.lblItensGrid.TabIndex = 107;
            this.lblItensGrid.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label6.Location = new System.Drawing.Point(12, 629);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 14);
            this.label6.TabIndex = 106;
            this.label6.Text = "Itens no Grid :";
            // 
            // lblTotalLista
            // 
            this.lblTotalLista.AutoSize = true;
            this.lblTotalLista.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalLista.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTotalLista.Location = new System.Drawing.Point(660, 629);
            this.lblTotalLista.Name = "lblTotalLista";
            this.lblTotalLista.Size = new System.Drawing.Size(13, 14);
            this.lblTotalLista.TabIndex = 105;
            this.lblTotalLista.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label4.Location = new System.Drawing.Point(567, 629);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 14);
            this.label4.TabIndex = 104;
            this.label4.Text = "Total de Itens :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(691, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 14);
            this.label1.TabIndex = 103;
            this.label1.Text = "Visualização Imagem";
            // 
            // pictureBoxImagem
            // 
            this.pictureBoxImagem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxImagem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxImagem.Location = new System.Drawing.Point(689, 76);
            this.pictureBoxImagem.Name = "pictureBoxImagem";
            this.pictureBoxImagem.Size = new System.Drawing.Size(200, 240);
            this.pictureBoxImagem.TabIndex = 102;
            this.pictureBoxImagem.TabStop = false;
            this.pictureBoxImagem.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBoxImagem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBoxImagem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 14);
            this.label2.TabIndex = 97;
            this.label2.Text = "Produto";
            // 
            // txtProduto
            // 
            this.txtProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProduto.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtProduto.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txtProduto.Location = new System.Drawing.Point(12, 76);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.Size = new System.Drawing.Size(589, 32);
            this.txtProduto.TabIndex = 1;
            this.txtProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProduto_KeyPress);
            // 
            // timerImagens
            // 
            this.timerImagens.Enabled = true;
            this.timerImagens.Interval = 1000;
            this.timerImagens.Tick += new System.EventHandler(this.timerImagens_Tick);
            // 
            // FrmFerramentaPesquisarImagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 648);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmFerramentaPesquisarImagem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPesquisarImagem";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TextBox txtProduto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblItensGrid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalLista;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxImagem;
        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Panel panelImagens;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Timer timerImagens;
        private System.Windows.Forms.Button btnDesfazer;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.RadioButton rbCima;
        private System.Windows.Forms.RadioButton rbLado;
        private System.Windows.Forms.NumericUpDown nUD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox chkRotEsquerda;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkRotDireita;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnClose;
    }
}