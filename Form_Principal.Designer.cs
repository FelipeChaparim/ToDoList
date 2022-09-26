
namespace ToDoList
{
    partial class Form_Principal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Txb_Novo = new System.Windows.Forms.TextBox();
            this.Btn_Add = new System.Windows.Forms.Button();
            this.Flp_Concluido = new System.Windows.Forms.FlowLayoutPanel();
            this.Flp_Afazer = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // Txb_Novo
            // 
            this.Txb_Novo.Location = new System.Drawing.Point(12, 12);
            this.Txb_Novo.Multiline = true;
            this.Txb_Novo.Name = "Txb_Novo";
            this.Txb_Novo.Size = new System.Drawing.Size(259, 59);
            this.Txb_Novo.TabIndex = 0;
            // 
            // Btn_Add
            // 
            this.Btn_Add.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn_Add.Location = new System.Drawing.Point(277, 26);
            this.Btn_Add.Name = "Btn_Add";
            this.Btn_Add.Size = new System.Drawing.Size(90, 32);
            this.Btn_Add.TabIndex = 1;
            this.Btn_Add.Text = "Adicionar";
            this.Btn_Add.UseVisualStyleBackColor = true;
            this.Btn_Add.Click += new System.EventHandler(this.Btn_Add_Click);
            this.Btn_Add.MouseEnter += new System.EventHandler(this.MouseEnter);
            this.Btn_Add.MouseLeave += new System.EventHandler(this.MouseLeave);
            // 
            // Flp_Concluido
            // 
            this.Flp_Concluido.AutoScroll = true;
            this.Flp_Concluido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Flp_Concluido.Location = new System.Drawing.Point(314, 96);
            this.Flp_Concluido.Name = "Flp_Concluido";
            this.Flp_Concluido.Size = new System.Drawing.Size(290, 535);
            this.Flp_Concluido.TabIndex = 3;
            // 
            // Flp_Afazer
            // 
            this.Flp_Afazer.AutoScroll = true;
            this.Flp_Afazer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Flp_Afazer.Location = new System.Drawing.Point(12, 96);
            this.Flp_Afazer.Name = "Flp_Afazer";
            this.Flp_Afazer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Flp_Afazer.Size = new System.Drawing.Size(290, 535);
            this.Flp_Afazer.TabIndex = 4;
            // 
            // Form_Principal
            // 
            this.AcceptButton = this.Btn_Add;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(616, 643);
            this.Controls.Add(this.Flp_Afazer);
            this.Controls.Add(this.Flp_Concluido);
            this.Controls.Add(this.Btn_Add);
            this.Controls.Add(this.Txb_Novo);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form_Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txb_Novo;
        private System.Windows.Forms.Button Btn_Add;
        private System.Windows.Forms.FlowLayoutPanel Flp_Concluido;
        private System.Windows.Forms.FlowLayoutPanel Flp_Afazer;
    }
}

