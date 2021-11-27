
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
            this.gpbCreditoDebitoFiscal = new System.Windows.Forms.GroupBox();
            this.lblTotalSitFiscal = new System.Windows.Forms.Label();
            this.lblDebitoFsical = new System.Windows.Forms.Label();
            this.lblCreditoFiscal = new System.Windows.Forms.Label();
            this.lblAño = new System.Windows.Forms.Label();
            this.lblMes = new System.Windows.Forms.Label();
            this.nudAño = new System.Windows.Forms.NumericUpDown();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.chbMes = new System.Windows.Forms.CheckBox();
            this.btnInformarAFIP = new System.Windows.Forms.Button();
            this.gpbConsumos = new System.Windows.Forms.GroupBox();
            this.lblBienDeConsumo = new System.Windows.Forms.Label();
            this.lblServicios = new System.Windows.Forms.Label();
            this.lblBienDeUso = new System.Windows.Forms.Label();
            this.prbBienDeUso = new System.Windows.Forms.ProgressBar();
            this.prbServicios = new System.Windows.Forms.ProgressBar();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.lblVarios = new System.Windows.Forms.Label();
            this.lvlInforme = new System.Windows.Forms.Label();
            this.rtbComprasConceptos = new System.Windows.Forms.RichTextBox();
            this.cmbConcepto = new System.Windows.Forms.ComboBox();
            this.gpbCreditoDebitoFiscal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAño)).BeginInit();
            this.gpbConsumos.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbCreditoDebitoFiscal
            // 
            this.gpbCreditoDebitoFiscal.Controls.Add(this.lvlInforme);
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
            this.gpbCreditoDebitoFiscal.Size = new System.Drawing.Size(921, 220);
            this.gpbCreditoDebitoFiscal.TabIndex = 0;
            this.gpbCreditoDebitoFiscal.TabStop = false;
            this.gpbCreditoDebitoFiscal.Text = "Crédito/Débito Fiscal";
            // 
            // lblTotalSitFiscal
            // 
            this.lblTotalSitFiscal.AutoSize = true;
            this.lblTotalSitFiscal.Location = new System.Drawing.Point(320, 158);
            this.lblTotalSitFiscal.Name = "lblTotalSitFiscal";
            this.lblTotalSitFiscal.Size = new System.Drawing.Size(103, 20);
            this.lblTotalSitFiscal.TabIndex = 9;
            this.lblTotalSitFiscal.Text = "Total Sit Fiscal";
            // 
            // lblDebitoFsical
            // 
            this.lblDebitoFsical.AutoSize = true;
            this.lblDebitoFsical.Location = new System.Drawing.Point(320, 106);
            this.lblDebitoFsical.Name = "lblDebitoFsical";
            this.lblDebitoFsical.Size = new System.Drawing.Size(95, 20);
            this.lblDebitoFsical.TabIndex = 8;
            this.lblDebitoFsical.Text = "Debito Fiscal";
            // 
            // lblCreditoFiscal
            // 
            this.lblCreditoFiscal.AutoSize = true;
            this.lblCreditoFiscal.Location = new System.Drawing.Point(320, 59);
            this.lblCreditoFiscal.Name = "lblCreditoFiscal";
            this.lblCreditoFiscal.Size = new System.Drawing.Size(98, 20);
            this.lblCreditoFiscal.TabIndex = 7;
            this.lblCreditoFiscal.Text = "Credito Fiscal";
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
            this.nudAño.Enabled = false;
            this.nudAño.Location = new System.Drawing.Point(31, 137);
            this.nudAño.Name = "nudAño";
            this.nudAño.Size = new System.Drawing.Size(209, 27);
            this.nudAño.TabIndex = 3;
            // 
            // cmbMes
            // 
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.Enabled = false;
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.cmbMes.Location = new System.Drawing.Point(31, 59);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(209, 28);
            this.cmbMes.TabIndex = 2;
            // 
            // chbMes
            // 
            this.chbMes.AutoSize = true;
            this.chbMes.Location = new System.Drawing.Point(7, 65);
            this.chbMes.Name = "chbMes";
            this.chbMes.Size = new System.Drawing.Size(18, 17);
            this.chbMes.TabIndex = 0;
            this.chbMes.UseVisualStyleBackColor = true;
            // 
            // btnInformarAFIP
            // 
            this.btnInformarAFIP.Location = new System.Drawing.Point(951, 21);
            this.btnInformarAFIP.Name = "btnInformarAFIP";
            this.btnInformarAFIP.Size = new System.Drawing.Size(253, 78);
            this.btnInformarAFIP.TabIndex = 1;
            this.btnInformarAFIP.Text = "Informar AFIP";
            this.btnInformarAFIP.UseVisualStyleBackColor = true;
            // 
            // gpbConsumos
            // 
            this.gpbConsumos.Controls.Add(this.cmbConcepto);
            this.gpbConsumos.Controls.Add(this.lblVarios);
            this.gpbConsumos.Controls.Add(this.rtbComprasConceptos);
            this.gpbConsumos.Controls.Add(this.progressBar2);
            this.gpbConsumos.Controls.Add(this.progressBar1);
            this.gpbConsumos.Controls.Add(this.prbServicios);
            this.gpbConsumos.Controls.Add(this.prbBienDeUso);
            this.gpbConsumos.Controls.Add(this.lblBienDeConsumo);
            this.gpbConsumos.Controls.Add(this.lblServicios);
            this.gpbConsumos.Controls.Add(this.lblBienDeUso);
            this.gpbConsumos.Location = new System.Drawing.Point(12, 238);
            this.gpbConsumos.Name = "gpbConsumos";
            this.gpbConsumos.Size = new System.Drawing.Size(921, 333);
            this.gpbConsumos.TabIndex = 2;
            this.gpbConsumos.TabStop = false;
            this.gpbConsumos.Text = "Informe de Gastos por conceptos por año";
            // 
            // lblBienDeConsumo
            // 
            this.lblBienDeConsumo.AutoSize = true;
            this.lblBienDeConsumo.Location = new System.Drawing.Point(22, 179);
            this.lblBienDeConsumo.Name = "lblBienDeConsumo";
            this.lblBienDeConsumo.Size = new System.Drawing.Size(125, 20);
            this.lblBienDeConsumo.TabIndex = 2;
            this.lblBienDeConsumo.Text = "Bien de Consumo";
            // 
            // lblServicios
            // 
            this.lblServicios.AutoSize = true;
            this.lblServicios.Location = new System.Drawing.Point(22, 107);
            this.lblServicios.Name = "lblServicios";
            this.lblServicios.Size = new System.Drawing.Size(67, 20);
            this.lblServicios.TabIndex = 1;
            this.lblServicios.Text = "Servicios";
            // 
            // lblBienDeUso
            // 
            this.lblBienDeUso.AutoSize = true;
            this.lblBienDeUso.Location = new System.Drawing.Point(22, 40);
            this.lblBienDeUso.Name = "lblBienDeUso";
            this.lblBienDeUso.Size = new System.Drawing.Size(88, 20);
            this.lblBienDeUso.TabIndex = 0;
            this.lblBienDeUso.Text = "Bien de Uso";
            // 
            // prbBienDeUso
            // 
            this.prbBienDeUso.Location = new System.Drawing.Point(22, 63);
            this.prbBienDeUso.Name = "prbBienDeUso";
            this.prbBienDeUso.Size = new System.Drawing.Size(253, 29);
            this.prbBienDeUso.TabIndex = 3;
            // 
            // prbServicios
            // 
            this.prbServicios.Location = new System.Drawing.Point(22, 130);
            this.prbServicios.Name = "prbServicios";
            this.prbServicios.Size = new System.Drawing.Size(253, 29);
            this.prbServicios.TabIndex = 4;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(22, 202);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(253, 29);
            this.progressBar1.TabIndex = 5;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(22, 274);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(253, 29);
            this.progressBar2.TabIndex = 6;
            // 
            // lblVarios
            // 
            this.lblVarios.AutoSize = true;
            this.lblVarios.Location = new System.Drawing.Point(22, 251);
            this.lblVarios.Name = "lblVarios";
            this.lblVarios.Size = new System.Drawing.Size(49, 20);
            this.lblVarios.TabIndex = 7;
            this.lblVarios.Text = "Varios";
            // 
            // lvlInforme
            // 
            this.lvlInforme.AutoSize = true;
            this.lvlInforme.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lvlInforme.Location = new System.Drawing.Point(320, 30);
            this.lvlInforme.Name = "lvlInforme";
            this.lvlInforme.Size = new System.Drawing.Size(70, 20);
            this.lvlInforme.TabIndex = 10;
            this.lvlInforme.Text = "Informe:";
            // 
            // rtbComprasConceptos
            // 
            this.rtbComprasConceptos.Enabled = false;
            this.rtbComprasConceptos.Location = new System.Drawing.Point(281, 57);
            this.rtbComprasConceptos.Name = "rtbComprasConceptos";
            this.rtbComprasConceptos.Size = new System.Drawing.Size(634, 270);
            this.rtbComprasConceptos.TabIndex = 3;
            this.rtbComprasConceptos.Text = "";
            // 
            // cmbConcepto
            // 
            this.cmbConcepto.FormattingEnabled = true;
            this.cmbConcepto.Location = new System.Drawing.Point(359, 23);
            this.cmbConcepto.Name = "cmbConcepto";
            this.cmbConcepto.Size = new System.Drawing.Size(217, 28);
            this.cmbConcepto.TabIndex = 4;
            // 
            // FrmInformes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 583);
            this.Controls.Add(this.gpbConsumos);
            this.Controls.Add(this.btnInformarAFIP);
            this.Controls.Add(this.gpbCreditoDebitoFiscal);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInformes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Informes y Estadisticas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmInformes_Load);
            this.gpbCreditoDebitoFiscal.ResumeLayout(false);
            this.gpbCreditoDebitoFiscal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAño)).EndInit();
            this.gpbConsumos.ResumeLayout(false);
            this.gpbConsumos.PerformLayout();
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
        private System.Windows.Forms.Button btnInformarAFIP;
        private System.Windows.Forms.GroupBox gpbConsumos;
        private System.Windows.Forms.Label lblBienDeConsumo;
        private System.Windows.Forms.Label lblServicios;
        private System.Windows.Forms.Label lblBienDeUso;
        private System.Windows.Forms.Label lblVarios;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar prbServicios;
        private System.Windows.Forms.ProgressBar prbBienDeUso;
        private System.Windows.Forms.Label lvlInforme;
        private System.Windows.Forms.RichTextBox rtbComprasConceptos;
        private System.Windows.Forms.ComboBox cmbConcepto;
    }
}