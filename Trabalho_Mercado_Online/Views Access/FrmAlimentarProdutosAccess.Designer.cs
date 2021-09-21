
namespace Trabalho_Mercado_Online.Views_Access
{
    partial class FrmAlimentarProdutosAccess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAlimentarProdutosAccess));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSelecionarTudo = new System.Windows.Forms.Button();
            this.lblSelecionados = new System.Windows.Forms.Label();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnLimparFiltro = new System.Windows.Forms.Button();
            this.chkIgualaProduto = new System.Windows.Forms.CheckBox();
            this.chkCategoria = new System.Windows.Forms.CheckBox();
            this.chkSemCategoria = new System.Windows.Forms.CheckBox();
            this.chkPromocao = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkCategoriaNivel1 = new System.Windows.Forms.CheckBox();
            this.chkCategoriaNivel2 = new System.Windows.Forms.CheckBox();
            this.cbNivel2 = new System.Windows.Forms.ComboBox();
            this.cbNivel1 = new System.Windows.Forms.ComboBox();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkMaisQue = new System.Windows.Forms.CheckBox();
            this.chkMenosQue = new System.Windows.Forms.CheckBox();
            this.nUDQuantidade = new System.Windows.Forms.NumericUpDown();
            this.btnAtualizarCodigos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDQuantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(47, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.TabIndex = 101;
            this.pictureBox1.TabStop = false;
            // 
            // btnSelecionarTudo
            // 
            this.btnSelecionarTudo.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSelecionarTudo.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnSelecionarTudo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelecionarTudo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSelecionarTudo.ForeColor = System.Drawing.Color.White;
            this.btnSelecionarTudo.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarTudo.Image")));
            this.btnSelecionarTudo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelecionarTudo.Location = new System.Drawing.Point(16, 588);
            this.btnSelecionarTudo.Name = "btnSelecionarTudo";
            this.btnSelecionarTudo.Size = new System.Drawing.Size(132, 50);
            this.btnSelecionarTudo.TabIndex = 100;
            this.btnSelecionarTudo.Text = "Selecionar Tudo";
            this.btnSelecionarTudo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelecionarTudo.UseVisualStyleBackColor = false;
            this.btnSelecionarTudo.Click += new System.EventHandler(this.btnSelecionarTudo_Click);
            // 
            // lblSelecionados
            // 
            this.lblSelecionados.AutoSize = true;
            this.lblSelecionados.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSelecionados.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblSelecionados.Location = new System.Drawing.Point(785, 554);
            this.lblSelecionados.Name = "lblSelecionados";
            this.lblSelecionados.Size = new System.Drawing.Size(90, 14);
            this.lblSelecionados.TabIndex = 99;
            this.lblSelecionados.Text = "0 Selecionados";
            this.lblSelecionados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAdicionar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAdicionar.ForeColor = System.Drawing.Color.White;
            this.btnAdicionar.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionar.Image")));
            this.btnAdicionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdicionar.Location = new System.Drawing.Point(742, 586);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(143, 50);
            this.btnAdicionar.TabIndex = 98;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnLimparFiltro
            // 
            this.btnLimparFiltro.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLimparFiltro.FlatAppearance.BorderSize = 0;
            this.btnLimparFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimparFiltro.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLimparFiltro.ForeColor = System.Drawing.Color.White;
            this.btnLimparFiltro.Location = new System.Drawing.Point(797, 87);
            this.btnLimparFiltro.Name = "btnLimparFiltro";
            this.btnLimparFiltro.Size = new System.Drawing.Size(89, 27);
            this.btnLimparFiltro.TabIndex = 97;
            this.btnLimparFiltro.Text = "Limpar Filtro";
            this.btnLimparFiltro.UseVisualStyleBackColor = false;
            this.btnLimparFiltro.Click += new System.EventHandler(this.btnLimparFiltro_Click);
            // 
            // chkIgualaProduto
            // 
            this.chkIgualaProduto.AutoSize = true;
            this.chkIgualaProduto.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkIgualaProduto.ForeColor = System.Drawing.Color.DodgerBlue;
            this.chkIgualaProduto.Location = new System.Drawing.Point(429, 90);
            this.chkIgualaProduto.Name = "chkIgualaProduto";
            this.chkIgualaProduto.Size = new System.Drawing.Size(105, 18);
            this.chkIgualaProduto.TabIndex = 96;
            this.chkIgualaProduto.Text = "Iguala Produto";
            this.chkIgualaProduto.UseVisualStyleBackColor = true;
            this.chkIgualaProduto.CheckedChanged += new System.EventHandler(this.chkIgualaProduto_CheckedChanged);
            // 
            // chkCategoria
            // 
            this.chkCategoria.AutoSize = true;
            this.chkCategoria.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkCategoria.ForeColor = System.Drawing.Color.DodgerBlue;
            this.chkCategoria.Location = new System.Drawing.Point(143, 90);
            this.chkCategoria.Name = "chkCategoria";
            this.chkCategoria.Size = new System.Drawing.Size(79, 18);
            this.chkCategoria.TabIndex = 95;
            this.chkCategoria.Text = "Categoria";
            this.chkCategoria.UseVisualStyleBackColor = true;
            this.chkCategoria.CheckedChanged += new System.EventHandler(this.chkCategoria_CheckedChanged);
            // 
            // chkSemCategoria
            // 
            this.chkSemCategoria.AutoSize = true;
            this.chkSemCategoria.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkSemCategoria.ForeColor = System.Drawing.Color.DodgerBlue;
            this.chkSemCategoria.Location = new System.Drawing.Point(228, 90);
            this.chkSemCategoria.Name = "chkSemCategoria";
            this.chkSemCategoria.Size = new System.Drawing.Size(107, 18);
            this.chkSemCategoria.TabIndex = 94;
            this.chkSemCategoria.Text = "Sem Categoria";
            this.chkSemCategoria.UseVisualStyleBackColor = true;
            this.chkSemCategoria.CheckedChanged += new System.EventHandler(this.chkSemCategoria_CheckedChanged);
            // 
            // chkPromocao
            // 
            this.chkPromocao.AutoSize = true;
            this.chkPromocao.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkPromocao.ForeColor = System.Drawing.Color.DodgerBlue;
            this.chkPromocao.Location = new System.Drawing.Point(341, 90);
            this.chkPromocao.Name = "chkPromocao";
            this.chkPromocao.Size = new System.Drawing.Size(82, 18);
            this.chkPromocao.TabIndex = 93;
            this.chkPromocao.Text = "Promoção";
            this.chkPromocao.UseVisualStyleBackColor = true;
            this.chkPromocao.CheckedChanged += new System.EventHandler(this.chkPromocao_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label6.Location = new System.Drawing.Point(450, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 14);
            this.label6.TabIndex = 92;
            this.label6.Text = "Nivel 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label5.Location = new System.Drawing.Point(154, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 91;
            this.label5.Text = "Nivel 1";
            // 
            // chkCategoriaNivel1
            // 
            this.chkCategoriaNivel1.AutoSize = true;
            this.chkCategoriaNivel1.Checked = true;
            this.chkCategoriaNivel1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCategoriaNivel1.Enabled = false;
            this.chkCategoriaNivel1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkCategoriaNivel1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.chkCategoriaNivel1.Location = new System.Drawing.Point(137, 131);
            this.chkCategoriaNivel1.Name = "chkCategoriaNivel1";
            this.chkCategoriaNivel1.Size = new System.Drawing.Size(15, 14);
            this.chkCategoriaNivel1.TabIndex = 90;
            this.chkCategoriaNivel1.UseVisualStyleBackColor = true;
            // 
            // chkCategoriaNivel2
            // 
            this.chkCategoriaNivel2.AutoSize = true;
            this.chkCategoriaNivel2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkCategoriaNivel2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.chkCategoriaNivel2.Location = new System.Drawing.Point(429, 131);
            this.chkCategoriaNivel2.Name = "chkCategoriaNivel2";
            this.chkCategoriaNivel2.Size = new System.Drawing.Size(15, 14);
            this.chkCategoriaNivel2.TabIndex = 89;
            this.chkCategoriaNivel2.UseVisualStyleBackColor = true;
            this.chkCategoriaNivel2.CheckedChanged += new System.EventHandler(this.chkCategoriaNivel2_CheckedChanged);
            // 
            // cbNivel2
            // 
            this.cbNivel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            this.cbNivel2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNivel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbNivel2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbNivel2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.cbNivel2.FormattingEnabled = true;
            this.cbNivel2.Location = new System.Drawing.Point(450, 126);
            this.cbNivel2.Name = "cbNivel2";
            this.cbNivel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbNivel2.Size = new System.Drawing.Size(250, 27);
            this.cbNivel2.TabIndex = 88;
            this.cbNivel2.SelectedIndexChanged += new System.EventHandler(this.cbNivel2_SelectedIndexChanged);
            // 
            // cbNivel1
            // 
            this.cbNivel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            this.cbNivel1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNivel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbNivel1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbNivel1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.cbNivel1.FormattingEnabled = true;
            this.cbNivel1.Location = new System.Drawing.Point(154, 126);
            this.cbNivel1.Name = "cbNivel1";
            this.cbNivel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbNivel1.Size = new System.Drawing.Size(250, 27);
            this.cbNivel1.TabIndex = 87;
            this.cbNivel1.SelectedIndexChanged += new System.EventHandler(this.cbNivel1_SelectedIndexChanged);
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRegistros.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblRegistros.Location = new System.Drawing.Point(16, 554);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(82, 14);
            this.lblRegistros.TabIndex = 86;
            this.lblRegistros.Text = "130 Registros";
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(143, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 14);
            this.label2.TabIndex = 85;
            this.label2.Text = "Descrição";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.ColumnHeadersHeight = 40;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.Location = new System.Drawing.Point(16, 174);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 50;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(869, 377);
            this.dataGridView.TabIndex = 84;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // txtDescricao
            // 
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDescricao.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txtDescricao.Location = new System.Drawing.Point(143, 49);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(742, 32);
            this.txtDescricao.TabIndex = 83;
            this.txtDescricao.TextChanged += new System.EventHandler(this.txtDescricao_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 58);
            this.label1.TabIndex = 82;
            this.label1.Text = "Produtos \r\nAccess\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkMaisQue
            // 
            this.chkMaisQue.AutoSize = true;
            this.chkMaisQue.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkMaisQue.ForeColor = System.Drawing.Color.DodgerBlue;
            this.chkMaisQue.Location = new System.Drawing.Point(540, 90);
            this.chkMaisQue.Name = "chkMaisQue";
            this.chkMaisQue.Size = new System.Drawing.Size(89, 18);
            this.chkMaisQue.TabIndex = 102;
            this.chkMaisQue.Text = "Vendido + =";
            this.chkMaisQue.UseVisualStyleBackColor = true;
            this.chkMaisQue.CheckedChanged += new System.EventHandler(this.chkMaisQue_CheckedChanged);
            // 
            // chkMenosQue
            // 
            this.chkMenosQue.AutoSize = true;
            this.chkMenosQue.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chkMenosQue.ForeColor = System.Drawing.Color.DodgerBlue;
            this.chkMenosQue.Location = new System.Drawing.Point(632, 90);
            this.chkMenosQue.Name = "chkMenosQue";
            this.chkMenosQue.Size = new System.Drawing.Size(87, 18);
            this.chkMenosQue.TabIndex = 103;
            this.chkMenosQue.Text = "Vendido - =";
            this.chkMenosQue.UseVisualStyleBackColor = true;
            this.chkMenosQue.CheckedChanged += new System.EventHandler(this.chkMenosQue_CheckedChanged);
            // 
            // nUDQuantidade
            // 
            this.nUDQuantidade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            this.nUDQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nUDQuantidade.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nUDQuantidade.ForeColor = System.Drawing.Color.DodgerBlue;
            this.nUDQuantidade.Location = new System.Drawing.Point(738, 92);
            this.nUDQuantidade.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nUDQuantidade.Name = "nUDQuantidade";
            this.nUDQuantidade.Size = new System.Drawing.Size(53, 18);
            this.nUDQuantidade.TabIndex = 105;
            this.nUDQuantidade.ValueChanged += new System.EventHandler(this.nUDQuantidade_ValueChanged);
            // 
            // btnAtualizarCodigos
            // 
            this.btnAtualizarCodigos.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAtualizarCodigos.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnAtualizarCodigos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizarCodigos.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAtualizarCodigos.ForeColor = System.Drawing.Color.White;
            this.btnAtualizarCodigos.Image = global::Trabalho_Mercado_Online.Properties.Resources.icone_barcode;
            this.btnAtualizarCodigos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAtualizarCodigos.Location = new System.Drawing.Point(173, 588);
            this.btnAtualizarCodigos.Name = "btnAtualizarCodigos";
            this.btnAtualizarCodigos.Size = new System.Drawing.Size(132, 50);
            this.btnAtualizarCodigos.TabIndex = 106;
            this.btnAtualizarCodigos.Text = "  Atualizar\r\n  Codigos";
            this.btnAtualizarCodigos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAtualizarCodigos.UseVisualStyleBackColor = false;
            this.btnAtualizarCodigos.Visible = false;
            this.btnAtualizarCodigos.Click += new System.EventHandler(this.btnAtualizarCodigos_Click);
            // 
            // FrmAlimentarProdutosAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(897, 648);
            this.Controls.Add(this.btnAtualizarCodigos);
            this.Controls.Add(this.nUDQuantidade);
            this.Controls.Add(this.chkMenosQue);
            this.Controls.Add(this.chkMaisQue);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSelecionarTudo);
            this.Controls.Add(this.lblSelecionados);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.btnLimparFiltro);
            this.Controls.Add(this.chkIgualaProduto);
            this.Controls.Add(this.chkCategoria);
            this.Controls.Add(this.chkSemCategoria);
            this.Controls.Add(this.chkPromocao);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkCategoriaNivel1);
            this.Controls.Add(this.chkCategoriaNivel2);
            this.Controls.Add(this.cbNivel2);
            this.Controls.Add(this.cbNivel1);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmAlimentarProdutosAccess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAlimentarProdutosAccess";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDQuantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSelecionarTudo;
        private System.Windows.Forms.Label lblSelecionados;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnLimparFiltro;
        private System.Windows.Forms.CheckBox chkIgualaProduto;
        private System.Windows.Forms.CheckBox chkCategoria;
        private System.Windows.Forms.CheckBox chkSemCategoria;
        private System.Windows.Forms.CheckBox chkPromocao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkCategoriaNivel1;
        private System.Windows.Forms.CheckBox chkCategoriaNivel2;
        private System.Windows.Forms.ComboBox cbNivel2;
        private System.Windows.Forms.ComboBox cbNivel1;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkMaisQue;
        private System.Windows.Forms.CheckBox chkMenosQue;
        private System.Windows.Forms.NumericUpDown nUDQuantidade;
        private System.Windows.Forms.Button btnAtualizarCodigos;
    }
}