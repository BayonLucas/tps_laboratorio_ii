
namespace SistemaContable
{
    partial class FrmVentas
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
            this.lblRazonSocialUsuario = new System.Windows.Forms.Label();
            this.lblCuitUsuario = new System.Windows.Forms.Label();
            this.lblSitFiscalUsuario = new System.Windows.Forms.Label();
            this.btnEmitir = new System.Windows.Forms.Button();
            this.txtPtoVenta = new System.Windows.Forms.TextBox();
            this.txtNroComprobante = new System.Windows.Forms.TextBox();
            this.lblRazonSocialReceptor = new System.Windows.Forms.Label();
            this.lblCuitReceptor = new System.Windows.Forms.Label();
            this.lblSitFiscal = new System.Windows.Forms.Label();
            this.txtRazonSocialReceptor = new System.Windows.Forms.TextBox();
            this.txtCuitReceptor = new System.Windows.Forms.TextBox();
            this.cmbSitFiscalReceptor = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblImporte = new System.Windows.Forms.Label();
            this.lblAlicuota = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.cmbAlicuota = new System.Windows.Forms.ComboBox();
            this.btnAnular = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.lblNroComprobante = new System.Windows.Forms.Label();
            this.lstListaVentas = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblRazonSocialUsuario
            // 
            this.lblRazonSocialUsuario.AutoSize = true;
            this.lblRazonSocialUsuario.Font = new System.Drawing.Font("Segoe UI", 25F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.lblRazonSocialUsuario.Location = new System.Drawing.Point(13, 13);
            this.lblRazonSocialUsuario.Name = "lblRazonSocialUsuario";
            this.lblRazonSocialUsuario.Size = new System.Drawing.Size(415, 57);
            this.lblRazonSocialUsuario.TabIndex = 0;
            this.lblRazonSocialUsuario.Text = "RazonSocialUsuario";
            // 
            // lblCuitUsuario
            // 
            this.lblCuitUsuario.AutoSize = true;
            this.lblCuitUsuario.Location = new System.Drawing.Point(13, 70);
            this.lblCuitUsuario.Name = "lblCuitUsuario";
            this.lblCuitUsuario.Size = new System.Drawing.Size(135, 20);
            this.lblCuitUsuario.TabIndex = 1;
            this.lblCuitUsuario.Text = "CUIT: 99999999999";
            // 
            // lblSitFiscalUsuario
            // 
            this.lblSitFiscalUsuario.AutoSize = true;
            this.lblSitFiscalUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSitFiscalUsuario.Location = new System.Drawing.Point(165, 70);
            this.lblSitFiscalUsuario.Name = "lblSitFiscalUsuario";
            this.lblSitFiscalUsuario.Size = new System.Drawing.Size(180, 20);
            this.lblSitFiscalUsuario.TabIndex = 2;
            this.lblSitFiscalUsuario.Text = "Situación Fiscal: xxxxxxxxx";
            // 
            // btnEmitir
            // 
            this.btnEmitir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmitir.Location = new System.Drawing.Point(1037, 13);
            this.btnEmitir.Name = "btnEmitir";
            this.btnEmitir.Size = new System.Drawing.Size(132, 50);
            this.btnEmitir.TabIndex = 3;
            this.btnEmitir.Text = "Emitir";
            this.btnEmitir.UseVisualStyleBackColor = true;
            this.btnEmitir.Click += new System.EventHandler(this.btnEmitir_Click);
            // 
            // txtPtoVenta
            // 
            this.txtPtoVenta.Enabled = false;
            this.txtPtoVenta.Location = new System.Drawing.Point(658, 56);
            this.txtPtoVenta.Name = "txtPtoVenta";
            this.txtPtoVenta.Size = new System.Drawing.Size(92, 27);
            this.txtPtoVenta.TabIndex = 5;
            this.txtPtoVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNroComprobante
            // 
            this.txtNroComprobante.Enabled = false;
            this.txtNroComprobante.Location = new System.Drawing.Point(756, 56);
            this.txtNroComprobante.Name = "txtNroComprobante";
            this.txtNroComprobante.Size = new System.Drawing.Size(134, 27);
            this.txtNroComprobante.TabIndex = 6;
            this.txtNroComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRazonSocialReceptor
            // 
            this.lblRazonSocialReceptor.AutoSize = true;
            this.lblRazonSocialReceptor.Location = new System.Drawing.Point(13, 127);
            this.lblRazonSocialReceptor.Name = "lblRazonSocialReceptor";
            this.lblRazonSocialReceptor.Size = new System.Drawing.Size(97, 20);
            this.lblRazonSocialReceptor.TabIndex = 7;
            this.lblRazonSocialReceptor.Text = "Razón Social:";
            // 
            // lblCuitReceptor
            // 
            this.lblCuitReceptor.AutoSize = true;
            this.lblCuitReceptor.Location = new System.Drawing.Point(314, 127);
            this.lblCuitReceptor.Name = "lblCuitReceptor";
            this.lblCuitReceptor.Size = new System.Drawing.Size(47, 20);
            this.lblCuitReceptor.TabIndex = 8;
            this.lblCuitReceptor.Text = "CUIT: ";
            // 
            // lblSitFiscal
            // 
            this.lblSitFiscal.AutoSize = true;
            this.lblSitFiscal.Location = new System.Drawing.Point(566, 127);
            this.lblSitFiscal.Name = "lblSitFiscal";
            this.lblSitFiscal.Size = new System.Drawing.Size(117, 20);
            this.lblSitFiscal.TabIndex = 9;
            this.lblSitFiscal.Text = "Situación Fiscal: ";
            // 
            // txtRazonSocialReceptor
            // 
            this.txtRazonSocialReceptor.Location = new System.Drawing.Point(116, 120);
            this.txtRazonSocialReceptor.Name = "txtRazonSocialReceptor";
            this.txtRazonSocialReceptor.Size = new System.Drawing.Size(167, 27);
            this.txtRazonSocialReceptor.TabIndex = 10;
            // 
            // txtCuitReceptor
            // 
            this.txtCuitReceptor.Location = new System.Drawing.Point(367, 120);
            this.txtCuitReceptor.Name = "txtCuitReceptor";
            this.txtCuitReceptor.Size = new System.Drawing.Size(148, 27);
            this.txtCuitReceptor.TabIndex = 11;
            // 
            // cmbSitFiscalReceptor
            // 
            this.cmbSitFiscalReceptor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSitFiscalReceptor.FormattingEnabled = true;
            this.cmbSitFiscalReceptor.Location = new System.Drawing.Point(689, 119);
            this.cmbSitFiscalReceptor.Name = "cmbSitFiscalReceptor";
            this.cmbSitFiscalReceptor.Size = new System.Drawing.Size(161, 28);
            this.cmbSitFiscalReceptor.TabIndex = 12;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(516, 13);
            this.dtpFecha.MinDate = new System.DateTime(2021, 11, 20, 0, 0, 0, 0);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(125, 27);
            this.dtpFecha.TabIndex = 13;
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Location = new System.Drawing.Point(85, 193);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(65, 20);
            this.lblImporte.TabIndex = 14;
            this.lblImporte.Text = "Importe:";
            // 
            // lblAlicuota
            // 
            this.lblAlicuota.AutoSize = true;
            this.lblAlicuota.Location = new System.Drawing.Point(289, 193);
            this.lblAlicuota.Name = "lblAlicuota";
            this.lblAlicuota.Size = new System.Drawing.Size(71, 20);
            this.lblAlicuota.TabIndex = 15;
            this.lblAlicuota.Text = "Alicuota: ";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(516, 193);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(49, 20);
            this.lblTotal.TabIndex = 16;
            this.lblTotal.Text = "Total: ";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(85, 217);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(147, 27);
            this.txtImporte.TabIndex = 17;
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(516, 216);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(156, 27);
            this.txtTotal.TabIndex = 18;
            // 
            // cmbAlicuota
            // 
            this.cmbAlicuota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlicuota.FormattingEnabled = true;
            this.cmbAlicuota.Location = new System.Drawing.Point(289, 217);
            this.cmbAlicuota.Name = "cmbAlicuota";
            this.cmbAlicuota.Size = new System.Drawing.Size(151, 28);
            this.cmbAlicuota.TabIndex = 19;
            this.cmbAlicuota.SelectedIndexChanged += new System.EventHandler(this.cmbAlicuota_SelectedIndexChanged);
            this.cmbAlicuota.SelectedValueChanged += new System.EventHandler(this.cmbAlicuota_SelectedValueChanged);
            // 
            // btnAnular
            // 
            this.btnAnular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnular.Location = new System.Drawing.Point(1037, 12);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(132, 51);
            this.btnAnular.TabIndex = 20;
            this.btnAnular.Text = "Anular";
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(997, 70);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(207, 20);
            this.lblError.TabIndex = 21;
            this.lblError.Text = "*Complete todos los campos*";
            // 
            // lblNroComprobante
            // 
            this.lblNroComprobante.AutoSize = true;
            this.lblNroComprobante.Location = new System.Drawing.Point(516, 63);
            this.lblNroComprobante.Name = "lblNroComprobante";
            this.lblNroComprobante.Size = new System.Drawing.Size(136, 20);
            this.lblNroComprobante.TabIndex = 22;
            this.lblNroComprobante.Text = "Nro. Comprobante:";
            // 
            // lstListaVentas
            // 
            this.lstListaVentas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstListaVentas.FormattingEnabled = true;
            this.lstListaVentas.ItemHeight = 20;
            this.lstListaVentas.Location = new System.Drawing.Point(12, 282);
            this.lstListaVentas.Name = "lstListaVentas";
            this.lstListaVentas.Size = new System.Drawing.Size(1192, 284);
            this.lstListaVentas.TabIndex = 23;
            // 
            // FrmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1216, 583);
            this.Controls.Add(this.lstListaVentas);
            this.Controls.Add(this.lblNroComprobante);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.cmbAlicuota);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblAlicuota);
            this.Controls.Add(this.lblImporte);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.cmbSitFiscalReceptor);
            this.Controls.Add(this.txtCuitReceptor);
            this.Controls.Add(this.txtRazonSocialReceptor);
            this.Controls.Add(this.lblSitFiscal);
            this.Controls.Add(this.lblCuitReceptor);
            this.Controls.Add(this.lblRazonSocialReceptor);
            this.Controls.Add(this.txtNroComprobante);
            this.Controls.Add(this.txtPtoVenta);
            this.Controls.Add(this.btnEmitir);
            this.Controls.Add(this.lblSitFiscalUsuario);
            this.Controls.Add(this.lblCuitUsuario);
            this.Controls.Add(this.lblRazonSocialUsuario);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVentas";
            this.Text = "Ventas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmVentas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRazonSocialUsuario;
        private System.Windows.Forms.Label lblCuitUsuario;
        private System.Windows.Forms.Label lblSitFiscalUsuario;
        private System.Windows.Forms.Button btnEmitir;
        private System.Windows.Forms.TextBox txtPtoVenta;
        private System.Windows.Forms.TextBox txtNroComprobante;
        private System.Windows.Forms.Label lblRazonSocialReceptor;
        private System.Windows.Forms.Label lblCuitReceptor;
        private System.Windows.Forms.Label lblSitFiscal;
        private System.Windows.Forms.TextBox txtRazonSocialReceptor;
        private System.Windows.Forms.TextBox txtCuitReceptor;
        private System.Windows.Forms.ComboBox cmbSitFiscalReceptor;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Label lblAlicuota;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.ComboBox cmbAlicuota;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblNroComprobante;
        private System.Windows.Forms.ListBox lstListaVentas;
    }
}