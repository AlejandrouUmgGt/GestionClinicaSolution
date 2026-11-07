namespace GestionClinica.UI.Controles
{
    partial class UcClinica
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
            this.lstMedicos = new System.Windows.Forms.ListBox();
            this.lblMedicosAsociados = new System.Windows.Forms.Label();
            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlFormulario.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstMedicos
            // 
            this.lstMedicos.BackColor = System.Drawing.Color.FromArgb(234, 240, 250);
            this.lstMedicos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMedicos.ForeColor = System.Drawing.Color.FromArgb(11, 31, 58);
            this.lstMedicos.FormattingEnabled = true;
            this.lstMedicos.Location = new System.Drawing.Point(0, 205);
            this.lstMedicos.Size = new System.Drawing.Size(1000, 395);
            this.lstMedicos.TabIndex = 0;
            this.lstMedicos.Name = "lstMedicos";
            // 
            // lblMedicosAsociados
            // 
            this.lblMedicosAsociados.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMedicosAsociados.Size = new System.Drawing.Size(1000, 35);
            this.lblMedicosAsociados.Text = "Médicos asociados (agregación)";
            this.lblMedicosAsociados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMedicosAsociados.TabIndex = 1;
            this.lblMedicosAsociados.Name = "lblMedicosAsociados";
            // 
            // pnlFormulario
            // 
            this.pnlFormulario.Controls.Add(this.lblNombre);
            this.pnlFormulario.Controls.Add(this.txtNombre);
            this.pnlFormulario.Controls.Add(this.lblUbicacion);
            this.pnlFormulario.Controls.Add(this.txtUbicacion);
            this.pnlFormulario.Controls.Add(this.btnGuardar);
            this.pnlFormulario.BackColor = System.Drawing.Color.FromArgb(18, 41, 77);
            this.pnlFormulario.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFormulario.Location = new System.Drawing.Point(0, 0);
            this.pnlFormulario.Size = new System.Drawing.Size(1000, 150);
            this.pnlFormulario.TabIndex = 2;
            this.pnlFormulario.Name = "pnlFormulario";
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(20, 15);
            this.lblNombre.Size = new System.Drawing.Size(130, 27);
            this.lblNombre.Text = "Nombre";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Name = "lblNombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.BackColor = System.Drawing.Color.FromArgb(234, 240, 250);
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(11, 31, 58);
            this.txtNombre.Location = new System.Drawing.Point(160, 15);
            this.txtNombre.Size = new System.Drawing.Size(500, 27);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.Name = "txtNombre";
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.Location = new System.Drawing.Point(20, 60);
            this.lblUbicacion.Size = new System.Drawing.Size(130, 27);
            this.lblUbicacion.Text = "Ubicación";
            this.lblUbicacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUbicacion.TabIndex = 2;
            this.lblUbicacion.Name = "lblUbicacion";
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUbicacion.BackColor = System.Drawing.Color.FromArgb(234, 240, 250);
            this.txtUbicacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUbicacion.ForeColor = System.Drawing.Color.FromArgb(11, 31, 58);
            this.txtUbicacion.Location = new System.Drawing.Point(160, 60);
            this.txtUbicacion.Size = new System.Drawing.Size(500, 27);
            this.txtUbicacion.TabIndex = 3;
            this.txtUbicacion.Name = "txtUbicacion";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(46, 134, 222);
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(234, 240, 250);
            this.btnGuardar.Location = new System.Drawing.Point(160, 102);
            this.btnGuardar.Size = new System.Drawing.Size(110, 36);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Size = new System.Drawing.Size(1000, 55);
            this.lblTitulo.Text = "Información de la clínica";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Name = "lblTitulo";
            // 
            // UcClinica
            // 
            this.Controls.Add(this.lstMedicos);
            this.Controls.Add(this.lblMedicosAsociados);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.lblTitulo);
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(11, 31, 58);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(234, 240, 250);
            this.Size = new System.Drawing.Size(1000, 600);
            this.Name = "UcClinica";
            this.Load += new System.EventHandler(this.UcClinica_Load);
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox lstMedicos;
        private System.Windows.Forms.Label lblMedicosAsociados;
        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblTitulo;
    }
}
