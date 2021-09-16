
namespace Trabalho_Mercado_Online.Views
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelLogoImagem = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMenuLateral = new System.Windows.Forms.Panel();
            this.panelAccessSubMenu = new System.Windows.Forms.Panel();
            this.btnProdutosAccess = new System.Windows.Forms.Button();
            this.btnAccess = new System.Windows.Forms.Button();
            this.panelFerramentasSubMenu = new System.Windows.Forms.Panel();
            this.btnAlimentarProdutos = new System.Windows.Forms.Button();
            this.btnFerramentas = new System.Windows.Forms.Button();
            this.panelBasedeDadosSubMenu = new System.Windows.Forms.Panel();
            this.btnCategoriasNivel3 = new System.Windows.Forms.Button();
            this.btnCategoriasNivel2 = new System.Windows.Forms.Button();
            this.btnCategoriasNivel1 = new System.Windows.Forms.Button();
            this.btnProdutos = new System.Windows.Forms.Button();
            this.btnBasedeDados = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.btnSair = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFuncionario = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelMenuLateral.SuspendLayout();
            this.panelAccessSubMenu.SuspendLayout();
            this.panelFerramentasSubMenu.SuspendLayout();
            this.panelBasedeDadosSubMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(143, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Delivery";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(86, 3);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(109, 54);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Mercado \r\nOnline\r\n";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            this.lblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitulo_MouseDown);
            this.lblTitulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTitulo_MouseMove);
            // 
            // panelLogoImagem
            // 
            this.panelLogoImagem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelLogoImagem.BackgroundImage")));
            this.panelLogoImagem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLogoImagem.Location = new System.Drawing.Point(7, 4);
            this.panelLogoImagem.Name = "panelLogoImagem";
            this.panelLogoImagem.Size = new System.Drawing.Size(65, 65);
            this.panelLogoImagem.TabIndex = 0;
            this.panelLogoImagem.Click += new System.EventHandler(this.panelLogoImagem_Click);
            this.panelLogoImagem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelLogoImagem_MouseDown);
            this.panelLogoImagem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelLogoImagem_MouseMove);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Location = new System.Drawing.Point(202, 1);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(897, 648);
            this.panelMain.TabIndex = 1;
            // 
            // panelMenuLateral
            // 
            this.panelMenuLateral.BackColor = System.Drawing.Color.DodgerBlue;
            this.panelMenuLateral.Controls.Add(this.panelAccessSubMenu);
            this.panelMenuLateral.Controls.Add(this.btnAccess);
            this.panelMenuLateral.Controls.Add(this.panelFerramentasSubMenu);
            this.panelMenuLateral.Controls.Add(this.btnFerramentas);
            this.panelMenuLateral.Controls.Add(this.panelBasedeDadosSubMenu);
            this.panelMenuLateral.Controls.Add(this.btnBasedeDados);
            this.panelMenuLateral.Controls.Add(this.panelLogo);
            this.panelMenuLateral.Location = new System.Drawing.Point(1, 1);
            this.panelMenuLateral.Name = "panelMenuLateral";
            this.panelMenuLateral.Size = new System.Drawing.Size(200, 574);
            this.panelMenuLateral.TabIndex = 2;
            // 
            // panelAccessSubMenu
            // 
            this.panelAccessSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(174)))), ((int)(((byte)(254)))));
            this.panelAccessSubMenu.Controls.Add(this.btnProdutosAccess);
            this.panelAccessSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAccessSubMenu.Location = new System.Drawing.Point(0, 458);
            this.panelAccessSubMenu.Name = "panelAccessSubMenu";
            this.panelAccessSubMenu.Size = new System.Drawing.Size(200, 50);
            this.panelAccessSubMenu.TabIndex = 9;
            // 
            // btnProdutosAccess
            // 
            this.btnProdutosAccess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(174)))), ((int)(((byte)(254)))));
            this.btnProdutosAccess.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProdutosAccess.FlatAppearance.BorderSize = 0;
            this.btnProdutosAccess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdutosAccess.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnProdutosAccess.ForeColor = System.Drawing.Color.White;
            this.btnProdutosAccess.Image = ((System.Drawing.Image)(resources.GetObject("btnProdutosAccess.Image")));
            this.btnProdutosAccess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProdutosAccess.Location = new System.Drawing.Point(0, 0);
            this.btnProdutosAccess.Name = "btnProdutosAccess";
            this.btnProdutosAccess.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnProdutosAccess.Size = new System.Drawing.Size(200, 45);
            this.btnProdutosAccess.TabIndex = 3;
            this.btnProdutosAccess.Text = "Produtos";
            this.btnProdutosAccess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProdutosAccess.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProdutosAccess.UseVisualStyleBackColor = false;
            this.btnProdutosAccess.Click += new System.EventHandler(this.btnProdutosAccess_Click);
            // 
            // btnAccess
            // 
            this.btnAccess.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAccess.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAccess.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnAccess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccess.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAccess.ForeColor = System.Drawing.Color.White;
            this.btnAccess.Image = ((System.Drawing.Image)(resources.GetObject("btnAccess.Image")));
            this.btnAccess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccess.Location = new System.Drawing.Point(0, 408);
            this.btnAccess.Name = "btnAccess";
            this.btnAccess.Size = new System.Drawing.Size(200, 50);
            this.btnAccess.TabIndex = 8;
            this.btnAccess.Text = "Access";
            this.btnAccess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccess.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccess.UseVisualStyleBackColor = false;
            this.btnAccess.Click += new System.EventHandler(this.btnAccess_Click);
            // 
            // panelFerramentasSubMenu
            // 
            this.panelFerramentasSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(174)))), ((int)(((byte)(254)))));
            this.panelFerramentasSubMenu.Controls.Add(this.btnAlimentarProdutos);
            this.panelFerramentasSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFerramentasSubMenu.Location = new System.Drawing.Point(0, 358);
            this.panelFerramentasSubMenu.Name = "panelFerramentasSubMenu";
            this.panelFerramentasSubMenu.Size = new System.Drawing.Size(200, 50);
            this.panelFerramentasSubMenu.TabIndex = 7;
            // 
            // btnAlimentarProdutos
            // 
            this.btnAlimentarProdutos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(174)))), ((int)(((byte)(254)))));
            this.btnAlimentarProdutos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAlimentarProdutos.FlatAppearance.BorderSize = 0;
            this.btnAlimentarProdutos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlimentarProdutos.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAlimentarProdutos.ForeColor = System.Drawing.Color.White;
            this.btnAlimentarProdutos.Image = ((System.Drawing.Image)(resources.GetObject("btnAlimentarProdutos.Image")));
            this.btnAlimentarProdutos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlimentarProdutos.Location = new System.Drawing.Point(0, 0);
            this.btnAlimentarProdutos.Name = "btnAlimentarProdutos";
            this.btnAlimentarProdutos.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAlimentarProdutos.Size = new System.Drawing.Size(200, 45);
            this.btnAlimentarProdutos.TabIndex = 3;
            this.btnAlimentarProdutos.Text = "Alimentar Produtos";
            this.btnAlimentarProdutos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlimentarProdutos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAlimentarProdutos.UseVisualStyleBackColor = false;
            this.btnAlimentarProdutos.Click += new System.EventHandler(this.btnAlimentarProdutos_Click);
            // 
            // btnFerramentas
            // 
            this.btnFerramentas.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnFerramentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFerramentas.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnFerramentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFerramentas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFerramentas.ForeColor = System.Drawing.Color.White;
            this.btnFerramentas.Image = ((System.Drawing.Image)(resources.GetObject("btnFerramentas.Image")));
            this.btnFerramentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFerramentas.Location = new System.Drawing.Point(0, 308);
            this.btnFerramentas.Name = "btnFerramentas";
            this.btnFerramentas.Size = new System.Drawing.Size(200, 50);
            this.btnFerramentas.TabIndex = 6;
            this.btnFerramentas.Text = "Ferramentas";
            this.btnFerramentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFerramentas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFerramentas.UseVisualStyleBackColor = false;
            this.btnFerramentas.Click += new System.EventHandler(this.btnFerramentas_Click);
            // 
            // panelBasedeDadosSubMenu
            // 
            this.panelBasedeDadosSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(174)))), ((int)(((byte)(254)))));
            this.panelBasedeDadosSubMenu.Controls.Add(this.btnCategoriasNivel3);
            this.panelBasedeDadosSubMenu.Controls.Add(this.btnCategoriasNivel2);
            this.panelBasedeDadosSubMenu.Controls.Add(this.btnCategoriasNivel1);
            this.panelBasedeDadosSubMenu.Controls.Add(this.btnProdutos);
            this.panelBasedeDadosSubMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBasedeDadosSubMenu.Location = new System.Drawing.Point(0, 123);
            this.panelBasedeDadosSubMenu.Name = "panelBasedeDadosSubMenu";
            this.panelBasedeDadosSubMenu.Size = new System.Drawing.Size(200, 185);
            this.panelBasedeDadosSubMenu.TabIndex = 5;
            // 
            // btnCategoriasNivel3
            // 
            this.btnCategoriasNivel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(174)))), ((int)(((byte)(254)))));
            this.btnCategoriasNivel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategoriasNivel3.FlatAppearance.BorderSize = 0;
            this.btnCategoriasNivel3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategoriasNivel3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCategoriasNivel3.ForeColor = System.Drawing.Color.White;
            this.btnCategoriasNivel3.Image = ((System.Drawing.Image)(resources.GetObject("btnCategoriasNivel3.Image")));
            this.btnCategoriasNivel3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategoriasNivel3.Location = new System.Drawing.Point(0, 135);
            this.btnCategoriasNivel3.Name = "btnCategoriasNivel3";
            this.btnCategoriasNivel3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnCategoriasNivel3.Size = new System.Drawing.Size(200, 45);
            this.btnCategoriasNivel3.TabIndex = 3;
            this.btnCategoriasNivel3.Text = "Categorias Nivel 3";
            this.btnCategoriasNivel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategoriasNivel3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCategoriasNivel3.UseVisualStyleBackColor = false;
            this.btnCategoriasNivel3.Click += new System.EventHandler(this.btnCategoriasNivel3_Click);
            // 
            // btnCategoriasNivel2
            // 
            this.btnCategoriasNivel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategoriasNivel2.FlatAppearance.BorderSize = 0;
            this.btnCategoriasNivel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategoriasNivel2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCategoriasNivel2.ForeColor = System.Drawing.Color.White;
            this.btnCategoriasNivel2.Image = ((System.Drawing.Image)(resources.GetObject("btnCategoriasNivel2.Image")));
            this.btnCategoriasNivel2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategoriasNivel2.Location = new System.Drawing.Point(0, 90);
            this.btnCategoriasNivel2.Name = "btnCategoriasNivel2";
            this.btnCategoriasNivel2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnCategoriasNivel2.Size = new System.Drawing.Size(200, 45);
            this.btnCategoriasNivel2.TabIndex = 2;
            this.btnCategoriasNivel2.Text = "Categorias Nivel 2";
            this.btnCategoriasNivel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategoriasNivel2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCategoriasNivel2.UseVisualStyleBackColor = true;
            this.btnCategoriasNivel2.Click += new System.EventHandler(this.btnCategoriasNivel2_Click);
            // 
            // btnCategoriasNivel1
            // 
            this.btnCategoriasNivel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategoriasNivel1.FlatAppearance.BorderSize = 0;
            this.btnCategoriasNivel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategoriasNivel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCategoriasNivel1.ForeColor = System.Drawing.Color.White;
            this.btnCategoriasNivel1.Image = ((System.Drawing.Image)(resources.GetObject("btnCategoriasNivel1.Image")));
            this.btnCategoriasNivel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategoriasNivel1.Location = new System.Drawing.Point(0, 45);
            this.btnCategoriasNivel1.Name = "btnCategoriasNivel1";
            this.btnCategoriasNivel1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnCategoriasNivel1.Size = new System.Drawing.Size(200, 45);
            this.btnCategoriasNivel1.TabIndex = 1;
            this.btnCategoriasNivel1.Text = "Categorias Nivel 1";
            this.btnCategoriasNivel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategoriasNivel1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCategoriasNivel1.UseVisualStyleBackColor = true;
            this.btnCategoriasNivel1.Click += new System.EventHandler(this.btnCategoriasNivel1_Click);
            // 
            // btnProdutos
            // 
            this.btnProdutos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProdutos.FlatAppearance.BorderSize = 0;
            this.btnProdutos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdutos.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnProdutos.ForeColor = System.Drawing.Color.White;
            this.btnProdutos.Image = ((System.Drawing.Image)(resources.GetObject("btnProdutos.Image")));
            this.btnProdutos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProdutos.Location = new System.Drawing.Point(0, 0);
            this.btnProdutos.Name = "btnProdutos";
            this.btnProdutos.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnProdutos.Size = new System.Drawing.Size(200, 45);
            this.btnProdutos.TabIndex = 0;
            this.btnProdutos.Text = "Produtos";
            this.btnProdutos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProdutos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProdutos.UseVisualStyleBackColor = true;
            this.btnProdutos.Click += new System.EventHandler(this.btnProdutos_Click);
            // 
            // btnBasedeDados
            // 
            this.btnBasedeDados.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBasedeDados.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBasedeDados.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnBasedeDados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBasedeDados.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBasedeDados.ForeColor = System.Drawing.Color.White;
            this.btnBasedeDados.Image = ((System.Drawing.Image)(resources.GetObject("btnBasedeDados.Image")));
            this.btnBasedeDados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBasedeDados.Location = new System.Drawing.Point(0, 73);
            this.btnBasedeDados.Name = "btnBasedeDados";
            this.btnBasedeDados.Size = new System.Drawing.Size(200, 50);
            this.btnBasedeDados.TabIndex = 4;
            this.btnBasedeDados.Text = "Base de Dados";
            this.btnBasedeDados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBasedeDados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBasedeDados.UseVisualStyleBackColor = false;
            this.btnBasedeDados.Click += new System.EventHandler(this.btnBasedeDados_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.DodgerBlue;
            this.panelLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelLogo.Controls.Add(this.panelLogoImagem);
            this.panelLogo.Controls.Add(this.label2);
            this.panelLogo.Controls.Add(this.lblTitulo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(200, 73);
            this.panelLogo.TabIndex = 3;
            this.panelLogo.Click += new System.EventHandler(this.panelLogo_Click);
            this.panelLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelLogo_MouseDown);
            this.panelLogo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelLogo_MouseMove);
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSair.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSair.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSair.Location = new System.Drawing.Point(0, 0);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(200, 50);
            this.btnSair.TabIndex = 10;
            this.btnSair.Text = "Sair";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.lblFuncionario);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Location = new System.Drawing.Point(1, 575);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 74);
            this.panel1.TabIndex = 3;
            // 
            // lblFuncionario
            // 
            this.lblFuncionario.AutoSize = true;
            this.lblFuncionario.BackColor = System.Drawing.Color.Transparent;
            this.lblFuncionario.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFuncionario.ForeColor = System.Drawing.Color.White;
            this.lblFuncionario.Location = new System.Drawing.Point(60, 55);
            this.lblFuncionario.Name = "lblFuncionario";
            this.lblFuncionario.Size = new System.Drawing.Size(123, 14);
            this.lblFuncionario.TabIndex = 12;
            this.lblFuncionario.Tag = "";
            this.lblFuncionario.Text = "Nome do Funcionário";
            this.lblFuncionario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(4, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Usuário :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelMenuLateral);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Teste";
            this.Text = "Mercado Online";
            this.panelMenuLateral.ResumeLayout(false);
            this.panelAccessSubMenu.ResumeLayout(false);
            this.panelFerramentasSubMenu.ResumeLayout(false);
            this.panelBasedeDadosSubMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelLogoImagem;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelMenuLateral;
        private System.Windows.Forms.Button btnBasedeDados;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelBasedeDadosSubMenu;
        private System.Windows.Forms.Button btnCategoriasNivel3;
        private System.Windows.Forms.Button btnCategoriasNivel2;
        private System.Windows.Forms.Button btnCategoriasNivel1;
        private System.Windows.Forms.Button btnProdutos;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Panel panelAccessSubMenu;
        private System.Windows.Forms.Button btnProdutosAccess;
        private System.Windows.Forms.Button btnAccess;
        private System.Windows.Forms.Panel panelFerramentasSubMenu;
        private System.Windows.Forms.Button btnAlimentarProdutos;
        private System.Windows.Forms.Button btnFerramentas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblFuncionario;
    }
}