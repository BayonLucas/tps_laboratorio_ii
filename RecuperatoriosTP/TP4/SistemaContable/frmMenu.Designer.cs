
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
            this.smiArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.GuardarComoJsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GuardarComoXmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smiCompra = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smiVenta = new System.Windows.Forms.ToolStripMenuItem();
            this.emitirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smiInformes = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elminarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estasSeguroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.muySeguroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.siToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiArchivo,
            this.smiCompra,
            this.smiVenta,
            this.smiInformes,
            this.usuarioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1216, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // smiArchivo
            // 
            this.smiArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GuardarComoJsonToolStripMenuItem,
            this.GuardarComoXmlToolStripMenuItem});
            this.smiArchivo.Name = "smiArchivo";
            this.smiArchivo.Size = new System.Drawing.Size(73, 24);
            this.smiArchivo.Text = "Archivo";
            // 
            // GuardarComoJsonToolStripMenuItem
            // 
            this.GuardarComoJsonToolStripMenuItem.Name = "GuardarComoJsonToolStripMenuItem";
            this.GuardarComoJsonToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.GuardarComoJsonToolStripMenuItem.Text = "Guardar como Json";
            this.GuardarComoJsonToolStripMenuItem.Click += new System.EventHandler(this.GuardarComoJsonToolStripMenuItem_Click);
            // 
            // GuardarComoXmlToolStripMenuItem
            // 
            this.GuardarComoXmlToolStripMenuItem.Name = "GuardarComoXmlToolStripMenuItem";
            this.GuardarComoXmlToolStripMenuItem.Size = new System.Drawing.Size(220, 26);
            this.GuardarComoXmlToolStripMenuItem.Text = "Guardar como XML";
            this.GuardarComoXmlToolStripMenuItem.Click += new System.EventHandler(this.GuardarComoXmlToolStripMenuItem_Click);
            // 
            // smiCompra
            // 
            this.smiCompra.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarToolStripMenuItem,
            this.modificarToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.smiCompra.Name = "smiCompra";
            this.smiCompra.Size = new System.Drawing.Size(76, 24);
            this.smiCompra.Text = "Compra";
            // 
            // cargarToolStripMenuItem
            // 
            this.cargarToolStripMenuItem.Name = "cargarToolStripMenuItem";
            this.cargarToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.cargarToolStripMenuItem.Text = "Cargar";
            this.cargarToolStripMenuItem.Click += new System.EventHandler(this.cargarToolStripMenuItem_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // smiVenta
            // 
            this.smiVenta.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emitirToolStripMenuItem,
            this.anularToolStripMenuItem});
            this.smiVenta.Name = "smiVenta";
            this.smiVenta.Size = new System.Drawing.Size(60, 24);
            this.smiVenta.Text = "Venta";
            // 
            // emitirToolStripMenuItem
            // 
            this.emitirToolStripMenuItem.Name = "emitirToolStripMenuItem";
            this.emitirToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.emitirToolStripMenuItem.Text = "Emitir";
            this.emitirToolStripMenuItem.Click += new System.EventHandler(this.emitirToolStripMenuItem_Click);
            // 
            // anularToolStripMenuItem
            // 
            this.anularToolStripMenuItem.Name = "anularToolStripMenuItem";
            this.anularToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.anularToolStripMenuItem.Text = "Anular";
            this.anularToolStripMenuItem.Click += new System.EventHandler(this.anularToolStripMenuItem_Click);
            // 
            // smiInformes
            // 
            this.smiInformes.Name = "smiInformes";
            this.smiInformes.Size = new System.Drawing.Size(81, 24);
            this.smiInformes.Text = "Informes";
            this.smiInformes.Click += new System.EventHandler(this.smiInformes_Click);
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.elminarUsuarioToolStripMenuItem});
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.usuarioToolStripMenuItem.Text = "Usuario";
            // 
            // elminarUsuarioToolStripMenuItem
            // 
            this.elminarUsuarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.estasSeguroToolStripMenuItem});
            this.elminarUsuarioToolStripMenuItem.Name = "elminarUsuarioToolStripMenuItem";
            this.elminarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.elminarUsuarioToolStripMenuItem.Text = "Elminar Usuario";
            // 
            // estasSeguroToolStripMenuItem
            // 
            this.estasSeguroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.muySeguroToolStripMenuItem});
            this.estasSeguroToolStripMenuItem.Name = "estasSeguroToolStripMenuItem";
            this.estasSeguroToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.estasSeguroToolStripMenuItem.Text = "Estas seguro?";
            // 
            // muySeguroToolStripMenuItem
            // 
            this.muySeguroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.siToolStripMenuItem,
            this.noToolStripMenuItem});
            this.muySeguroToolStripMenuItem.Name = "muySeguroToolStripMenuItem";
            this.muySeguroToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.muySeguroToolStripMenuItem.Text = "Muy seguro?";
            // 
            // siToolStripMenuItem
            // 
            this.siToolStripMenuItem.Name = "siToolStripMenuItem";
            this.siToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.siToolStripMenuItem.Text = "Si";
            // 
            // noToolStripMenuItem
            // 
            this.noToolStripMenuItem.Name = "noToolStripMenuItem";
            this.noToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.noToolStripMenuItem.Text = "No";
            this.noToolStripMenuItem.Click += new System.EventHandler(this.noToolStripMenuItem_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1216, 583);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro Contable";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem smiArchivo;
        private System.Windows.Forms.ToolStripMenuItem smiCompra;
        private System.Windows.Forms.ToolStripMenuItem smiVenta;
        private System.Windows.Forms.ToolStripMenuItem smiInformes;
        private System.Windows.Forms.ToolStripMenuItem GuardarComoJsonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GuardarComoXmlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emitirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem elminarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estasSeguroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem muySeguroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem siToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noToolStripMenuItem;
    }
}