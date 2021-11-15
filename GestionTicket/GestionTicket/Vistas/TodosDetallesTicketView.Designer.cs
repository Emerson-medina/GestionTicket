
namespace GestionTicket.Vistas
{
    partial class TodosDetallesTicketView
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
            this.label6 = new System.Windows.Forms.Label();
            this.DetallesTicketDataGridView = new System.Windows.Forms.DataGridView();
            this.EliminarButton = new System.Windows.Forms.Button();
            this.ModificarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DetallesTicketDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(357, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 22);
            this.label6.TabIndex = 32;
            this.label6.Text = "Detallles ticket";
            // 
            // DetallesTicketDataGridView
            // 
            this.DetallesTicketDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DetallesTicketDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DetallesTicketDataGridView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DetallesTicketDataGridView.Location = new System.Drawing.Point(0, 176);
            this.DetallesTicketDataGridView.Name = "DetallesTicketDataGridView";
            this.DetallesTicketDataGridView.Size = new System.Drawing.Size(863, 180);
            this.DetallesTicketDataGridView.TabIndex = 33;
            // 
            // EliminarButton
            // 
            this.EliminarButton.Location = new System.Drawing.Point(446, 112);
            this.EliminarButton.Name = "EliminarButton";
            this.EliminarButton.Size = new System.Drawing.Size(100, 42);
            this.EliminarButton.TabIndex = 35;
            this.EliminarButton.Text = "Eliminar";
            this.EliminarButton.UseVisualStyleBackColor = true;
            // 
            // ModificarButton
            // 
            this.ModificarButton.Location = new System.Drawing.Point(317, 112);
            this.ModificarButton.Name = "ModificarButton";
            this.ModificarButton.Size = new System.Drawing.Size(114, 42);
            this.ModificarButton.TabIndex = 34;
            this.ModificarButton.Text = "Modificar";
            this.ModificarButton.UseVisualStyleBackColor = true;
            // 
            // TodosDetallesTicketView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 356);
            this.Controls.Add(this.EliminarButton);
            this.Controls.Add(this.ModificarButton);
            this.Controls.Add(this.DetallesTicketDataGridView);
            this.Controls.Add(this.label6);
            this.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "TodosDetallesTicketView";
            this.Text = "TodosDetallesTicketView";
            ((System.ComponentModel.ISupportInitialize)(this.DetallesTicketDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.DataGridView DetallesTicketDataGridView;
        public System.Windows.Forms.Button EliminarButton;
        public System.Windows.Forms.Button ModificarButton;
    }
}