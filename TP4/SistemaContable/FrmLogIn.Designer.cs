
namespace SistemaContable
{
    partial class FrmLogIn
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.lblCUIT = new System.Windows.Forms.Label();
            this.lblStiFiscal = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.cmbSitFiscal = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblBienvenido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBienvenido.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBienvenido.Location = new System.Drawing.Point(12, 9);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(91, 20);
            this.lblBienvenido.TabIndex = 0;
            this.lblBienvenido.Text = "Bienvenido.";
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.AutoSize = true;
            this.lblRazonSocial.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblRazonSocial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRazonSocial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRazonSocial.Location = new System.Drawing.Point(68, 55);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(96, 20);
            this.lblRazonSocial.TabIndex = 1;
            this.lblRazonSocial.Text = "Razon Social";
            // 
            // lblCUIT
            // 
            this.lblCUIT.AutoSize = true;
            this.lblCUIT.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblCUIT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCUIT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCUIT.Location = new System.Drawing.Point(121, 88);
            this.lblCUIT.Name = "lblCUIT";
            this.lblCUIT.Size = new System.Drawing.Size(43, 20);
            this.lblCUIT.TabIndex = 2;
            this.lblCUIT.Text = "CUIT";
            // 
            // lblStiFiscal
            // 
            this.lblStiFiscal.AutoSize = true;
            this.lblStiFiscal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblStiFiscal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStiFiscal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStiFiscal.Location = new System.Drawing.Point(49, 121);
            this.lblStiFiscal.Name = "lblStiFiscal";
            this.lblStiFiscal.Size = new System.Drawing.Size(115, 20);
            this.lblStiFiscal.TabIndex = 3;
            this.lblStiFiscal.Text = "Situación Fiscal";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(170, 52);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(253, 27);
            this.txtRazonSocial.TabIndex = 1;
            // 
            // txtCuit
            // 
            this.txtCuit.Location = new System.Drawing.Point(170, 85);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(253, 27);
            this.txtCuit.TabIndex = 2;
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(205, 160);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(94, 29);
            this.btnIngresar.TabIndex = 4;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // cmbSitFiscal
            // 
            this.cmbSitFiscal.FormattingEnabled = true;
            this.cmbSitFiscal.Location = new System.Drawing.Point(170, 118);
            this.cmbSitFiscal.Name = "cmbSitFiscal";
            this.cmbSitFiscal.Size = new System.Drawing.Size(253, 28);
            this.cmbSitFiscal.TabIndex = 3;
            // 
            // FrmLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(482, 203);
            this.Controls.Add(this.cmbSitFiscal);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.txtRazonSocial);
            this.Controls.Add(this.lblStiFiscal);
            this.Controls.Add(this.lblCUIT);
            this.Controls.Add(this.lblRazonSocial);
            this.Controls.Add(this.lblBienvenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio Sesión";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.Label lblRazonSocial;
        private System.Windows.Forms.Label lblCUIT;
        private System.Windows.Forms.Label lblStiFiscal;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.ComboBox cmbSitFiscal;
    }
}

