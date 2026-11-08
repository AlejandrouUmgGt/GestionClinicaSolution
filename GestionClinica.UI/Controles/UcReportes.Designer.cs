namespace GestionClinica.UI.Controles
{
    partial class UcReportes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabReportes = new System.Windows.Forms.TabControl();
            this.tabMedico = new System.Windows.Forms.TabPage();
            this.dgvMedico = new System.Windows.Forms.DataGridView();
            this.lblMedico = new System.Windows.Forms.Label();
            this.pnlFiltrosMedico = new System.Windows.Forms.Panel();
            this.chkTodosMedicos = new System.Windows.Forms.CheckBox();
            this.cmbMedico = new System.Windows.Forms.ComboBox();
            this.btnCitasMedico = new System.Windows.Forms.Button();
            this.tabPaciente = new System.Windows.Forms.TabPage();
            this.dgvPaciente = new System.Windows.Forms.DataGridView();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.pnlFiltrosPaciente = new System.Windows.Forms.Panel();
            this.chkTodosPacientes = new System.Windows.Forms.CheckBox();
            this.cmbPaciente = new System.Windows.Forms.ComboBox();
            this.btnCitasPaciente = new System.Windows.Forms.Button();
            this.tabTratamientos = new System.Windows.Forms.TabPage();
            this.dgvTratamientos = new System.Windows.Forms.DataGridView();
            this.lblTratamientos = new System.Windows.Forms.Label();
            this.tabHistorial = new System.Windows.Forms.TabPage();
            this.txtHistorial = new System.Windows.Forms.TextBox();
            this.lblHistorial = new System.Windows.Forms.Label();
            this.pnlFiltrosHistorial = new System.Windows.Forms.Panel();
            this.lblPacienteHistorial = new System.Windows.Forms.Label();
            this.cmbHistorial = new System.Windows.Forms.ComboBox();
            this.tabDirectorio = new System.Windows.Forms.TabPage();
            this.tblDirectorio = new System.Windows.Forms.TableLayoutPanel();
            this.lblDirectorio = new System.Windows.Forms.Label();
            this.dgvDirectorio = new System.Windows.Forms.DataGridView();
            this.colDirRol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDirResumen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblResumibles = new System.Windows.Forms.Label();
            this.dgvResumibles = new System.Windows.Forms.DataGridView();
            this.colResTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResResumen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotalDirectorio = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaciente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTratamientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirectorio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumibles)).BeginInit();
            this.tabReportes.SuspendLayout();
            this.tabMedico.SuspendLayout();
            this.pnlFiltrosMedico.SuspendLayout();
            this.tabPaciente.SuspendLayout();
            this.pnlFiltrosPaciente.SuspendLayout();
            this.tabTratamientos.SuspendLayout();
            this.tabHistorial.SuspendLayout();
            this.pnlFiltrosHistorial.SuspendLayout();
            this.tabDirectorio.SuspendLayout();
            this.tblDirectorio.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabReportes
            // 
            this.tabReportes.Controls.Add(this.tabMedico);
            this.tabReportes.Controls.Add(this.tabPaciente);
            this.tabReportes.Controls.Add(this.tabTratamientos);
            this.tabReportes.Controls.Add(this.tabHistorial);
            this.tabReportes.Controls.Add(this.tabDirectorio);
            this.tabReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabReportes.Location = new System.Drawing.Point(0, 50);
            this.tabReportes.SelectedIndex = 0;
            this.tabReportes.Size = new System.Drawing.Size(1000, 550);
            this.tabReportes.TabIndex = 0;
            this.tabReportes.Name = "tabReportes";
            // 
            // tabMedico
            // 
            this.tabMedico.Controls.Add(this.dgvMedico);
            this.tabMedico.Controls.Add(this.lblMedico);
            this.tabMedico.Controls.Add(this.pnlFiltrosMedico);
            this.tabMedico.BackColor = System.Drawing.Color.FromArgb(20, 32, 60);
            this.tabMedico.Location = new System.Drawing.Point(4, 29);
            this.tabMedico.Padding = new System.Windows.Forms.Padding(3);
            this.tabMedico.Size = new System.Drawing.Size(992, 467);
            this.tabMedico.Text = "Citas por médico";
            this.tabMedico.UseVisualStyleBackColor = false;
            this.tabMedico.TabIndex = 0;
            this.tabMedico.Name = "tabMedico";
            // 
            // dgvMedico
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(10, 20, 40);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.dgvMedico.AllowUserToAddRows = false;
            this.dgvMedico.AllowUserToDeleteRows = false;
            this.dgvMedico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedico.BackgroundColor = System.Drawing.Color.FromArgb(20, 32, 60);
            this.dgvMedico.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMedico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedico.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMedico.EnableHeadersVisualStyles = false;
            this.dgvMedico.MultiSelect = false;
            this.dgvMedico.ReadOnly = true;
            this.dgvMedico.RowHeadersVisible = false;
            this.dgvMedico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMedico.Location = new System.Drawing.Point(0, 0);
            this.dgvMedico.Size = new System.Drawing.Size(800, 300);
            this.dgvMedico.TabIndex = 0;
            this.dgvMedico.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMedico.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(26, 54, 108);
            this.dgvMedico.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvMedico.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 50, 90);
            this.dgvMedico.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.dgvMedico.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.dgvMedico.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvMedico.Name = "dgvMedico";
            // 
            // lblMedico
            // 
            this.lblMedico.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMedico.Size = new System.Drawing.Size(986, 28);
            this.lblMedico.Text = "Total de filas: 0";
            this.lblMedico.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMedico.TabIndex = 1;
            this.lblMedico.ForeColor = System.Drawing.Color.FromArgb(120, 170, 230);
            this.lblMedico.Name = "lblMedico";
            // 
            // pnlFiltrosMedico
            // 
            this.pnlFiltrosMedico.Controls.Add(this.chkTodosMedicos);
            this.pnlFiltrosMedico.Controls.Add(this.cmbMedico);
            this.pnlFiltrosMedico.Controls.Add(this.btnCitasMedico);
            this.pnlFiltrosMedico.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltrosMedico.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltrosMedico.Size = new System.Drawing.Size(986, 48);
            this.pnlFiltrosMedico.TabIndex = 2;
            this.pnlFiltrosMedico.Name = "pnlFiltrosMedico";
            // 
            // chkTodosMedicos
            // 
            this.chkTodosMedicos.Checked = true;
            this.chkTodosMedicos.Location = new System.Drawing.Point(10, 10);
            this.chkTodosMedicos.Size = new System.Drawing.Size(65, 27);
            this.chkTodosMedicos.Text = "Todos";
            this.chkTodosMedicos.TabIndex = 0;
            this.chkTodosMedicos.Name = "chkTodosMedicos";
            // 
            // cmbMedico
            // 
            this.cmbMedico.BackColor = System.Drawing.Color.FromArgb(30, 50, 90);
            this.cmbMedico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedico.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.cmbMedico.FormattingEnabled = true;
            this.cmbMedico.Location = new System.Drawing.Point(85, 10);
            this.cmbMedico.Size = new System.Drawing.Size(260, 28);
            this.cmbMedico.TabIndex = 1;
            this.cmbMedico.Name = "cmbMedico";
            // 
            // btnCitasMedico
            // 
            this.btnCitasMedico.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnCitasMedico.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCitasMedico.FlatAppearance.BorderSize = 0;
            this.btnCitasMedico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCitasMedico.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.btnCitasMedico.Location = new System.Drawing.Point(355, 6);
            this.btnCitasMedico.Size = new System.Drawing.Size(110, 36);
            this.btnCitasMedico.Text = "Generar";
            this.btnCitasMedico.UseVisualStyleBackColor = false;
            this.btnCitasMedico.TabIndex = 2;
            this.btnCitasMedico.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCitasMedico.Name = "btnCitasMedico";
            this.btnCitasMedico.Click += new System.EventHandler(this.btnCitasMedico_Click);
            // 
            // tabPaciente
            // 
            this.tabPaciente.Controls.Add(this.dgvPaciente);
            this.tabPaciente.Controls.Add(this.lblPaciente);
            this.tabPaciente.Controls.Add(this.pnlFiltrosPaciente);
            this.tabPaciente.BackColor = System.Drawing.Color.FromArgb(20, 32, 60);
            this.tabPaciente.Location = new System.Drawing.Point(4, 29);
            this.tabPaciente.Padding = new System.Windows.Forms.Padding(3);
            this.tabPaciente.Size = new System.Drawing.Size(992, 467);
            this.tabPaciente.Text = "Citas por paciente";
            this.tabPaciente.UseVisualStyleBackColor = false;
            this.tabPaciente.TabIndex = 1;
            this.tabPaciente.Name = "tabPaciente";
            // 
            // dgvPaciente
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(10, 20, 40);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.dgvPaciente.AllowUserToAddRows = false;
            this.dgvPaciente.AllowUserToDeleteRows = false;
            this.dgvPaciente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPaciente.BackgroundColor = System.Drawing.Color.FromArgb(20, 32, 60);
            this.dgvPaciente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPaciente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaciente.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPaciente.EnableHeadersVisualStyles = false;
            this.dgvPaciente.MultiSelect = false;
            this.dgvPaciente.ReadOnly = true;
            this.dgvPaciente.RowHeadersVisible = false;
            this.dgvPaciente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPaciente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPaciente.Location = new System.Drawing.Point(0, 0);
            this.dgvPaciente.Size = new System.Drawing.Size(800, 300);
            this.dgvPaciente.TabIndex = 0;
            this.dgvPaciente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPaciente.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(26, 54, 108);
            this.dgvPaciente.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvPaciente.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 50, 90);
            this.dgvPaciente.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.dgvPaciente.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.dgvPaciente.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvPaciente.Name = "dgvPaciente";
            // 
            // lblPaciente
            // 
            this.lblPaciente.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPaciente.Size = new System.Drawing.Size(986, 28);
            this.lblPaciente.Text = "Total de filas: 0";
            this.lblPaciente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPaciente.TabIndex = 1;
            this.lblPaciente.ForeColor = System.Drawing.Color.FromArgb(120, 170, 230);
            this.lblPaciente.Name = "lblPaciente";
            // 
            // pnlFiltrosPaciente
            // 
            this.pnlFiltrosPaciente.Controls.Add(this.chkTodosPacientes);
            this.pnlFiltrosPaciente.Controls.Add(this.cmbPaciente);
            this.pnlFiltrosPaciente.Controls.Add(this.btnCitasPaciente);
            this.pnlFiltrosPaciente.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltrosPaciente.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltrosPaciente.Size = new System.Drawing.Size(986, 48);
            this.pnlFiltrosPaciente.TabIndex = 2;
            this.pnlFiltrosPaciente.Name = "pnlFiltrosPaciente";
            // 
            // chkTodosPacientes
            // 
            this.chkTodosPacientes.Checked = true;
            this.chkTodosPacientes.Location = new System.Drawing.Point(10, 10);
            this.chkTodosPacientes.Size = new System.Drawing.Size(65, 27);
            this.chkTodosPacientes.Text = "Todos";
            this.chkTodosPacientes.TabIndex = 0;
            this.chkTodosPacientes.Name = "chkTodosPacientes";
            // 
            // cmbPaciente
            // 
            this.cmbPaciente.BackColor = System.Drawing.Color.FromArgb(30, 50, 90);
            this.cmbPaciente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaciente.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.cmbPaciente.FormattingEnabled = true;
            this.cmbPaciente.Location = new System.Drawing.Point(85, 10);
            this.cmbPaciente.Size = new System.Drawing.Size(260, 28);
            this.cmbPaciente.TabIndex = 1;
            this.cmbPaciente.Name = "cmbPaciente";
            // 
            // btnCitasPaciente
            // 
            this.btnCitasPaciente.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnCitasPaciente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCitasPaciente.FlatAppearance.BorderSize = 0;
            this.btnCitasPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCitasPaciente.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.btnCitasPaciente.Location = new System.Drawing.Point(355, 6);
            this.btnCitasPaciente.Size = new System.Drawing.Size(110, 36);
            this.btnCitasPaciente.Text = "Generar";
            this.btnCitasPaciente.UseVisualStyleBackColor = false;
            this.btnCitasPaciente.TabIndex = 2;
            this.btnCitasPaciente.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCitasPaciente.Name = "btnCitasPaciente";
            this.btnCitasPaciente.Click += new System.EventHandler(this.btnCitasPaciente_Click);
            // 
            // tabTratamientos
            // 
            this.tabTratamientos.Controls.Add(this.dgvTratamientos);
            this.tabTratamientos.Controls.Add(this.lblTratamientos);
            this.tabTratamientos.BackColor = System.Drawing.Color.FromArgb(20, 32, 60);
            this.tabTratamientos.Location = new System.Drawing.Point(4, 29);
            this.tabTratamientos.Padding = new System.Windows.Forms.Padding(3);
            this.tabTratamientos.Size = new System.Drawing.Size(992, 467);
            this.tabTratamientos.Text = "Tratamientos realizados";
            this.tabTratamientos.UseVisualStyleBackColor = false;
            this.tabTratamientos.TabIndex = 2;
            this.tabTratamientos.Name = "tabTratamientos";
            // 
            // dgvTratamientos
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(10, 20, 40);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.dgvTratamientos.AllowUserToAddRows = false;
            this.dgvTratamientos.AllowUserToDeleteRows = false;
            this.dgvTratamientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTratamientos.BackgroundColor = System.Drawing.Color.FromArgb(20, 32, 60);
            this.dgvTratamientos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTratamientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTratamientos.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTratamientos.EnableHeadersVisualStyles = false;
            this.dgvTratamientos.MultiSelect = false;
            this.dgvTratamientos.ReadOnly = true;
            this.dgvTratamientos.RowHeadersVisible = false;
            this.dgvTratamientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTratamientos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTratamientos.Location = new System.Drawing.Point(0, 0);
            this.dgvTratamientos.Size = new System.Drawing.Size(800, 300);
            this.dgvTratamientos.TabIndex = 0;
            this.dgvTratamientos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTratamientos.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(26, 54, 108);
            this.dgvTratamientos.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTratamientos.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 50, 90);
            this.dgvTratamientos.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.dgvTratamientos.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.dgvTratamientos.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvTratamientos.Name = "dgvTratamientos";
            // 
            // lblTratamientos
            // 
            this.lblTratamientos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTratamientos.Size = new System.Drawing.Size(986, 28);
            this.lblTratamientos.Text = "Total de filas: 0";
            this.lblTratamientos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTratamientos.TabIndex = 1;
            this.lblTratamientos.ForeColor = System.Drawing.Color.FromArgb(120, 170, 230);
            this.lblTratamientos.Name = "lblTratamientos";
            // 
            // tabHistorial
            // 
            this.tabHistorial.Controls.Add(this.txtHistorial);
            this.tabHistorial.Controls.Add(this.lblHistorial);
            this.tabHistorial.Controls.Add(this.pnlFiltrosHistorial);
            this.tabHistorial.BackColor = System.Drawing.Color.FromArgb(20, 32, 60);
            this.tabHistorial.Location = new System.Drawing.Point(4, 29);
            this.tabHistorial.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistorial.Size = new System.Drawing.Size(992, 467);
            this.tabHistorial.Text = "Historial médico";
            this.tabHistorial.UseVisualStyleBackColor = false;
            this.tabHistorial.TabIndex = 3;
            this.tabHistorial.Name = "tabHistorial";
            // 
            // txtHistorial
            // 
            this.txtHistorial.BackColor = System.Drawing.Color.FromArgb(30, 50, 90);
            this.txtHistorial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHistorial.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHistorial.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.txtHistorial.Multiline = true;
            this.txtHistorial.ReadOnly = true;
            this.txtHistorial.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtHistorial.Size = new System.Drawing.Size(986, 300);
            this.txtHistorial.TabIndex = 0;
            this.txtHistorial.Name = "txtHistorial";
            // 
            // lblHistorial
            // 
            this.lblHistorial.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblHistorial.Size = new System.Drawing.Size(986, 28);
            this.lblHistorial.Text = "Total de filas: 0";
            this.lblHistorial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHistorial.TabIndex = 1;
            this.lblHistorial.ForeColor = System.Drawing.Color.FromArgb(120, 170, 230);
            this.lblHistorial.Name = "lblHistorial";
            // 
            // pnlFiltrosHistorial
            // 
            this.pnlFiltrosHistorial.Controls.Add(this.lblPacienteHistorial);
            this.pnlFiltrosHistorial.Controls.Add(this.cmbHistorial);
            this.pnlFiltrosHistorial.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltrosHistorial.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltrosHistorial.Size = new System.Drawing.Size(986, 48);
            this.pnlFiltrosHistorial.TabIndex = 2;
            this.pnlFiltrosHistorial.Name = "pnlFiltrosHistorial";
            // 
            // lblPacienteHistorial
            // 
            this.lblPacienteHistorial.Location = new System.Drawing.Point(10, 10);
            this.lblPacienteHistorial.Size = new System.Drawing.Size(70, 27);
            this.lblPacienteHistorial.Text = "Paciente";
            this.lblPacienteHistorial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPacienteHistorial.TabIndex = 0;
            this.lblPacienteHistorial.ForeColor = System.Drawing.Color.FromArgb(120, 170, 230);
            this.lblPacienteHistorial.Name = "lblPacienteHistorial";
            // 
            // cmbHistorial
            // 
            this.cmbHistorial.BackColor = System.Drawing.Color.FromArgb(30, 50, 90);
            this.cmbHistorial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHistorial.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.cmbHistorial.FormattingEnabled = true;
            this.cmbHistorial.Location = new System.Drawing.Point(85, 10);
            this.cmbHistorial.Size = new System.Drawing.Size(280, 28);
            this.cmbHistorial.TabIndex = 1;
            this.cmbHistorial.Name = "cmbHistorial";
            this.cmbHistorial.SelectedIndexChanged += new System.EventHandler(this.cmbHistorial_SelectedIndexChanged);
            // 
            // tabDirectorio
            // 
            this.tabDirectorio.Controls.Add(this.tblDirectorio);
            this.tabDirectorio.BackColor = System.Drawing.Color.FromArgb(20, 32, 60);
            this.tabDirectorio.Location = new System.Drawing.Point(4, 29);
            this.tabDirectorio.Padding = new System.Windows.Forms.Padding(3);
            this.tabDirectorio.Size = new System.Drawing.Size(992, 467);
            this.tabDirectorio.Text = "Directorio y polimorfismo";
            this.tabDirectorio.UseVisualStyleBackColor = false;
            this.tabDirectorio.TabIndex = 4;
            this.tabDirectorio.Name = "tabDirectorio";
            // 
            // tblDirectorio
            // 
            this.tblDirectorio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblDirectorio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tblDirectorio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.tblDirectorio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tblDirectorio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.tblDirectorio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tblDirectorio.Controls.Add(this.lblDirectorio, 0, 0);
            this.tblDirectorio.Controls.Add(this.dgvDirectorio, 0, 1);
            this.tblDirectorio.Controls.Add(this.lblResumibles, 0, 2);
            this.tblDirectorio.Controls.Add(this.dgvResumibles, 0, 3);
            this.tblDirectorio.Controls.Add(this.lblTotalDirectorio, 0, 4);
            this.tblDirectorio.ColumnCount = 1;
            this.tblDirectorio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblDirectorio.Location = new System.Drawing.Point(3, 3);
            this.tblDirectorio.RowCount = 5;
            this.tblDirectorio.Size = new System.Drawing.Size(986, 461);
            this.tblDirectorio.TabIndex = 0;
            this.tblDirectorio.Name = "tblDirectorio";
            // 
            // lblDirectorio
            // 
            this.lblDirectorio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDirectorio.Size = new System.Drawing.Size(100, 28);
            this.lblDirectorio.Text = "Directorio de personas (clase base Persona)";
            this.lblDirectorio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDirectorio.TabIndex = 0;
            this.lblDirectorio.ForeColor = System.Drawing.Color.FromArgb(120, 170, 230);
            this.lblDirectorio.Name = "lblDirectorio";
            // 
            // dgvDirectorio
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(10, 20, 40);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.dgvDirectorio.AllowUserToAddRows = false;
            this.dgvDirectorio.AllowUserToDeleteRows = false;
            this.dgvDirectorio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDirectorio.BackgroundColor = System.Drawing.Color.FromArgb(20, 32, 60);
            this.dgvDirectorio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDirectorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDirectorio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDirRol,
            this.colDirResumen});
            this.dgvDirectorio.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDirectorio.EnableHeadersVisualStyles = false;
            this.dgvDirectorio.MultiSelect = false;
            this.dgvDirectorio.ReadOnly = true;
            this.dgvDirectorio.RowHeadersVisible = false;
            this.dgvDirectorio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDirectorio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDirectorio.Location = new System.Drawing.Point(3, 31);
            this.dgvDirectorio.Size = new System.Drawing.Size(980, 180);
            this.dgvDirectorio.TabIndex = 1;
            this.dgvDirectorio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDirectorio.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(26, 54, 108);
            this.dgvDirectorio.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvDirectorio.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 50, 90);
            this.dgvDirectorio.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.dgvDirectorio.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.dgvDirectorio.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDirectorio.Name = "dgvDirectorio";
            // 
            // colDirRol
            // 
            this.colDirRol.HeaderText = "Rol";
            this.colDirRol.Name = "colDirRol";
            this.colDirRol.ReadOnly = true;
            // 
            // colDirResumen
            // 
            this.colDirResumen.HeaderText = "Resumen";
            this.colDirResumen.Name = "colDirResumen";
            this.colDirResumen.ReadOnly = true;
            // 
            // lblResumibles
            // 
            this.lblResumibles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResumibles.Size = new System.Drawing.Size(100, 28);
            this.lblResumibles.Text = "Lista de objetos IResumible";
            this.lblResumibles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblResumibles.TabIndex = 2;
            this.lblResumibles.ForeColor = System.Drawing.Color.FromArgb(120, 170, 230);
            this.lblResumibles.Name = "lblResumibles";
            // 
            // dgvResumibles
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(10, 20, 40);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.dgvResumibles.AllowUserToAddRows = false;
            this.dgvResumibles.AllowUserToDeleteRows = false;
            this.dgvResumibles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResumibles.BackgroundColor = System.Drawing.Color.FromArgb(20, 32, 60);
            this.dgvResumibles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvResumibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResumibles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colResTipo,
            this.colResResumen});
            this.dgvResumibles.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvResumibles.EnableHeadersVisualStyles = false;
            this.dgvResumibles.MultiSelect = false;
            this.dgvResumibles.ReadOnly = true;
            this.dgvResumibles.RowHeadersVisible = false;
            this.dgvResumibles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResumibles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResumibles.Location = new System.Drawing.Point(3, 31);
            this.dgvResumibles.Size = new System.Drawing.Size(980, 180);
            this.dgvResumibles.TabIndex = 3;
            this.dgvResumibles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResumibles.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(26, 54, 108);
            this.dgvResumibles.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvResumibles.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 50, 90);
            this.dgvResumibles.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.dgvResumibles.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.dgvResumibles.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvResumibles.Name = "dgvResumibles";
            // 
            // colResTipo
            // 
            this.colResTipo.HeaderText = "Objeto";
            this.colResTipo.Name = "colResTipo";
            this.colResTipo.ReadOnly = true;
            // 
            // colResResumen
            // 
            this.colResResumen.HeaderText = "Resumen de interfaz";
            this.colResResumen.Name = "colResResumen";
            this.colResResumen.ReadOnly = true;
            // 
            // lblTotalDirectorio
            // 
            this.lblTotalDirectorio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalDirectorio.Size = new System.Drawing.Size(100, 28);
            this.lblTotalDirectorio.Text = "Total de filas: 0";
            this.lblTotalDirectorio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotalDirectorio.TabIndex = 4;
            this.lblTotalDirectorio.ForeColor = System.Drawing.Color.FromArgb(120, 170, 230);
            this.lblTotalDirectorio.Name = "lblTotalDirectorio";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Size = new System.Drawing.Size(1000, 50);
            this.lblTitulo.Text = "Consultas y reportes";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(41, 182, 246);
            this.lblTitulo.Name = "lblTitulo";
            // 
            // UcReportes
            // 
            this.Controls.Add(this.tabReportes);
            this.Controls.Add(this.lblTitulo);
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(10, 20, 40);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.Size = new System.Drawing.Size(1000, 600);
            this.Name = "UcReportes";
            this.Load += new System.EventHandler(this.UcReportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaciente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTratamientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirectorio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResumibles)).EndInit();
            this.tblDirectorio.ResumeLayout(false);
            this.tblDirectorio.PerformLayout();
            this.tabDirectorio.ResumeLayout(false);
            this.tabDirectorio.PerformLayout();
            this.pnlFiltrosHistorial.ResumeLayout(false);
            this.pnlFiltrosHistorial.PerformLayout();
            this.tabHistorial.ResumeLayout(false);
            this.tabHistorial.PerformLayout();
            this.tabTratamientos.ResumeLayout(false);
            this.tabTratamientos.PerformLayout();
            this.pnlFiltrosPaciente.ResumeLayout(false);
            this.pnlFiltrosPaciente.PerformLayout();
            this.tabPaciente.ResumeLayout(false);
            this.tabPaciente.PerformLayout();
            this.pnlFiltrosMedico.ResumeLayout(false);
            this.pnlFiltrosMedico.PerformLayout();
            this.tabMedico.ResumeLayout(false);
            this.tabMedico.PerformLayout();
            this.tabReportes.ResumeLayout(false);
            this.tabReportes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TabControl tabReportes;
        private System.Windows.Forms.TabPage tabMedico;
        private System.Windows.Forms.DataGridView dgvMedico;
        private System.Windows.Forms.Label lblMedico;
        private System.Windows.Forms.Panel pnlFiltrosMedico;
        private System.Windows.Forms.CheckBox chkTodosMedicos;
        private System.Windows.Forms.ComboBox cmbMedico;
        private System.Windows.Forms.Button btnCitasMedico;
        private System.Windows.Forms.TabPage tabPaciente;
        private System.Windows.Forms.DataGridView dgvPaciente;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.Panel pnlFiltrosPaciente;
        private System.Windows.Forms.CheckBox chkTodosPacientes;
        private System.Windows.Forms.ComboBox cmbPaciente;
        private System.Windows.Forms.Button btnCitasPaciente;
        private System.Windows.Forms.TabPage tabTratamientos;
        private System.Windows.Forms.DataGridView dgvTratamientos;
        private System.Windows.Forms.Label lblTratamientos;
        private System.Windows.Forms.TabPage tabHistorial;
        private System.Windows.Forms.TextBox txtHistorial;
        private System.Windows.Forms.Label lblHistorial;
        private System.Windows.Forms.Panel pnlFiltrosHistorial;
        private System.Windows.Forms.Label lblPacienteHistorial;
        private System.Windows.Forms.ComboBox cmbHistorial;
        private System.Windows.Forms.TabPage tabDirectorio;
        private System.Windows.Forms.TableLayoutPanel tblDirectorio;
        private System.Windows.Forms.Label lblDirectorio;
        private System.Windows.Forms.DataGridView dgvDirectorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDirRol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDirResumen;
        private System.Windows.Forms.Label lblResumibles;
        private System.Windows.Forms.DataGridView dgvResumibles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResResumen;
        private System.Windows.Forms.Label lblTotalDirectorio;
        private System.Windows.Forms.Label lblTitulo;
    }
}
