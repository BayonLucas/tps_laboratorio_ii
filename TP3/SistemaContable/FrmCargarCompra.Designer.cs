﻿
namespace SistemaContable
{
    partial class FrmCargarCompra
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
            this.components = new System.ComponentModel.Container();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txtEmisor = new System.Windows.Forms.TextBox();
            this.txtCuitEmisor = new System.Windows.Forms.TextBox();
            this.lblCuitEmisor = new System.Windows.Forms.Label();
            this.lblSitFiscalEmisor = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtPtoVenta = new System.Windows.Forms.TextBox();
            this.txtNroComprobante = new System.Windows.Forms.TextBox();
            this.lblNroComprobante = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gpbEnte = new System.Windows.Forms.GroupBox();
            this.gpbDatosCompra = new System.Windows.Forms.GroupBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this.lblAlicuota = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblConcepto = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cmbAlicuota = new System.Windows.Forms.ComboBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.cmbConcepto = new System.Windows.Forms.ComboBox();
            this.btnCargar = new System.Windows.Forms.Button();
            this.gpbEnte.SuspendLayout();
            this.gpbDatosCompra.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 223);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(776, 215);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // txtEmisor
            // 
            this.txtEmisor.Location = new System.Drawing.Point(118, 20);
            this.txtEmisor.Name = "txtEmisor";
            this.txtEmisor.Size = new System.Drawing.Size(125, 27);
            this.txtEmisor.TabIndex = 2;
            // 
            // txtCuitEmisor
            // 
            this.txtCuitEmisor.Location = new System.Drawing.Point(343, 20);
            this.txtCuitEmisor.Name = "txtCuitEmisor";
            this.txtCuitEmisor.Size = new System.Drawing.Size(125, 27);
            this.txtCuitEmisor.TabIndex = 3;
            // 
            // lblCuitEmisor
            // 
            this.lblCuitEmisor.AutoSize = true;
            this.lblCuitEmisor.Location = new System.Drawing.Point(290, 23);
            this.lblCuitEmisor.Name = "lblCuitEmisor";
            this.lblCuitEmisor.Size = new System.Drawing.Size(47, 20);
            this.lblCuitEmisor.TabIndex = 6;
            this.lblCuitEmisor.Text = "CUIT: ";
            // 
            // lblSitFiscalEmisor
            // 
            this.lblSitFiscalEmisor.AutoSize = true;
            this.lblSitFiscalEmisor.Location = new System.Drawing.Point(491, 23);
            this.lblSitFiscalEmisor.Name = "lblSitFiscalEmisor";
            this.lblSitFiscalEmisor.Size = new System.Drawing.Size(117, 20);
            this.lblSitFiscalEmisor.TabIndex = 7;
            this.lblSitFiscalEmisor.Text = "Situación Fiscal: ";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 11);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(122, 27);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // txtPtoVenta
            // 
            this.txtPtoVenta.Location = new System.Drawing.Point(391, 15);
            this.txtPtoVenta.Name = "txtPtoVenta";
            this.txtPtoVenta.Size = new System.Drawing.Size(80, 27);
            this.txtPtoVenta.TabIndex = 10;
            // 
            // txtNroComprobante
            // 
            this.txtNroComprobante.Location = new System.Drawing.Point(477, 15);
            this.txtNroComprobante.Name = "txtNroComprobante";
            this.txtNroComprobante.Size = new System.Drawing.Size(125, 27);
            this.txtNroComprobante.TabIndex = 11;
            // 
            // lblNroComprobante
            // 
            this.lblNroComprobante.AutoSize = true;
            this.lblNroComprobante.Location = new System.Drawing.Point(249, 18);
            this.lblNroComprobante.Name = "lblNroComprobante";
            this.lblNroComprobante.Size = new System.Drawing.Size(136, 20);
            this.lblNroComprobante.TabIndex = 12;
            this.lblNroComprobante.Text = "Nro. Comprobante:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Razón Social:";
            // 
            // gpbEnte
            // 
            this.gpbEnte.Controls.Add(this.comboBox1);
            this.gpbEnte.Controls.Add(this.label1);
            this.gpbEnte.Controls.Add(this.txtEmisor);
            this.gpbEnte.Controls.Add(this.txtCuitEmisor);
            this.gpbEnte.Controls.Add(this.lblCuitEmisor);
            this.gpbEnte.Controls.Add(this.lblSitFiscalEmisor);
            this.gpbEnte.Location = new System.Drawing.Point(12, 48);
            this.gpbEnte.Name = "gpbEnte";
            this.gpbEnte.Size = new System.Drawing.Size(776, 63);
            this.gpbEnte.TabIndex = 17;
            this.gpbEnte.TabStop = false;
            this.gpbEnte.Text = "Ente";
            // 
            // gpbDatosCompra
            // 
            this.gpbDatosCompra.Controls.Add(this.cmbConcepto);
            this.gpbDatosCompra.Controls.Add(this.txtTotal);
            this.gpbDatosCompra.Controls.Add(this.cmbAlicuota);
            this.gpbDatosCompra.Controls.Add(this.txtImporte);
            this.gpbDatosCompra.Controls.Add(this.lblConcepto);
            this.gpbDatosCompra.Controls.Add(this.lblTotal);
            this.gpbDatosCompra.Controls.Add(this.lblAlicuota);
            this.gpbDatosCompra.Controls.Add(this.lblImporte);
            this.gpbDatosCompra.Location = new System.Drawing.Point(12, 118);
            this.gpbDatosCompra.Name = "gpbDatosCompra";
            this.gpbDatosCompra.Size = new System.Drawing.Size(776, 99);
            this.gpbDatosCompra.TabIndex = 18;
            this.gpbDatosCompra.TabStop = false;
            this.gpbDatosCompra.Text = "Datos Compra";
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Location = new System.Drawing.Point(15, 34);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(69, 20);
            this.lblImporte.TabIndex = 0;
            this.lblImporte.Text = "Importe: ";
            // 
            // lblAlicuota
            // 
            this.lblAlicuota.AutoSize = true;
            this.lblAlicuota.Location = new System.Drawing.Point(270, 34);
            this.lblAlicuota.Name = "lblAlicuota";
            this.lblAlicuota.Size = new System.Drawing.Size(67, 20);
            this.lblAlicuota.TabIndex = 1;
            this.lblAlicuota.Text = "Alicuota:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(465, 33);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(45, 20);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "Total:";
            // 
            // lblConcepto
            // 
            this.lblConcepto.AutoSize = true;
            this.lblConcepto.Location = new System.Drawing.Point(15, 68);
            this.lblConcepto.Name = "lblConcepto";
            this.lblConcepto.Size = new System.Drawing.Size(76, 20);
            this.lblConcepto.TabIndex = 3;
            this.lblConcepto.Text = "Concepto:";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(90, 31);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(125, 27);
            this.txtImporte.TabIndex = 4;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(614, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(151, 28);
            this.comboBox1.TabIndex = 14;
            // 
            // cmbAlicuota
            // 
            this.cmbAlicuota.FormattingEnabled = true;
            this.cmbAlicuota.Location = new System.Drawing.Point(343, 30);
            this.cmbAlicuota.Name = "cmbAlicuota";
            this.cmbAlicuota.Size = new System.Drawing.Size(74, 28);
            this.cmbAlicuota.TabIndex = 5;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(516, 30);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(125, 27);
            this.txtTotal.TabIndex = 6;
            // 
            // cmbConcepto
            // 
            this.cmbConcepto.FormattingEnabled = true;
            this.cmbConcepto.Location = new System.Drawing.Point(90, 68);
            this.cmbConcepto.Name = "cmbConcepto";
            this.cmbConcepto.Size = new System.Drawing.Size(151, 28);
            this.cmbConcepto.TabIndex = 7;
            // 
            // btnCargar
            // 
            this.btnCargar.Location = new System.Drawing.Point(683, 11);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(94, 29);
            this.btnCargar.TabIndex = 19;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = true;
            this.btnCargar.Visible = false;
            // 
            // FrmCargarCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.gpbDatosCompra);
            this.Controls.Add(this.gpbEnte);
            this.Controls.Add(this.lblNroComprobante);
            this.Controls.Add(this.txtNroComprobante);
            this.Controls.Add(this.txtPtoVenta);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "FrmCargarCompra";
            this.Text = "Cargar Compra";
            this.Load += new System.EventHandler(this.FrmCargarCompra_Load);
            this.gpbEnte.ResumeLayout(false);
            this.gpbEnte.PerformLayout();
            this.gpbDatosCompra.ResumeLayout(false);
            this.gpbDatosCompra.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox txtEmisor;
        private System.Windows.Forms.TextBox txtCuitEmisor;
        private System.Windows.Forms.Label lblCuitEmisor;
        private System.Windows.Forms.Label lblSitFiscalEmisor;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtPtoVenta;
        private System.Windows.Forms.TextBox txtNroComprobante;
        private System.Windows.Forms.Label lblNroComprobante;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gpbEnte;
        private System.Windows.Forms.GroupBox gpbDatosCompra;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label lblConcepto;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblAlicuota;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox cmbConcepto;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.ComboBox cmbAlicuota;
        private System.Windows.Forms.Button btnCargar;
    }
}