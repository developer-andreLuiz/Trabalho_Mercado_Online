
namespace Trabalho_Mercado_Online.Views
{
    partial class FrmEncarte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEncarte));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mySqlDataAdapter1 = new MySqlConnector.MySqlDataAdapter();
            this.panelMain = new System.Windows.Forms.Panel();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnLimparProduto = new System.Windows.Forms.Button();
            this.btnExportarImagem = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProduto = new System.Windows.Forms.TextBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTipoEncarte = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelA4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNomeEncarte = new System.Windows.Forms.TextBox();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mySqlDataAdapter1
            // 
            this.mySqlDataAdapter1.DeleteCommand = null;
            this.mySqlDataAdapter1.InsertCommand = null;
            this.mySqlDataAdapter1.SelectCommand = null;
            this.mySqlDataAdapter1.UpdateBatchSize = 0;
            this.mySqlDataAdapter1.UpdateCommand = null;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.label8);
            this.panelMain.Controls.Add(this.txtNomeEncarte);
            this.panelMain.Controls.Add(this.txtPesquisar);
            this.panelMain.Controls.Add(this.btnDeletar);
            this.panelMain.Controls.Add(this.btnPesquisar);
            this.panelMain.Controls.Add(this.label7);
            this.panelMain.Controls.Add(this.dataGridView);
            this.panelMain.Controls.Add(this.btnLimparProduto);
            this.panelMain.Controls.Add(this.btnExportarImagem);
            this.panelMain.Controls.Add(this.btnNovo);
            this.panelMain.Controls.Add(this.dateTimePicker);
            this.panelMain.Controls.Add(this.label6);
            this.panelMain.Controls.Add(this.label2);
            this.panelMain.Controls.Add(this.txtProduto);
            this.panelMain.Controls.Add(this.txtValor);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.cbTipoEncarte);
            this.panelMain.Controls.Add(this.label4);
            this.panelMain.Controls.Add(this.label3);
            this.panelMain.Controls.Add(this.panelA4);
            this.panelMain.Controls.Add(this.pictureBox1);
            this.panelMain.Controls.Add(this.label5);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(897, 648);
            this.panelMain.TabIndex = 0;
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesquisar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPesquisar.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txtPesquisar.Location = new System.Drawing.Point(19, 346);
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(358, 32);
            this.txtPesquisar.TabIndex = 617;
            // 
            // btnDeletar
            // 
            this.btnDeletar.BackColor = System.Drawing.Color.White;
            this.btnDeletar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDeletar.BackgroundImage")));
            this.btnDeletar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDeletar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDeletar.FlatAppearance.BorderSize = 0;
            this.btnDeletar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnDeletar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnDeletar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeletar.ForeColor = System.Drawing.Color.White;
            this.btnDeletar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeletar.Location = new System.Drawing.Point(417, 343);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(40, 40);
            this.btnDeletar.TabIndex = 616;
            this.btnDeletar.TabStop = false;
            this.btnDeletar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeletar.UseVisualStyleBackColor = false;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnPesquisar.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPesquisar.ForeColor = System.Drawing.Color.White;
            this.btnPesquisar.Image = global::Trabalho_Mercado_Online.Properties.Resources.icone_search;
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(382, 347);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(37, 31);
            this.btnPesquisar.TabIndex = 615;
            this.btnPesquisar.TabStop = false;
            this.btnPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPesquisar.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label7.Location = new System.Drawing.Point(19, 324);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 16);
            this.label7.TabIndex = 614;
            this.label7.Text = "Pesquisa Encarte";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(224)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.MidnightBlue;
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView.ColumnHeadersHeight = 40;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.Location = new System.Drawing.Point(19, 386);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 50;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(433, 206);
            this.dataGridView.TabIndex = 613;
            // 
            // btnLimparProduto
            // 
            this.btnLimparProduto.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLimparProduto.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnLimparProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimparProduto.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLimparProduto.ForeColor = System.Drawing.Color.White;
            this.btnLimparProduto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimparProduto.Location = new System.Drawing.Point(169, 598);
            this.btnLimparProduto.Name = "btnLimparProduto";
            this.btnLimparProduto.Size = new System.Drawing.Size(135, 38);
            this.btnLimparProduto.TabIndex = 606;
            this.btnLimparProduto.Text = "Limpar Produto";
            this.btnLimparProduto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimparProduto.UseVisualStyleBackColor = false;
            // 
            // btnExportarImagem
            // 
            this.btnExportarImagem.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnExportarImagem.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnExportarImagem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarImagem.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExportarImagem.ForeColor = System.Drawing.Color.White;
            this.btnExportarImagem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportarImagem.Location = new System.Drawing.Point(317, 598);
            this.btnExportarImagem.Name = "btnExportarImagem";
            this.btnExportarImagem.Size = new System.Drawing.Size(135, 38);
            this.btnExportarImagem.TabIndex = 605;
            this.btnExportarImagem.Text = "Exportar Imagem";
            this.btnExportarImagem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportarImagem.UseVisualStyleBackColor = false;
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnNovo.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNovo.ForeColor = System.Drawing.Color.White;
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovo.Location = new System.Drawing.Point(20, 598);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(135, 38);
            this.btnNovo.TabIndex = 602;
            this.btnNovo.Text = "Novo";
            this.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNovo.UseVisualStyleBackColor = false;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(180, 159);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(272, 26);
            this.dateTimePicker.TabIndex = 596;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label6.Location = new System.Drawing.Point(19, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 19);
            this.label6.TabIndex = 595;
            this.label6.Text = "Data de Validade";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label2.Location = new System.Drawing.Point(19, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 19);
            this.label2.TabIndex = 592;
            this.label2.Text = "Produto";
            // 
            // txtProduto
            // 
            this.txtProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProduto.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtProduto.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txtProduto.Location = new System.Drawing.Point(19, 250);
            this.txtProduto.Name = "txtProduto";
            this.txtProduto.Size = new System.Drawing.Size(304, 32);
            this.txtProduto.TabIndex = 591;
            // 
            // txtValor
            // 
            this.txtValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValor.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtValor.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txtValor.Location = new System.Drawing.Point(329, 250);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(123, 32);
            this.txtValor.TabIndex = 593;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(329, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 19);
            this.label1.TabIndex = 594;
            this.label1.Text = "Valor";
            // 
            // cbTipoEncarte
            // 
            this.cbTipoEncarte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            this.cbTipoEncarte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoEncarte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTipoEncarte.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbTipoEncarte.ForeColor = System.Drawing.Color.DodgerBlue;
            this.cbTipoEncarte.FormattingEnabled = true;
            this.cbTipoEncarte.Items.AddRange(new object[] {
            "15 Itens",
            "18 Itens"});
            this.cbTipoEncarte.Location = new System.Drawing.Point(180, 84);
            this.cbTipoEncarte.Name = "cbTipoEncarte";
            this.cbTipoEncarte.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbTipoEncarte.Size = new System.Drawing.Size(272, 32);
            this.cbTipoEncarte.TabIndex = 590;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label4.Location = new System.Drawing.Point(19, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 19);
            this.label4.TabIndex = 589;
            this.label4.Text = "Modelo de Encarte";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(469, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 14);
            this.label3.TabIndex = 588;
            this.label3.Text = "Tamanho A4";
            // 
            // panelA4
            // 
            this.panelA4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelA4.Location = new System.Drawing.Point(469, 52);
            this.panelA4.Name = "panelA4";
            this.panelA4.Size = new System.Drawing.Size(413, 584);
            this.panelA4.TabIndex = 586;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Trabalho_Mercado_Online.Properties.Resources.icone_grid_Image;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(15, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.TabIndex = 584;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label5.Location = new System.Drawing.Point(76, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 32);
            this.label5.TabIndex = 585;
            this.label5.Text = "Encarte";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label8.Location = new System.Drawing.Point(19, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 19);
            this.label8.TabIndex = 619;
            this.label8.Text = "Nome";
            // 
            // txtNomeEncarte
            // 
            this.txtNomeEncarte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNomeEncarte.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNomeEncarte.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txtNomeEncarte.Location = new System.Drawing.Point(180, 121);
            this.txtNomeEncarte.Name = "txtNomeEncarte";
            this.txtNomeEncarte.Size = new System.Drawing.Size(272, 32);
            this.txtNomeEncarte.TabIndex = 618;
            // 
            // FrmEncarte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(897, 648);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmEncarte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEncarte";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MySqlConnector.MySqlDataAdapter mySqlDataAdapter1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProduto;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTipoEncarte;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelA4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnLimparProduto;
        private System.Windows.Forms.Button btnExportarImagem;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNomeEncarte;
    }
}