
namespace SistemaContable
{
    partial class frmMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.smiLogIn = new System.Windows.Forms.ToolStripMenuItem();
            this.smiArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.smiCompra = new System.Windows.Forms.ToolStripMenuItem();
            this.smiVenta = new System.Windows.Forms.ToolStripMenuItem();
            this.smiInformes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiLogIn,
            this.smiArchivo,
            this.smiCompra,
            this.smiVenta,
            this.smiInformes});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // smiLogIn
            // 
            this.smiLogIn.Name = "smiLogIn";
            this.smiLogIn.Size = new System.Drawing.Size(64, 24);
            this.smiLogIn.Text = "Log In";
            this.smiLogIn.Click += new System.EventHandler(this.logInToolStripMenuItem_Click);
            // 
            // smiArchivo
            // 
            this.smiArchivo.Name = "smiArchivo";
            this.smiArchivo.Size = new System.Drawing.Size(73, 24);
            this.smiArchivo.Text = "Archivo";
            this.smiArchivo.Visible = false;
            // 
            // smiCompra
            // 
            this.smiCompra.Name = "smiCompra";
            this.smiCompra.Size = new System.Drawing.Size(76, 24);
            this.smiCompra.Text = "Compra";
            this.smiCompra.Visible = false;
            // 
            // smiVenta
            // 
            this.smiVenta.Name = "smiVenta";
            this.smiVenta.Size = new System.Drawing.Size(60, 24);
            this.smiVenta.Text = "Venta";
            this.smiVenta.Visible = false;
            // 
            // smiInformes
            // 
            this.smiInformes.Name = "smiInformes";
            this.smiInformes.Size = new System.Drawing.Size(81, 24);
            this.smiInformes.Text = "Informes";
            this.smiInformes.Visible = false;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMenu";
            this.Text = "Registro Contable";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem smiLogIn;
        private System.Windows.Forms.ToolStripMenuItem smiArchivo;
        private System.Windows.Forms.ToolStripMenuItem smiCompra;
        private System.Windows.Forms.ToolStripMenuItem smiVenta;
        private System.Windows.Forms.ToolStripMenuItem smiInformes;
    }
}