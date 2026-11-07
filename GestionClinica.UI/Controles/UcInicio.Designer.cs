namespace GestionClinica.UI.Controles
{
    partial class UcInicio
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
            this.pnlTarjetas = new System.Windows.Forms.Panel();
            this.pnlTarjetaMedicos = new System.Windows.Forms.Panel();
            this.lblTotalMedicos = new System.Windows.Forms.Label();
            this.lblTituloTarjetaMedicos = new System.Windows.Forms.Label();
            this.pnlTarjetaPacientes = new System.Windows.Forms.Panel();
            this.lblTotalPacientes = new System.Windows.Forms.Label();
            this.lblTituloTarjetaPacientes = new System.Windows.Forms.Label();
            this.pnlTarjetaCitas = new System.Windows.Forms.Panel();
            this.lblTotalCitas = new System.Windows.Forms.Label();
            this.lblTituloTarjetaCitas = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlTarjetas.SuspendLayout();
            this.pnlTarjetaMedicos.SuspendLayout();
            this.pnlTarjetaPacientes.SuspendLayout();
            this.pnlTarjetaCitas.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTarjetas
            // 
            this.pnlTarjetas.Controls.Add(this.pnlTarjetaMedicos);
            this.pnlTarjetas.Controls.Add(this.pnlTarjetaPacientes);
            this.pnlTarjetas.Controls.Add(this.pnlTarjetaCitas);
            this.pnlTarjetas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTarjetas.Location = new System.Drawing.Point(0, 0);
            this.pnlTarjetas.Padding = new System.Windows.Forms.Padding(10);
            this.pnlTarjetas.Size = new System.Drawing.Size(1000, 170);
            this.pnlTarjetas.TabIndex = 0;
            this.pnlTarjetas.Name = "pnlTarjetas";
            // 
            // pnlTarjetaMedicos
            // 
            this.pnlTarjetaMedicos.Controls.Add(this.lblTotalMedicos);
            this.pnlTarjetaMedicos.Controls.Add(this.lblTituloTarjetaMedicos);
            this.pnlTarjetaMedicos.BackColor = System.Drawing.Color.FromArgb(18, 41, 77);
            this.pnlTarjetaMedicos.Location = new System.Drawing.Point(10, 10);
            this.pnlTarjetaMedicos.Padding = new System.Windows.Forms.Padding(12);
            this.pnlTarjetaMedicos.Size = new System.Drawing.Size(220, 130);
            this.pnlTarjetaMedicos.TabIndex = 0;
            this.pnlTarjetaMedicos.Name = "pnlTarjetaMedicos";
            // 
            // lblTotalMedicos
            // 
            this.lblTotalMedicos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalMedicos.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMedicos.Size = new System.Drawing.Size(196, 78);
            this.lblTotalMedicos.Text = "0";
            this.lblTotalMedicos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotalMedicos.TabIndex = 0;
            this.lblTotalMedicos.Name = "lblTotalMedicos";
            // 
            // lblTituloTarjetaMedicos
            // 
            this.lblTituloTarjetaMedicos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloTarjetaMedicos.Size = new System.Drawing.Size(196, 40);
            this.lblTituloTarjetaMedicos.Text = "Médicos";
            this.lblTituloTarjetaMedicos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTituloTarjetaMedicos.TabIndex = 1;
            this.lblTituloTarjetaMedicos.Name = "lblTituloTarjetaMedicos";
            // 
            // pnlTarjetaPacientes
            // 
            this.pnlTarjetaPacientes.Controls.Add(this.lblTotalPacientes);
            this.pnlTarjetaPacientes.Controls.Add(this.lblTituloTarjetaPacientes);
            this.pnlTarjetaPacientes.BackColor = System.Drawing.Color.FromArgb(18, 41, 77);
            this.pnlTarjetaPacientes.Location = new System.Drawing.Point(250, 10);
            this.pnlTarjetaPacientes.Padding = new System.Windows.Forms.Padding(12);
            this.pnlTarjetaPacientes.Size = new System.Drawing.Size(220, 130);
            this.pnlTarjetaPacientes.TabIndex = 1;
            this.pnlTarjetaPacientes.Name = "pnlTarjetaPacientes";
            // 
            // lblTotalPacientes
            // 
            this.lblTotalPacientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalPacientes.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPacientes.Size = new System.Drawing.Size(196, 78);
            this.lblTotalPacientes.Text = "0";
            this.lblTotalPacientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotalPacientes.TabIndex = 0;
            this.lblTotalPacientes.Name = "lblTotalPacientes";
            // 
            // lblTituloTarjetaPacientes
            // 
            this.lblTituloTarjetaPacientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloTarjetaPacientes.Size = new System.Drawing.Size(196, 40);
            this.lblTituloTarjetaPacientes.Text = "Pacientes";
            this.lblTituloTarjetaPacientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTituloTarjetaPacientes.TabIndex = 1;
            this.lblTituloTarjetaPacientes.Name = "lblTituloTarjetaPacientes";
            // 
            // pnlTarjetaCitas
            // 
            this.pnlTarjetaCitas.Controls.Add(this.lblTotalCitas);
            this.pnlTarjetaCitas.Controls.Add(this.lblTituloTarjetaCitas);
            this.pnlTarjetaCitas.BackColor = System.Drawing.Color.FromArgb(18, 41, 77);
            this.pnlTarjetaCitas.Location = new System.Drawing.Point(490, 10);
            this.pnlTarjetaCitas.Padding = new System.Windows.Forms.Padding(12);
            this.pnlTarjetaCitas.Size = new System.Drawing.Size(220, 130);
            this.pnlTarjetaCitas.TabIndex = 2;
            this.pnlTarjetaCitas.Name = "pnlTarjetaCitas";
            // 
            // lblTotalCitas
            // 
            this.lblTotalCitas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalCitas.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCitas.Size = new System.Drawing.Size(196, 78);
            this.lblTotalCitas.Text = "0";
            this.lblTotalCitas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotalCitas.TabIndex = 0;
            this.lblTotalCitas.Name = "lblTotalCitas";
            // 
            // lblTituloTarjetaCitas
            // 
            this.lblTituloTarjetaCitas.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloTarjetaCitas.Size = new System.Drawing.Size(196, 40);
            this.lblTituloTarjetaCitas.Text = "Citas de hoy";
            this.lblTituloTarjetaCitas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTituloTarjetaCitas.TabIndex = 1;
            this.lblTituloTarjetaCitas.Name = "lblTituloTarjetaCitas";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Size = new System.Drawing.Size(1000, 70);
            this.lblTitulo.Text = "Bienvenido";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Name = "lblTitulo";
            // 
            // UcInicio
            // 
            this.Controls.Add(this.pnlTarjetas);
            this.Controls.Add(this.lblTitulo);
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(11, 31, 58);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(234, 240, 250);
            this.Size = new System.Drawing.Size(1000, 600);
            this.Name = "UcInicio";
            this.Load += new System.EventHandler(this.UcInicio_Load);
            this.pnlTarjetaCitas.ResumeLayout(false);
            this.pnlTarjetaCitas.PerformLayout();
            this.pnlTarjetaPacientes.ResumeLayout(false);
            this.pnlTarjetaPacientes.PerformLayout();
            this.pnlTarjetaMedicos.ResumeLayout(false);
            this.pnlTarjetaMedicos.PerformLayout();
            this.pnlTarjetas.ResumeLayout(false);
            this.pnlTarjetas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlTarjetas;
        private System.Windows.Forms.Panel pnlTarjetaMedicos;
        private System.Windows.Forms.Label lblTotalMedicos;
        private System.Windows.Forms.Label lblTituloTarjetaMedicos;
        private System.Windows.Forms.Panel pnlTarjetaPacientes;
        private System.Windows.Forms.Label lblTotalPacientes;
        private System.Windows.Forms.Label lblTituloTarjetaPacientes;
        private System.Windows.Forms.Panel pnlTarjetaCitas;
        private System.Windows.Forms.Label lblTotalCitas;
        private System.Windows.Forms.Label lblTituloTarjetaCitas;
        private System.Windows.Forms.Label lblTitulo;
    }
}
