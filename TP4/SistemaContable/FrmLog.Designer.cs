
namespace SistemaContable
{
    partial class FrmLog
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
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.cmbUsuarios = new System.Windows.Forms.ComboBox();
            this.chbNuevoUsuario = new System.Windows.Forms.CheckBox();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.cmbSitFiscal = new System.Windows.Forms.ComboBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.lblUsuarios = new System.Windows.Forms.Label();
            this.lblCuit = new System.Windows.Forms.Label();
            this.lblSitFiscal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Location = new System.Drawing.Point(13, 13);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(83, 20);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = "Bienvenido";
            // 
            // cmbUsuarios
            // 
            this.cmbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuarios.FormattingEnabled = true;
            this.cmbUsuarios.Location = new System.Drawing.Point(130, 51);
            this.cmbUsuarios.Name = "cmbUsuarios";
            this.cmbUsuarios.Size = new System.Drawing.Size(277, 28);
            this.cmbUsuarios.TabIndex = 1;
            this.cmbUsuarios.SelectedValueChanged += new System.EventHandler(this.cmbUsuarios_SelectedValueChanged);
            // 
            // chbNuevoUsuario
            // 
            this.chbNuevoUsuario.AutoSize = true;
            this.chbNuevoUsuario.Location = new System.Drawing.Point(301, 9);
            this.chbNuevoUsuario.Name = "chbNuevoUsuario";
            this.chbNuevoUsuario.Size = new System.Drawing.Size(128, 24);
            this.chbNuevoUsuario.TabIndex = 2;
            this.chbNuevoUsuario.Text = "Nuevo Usuario";
            this.chbNuevoUsuario.UseVisualStyleBackColor = true;
            this.chbNuevoUsuario.CheckedChanged += new System.EventHandler(this.chbNuevoUsuario_CheckedChanged);
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(130, 103);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(277, 27);
            this.txtRazonSocial.TabIndex = 3;
            // 
            // txtCuit
            // 
            this.txtCuit.Location = new System.Drawing.Point(130, 150);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(277, 27);
            this.txtCuit.TabIndex = 4;
            // 
            // cmbSitFiscal
            // 
            this.cmbSitFiscal.FormattingEnabled = true;
            this.cmbSitFiscal.Location = new System.Drawing.Point(130, 196);
            this.cmbSitFiscal.Name = "cmbSitFiscal";
            this.cmbSitFiscal.Size = new System.Drawing.Size(277, 28);
            this.cmbSitFiscal.TabIndex = 5;
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(144, 247);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(159, 51);
            this.btnIngresar.TabIndex = 6;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.AutoSize = true;
            this.lblRazonSocial.Location = new System.Drawing.Point(23, 110);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(101, 20);
            this.lblRazonSocial.TabIndex = 7;
            this.lblRazonSocial.Text = "Razón Social: ";
            // 
            // lblUsuarios
            // 
            this.lblUsuarios.AutoSize = true;
            this.lblUsuarios.Location = new System.Drawing.Point(64, 59);
            this.lblUsuarios.Name = "lblUsuarios";
            this.lblUsuarios.Size = new System.Drawing.Size(59, 20);
            this.lblUsuarios.TabIndex = 8;
            this.lblUsuarios.Text = "Usuario";
            // 
            // lblCuit
            // 
            this.lblCuit.AutoSize = true;
            this.lblCuit.Location = new System.Drawing.Point(76, 157);
            this.lblCuit.Name = "lblCuit";
            this.lblCuit.Size = new System.Drawing.Size(47, 20);
            this.lblCuit.TabIndex = 9;
            this.lblCuit.Text = "CUIT: ";
            // 
            // lblSitFiscal
            // 
            this.lblSitFiscal.AutoSize = true;
            this.lblSitFiscal.Location = new System.Drawing.Point(10, 204);
            this.lblSitFiscal.Name = "lblSitFiscal";
            this.lblSitFiscal.Size = new System.Drawing.Size(113, 20);
            this.lblSitFiscal.TabIndex = 10;
            this.lblSitFiscal.Text = "Situación Fiscal:";
            // 
            // Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 323);
            this.Controls.Add(this.lblSitFiscal);
            this.Controls.Add(this.lblCuit);
            this.Controls.Add(this.lblUsuarios);
            this.Controls.Add(this.lblRazonSocial);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.cmbSitFiscal);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.txtRazonSocial);
            this.Controls.Add(this.chbNuevoUsuario);
            this.Controls.Add(this.cmbUsuarios);
            this.Controls.Add(this.lblBienvenida);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Log";
            this.Text = "Registro Contable - Log";
            this.Load += new System.EventHandler(this.Log_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.ComboBox cmbUsuarios;
        private System.Windows.Forms.CheckBox chbNuevoUsuario;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.ComboBox cmbSitFiscal;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label lblRazonSocial;
        private System.Windows.Forms.Label lblUsuarios;
        private System.Windows.Forms.Label lblCuit;
        private System.Windows.Forms.Label lblSitFiscal;
    }
}