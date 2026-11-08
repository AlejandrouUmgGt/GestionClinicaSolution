namespace GestionClinica.UI
{
    partial class FrmPrincipal
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
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.flowMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTituloMenu = new System.Windows.Forms.Label();
            this.btnInicio = new System.Windows.Forms.Button();
            this.lblInfoBase = new System.Windows.Forms.Label();
            this.btnClinica = new System.Windows.Forms.Button();
            this.btnMedicos = new System.Windows.Forms.Button();
            this.btnPacientes = new System.Windows.Forms.Button();
            this.lblMovimientos = new System.Windows.Forms.Label();
            this.btnCitas = new System.Windows.Forms.Button();
            this.btnTratamientos = new System.Windows.Forms.Button();
            this.btnExpediente = new System.Windows.Forms.Button();
            this.lblConsultas = new System.Windows.Forms.Label();
            this.btnReportes = new System.Windows.Forms.Button();
            this.pnlBarra = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.lblTituloBarra = new System.Windows.Forms.Label();
            this.pnlContenedor.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.flowMenu.SuspendLayout();
            this.pnlBarra.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackColor = System.Drawing.Color.FromArgb(10, 20, 40);
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(0, 0);
            this.pnlContenedor.Padding = new System.Windows.Forms.Padding(16);
            this.pnlContenedor.Size = new System.Drawing.Size(980, 600);
            this.pnlContenedor.TabIndex = 0;
            this.pnlContenedor.Name = "pnlContenedor";
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.flowMenu);
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(20, 32, 60);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Size = new System.Drawing.Size(250, 600);
            this.pnlMenu.TabIndex = 1;
            this.pnlMenu.Name = "pnlMenu";
            // 
            // flowMenu
            // 
            this.flowMenu.Controls.Add(this.lblTituloMenu);
            this.flowMenu.Controls.Add(this.btnInicio);
            this.flowMenu.Controls.Add(this.lblInfoBase);
            this.flowMenu.Controls.Add(this.btnClinica);
            this.flowMenu.Controls.Add(this.btnMedicos);
            this.flowMenu.Controls.Add(this.btnPacientes);
            this.flowMenu.Controls.Add(this.lblMovimientos);
            this.flowMenu.Controls.Add(this.btnCitas);
            this.flowMenu.Controls.Add(this.btnTratamientos);
            this.flowMenu.Controls.Add(this.btnExpediente);
            this.flowMenu.Controls.Add(this.lblConsultas);
            this.flowMenu.Controls.Add(this.btnReportes);
            this.flowMenu.AutoScroll = true;
            this.flowMenu.BackColor = System.Drawing.Color.FromArgb(20, 32, 60);
            this.flowMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowMenu.Location = new System.Drawing.Point(0, 0);
            this.flowMenu.Size = new System.Drawing.Size(250, 600);
            this.flowMenu.WrapContents = false;
            this.flowMenu.TabIndex = 0;
            this.flowMenu.Name = "flowMenu";
            // 
            // lblTituloMenu
            // 
            this.lblTituloMenu.Size = new System.Drawing.Size(222, 58);
            this.lblTituloMenu.Text = "GESTIÓN CLÍNICA";
            this.lblTituloMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTituloMenu.TabIndex = 0;
            this.lblTituloMenu.ForeColor = System.Drawing.Color.FromArgb(41, 182, 246);
            this.lblTituloMenu.Name = "lblTituloMenu";
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.btnInicio.Size = new System.Drawing.Size(222, 44);
            this.btnInicio.Text = "Inicio";
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.TabIndex = 1;
            this.btnInicio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // lblInfoBase
            // 
            this.lblInfoBase.Size = new System.Drawing.Size(222, 34);
            this.lblInfoBase.Text = "Información base";
            this.lblInfoBase.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblInfoBase.TabIndex = 2;
            this.lblInfoBase.ForeColor = System.Drawing.Color.FromArgb(120, 170, 230);
            this.lblInfoBase.Name = "lblInfoBase";
            // 
            // btnClinica
            // 
            this.btnClinica.BackColor = System.Drawing.Color.FromArgb(25, 45, 85);
            this.btnClinica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClinica.FlatAppearance.BorderSize = 0;
            this.btnClinica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClinica.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.btnClinica.Size = new System.Drawing.Size(222, 44);
            this.btnClinica.Text = "Clínica";
            this.btnClinica.UseVisualStyleBackColor = false;
            this.btnClinica.TabIndex = 3;
            this.btnClinica.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClinica.Name = "btnClinica";
            this.btnClinica.Click += new System.EventHandler(this.btnClinica_Click);
            // 
            // btnMedicos
            // 
            this.btnMedicos.BackColor = System.Drawing.Color.FromArgb(25, 45, 85);
            this.btnMedicos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMedicos.FlatAppearance.BorderSize = 0;
            this.btnMedicos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedicos.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.btnMedicos.Size = new System.Drawing.Size(222, 44);
            this.btnMedicos.Text = "Médicos";
            this.btnMedicos.UseVisualStyleBackColor = false;
            this.btnMedicos.TabIndex = 4;
            this.btnMedicos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMedicos.Name = "btnMedicos";
            this.btnMedicos.Click += new System.EventHandler(this.btnMedicos_Click);
            // 
            // btnPacientes
            // 
            this.btnPacientes.BackColor = System.Drawing.Color.FromArgb(25, 45, 85);
            this.btnPacientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPacientes.FlatAppearance.BorderSize = 0;
            this.btnPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacientes.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.btnPacientes.Size = new System.Drawing.Size(222, 44);
            this.btnPacientes.Text = "Pacientes";
            this.btnPacientes.UseVisualStyleBackColor = false;
            this.btnPacientes.TabIndex = 5;
            this.btnPacientes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            // 
            // lblMovimientos
            // 
            this.lblMovimientos.Size = new System.Drawing.Size(222, 34);
            this.lblMovimientos.Text = "Movimientos";
            this.lblMovimientos.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblMovimientos.TabIndex = 6;
            this.lblMovimientos.ForeColor = System.Drawing.Color.FromArgb(120, 170, 230);
            this.lblMovimientos.Name = "lblMovimientos";
            // 
            // btnCitas
            // 
            this.btnCitas.BackColor = System.Drawing.Color.FromArgb(25, 45, 85);
            this.btnCitas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCitas.FlatAppearance.BorderSize = 0;
            this.btnCitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCitas.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.btnCitas.Size = new System.Drawing.Size(222, 44);
            this.btnCitas.Text = "Citas";
            this.btnCitas.UseVisualStyleBackColor = false;
            this.btnCitas.TabIndex = 7;
            this.btnCitas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCitas.Name = "btnCitas";
            this.btnCitas.Click += new System.EventHandler(this.btnCitas_Click);
            // 
            // btnTratamientos
            // 
            this.btnTratamientos.BackColor = System.Drawing.Color.FromArgb(25, 45, 85);
            this.btnTratamientos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTratamientos.FlatAppearance.BorderSize = 0;
            this.btnTratamientos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTratamientos.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.btnTratamientos.Size = new System.Drawing.Size(222, 44);
            this.btnTratamientos.Text = "Tratamientos";
            this.btnTratamientos.UseVisualStyleBackColor = false;
            this.btnTratamientos.TabIndex = 8;
            this.btnTratamientos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTratamientos.Name = "btnTratamientos";
            this.btnTratamientos.Click += new System.EventHandler(this.btnTratamientos_Click);
            // 
            // btnExpediente
            // 
            this.btnExpediente.BackColor = System.Drawing.Color.FromArgb(25, 45, 85);
            this.btnExpediente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExpediente.FlatAppearance.BorderSize = 0;
            this.btnExpediente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpediente.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.btnExpediente.Size = new System.Drawing.Size(222, 44);
            this.btnExpediente.Text = "Expediente";
            this.btnExpediente.UseVisualStyleBackColor = false;
            this.btnExpediente.TabIndex = 9;
            this.btnExpediente.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExpediente.Name = "btnExpediente";
            this.btnExpediente.Click += new System.EventHandler(this.btnExpediente_Click);
            // 
            // lblConsultas
            // 
            this.lblConsultas.Size = new System.Drawing.Size(222, 34);
            this.lblConsultas.Text = "Consultas y reportes";
            this.lblConsultas.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblConsultas.TabIndex = 10;
            this.lblConsultas.ForeColor = System.Drawing.Color.FromArgb(120, 170, 230);
            this.lblConsultas.Name = "lblConsultas";
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.FromArgb(25, 45, 85);
            this.btnReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.btnReportes.Size = new System.Drawing.Size(222, 44);
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.TabIndex = 11;
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // pnlBarra
            // 
            this.pnlBarra.Controls.Add(this.lblUsuario);
            this.pnlBarra.Controls.Add(this.btnCerrarSesion);
            this.pnlBarra.Controls.Add(this.lblTituloBarra);
            this.pnlBarra.BackColor = System.Drawing.Color.FromArgb(20, 32, 60);
            this.pnlBarra.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarra.Location = new System.Drawing.Point(0, 0);
            this.pnlBarra.Size = new System.Drawing.Size(1200, 60);
            this.pnlBarra.TabIndex = 2;
            this.pnlBarra.Name = "pnlBarra";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUsuario.Size = new System.Drawing.Size(500, 60);
            this.lblUsuario.Text = "";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(120, 170, 230);
            this.lblUsuario.Name = "lblUsuario";
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(78, 91, 119);
            this.btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarSesion.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.btnCerrarSesion.Size = new System.Drawing.Size(140, 60);
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.TabIndex = 1;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // lblTituloBarra
            // 
            this.lblTituloBarra.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTituloBarra.Size = new System.Drawing.Size(420, 60);
            this.lblTituloBarra.Text = "SISTEMA DE GESTIÓN CLÍNICA";
            this.lblTituloBarra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTituloBarra.TabIndex = 2;
            this.lblTituloBarra.ForeColor = System.Drawing.Color.FromArgb(41, 182, 246);
            this.lblTituloBarra.Name = "lblTituloBarra";
            // 
            // FrmPrincipal
            // 
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlBarra);
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(10, 20, 40);
            this.ClientSize = new System.Drawing.Size(1200, 660);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Clínica Médica";
            this.Name = "FrmPrincipal";
            this.pnlBarra.ResumeLayout(false);
            this.pnlBarra.PerformLayout();
            this.flowMenu.ResumeLayout(false);
            this.flowMenu.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.pnlContenedor.ResumeLayout(false);
            this.pnlContenedor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.FlowLayoutPanel flowMenu;
        private System.Windows.Forms.Label lblTituloMenu;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Label lblInfoBase;
        private System.Windows.Forms.Button btnClinica;
        private System.Windows.Forms.Button btnMedicos;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Label lblMovimientos;
        private System.Windows.Forms.Button btnCitas;
        private System.Windows.Forms.Button btnTratamientos;
        private System.Windows.Forms.Button btnExpediente;
        private System.Windows.Forms.Label lblConsultas;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Panel pnlBarra;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Label lblTituloBarra;
    }
}
