namespace GestionClinica.UI.Forms
{
    partial class FrmCita
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
            this.lblMedico = new System.Windows.Forms.Label();
            this.cmbMedicos = new System.Windows.Forms.ComboBox();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.cmbPacientes = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblHora = new System.Windows.Forms.Label();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMedico
            // 
            this.lblMedico.Location = new System.Drawing.Point(25, 25);
            this.lblMedico.Size = new System.Drawing.Size(155, 27);
            this.lblMedico.Text = "Médico";
            this.lblMedico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMedico.TabIndex = 0;
            this.lblMedico.ForeColor = System.Drawing.Color.FromArgb(120, 170, 230);
            this.lblMedico.Name = "lblMedico";
            // 
            // cmbMedicos
            // 
            this.cmbMedicos.BackColor = System.Drawing.Color.FromArgb(30, 50, 90);
            this.cmbMedicos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedicos.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.cmbMedicos.FormattingEnabled = true;
            this.cmbMedicos.Location = new System.Drawing.Point(185, 25);
            this.cmbMedicos.Size = new System.Drawing.Size(290, 28);
            this.cmbMedicos.TabIndex = 1;
            this.cmbMedicos.Name = "cmbMedicos";
            // 
            // lblPaciente
            // 
            this.lblPaciente.Location = new System.Drawing.Point(25, 71);
            this.lblPaciente.Size = new System.Drawing.Size(155, 27);
            this.lblPaciente.Text = "Paciente";
            this.lblPaciente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPaciente.TabIndex = 2;
            this.lblPaciente.ForeColor = System.Drawing.Color.FromArgb(120, 170, 230);
            this.lblPaciente.Name = "lblPaciente";
            // 
            // cmbPacientes
            // 
            this.cmbPacientes.BackColor = System.Drawing.Color.FromArgb(30, 50, 90);
            this.cmbPacientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPacientes.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.cmbPacientes.FormattingEnabled = true;
            this.cmbPacientes.Location = new System.Drawing.Point(185, 71);
            this.cmbPacientes.Size = new System.Drawing.Size(290, 28);
            this.cmbPacientes.TabIndex = 3;
            this.cmbPacientes.Name = "cmbPacientes";
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(25, 117);
            this.lblFecha.Size = new System.Drawing.Size(155, 27);
            this.lblFecha.Text = "Fecha";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFecha.TabIndex = 4;
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(120, 170, 230);
            this.lblFecha.Name = "lblFecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(185, 117);
            this.dtpFecha.Size = new System.Drawing.Size(290, 27);
            this.dtpFecha.TabIndex = 5;
            this.dtpFecha.Name = "dtpFecha";
            // 
            // lblHora
            // 
            this.lblHora.Location = new System.Drawing.Point(25, 163);
            this.lblHora.Size = new System.Drawing.Size(155, 27);
            this.lblHora.Text = "Hora";
            this.lblHora.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHora.TabIndex = 6;
            this.lblHora.ForeColor = System.Drawing.Color.FromArgb(120, 170, 230);
            this.lblHora.Name = "lblHora";
            // 
            // dtpHora
            // 
            this.dtpHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHora.Location = new System.Drawing.Point(185, 163);
            this.dtpHora.Size = new System.Drawing.Size(290, 27);
            this.dtpHora.ShowUpDown = true;
            this.dtpHora.TabIndex = 7;
            this.dtpHora.Name = "dtpHora";
            // 
            // lblMotivo
            // 
            this.lblMotivo.Location = new System.Drawing.Point(25, 209);
            this.lblMotivo.Size = new System.Drawing.Size(155, 27);
            this.lblMotivo.Text = "Motivo";
            this.lblMotivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMotivo.TabIndex = 8;
            this.lblMotivo.ForeColor = System.Drawing.Color.FromArgb(120, 170, 230);
            this.lblMotivo.Name = "lblMotivo";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMotivo.BackColor = System.Drawing.Color.FromArgb(30, 50, 90);
            this.txtMotivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMotivo.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.txtMotivo.Location = new System.Drawing.Point(185, 209);
            this.txtMotivo.Size = new System.Drawing.Size(290, 27);
            this.txtMotivo.TabIndex = 9;
            this.txtMotivo.Name = "txtMotivo";
            // 
            // lblEstado
            // 
            this.lblEstado.Location = new System.Drawing.Point(25, 255);
            this.lblEstado.Size = new System.Drawing.Size(155, 27);
            this.lblEstado.Text = "Estado";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEstado.TabIndex = 10;
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(120, 170, 230);
            this.lblEstado.Name = "lblEstado";
            // 
            // cmbEstado
            // 
            this.cmbEstado.Items.AddRange(new object[] {"Programada", "Atendida", "Cancelada"});
            this.cmbEstado.BackColor = System.Drawing.Color.FromArgb(30, 50, 90);
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(185, 255);
            this.cmbEstado.Size = new System.Drawing.Size(290, 28);
            this.cmbEstado.TabIndex = 11;
            this.cmbEstado.Name = "cmbEstado";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.btnGuardar.Location = new System.Drawing.Point(185, 311);
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
            this.btnCancelar.Location = new System.Drawing.Point(305, 311);
            this.btnCancelar.Size = new System.Drawing.Size(110, 36);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.Name = "btnCancelar";
            // 
            // FrmCita
            // 
            this.Controls.Add(this.lblMedico);
            this.Controls.Add(this.cmbMedicos);
            this.Controls.Add(this.lblPaciente);
            this.Controls.Add(this.cmbPacientes);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.lblHora);
            this.Controls.Add(this.dtpHora);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.AcceptButton = this.btnGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(10, 20, 40);
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(500, 365);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cita";
            this.Name = "FrmCita";
            this.Load += new System.EventHandler(this.FrmCita_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblMedico;
        private System.Windows.Forms.ComboBox cmbMedicos;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.ComboBox cmbPacientes;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
