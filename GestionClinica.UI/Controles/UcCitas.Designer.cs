namespace GestionClinica.UI.Controles
{
    partial class UcCitas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCitas = new System.Windows.Forms.DataGridView();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMedico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnAtendida = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.chkTodos = new System.Windows.Forms.CheckBox();
            this.cmbMedicos = new System.Windows.Forms.ComboBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).BeginInit();
            this.pnlBotones.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCitas
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(10, 20, 40);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.dgvCitas.AllowUserToAddRows = false;
            this.dgvCitas.AllowUserToDeleteRows = false;
            this.dgvCitas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCitas.BackgroundColor = System.Drawing.Color.FromArgb(20, 32, 60);
            this.dgvCitas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCitas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFecha,
            this.colMedico,
            this.colPaciente,
            this.colMotivo,
            this.colEstado});
            this.dgvCitas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCitas.EnableHeadersVisualStyles = false;
            this.dgvCitas.MultiSelect = false;
            this.dgvCitas.ReadOnly = true;
            this.dgvCitas.RowHeadersVisible = false;
            this.dgvCitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCitas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCitas.Location = new System.Drawing.Point(0, 0);
            this.dgvCitas.Size = new System.Drawing.Size(800, 300);
            this.dgvCitas.TabIndex = 0;
            this.dgvCitas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCitas.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(26, 54, 108);
            this.dgvCitas.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvCitas.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 50, 90);
            this.dgvCitas.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.dgvCitas.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.dgvCitas.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCitas.Name = "dgvCitas";
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha y hora";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // colMedico
            // 
            this.colMedico.HeaderText = "Médico";
            this.colMedico.Name = "colMedico";
            this.colMedico.ReadOnly = true;
            // 
            // colPaciente
            // 
            this.colPaciente.HeaderText = "Paciente";
            this.colPaciente.Name = "colPaciente";
            this.colPaciente.ReadOnly = true;
            // 
            // colMotivo
            // 
            this.colMotivo.HeaderText = "Motivo";
            this.colMotivo.Name = "colMotivo";
            this.colMotivo.ReadOnly = true;
            // 
            // colEstado
            // 
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            // 
            // pnlBotones
            // 
            this.pnlBotones.Controls.Add(this.btnNuevo);
            this.pnlBotones.Controls.Add(this.btnEditar);
            this.pnlBotones.Controls.Add(this.btnEliminar);
            this.pnlBotones.Controls.Add(this.btnAtendida);
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.btnActualizar);
            this.pnlBotones.BackColor = System.Drawing.Color.FromArgb(20, 32, 60);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 0);
            this.pnlBotones.Size = new System.Drawing.Size(1000, 55);
            this.pnlBotones.TabIndex = 1;
            this.pnlBotones.Name = "pnlBotones";
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.btnNuevo.Location = new System.Drawing.Point(10, 9);
            this.btnNuevo.Size = new System.Drawing.Size(90, 36);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.btnEditar.Location = new System.Drawing.Point(110, 9);
            this.btnEditar.Size = new System.Drawing.Size(90, 36);
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.btnEliminar.Location = new System.Drawing.Point(210, 9);
            this.btnEliminar.Size = new System.Drawing.Size(100, 36);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnAtendida
            // 
            this.btnAtendida.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnAtendida.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAtendida.FlatAppearance.BorderSize = 0;
            this.btnAtendida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtendida.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.btnAtendida.Location = new System.Drawing.Point(320, 9);
            this.btnAtendida.Size = new System.Drawing.Size(150, 36);
            this.btnAtendida.Text = "Marcar atendida";
            this.btnAtendida.UseVisualStyleBackColor = false;
            this.btnAtendida.TabIndex = 3;
            this.btnAtendida.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAtendida.Name = "btnAtendida";
            this.btnAtendida.Click += new System.EventHandler(this.btnAtendida_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.btnCancelar.Location = new System.Drawing.Point(480, 9);
            this.btnCancelar.Size = new System.Drawing.Size(130, 36);
            this.btnCancelar.Text = "Cancelar cita";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.btnActualizar.Location = new System.Drawing.Point(620, 9);
            this.btnActualizar.Size = new System.Drawing.Size(110, 36);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.TabIndex = 5;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Controls.Add(this.chkTodos);
            this.pnlFiltros.Controls.Add(this.cmbMedicos);
            this.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(20, 32, 60);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltros.Size = new System.Drawing.Size(1000, 48);
            this.pnlFiltros.TabIndex = 2;
            this.pnlFiltros.Name = "pnlFiltros";
            // 
            // chkTodos
            // 
            this.chkTodos.Checked = true;
            this.chkTodos.Location = new System.Drawing.Point(10, 10);
            this.chkTodos.Size = new System.Drawing.Size(65, 27);
            this.chkTodos.Text = "Todos";
            this.chkTodos.TabIndex = 0;
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.CheckedChanged += new System.EventHandler(this.chkTodos_CheckedChanged);
            // 
            // cmbMedicos
            // 
            this.cmbMedicos.BackColor = System.Drawing.Color.FromArgb(30, 50, 90);
            this.cmbMedicos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedicos.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.cmbMedicos.FormattingEnabled = true;
            this.cmbMedicos.Location = new System.Drawing.Point(85, 10);
            this.cmbMedicos.Size = new System.Drawing.Size(280, 28);
            this.cmbMedicos.TabIndex = 1;
            this.cmbMedicos.Name = "cmbMedicos";
            this.cmbMedicos.SelectedIndexChanged += new System.EventHandler(this.cmbMedicos_SelectedIndexChanged);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Size = new System.Drawing.Size(1000, 50);
            this.lblTitulo.Text = "Citas";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(41, 182, 246);
            this.lblTitulo.Name = "lblTitulo";
            // 
            // UcCitas
            // 
            this.Controls.Add(this.dgvCitas);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.lblTitulo);
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(10, 20, 40);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.Size = new System.Drawing.Size(1000, 600);
            this.Name = "UcCitas";
            this.Load += new System.EventHandler(this.UcCitas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCitas)).EndInit();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.pnlBotones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCitas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedico;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAtendida;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.CheckBox chkTodos;
        private System.Windows.Forms.ComboBox cmbMedicos;
        private System.Windows.Forms.Label lblTitulo;
    }
}
