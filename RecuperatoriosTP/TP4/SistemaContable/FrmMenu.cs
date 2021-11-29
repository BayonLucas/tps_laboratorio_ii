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
using Archivos;
using System.IO;

namespace SistemaContable
{
    public partial class frmMenu : Form
    {
        private RegistroContable registroContable;
        private FrmCompra compra;
        private FrmVentas ventas;
        private FrmLog logIn;
        private FrmInformes informes;
      

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
            this.informes = new FrmInformes(this.registroContable);
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

        #region Botones Archivos
        private void GuardarComoJsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string rutaVentas = Ruta.GenerarRuta($"{this.registroContable.Usuario.RazonSocial}Ventas.Json");
            string rutaCompras = Ruta.GenerarRuta($"{this.registroContable.Usuario.RazonSocial}Compras.Json");

            foreach (Factura item in this.registroContable.Ventas)
            {
                JsonSerial.SerializarJson<Factura>(rutaVentas, item);
            }
            File.Delete(rutaCompras);
            foreach(Compra item in this.registroContable.Compras)
            {
                JsonSerial.SerializarJson<Compra>(rutaCompras, item);
            }
            if(File.Exists(rutaVentas) && File.Exists(rutaCompras))
            {
                MessageBox.Show("El guardado del archivo a Json se realizó con exito", "Guardar como Json", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Error en el guardado del archivos a Json ", "Error", MessageBoxButtons.OK);
            }
        }

        private void GuardarComoXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string rutaVentas = Ruta.GenerarRuta($"{this.registroContable.Usuario.RazonSocial}Ventas.xml");
            string rutaCompras = Ruta.GenerarRuta($"{this.registroContable.Usuario.RazonSocial}Compras.xml");

            XmlSerial.SerializarAXm<List<Factura>>(this.registroContable.Ventas, rutaVentas);
            
            File.Delete(rutaCompras);

            XmlSerial.SerializarAXm<List<Compra>>(this.registroContable.Compras, rutaCompras);

            if (File.Exists(rutaVentas) && File.Exists(rutaCompras))
            {
                MessageBox.Show("El guardado del archivo a XML se realizó con exito", "Guardar como XML", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Error en el guardado del archivos a XML ", "Error", MessageBoxButtons.OK);
            }

        }

        #endregion



        private void smiInformes_Click(object sender, EventArgs e)
        {
            if ((IsFormAlreadyOpen(typeof(FrmInformes))) == null)
            {
                if (this.informes.IsDisposed)
                    this.informes = new FrmInformes(this.registroContable);

                this.informes.MdiParent = this;
                informes.Show();
            }
            else
            {
                informes.BringToFront();
            }
        }
        public static Form IsFormAlreadyOpen(Type FormType)
        {
            foreach (Form OpenForm in System.Windows.Forms.Application.OpenForms)
            {
                if (OpenForm.GetType() == FormType)
                    return OpenForm;
            }

            return null;
        }


        ///Eliminar usuario






        public void EliminarListas(RegistroContable usuario)
        {
            usuario.Ventas.Clear();
            usuario.Compras.Clear();
        }

        private void noToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Menos mal que pregunté", "Borrar Usuario - Negado", MessageBoxButtons.OK);
        }
    }
}
