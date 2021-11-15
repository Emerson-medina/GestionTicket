
namespace GestionTicket.Vistas
{
    partial class VerDetallesView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.IdTicketTextBox = new System.Windows.Forms.TextBox();
            this.DetallesTextBox = new System.Windows.Forms.TextBox();
            this.ClienteTextBox = new System.Windows.Forms.TextBox();
            this.CostoTextBox = new System.Windows.Forms.TextBox();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(268, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Detalle ticket";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Id Ticket";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Detalles";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cliente";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "Costo";
            // 
            // IdTicketTextBox
            // 
            this.IdTicketTextBox.Location = new System.Drawing.Point(165, 99);
            this.IdTicketTextBox.Name = "IdTicketTextBox";
            this.IdTicketTextBox.ReadOnly = true;
            this.IdTicketTextBox.Size = new System.Drawing.Size(140, 30);
            this.IdTicketTextBox.TabIndex = 5;
            // 
            // DetallesTextBox
            // 
            this.DetallesTextBox.Location = new System.Drawing.Point(165, 151);
            this.DetallesTextBox.Multiline = true;
            this.DetallesTextBox.Name = "DetallesTextBox";
            this.DetallesTextBox.ReadOnly = true;
            this.DetallesTextBox.Size = new System.Drawing.Size(347, 68);
            this.DetallesTextBox.TabIndex = 6;
            // 
            // ClienteTextBox
            // 
            this.ClienteTextBox.Location = new System.Drawing.Point(165, 250);
            this.ClienteTextBox.Name = "ClienteTextBox";
            this.ClienteTextBox.ReadOnly = true;
            this.ClienteTextBox.Size = new System.Drawing.Size(347, 30);
            this.ClienteTextBox.TabIndex = 7;
            // 
            // CostoTextBox
            // 
            this.CostoTextBox.Location = new System.Drawing.Point(165, 309);
            this.CostoTextBox.Name = "CostoTextBox";
            this.CostoTextBox.ReadOnly = true;
            this.CostoTextBox.Size = new System.Drawing.Size(140, 30);
            this.CostoTextBox.TabIndex = 8;
            // 
            // AceptarButton
            // 
            this.AceptarButton.Location = new System.Drawing.Point(295, 360);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(92, 30);
            this.AceptarButton.TabIndex = 9;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.UseVisualStyleBackColor = true;
            // 
            // VerDetallesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 414);
            this.Controls.Add(this.AceptarButton);
            this.Controls.Add(this.CostoTextBox);
            this.Controls.Add(this.ClienteTextBox);
            this.Controls.Add(this.DetallesTextBox);
            this.Controls.Add(this.IdTicketTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "VerDetallesView";
            this.Text = "VerDetallesView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox IdTicketTextBox;
        public System.Windows.Forms.TextBox DetallesTextBox;
        public System.Windows.Forms.TextBox ClienteTextBox;
        public System.Windows.Forms.TextBox CostoTextBox;
        public System.Windows.Forms.Button AceptarButton;
    }
}