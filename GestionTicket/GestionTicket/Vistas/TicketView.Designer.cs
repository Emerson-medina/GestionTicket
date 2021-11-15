
namespace GestionTicket.Vistas
{
    partial class TicketView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ClienteTextBox = new System.Windows.Forms.TextBox();
            this.TipoServicioTextBox = new System.Windows.Forms.TextBox();
            this.DetalleTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CostoTextBox = new System.Windows.Forms.TextBox();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.ClienteButton = new System.Windows.Forms.Button();
            this.TipoServicioButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(288, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tickets";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cliente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tipo Servicio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(76, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "Detalle";
            // 
            // ClienteTextBox
            // 
            this.ClienteTextBox.Location = new System.Drawing.Point(177, 169);
            this.ClienteTextBox.Name = "ClienteTextBox";
            this.ClienteTextBox.ReadOnly = true;
            this.ClienteTextBox.Size = new System.Drawing.Size(374, 30);
            this.ClienteTextBox.TabIndex = 9;
            // 
            // TipoServicioTextBox
            // 
            this.TipoServicioTextBox.Location = new System.Drawing.Point(177, 211);
            this.TipoServicioTextBox.Name = "TipoServicioTextBox";
            this.TipoServicioTextBox.ReadOnly = true;
            this.TipoServicioTextBox.Size = new System.Drawing.Size(374, 30);
            this.TipoServicioTextBox.TabIndex = 10;
            // 
            // DetalleTextBox
            // 
            this.DetalleTextBox.Location = new System.Drawing.Point(177, 262);
            this.DetalleTextBox.Multiline = true;
            this.DetalleTextBox.Name = "DetalleTextBox";
            this.DetalleTextBox.Size = new System.Drawing.Size(374, 67);
            this.DetalleTextBox.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(76, 357);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 22);
            this.label7.TabIndex = 12;
            this.label7.Text = "Costo";
            // 
            // CostoTextBox
            // 
            this.CostoTextBox.Location = new System.Drawing.Point(177, 349);
            this.CostoTextBox.Name = "CostoTextBox";
            this.CostoTextBox.Size = new System.Drawing.Size(160, 30);
            this.CostoTextBox.TabIndex = 13;
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(204, 423);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(103, 30);
            this.GuardarButton.TabIndex = 14;
            this.GuardarButton.Text = "Guardar";
            this.GuardarButton.UseVisualStyleBackColor = true;
            // 
            // CancelarButton
            // 
            this.CancelarButton.Location = new System.Drawing.Point(357, 423);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(103, 30);
            this.CancelarButton.TabIndex = 15;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            // 
            // ClienteButton
            // 
            this.ClienteButton.Location = new System.Drawing.Point(557, 169);
            this.ClienteButton.Name = "ClienteButton";
            this.ClienteButton.Size = new System.Drawing.Size(47, 30);
            this.ClienteButton.TabIndex = 17;
            this.ClienteButton.Text = "...";
            this.ClienteButton.UseVisualStyleBackColor = true;
            // 
            // TipoServicioButton
            // 
            this.TipoServicioButton.Location = new System.Drawing.Point(557, 211);
            this.TipoServicioButton.Name = "TipoServicioButton";
            this.TipoServicioButton.Size = new System.Drawing.Size(47, 30);
            this.TipoServicioButton.TabIndex = 18;
            this.TipoServicioButton.Text = "...";
            this.TipoServicioButton.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // TicketView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 490);
            this.Controls.Add(this.TipoServicioButton);
            this.Controls.Add(this.ClienteButton);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.CostoTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DetalleTextBox);
            this.Controls.Add(this.TipoServicioTextBox);
            this.Controls.Add(this.ClienteTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "TicketView";
            this.Text = "Tickets";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox ClienteTextBox;
        public System.Windows.Forms.TextBox TipoServicioTextBox;
        public System.Windows.Forms.TextBox DetalleTextBox;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox CostoTextBox;
        public System.Windows.Forms.Button GuardarButton;
        public System.Windows.Forms.Button CancelarButton;
        public System.Windows.Forms.Button ClienteButton;
        public System.Windows.Forms.Button TipoServicioButton;
        public System.Windows.Forms.ErrorProvider errorProvider1;
    }
}