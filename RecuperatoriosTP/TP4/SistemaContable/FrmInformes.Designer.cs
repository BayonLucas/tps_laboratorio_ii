
namespace SistemaContable
{
    partial class FrmInformes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInformes));
            this.gpbCreditoDebitoFiscal = new System.Windows.Forms.GroupBox();
            this.lblAvisoEmergente = new System.Windows.Forms.Label();
            this.lblInforme = new System.Windows.Forms.Label();
            this.lblTotalSitFiscal = new System.Windows.Forms.Label();
            this.lblDebitoFsical = new System.Windows.Forms.Label();
            this.lblCreditoFiscal = new System.Windows.Forms.Label();
            this.lblAño = new System.Windows.Forms.Label();
            this.lblMes = new System.Windows.Forms.Label();
            this.nudAño = new System.Windows.Forms.NumericUpDown();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.chbMes = new System.Windows.Forms.CheckBox();
            this.picGif = new System.Windows.Forms.PictureBox();
            this.gpbGastos = new System.Windows.Forms.GroupBox();
            this.lstComprasPorConcepto = new System.Windows.Forms.ListBox();
            this.cmbConcepto = new System.Windows.Forms.ComboBox();
            this.lblVarios = new System.Windows.Forms.Label();
            this.prbVarios = new System.Windows.Forms.ProgressBar();
            this.prbBienDeConsumo = new System.Windows.Forms.ProgressBar();
            this.prbServicios = new System.Windows.Forms.ProgressBar();
            this.prbBienDeUso = new System.Windows.Forms.ProgressBar();
            this.lblBienDeConsumo = new System.Windows.Forms.Label();
            this.lblServicios = new System.Windows.Forms.Label();
            this.lblBienDeUso = new System.Windows.Forms.Label();
            this.gpbCreditoDebitoFiscal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAño)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGif)).BeginInit();
            this.gpbGastos.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbCreditoDebitoFiscal
            // 
            this.gpbCreditoDebitoFiscal.Controls.Add(this.lblAvisoEmergente);
            this.gpbCreditoDebitoFiscal.Controls.Add(this.lblInforme);
            this.gpbCreditoDebitoFiscal.Controls.Add(this.lblTotalSitFiscal);
            this.gpbCreditoDebitoFiscal.Controls.Add(this.lblDebitoFsical);
            this.gpbCreditoDebitoFiscal.Controls.Add(this.lblCreditoFiscal);
            this.gpbCreditoDebitoFiscal.Controls.Add(this.lblAño);
            this.gpbCreditoDebitoFiscal.Controls.Add(this.lblMes);
            this.gpbCreditoDebitoFiscal.Controls.Add(this.nudAño);
            this.gpbCreditoDebitoFiscal.Controls.Add(this.cmbMes);
            this.gpbCreditoDebitoFiscal.Controls.Add(this.chbMes);
            this.gpbCreditoDebitoFiscal.Location = new System.Drawing.Point(12, 12);
            this.gpbCreditoDebitoFiscal.Name = "gpbCreditoDebitoFiscal";
            this.gpbCreditoDebitoFiscal.Size = new System.Drawing.Size(1192, 220);
            this.gpbCreditoDebitoFiscal.TabIndex = 0;
            this.gpbCreditoDebitoFiscal.TabStop = false;
            this.gpbCreditoDebitoFiscal.Text = "Crédito/Débito Fiscal";
            // 
            // lblAvisoEmergente
            // 
            this.lblAvisoEmergente.AutoSize = true;
            this.lblAvisoEmergente.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblAvisoEmergente.ForeColor = System.Drawing.Color.Red;
            this.lblAvisoEmergente.Location = new System.Drawing.Point(648, 183);
            this.lblAvisoEmergente.Name = "lblAvisoEmergente";
            this.lblAvisoEmergente.Size = new System.Drawing.Size(232, 20);
            this.lblAvisoEmergente.TabIndex = 11;
            this.lblAvisoEmergente.Text = "*Debe regularizar su situación*";
            this.lblAvisoEmergente.Visible = false;
            // 
            // lblInforme
            // 
            this.lblInforme.AutoSize = true;
            this.lblInforme.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblInforme.Location = new System.Drawing.Point(404, 22);
            this.lblInforme.Name = "lblInforme";
            this.lblInforme.Size = new System.Drawing.Size(91, 28);
            this.lblInforme.TabIndex = 10;
            this.lblInforme.Text = "Informe:";
            // 
            // lblTotalSitFiscal
            // 
            this.lblTotalSitFiscal.AutoSize = true;
            this.lblTotalSitFiscal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalSitFiscal.Location = new System.Drawing.Point(439, 137);
            this.lblTotalSitFiscal.Name = "lblTotalSitFiscal";
            this.lblTotalSitFiscal.Size = new System.Drawing.Size(226, 23);
            this.lblTotalSitFiscal.TabIndex = 9;
            this.lblTotalSitFiscal.Text = "El total acumulado es de: $";
            // 
            // lblDebitoFsical
            // 
            this.lblDebitoFsical.AutoSize = true;
            this.lblDebitoFsical.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDebitoFsical.Location = new System.Drawing.Point(439, 93);
            this.lblDebitoFsical.Name = "lblDebitoFsical";
            this.lblDebitoFsical.Size = new System.Drawing.Size(543, 25);
            this.lblDebitoFsical.TabIndex = 8;
            this.lblDebitoFsical.Text = "El débito fiscal acumulado en el período seleccionado es de: $0";
            // 
            // lblCreditoFiscal
            // 
            this.lblCreditoFiscal.AutoSize = true;
            this.lblCreditoFiscal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCreditoFiscal.Location = new System.Drawing.Point(439, 59);
            this.lblCreditoFiscal.Name = "lblCreditoFiscal";
            this.lblCreditoFiscal.Size = new System.Drawing.Size(548, 25);
            this.lblCreditoFiscal.TabIndex = 7;
            this.lblCreditoFiscal.Text = "El crédito fiscal acumulado en el período seleccionado es de: $0";
            // 
            // lblAño
            // 
            this.lblAño.AutoSize = true;
            this.lblAño.Location = new System.Drawing.Point(31, 106);
            this.lblAño.Name = "lblAño";
            this.lblAño.Size = new System.Drawing.Size(36, 20);
            this.lblAño.TabIndex = 6;
            this.lblAño.Text = "Año";
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(31, 30);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(36, 20);
            this.lblMes.TabIndex = 5;
            this.lblMes.Text = "Mes";
            // 
            // nudAño
            // 
            this.nudAño.Location = new System.Drawing.Point(31, 137);
            this.nudAño.Name = "nudAño";
            this.nudAño.Size = new System.Drawing.Size(209, 27);
            this.nudAño.TabIndex = 3;
            this.nudAño.ValueChanged += new System.EventHandler(this.nudAño_ValueChanged);
            // 
            // cmbMes
            // 
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.Enabled = false;
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbMes.Location = new System.Drawing.Point(31, 59);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(209, 28);
            this.cmbMes.TabIndex = 2;
            this.cmbMes.SelectedValueChanged += new System.EventHandler(this.cmbMes_SelectedValueChanged);
            // 
            // chbMes
            // 
            this.chbMes.AutoSize = true;
            this.chbMes.Location = new System.Drawing.Point(7, 65);
            this.chbMes.Name = "chbMes";
            this.chbMes.Size = new System.Drawing.Size(18, 17);
            this.chbMes.TabIndex = 0;
            this.chbMes.UseVisualStyleBackColor = true;
            this.chbMes.CheckedChanged += new System.EventHandler(this.chbMes_CheckedChanged);
            // 
            // picGif
            // 
            this.picGif.Image = ((System.Drawing.Image)(resources.GetObject("picGif.Image")));
            this.picGif.Location = new System.Drawing.Point(-1, 0);
            this.picGif.Name = "picGif";
            this.picGif.Size = new System.Drawing.Size(1220, 565);
            this.picGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGif.TabIndex = 4;
            this.picGif.TabStop = false;
            // 
            // gpbGastos
            // 
            this.gpbGastos.Controls.Add(this.lstComprasPorConcepto);
            this.gpbGastos.Controls.Add(this.cmbConcepto);
            this.gpbGastos.Controls.Add(this.lblVarios);
            this.gpbGastos.Controls.Add(this.prbVarios);
            this.gpbGastos.Controls.Add(this.prbBienDeConsumo);
            this.gpbGastos.Controls.Add(this.prbServicios);
            this.gpbGastos.Controls.Add(this.prbBienDeUso);
            this.gpbGastos.Controls.Add(this.lblBienDeConsumo);
            this.gpbGastos.Controls.Add(this.lblServicios);
            this.gpbGastos.Controls.Add(this.lblBienDeUso);
            this.gpbGastos.Location = new System.Drawing.Point(12, 238);
            this.gpbGastos.Name = "gpbGastos";
            this.gpbGastos.Size = new System.Drawing.Size(1192, 333);
            this.gpbGastos.TabIndex = 2;
            this.gpbGastos.TabStop = false;
            this.gpbGastos.Text = "Informe de Gastos Anuales por conceptos ";
            // 
            // lstComprasPorConcepto
            // 
            this.lstComprasPorConcepto.Enabled = false;
            this.lstComprasPorConcepto.FormattingEnabled = true;
            this.lstComprasPorConcepto.ItemHeight = 20;
            this.lstComprasPorConcepto.Location = new System.Drawing.Point(275, 63);
            this.lstComprasPorConcepto.Name = "lstComprasPorConcepto";
            this.lstComprasPorConcepto.Size = new System.Drawing.Size(911, 244);
            this.lstComprasPorConcepto.TabIndex = 8;
            // 
            // cmbConcepto
            // 
            this.cmbConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConcepto.FormattingEnabled = true;
            this.cmbConcepto.Location = new System.Drawing.Point(359, 23);
            this.cmbConcepto.Name = "cmbConcepto";
            this.cmbConcepto.Size = new System.Drawing.Size(217, 28);
            this.cmbConcepto.TabIndex = 4;
            this.cmbConcepto.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.Cmbformat);
            this.cmbConcepto.SelectedValueChanged += new System.EventHandler(this.cmbConcepto_SelectedValueChanged);
            // 
            // lblVarios
            // 
            this.lblVarios.AutoSize = true;
            this.lblVarios.Location = new System.Drawing.Point(16, 251);
            this.lblVarios.Name = "lblVarios";
            this.lblVarios.Size = new System.Drawing.Size(49, 20);
            this.lblVarios.TabIndex = 7;
            this.lblVarios.Text = "Varios";
            // 
            // prbVarios
            // 
            this.prbVarios.Location = new System.Drawing.Point(16, 274);
            this.prbVarios.Name = "prbVarios";
            this.prbVarios.Size = new System.Drawing.Size(253, 29);
            this.prbVarios.TabIndex = 6;
            // 
            // prbBienDeConsumo
            // 
            this.prbBienDeConsumo.Location = new System.Drawing.Point(16, 202);
            this.prbBienDeConsumo.Name = "prbBienDeConsumo";
            this.prbBienDeConsumo.Size = new System.Drawing.Size(253, 29);
            this.prbBienDeConsumo.TabIndex = 5;
            // 
            // prbServicios
            // 
            this.prbServicios.Location = new System.Drawing.Point(16, 130);
            this.prbServicios.Name = "prbServicios";
            this.prbServicios.Size = new System.Drawing.Size(253, 29);
            this.prbServicios.TabIndex = 4;
            // 
            // prbBienDeUso
            // 
            this.prbBienDeUso.Location = new System.Drawing.Point(16, 63);
            this.prbBienDeUso.Name = "prbBienDeUso";
            this.prbBienDeUso.Size = new System.Drawing.Size(253, 29);
            this.prbBienDeUso.TabIndex = 3;
            // 
            // lblBienDeConsumo
            // 
            this.lblBienDeConsumo.AutoSize = true;
            this.lblBienDeConsumo.Location = new System.Drawing.Point(16, 179);
            this.lblBienDeConsumo.Name = "lblBienDeConsumo";
            this.lblBienDeConsumo.Size = new System.Drawing.Size(125, 20);
            this.lblBienDeConsumo.TabIndex = 2;
            this.lblBienDeConsumo.Text = "Bien de Consumo";
            // 
            // lblServicios
            // 
            this.lblServicios.AutoSize = true;
            this.lblServicios.Location = new System.Drawing.Point(16, 107);
            this.lblServicios.Name = "lblServicios";
            this.lblServicios.Size = new System.Drawing.Size(67, 20);
            this.lblServicios.TabIndex = 1;
            this.lblServicios.Text = "Servicios";
            // 
            // lblBienDeUso
            // 
            this.lblBienDeUso.AutoSize = true;
            this.lblBienDeUso.Location = new System.Drawing.Point(16, 40);
            this.lblBienDeUso.Name = "lblBienDeUso";
            this.lblBienDeUso.Size = new System.Drawing.Size(88, 20);
            this.lblBienDeUso.TabIndex = 0;
            this.lblBienDeUso.Text = "Bien de Uso";
            // 
            // FrmInformes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 553);
            this.Controls.Add(this.picGif);
            this.Controls.Add(this.gpbGastos);
            this.Controls.Add(this.gpbCreditoDebitoFiscal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInformes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Informes y Estadisticas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmInformes_FormClosing);
            this.Load += new System.EventHandler(this.FrmInformes_Load);
            this.gpbCreditoDebitoFiscal.ResumeLayout(false);
            this.gpbCreditoDebitoFiscal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAño)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGif)).EndInit();
            this.gpbGastos.ResumeLayout(false);
            this.gpbGastos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbCreditoDebitoFiscal;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.CheckBox chbMes;
        private System.Windows.Forms.NumericUpDown nudAño;
        private System.Windows.Forms.Label lblAño;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.Label lblTotalSitFiscal;
        private System.Windows.Forms.Label lblDebitoFsical;
        private System.Windows.Forms.Label lblCreditoFiscal;
        private System.Windows.Forms.GroupBox gpbGastos;
        private System.Windows.Forms.Label lblBienDeConsumo;
        private System.Windows.Forms.Label lblServicios;
        private System.Windows.Forms.Label lblBienDeUso;
        private System.Windows.Forms.Label lblVarios;
        private System.Windows.Forms.ProgressBar prbVarios;
        private System.Windows.Forms.ProgressBar prbBienDeConsumo;
        private System.Windows.Forms.ProgressBar prbServicios;
        private System.Windows.Forms.ProgressBar prbBienDeUso;
        private System.Windows.Forms.Label lblInforme;
        private System.Windows.Forms.ComboBox cmbConcepto;
        private System.Windows.Forms.ListBox lstComprasPorConcepto;
        private System.Windows.Forms.Label lblAvisoEmergente;
        private System.Windows.Forms.PictureBox picGif;
    }
}