namespace GestionClinica.UI.Controles
{
    partial class UcLogin
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
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.pnlLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLogin
            // 
            this.pnlLogin.Controls.Add(this.lblTitulo);
            this.pnlLogin.Controls.Add(this.lblUsuario);
            this.pnlLogin.Controls.Add(this.txtUsuario);
            this.pnlLogin.Controls.Add(this.lblClave);
            this.pnlLogin.Controls.Add(this.txtClave);
            this.pnlLogin.Controls.Add(this.btnIngresar);
            this.pnlLogin.Controls.Add(this.lblError);
            this.pnlLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlLogin.BackColor = System.Drawing.Color.FromArgb(20, 32, 60);
            this.pnlLogin.Location = new System.Drawing.Point(190, 70);
            this.pnlLogin.Size = new System.Drawing.Size(420, 360);
            this.pnlLogin.TabIndex = 0;
            this.pnlLogin.Name = "pnlLogin";
            // 
            // lblTitulo
            // 
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Size = new System.Drawing.Size(380, 50);
            this.lblTitulo.Text = "INGRESO AL SISTEMA";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(41, 182, 246);
            this.lblTitulo.Name = "lblTitulo";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Location = new System.Drawing.Point(20, 80);
            this.lblUsuario.Size = new System.Drawing.Size(380, 25);
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(120, 170, 230);
            this.lblUsuario.Name = "lblUsuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(30, 50, 90);
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.txtUsuario.Location = new System.Drawing.Point(20, 108);
            this.txtUsuario.Size = new System.Drawing.Size(380, 27);
            this.txtUsuario.TabIndex = 2;
            this.txtUsuario.Name = "txtUsuario";
            // 
            // lblClave
            // 
            this.lblClave.Location = new System.Drawing.Point(20, 150);
            this.lblClave.Size = new System.Drawing.Size(380, 25);
            this.lblClave.Text = "Clave";
            this.lblClave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblClave.TabIndex = 3;
            this.lblClave.ForeColor = System.Drawing.Color.FromArgb(120, 170, 230);
            this.lblClave.Name = "lblClave";
            // 
            // txtClave
            // 
            this.txtClave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtClave.BackColor = System.Drawing.Color.FromArgb(30, 50, 90);
            this.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClave.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.txtClave.Location = new System.Drawing.Point(20, 178);
            this.txtClave.Size = new System.Drawing.Size(380, 27);
            this.txtClave.UseSystemPasswordChar = true;
            this.txtClave.TabIndex = 4;
            this.txtClave.Name = "txtClave";
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.btnIngresar.Location = new System.Drawing.Point(20, 228);
            this.btnIngresar.Size = new System.Drawing.Size(380, 40);
            this.btnIngresar.Text = "INICIAR SESIÓN";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.TabIndex = 5;
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // lblError
            // 
            this.lblError.Location = new System.Drawing.Point(20, 278);
            this.lblError.Size = new System.Drawing.Size(380, 45);
            this.lblError.Text = "";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblError.TabIndex = 6;
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(120, 170, 230);
            this.lblError.Name = "lblError";
            // 
            // UcLogin
            // 
            this.Controls.Add(this.pnlLogin);
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(10, 20, 40);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(210, 230, 255);
            this.Size = new System.Drawing.Size(800, 500);
            this.Name = "UcLogin";
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label lblError;
    }
}
