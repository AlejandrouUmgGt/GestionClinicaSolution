namespace GestionClinica.UI.Controles
{
    partial class UcExpediente
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
            this.tblExpediente = new System.Windows.Forms.TableLayoutPanel();
            this.lblAntecedentes = new System.Windows.Forms.Label();
            this.lblAlergias = new System.Windows.Forms.Label();
            this.txtAntecedentes = new System.Windows.Forms.TextBox();
            this.txtAlergias = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblHistorial = new System.Windows.Forms.Label();
            this.txtHistorial = new System.Windows.Forms.TextBox();
            this.pnlPaciente = new System.Windows.Forms.Panel();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.cmbPacientes = new System.Windows.Forms.ComboBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tblExpediente.SuspendLayout();
            this.pnlPaciente.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblExpediente
            // 
            this.tblExpediente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblExpediente.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblExpediente.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tblExpediente.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tblExpediente.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblExpediente.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tblExpediente.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72F));
            this.tblExpediente.Controls.Add(this.lblAntecedentes, 0, 0);
            this.tblExpediente.Controls.Add(this.lblAlergias, 1, 0);
            this.tblExpediente.Controls.Add(this.txtAntecedentes, 0, 1);
            this.tblExpediente.Controls.Add(this.txtAlergias, 1, 1);
            this.tblExpediente.Controls.Add(this.btnGuardar, 0, 2);
            this.tblExpediente.Controls.Add(this.lblHistorial, 0, 3);
            this.tblExpediente.SetColumnSpan(this.lblHistorial, 2);
            this.tblExpediente.Controls.Add(this.txtHistorial, 0, 4);
            this.tblExpediente.SetColumnSpan(this.txtHistorial, 2);
            this.tblExpediente.BackColor = System.Drawing.Color.FromArgb(18, 41, 77);
            this.tblExpediente.ColumnCount = 2;
            this.tblExpediente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblExpediente.Location = new System.Drawing.Point(0, 98);
            this.tblExpediente.RowCount = 5;
            this.tblExpediente.Size = new System.Drawing.Size(1000, 502);
            this.tblExpediente.TabIndex = 0;
            this.tblExpediente.Name = "tblExpediente";
            // 
            // lblAntecedentes
            // 
            this.lblAntecedentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAntecedentes.Size = new System.Drawing.Size(100, 28);
            this.lblAntecedentes.Text = "Antecedentes";
            this.lblAntecedentes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAntecedentes.TabIndex = 0;
            this.lblAntecedentes.Name = "lblAntecedentes";
            // 
            // lblAlergias
            // 
            this.lblAlergias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAlergias.Size = new System.Drawing.Size(100, 28);
            this.lblAlergias.Text = "Alergias";
            this.lblAlergias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAlergias.TabIndex = 1;
            this.lblAlergias.Name = "lblAlergias";
            // 
            // txtAntecedentes
            // 
            this.txtAntecedentes.BackColor = System.Drawing.Color.FromArgb(234, 240, 250);
            this.txtAntecedentes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAntecedentes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAntecedentes.ForeColor = System.Drawing.Color.FromArgb(11, 31, 58);
            this.txtAntecedentes.Multiline = true;
            this.txtAntecedentes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAntecedentes.Size = new System.Drawing.Size(100, 100);
            this.txtAntecedentes.TabIndex = 2;
            this.txtAntecedentes.Name = "txtAntecedentes";
            // 
            // txtAlergias
            // 
            this.txtAlergias.BackColor = System.Drawing.Color.FromArgb(234, 240, 250);
            this.txtAlergias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAlergias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAlergias.ForeColor = System.Drawing.Color.FromArgb(11, 31, 58);
            this.txtAlergias.Multiline = true;
            this.txtAlergias.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAlergias.Size = new System.Drawing.Size(100, 100);
            this.txtAlergias.TabIndex = 3;
            this.txtAlergias.Name = "txtAlergias";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(46, 134, 222);
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(234, 240, 250);
            this.btnGuardar.Size = new System.Drawing.Size(190, 34);
            this.btnGuardar.Text = "Guardar expediente";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblHistorial
            // 
            this.lblHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHistorial.Size = new System.Drawing.Size(100, 28);
            this.lblHistorial.Text = "Historial: composición de citas y tratamientos";
            this.lblHistorial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHistorial.TabIndex = 5;
            this.lblHistorial.Name = "lblHistorial";
            // 
            // txtHistorial
            // 
            this.txtHistorial.BackColor = System.Drawing.Color.FromArgb(234, 240, 250);
            this.txtHistorial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHistorial.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHistorial.ForeColor = System.Drawing.Color.FromArgb(11, 31, 58);
            this.txtHistorial.Multiline = true;
            this.txtHistorial.ReadOnly = true;
            this.txtHistorial.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtHistorial.Size = new System.Drawing.Size(100, 100);
            this.txtHistorial.TabIndex = 6;
            this.txtHistorial.Name = "txtHistorial";
            // 
            // pnlPaciente
            // 
            this.pnlPaciente.Controls.Add(this.lblPaciente);
            this.pnlPaciente.Controls.Add(this.cmbPacientes);
            this.pnlPaciente.BackColor = System.Drawing.Color.FromArgb(18, 41, 77);
            this.pnlPaciente.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPaciente.Location = new System.Drawing.Point(0, 0);
            this.pnlPaciente.Size = new System.Drawing.Size(1000, 48);
            this.pnlPaciente.TabIndex = 1;
            this.pnlPaciente.Name = "pnlPaciente";
            // 
            // lblPaciente
            // 
            this.lblPaciente.Location = new System.Drawing.Point(10, 10);
            this.lblPaciente.Size = new System.Drawing.Size(70, 27);
            this.lblPaciente.Text = "Paciente";
            this.lblPaciente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPaciente.TabIndex = 0;
            this.lblPaciente.Name = "lblPaciente";
            // 
            // cmbPacientes
            // 
            this.cmbPacientes.BackColor = System.Drawing.Color.FromArgb(234, 240, 250);
            this.cmbPacientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPacientes.ForeColor = System.Drawing.Color.FromArgb(11, 31, 58);
            this.cmbPacientes.FormattingEnabled = true;
            this.cmbPacientes.Location = new System.Drawing.Point(85, 10);
            this.cmbPacientes.Size = new System.Drawing.Size(320, 28);
            this.cmbPacientes.TabIndex = 1;
            this.cmbPacientes.Name = "cmbPacientes";
            this.cmbPacientes.SelectedIndexChanged += new System.EventHandler(this.cmbPacientes_SelectedIndexChanged);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Size = new System.Drawing.Size(1000, 50);
            this.lblTitulo.Text = "Expediente e historial médico";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Name = "lblTitulo";
            // 
            // UcExpediente
            // 
            this.Controls.Add(this.tblExpediente);
            this.Controls.Add(this.pnlPaciente);
            this.Controls.Add(this.lblTitulo);
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(11, 31, 58);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(234, 240, 250);
            this.Size = new System.Drawing.Size(1000, 600);
            this.Name = "UcExpediente";
            this.Load += new System.EventHandler(this.UcExpediente_Load);
            this.pnlPaciente.ResumeLayout(false);
            this.pnlPaciente.PerformLayout();
            this.tblExpediente.ResumeLayout(false);
            this.tblExpediente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblExpediente;
        private System.Windows.Forms.Label lblAntecedentes;
        private System.Windows.Forms.Label lblAlergias;
        private System.Windows.Forms.TextBox txtAntecedentes;
        private System.Windows.Forms.TextBox txtAlergias;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblHistorial;
        private System.Windows.Forms.TextBox txtHistorial;
        private System.Windows.Forms.Panel pnlPaciente;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.ComboBox cmbPacientes;
        private System.Windows.Forms.Label lblTitulo;
    }
}
