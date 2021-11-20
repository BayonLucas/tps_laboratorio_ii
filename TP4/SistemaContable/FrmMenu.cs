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
        private FrmVentas ventas;
        private FrmLog logIn;
      

        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            logIn = new FrmLog(this.registroContable);
            logIn.ShowDialog();

            this.registroContable = logIn.GetInstance;
            if (this.registroContable.Usuario is not null)
            {
                this.Visible = true;
                this.Text = $"Registro Contable: {this.registroContable.Usuario.RazonSocial} - {this.registroContable.Usuario.Cuit}";
            }
            else
            {
                this.Close();
            }
            this.compra = new FrmCompra(this.registroContable);
            this.ventas = new FrmVentas(this.registroContable);
        }


        #region Botones Compras
        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if((IsFormAlreadyOpen(typeof(FrmCompra))) == null)
            {
                if (this.compra.IsDisposed)
                    this.compra = new FrmCompra(this.registroContable);

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
            if ((IsFormAlreadyOpen(typeof(FrmCompra))) == null)
            {
                if(!(this.registroContable.Compras.Count == 0))
                {
                    if (this.compra.IsDisposed)
                        this.compra = new FrmCompra(this.registroContable);

                    this.compra.GetOption = "Modificar";
                    this.compra.MdiParent = this;
                    compra.Show();
                }
            }
            else
            {
                compra.BringToFront();
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((IsFormAlreadyOpen(typeof(FrmCompra))) == null)
            {
                if (!(this.registroContable.Compras.Count == 0))
                {
                    if (this.compra.IsDisposed)
                        this.compra = new FrmCompra(this.registroContable);

                    this.compra.GetOption = "Eliminar";
                    this.compra.MdiParent = this;
                    compra.Show();
                }
            }
            else
            {
                compra.BringToFront();
            }
        }
        #endregion

        #region Botones Ventas

        private void emitirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((IsFormAlreadyOpen(typeof(FrmVentas))) == null)
            {
                if (this.ventas.IsDisposed)
                    this.ventas = new FrmVentas(this.registroContable);

                this.ventas.GetOption = "Emitir";
                this.ventas.MdiParent = this;
                ventas.Show();
            }
            else
            {
                ventas.BringToFront();
            }
        }

        private void anularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((IsFormAlreadyOpen(typeof(FrmVentas))) == null)
            {
                if (!(this.registroContable.Ventas.Count == 0))
                {
                    if (this.ventas.IsDisposed)
                        this.ventas = new FrmVentas(this.registroContable);

                    this.ventas.GetOption = "Anular";
                    this.ventas.MdiParent = this;
                    ventas.Show();
                }
            }
            else
            {
                ventas.BringToFront();
            }
        }

        #endregion


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
