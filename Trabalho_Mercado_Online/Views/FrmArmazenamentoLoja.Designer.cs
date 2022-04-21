namespace Trabalho_Mercado_Online.Views
{
    partial class FrmArmazenamentoLoja
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnEstrutura = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Trabalho_Mercado_Online.Properties.Resources.icone_store;
            this.pictureBox1.Location = new System.Drawing.Point(18, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.TabIndex = 55624;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(100, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 32);
            this.label3.TabIndex = 55612;
            this.label3.Text = "Loja";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMain.Controls.Add(this.pictureBox1);
            this.panelMain.Controls.Add(this.btnEstrutura);
            this.panelMain.Controls.Add(this.label3);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(897, 648);
            this.panelMain.TabIndex = 4;
            // 
            // btnEstrutura
            // 
            this.btnEstrutura.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnEstrutura.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnEstrutura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstrutura.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEstrutura.ForeColor = System.Drawing.Color.White;
            this.btnEstrutura.Image = global::Trabalho_Mercado_Online.Properties.Resources.icone_access;
            this.btnEstrutura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEstrutura.Location = new System.Drawing.Point(18, 586);
            this.btnEstrutura.Name = "btnEstrutura";
            this.btnEstrutura.Size = new System.Drawing.Size(153, 50);
            this.btnEstrutura.TabIndex = 55607;
            this.btnEstrutura.TabStop = false;
            this.btnEstrutura.Text = "  Estrutura";
            this.btnEstrutura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEstrutura.UseVisualStyleBackColor = false;
            this.btnEstrutura.Click += new System.EventHandler(this.btnEstrutura_Click);
            // 
            // FrmArmazenamentoLoja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(897, 648);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmArmazenamentoLoja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmArmazenamento";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnEstrutura;
    }
}