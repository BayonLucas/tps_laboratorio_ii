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
        private RegistroContable registroContable;
        private FrmCompra compra;
      

        public frmMenu(RegistroContable registroContable)
        {
            InitializeComponent();
            this.registroContable = registroContable;
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
            if((compra = (FrmCompra)IsFormAlreadyOpen(typeof(FrmCompra))) == null)
            {
                //this.compra = new FrmCompra(registroContable, "Cargar");
                this.compra = compra.GetInstance;
                this.compra.GetOption = "Cargar";
                this.compra.MdiParent = this;
                compra.Show();
            }
            else
            {
                compra.BringToFront();
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((compra = (FrmCompra)IsFormAlreadyOpen(typeof(FrmCompra))) == null)
            {
                //this.compra = new FrmCompra(registroContable, "Modificar");
                this.compra = compra.GetInstance;
                this.compra.GetOption = "Modificar";
                this.compra.MdiParent = this;
                compra.Show();
            }
            else
            {
                compra.BringToFront();
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((compra = (FrmCompra)IsFormAlreadyOpen(typeof(FrmCompra))) == null)
            {
                //this.compra = new FrmCompra(registroContable, "Eliminar");
                this.compra = compra.GetInstance;
                this.compra.GetOption = "Eliminar";
                this.compra.MdiParent = this;
                compra.Show();
            }
            else
            {
                compra.BringToFront();
            }
        }

        //Experimento
        public static Form IsFormAlreadyOpen(Type FormType)
        {
            foreach (Form OpenForm in System.Windows.Forms.Application.OpenForms)
            {
                if (OpenForm.GetType() == FormType)
                    return OpenForm;
            }

            return null;
        }
        

    }
}
