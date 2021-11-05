using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace SistemaContable
{
    public partial class frmMenu : Form
    {
        public RegistroContable registroContable;
        FrmCompra compra /*= new FrmCompra(registroContable)*/;

        public frmMenu()
        {
            InitializeComponent();
            this.registroContable = new RegistroContable();
            compra = new FrmCompra(registroContable);
            this.compra.MdiParent = this;
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogIn frmLog = new FrmLogIn(registroContable);
            frmLog.ShowDialog();
            if(this.registroContable.Usuario is not null)
            {
                smiLogIn.Enabled = false;
                smiArchivo.Visible = true;
                smiCompra.Visible = true;
                smiVenta.Visible = true;
                smiInformes.Visible = true;
                this.Text = $"Registro Contable: {this.registroContable.Usuario.RazonSocial} - {this.registroContable.Usuario.Cuit}";
            }
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
        }

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmCompra compra = new FrmCompra(registroContable);
            compra.Show();
        }
    }
}
