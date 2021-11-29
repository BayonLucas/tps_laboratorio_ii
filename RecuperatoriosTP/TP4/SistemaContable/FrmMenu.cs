﻿using System;
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
using System.Threading;

namespace SistemaContable
{
    public partial class frmMenu : Form
    {
        private RegistroContable registroContable;
        private FrmCompra compra;
        private FrmVentas ventas;
        private FrmLog logIn;
        private FrmInformes informes;

        CancellationTokenSource cancelTask;
        CancellationToken token;

        public delegate void DelegateManejador();
        public event DelegateManejador Gif;
        private Task endLog;



        public frmMenu()
        {
            InitializeComponent();
            this.cancelTask = new CancellationTokenSource();
            this.token = cancelTask.Token;
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
                Gif += ApagarGif;
                this.endLog = new Task(() => this.CargarGif(token));
                endLog.Start();
            }
            else
            {
                this.Close();
            }
            this.compra = new FrmCompra(this.registroContable);
            this.ventas = new FrmVentas(this.registroContable);
            this.informes = new FrmInformes(this.registroContable);
        }


        private void ApagarGif()
        {
            this.picGif.Visible = false;
            this.mtrMenu.Enabled = true;
            this.cancelTask.Cancel();
        }
        private void CargarGif(CancellationToken cancelToken)
        {
            int contador = 0;
            while (!cancelToken.IsCancellationRequested)
            {
                if (this.picGif.InvokeRequired)
                {
                    contador++;
                    if (contador == 5)
                    {
                        this.picGif.BeginInvoke((MethodInvoker)delegate ()
                        {
                            picGif.Visible = true;
                            Gif.Invoke();
                        });
                        break;
                    }
                    Thread.Sleep(1000);
                }
                else
                {
                    picGif.Visible = false;
                }
            }
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
            if(this.registroContable.Compras.Count>0 || this.registroContable.Ventas.Count > 0)
            {
                string rutaVentas = Ruta.GenerarRuta($"{this.registroContable.Usuario.RazonSocial}Ventas.Json");
                string rutaCompras = Ruta.GenerarRuta($"{this.registroContable.Usuario.RazonSocial}Compras.Json");

                foreach (Factura item in this.registroContable.Ventas)
                {
                    JsonSerial.SerializarJson<Factura>(rutaVentas, item);
                }
                File.Delete(rutaCompras);
                foreach (Compra item in this.registroContable.Compras)
                {
                    JsonSerial.SerializarJson<Compra>(rutaCompras, item);
                }
                if (File.Exists(rutaVentas) && File.Exists(rutaCompras))
                {
                    MessageBox.Show("El guardado del archivo a Json se realizó con exito", "Guardar como Json", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Error en el guardado del archivos a Json ", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("No se pueden generar archivos si no hay contenido en las listas correspondientes al usuario.", "Error");
            }

           
        }

        private void GuardarComoXmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.registroContable.Compras.Count > 0 || this.registroContable.Ventas.Count > 0)
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
            else
            {
                MessageBox.Show("No se pueden generar archivos si no hay contenido en las listas correspondientes al usuario.", "Error");
            }

        }

        #endregion



        private void smiInformes_Click(object sender, EventArgs e)
        {
            try
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.cancelTask.Cancel();
        }

        private void siToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Estas 100% seguro?", "Última advertencia", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (GestorBD.EliminarTablas(this.registroContable) && GestorBD.EliminarUsuario(this.registroContable))
                {
                    this.EliminarListas(this.registroContable);
                    MessageBox.Show("Se ha eliminado al usuario de la base de datos exitosamente. Se procederá a cerrar el programa. \n Gracias por elegirnos!.", "Despedida");
                    this.Close();
                }
            }
        }
    }
}
