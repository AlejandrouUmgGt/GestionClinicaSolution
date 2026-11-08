namespace GestionClinica.UI.Forms
{
    partial class FrmTratamiento
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
            this.lblCita = new System.Windows.Forms.Label();
            this.cmbCitas = new System.Windows.Forms.ComboBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblIndicaciones = new System.Windows.Forms.Label();
            this.txtIndicaciones = new System.Windows.Forms.TextBox();
            this.lblInicio = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.chkTieneFin = new System.Windows.Forms.CheckBox();
            this.lblFin = new System.Windows.Forms.Label();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.chkRealizado = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCita
            // 
            this.lblCita.Location = new System.Drawing.Point(25, 25);
            this.lblCita.Size = new System.Drawing.Size(155, 27);
            this.lblCita.Text = "Cita";
            this.lblCita.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCita.TabIndex = 0;
            this.lblCita.ForeColor = System.Drawing.Color.FromArgb(120, 170, 230);
            this.lblCita.Name = "lblCita";
            // 
            // cmbCitas
            // 
            this.cmbCitas.BackColor = System.Drawing.Color.FromArgb(30, 50, 90);
            this.cmbCitas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCitas.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.cmbCitas.FormattingEnabled = true;
            this.cmbCitas.Location = new System.Drawing.Point(185, 25);
            this.cmbCitas.Size = new System.Drawing.Size(310, 28);
            this.cmbCitas.TabIndex = 1;
            this.cmbCitas.Name = "cmbCitas";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(25, 71);
            this.lblDescripcion.Size = new System.Drawing.Size(155, 27);
            this.lblDescripcion.Text = "Descripción";
            this.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(120, 170, 230);
            this.lblDescripcion.Name = "lblDescripcion";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescripcion.BackColor = System.Drawing.Color.FromArgb(30, 50, 90);
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.txtDescripcion.Location = new System.Drawing.Point(185, 71);
            this.txtDescripcion.Size = new System.Drawing.Size(310, 27);
            this.txtDescripcion.TabIndex = 3;
            this.txtDescripcion.Name = "txtDescripcion";
            // 
            // lblIndicaciones
            // 
            this.lblIndicaciones.Location = new System.Drawing.Point(25, 117);
            this.lblIndicaciones.Size = new System.Drawing.Size(155, 27);
            this.lblIndicaciones.Text = "Indicaciones";
            this.lblIndicaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblIndicaciones.TabIndex = 4;
            this.lblIndicaciones.ForeColor = System.Drawing.Color.FromArgb(120, 170, 230);
            this.lblIndicaciones.Name = "lblIndicaciones";
            // 
            // txtIndicaciones
            // 
            this.txtIndicaciones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIndicaciones.BackColor = System.Drawing.Color.FromArgb(30, 50, 90);
            this.txtIndicaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIndicaciones.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.txtIndicaciones.Location = new System.Drawing.Point(185, 117);
            this.txtIndicaciones.Multiline = true;
            this.txtIndicaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtIndicaciones.Size = new System.Drawing.Size(310, 70);
            this.txtIndicaciones.TabIndex = 5;
            this.txtIndicaciones.Name = "txtIndicaciones";
            // 
            // lblInicio
            // 
            this.lblInicio.Location = new System.Drawing.Point(25, 203);
            this.lblInicio.Size = new System.Drawing.Size(155, 27);
            this.lblInicio.Text = "Fecha inicio";
            this.lblInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInicio.TabIndex = 6;
            this.lblInicio.ForeColor = System.Drawing.Color.FromArgb(120, 170, 230);
            this.lblInicio.Name = "lblInicio";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(185, 203);
            this.dtpInicio.Size = new System.Drawing.Size(310, 27);
            this.dtpInicio.TabIndex = 7;
            this.dtpInicio.Name = "dtpInicio";
            // 
            // chkTieneFin
            // 
            this.chkTieneFin.Location = new System.Drawing.Point(185, 243);
            this.chkTieneFin.Size = new System.Drawing.Size(200, 27);
            this.chkTieneFin.Text = "Tiene fecha de fin";
            this.chkTieneFin.TabIndex = 8;
            this.chkTieneFin.Name = "chkTieneFin";
            this.chkTieneFin.CheckedChanged += new System.EventHandler(this.chkTieneFin_CheckedChanged);
            // 
            // lblFin
            // 
            this.lblFin.Location = new System.Drawing.Point(25, 277);
            this.lblFin.Size = new System.Drawing.Size(155, 27);
            this.lblFin.Text = "Fecha fin";
            this.lblFin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFin.TabIndex = 9;
            this.lblFin.ForeColor = System.Drawing.Color.FromArgb(120, 170, 230);
            this.lblFin.Name = "lblFin";
            // 
            // dtpFin
            // 
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFin.Enabled = false;
            this.dtpFin.Location = new System.Drawing.Point(185, 277);
            this.dtpFin.Size = new System.Drawing.Size(310, 27);
            this.dtpFin.TabIndex = 10;
            this.dtpFin.Name = "dtpFin";
            // 
            // chkRealizado
            // 
            this.chkRealizado.Location = new System.Drawing.Point(185, 317);
            this.chkRealizado.Size = new System.Drawing.Size(200, 27);
            this.chkRealizado.Text = "Realizado";
            this.chkRealizado.TabIndex = 11;
            this.chkRealizado.Name = "chkRealizado";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.btnGuardar.Location = new System.Drawing.Point(185, 363);
            this.btnGuardar.Size = new System.Drawing.Size(110, 36);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.btnCancelar.Location = new System.Drawing.Point(305, 363);
            this.btnCancelar.Size = new System.Drawing.Size(110, 36);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.Name = "btnCancelar";
            // 
            // FrmTratamiento
            // 
            this.Controls.Add(this.lblCita);
            this.Controls.Add(this.cmbCitas);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblIndicaciones);
            this.Controls.Add(this.txtIndicaciones);
            this.Controls.Add(this.lblInicio);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.chkTieneFin);
            this.Controls.Add(this.lblFin);
            this.Controls.Add(this.dtpFin);
            this.Controls.Add(this.chkRealizado);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(10, 20, 40);
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(520, 424);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tratamiento";
            this.Name = "FrmTratamiento";
            this.Load += new System.EventHandler(this.FrmTratamiento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblCita;
        private System.Windows.Forms.ComboBox cmbCitas;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblIndicaciones;
        private System.Windows.Forms.TextBox txtIndicaciones;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.CheckBox chkTieneFin;
        private System.Windows.Forms.Label lblFin;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.CheckBox chkRealizado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
