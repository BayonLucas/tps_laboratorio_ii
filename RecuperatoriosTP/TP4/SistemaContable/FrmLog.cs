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
using System.Threading;

namespace SistemaContable
{
    public partial class FrmLog : Form
    {
        private RegistroContable registro;
        private List<Ente> usuarios;

        CancellationTokenSource cancelTask;
        //CancellationToken token;
        public delegate void DelLoad();
        public event DelLoad EventLoad;
        private Task loadSimulator;



        public RegistroContable GetInstance
        {
            get
            {
                if(this.registro is null)
                {
                    this.registro = new RegistroContable();
                }
                return this.registro;
            }
        }


        public FrmLog(RegistroContable registroContable)
        {
            InitializeComponent();
            this.registro = registroContable;

            //task y eventos
            this.cancelTask = new CancellationTokenSource();
            //this.token = cancelTask.Token;
           

        }

        private void Log_Load(object sender, EventArgs e)
        {
            cmbSitFiscal.DataSource = Enum.GetValues(typeof(ESitFiscal));
            this.usuarios = GestorBD.CargarListaUsuarios();
            this.cmbUsuarios.DataSource = this.usuarios;
            this.cmbUsuarios.SelectedIndex = -1;
            this.cmbSitFiscal.SelectedIndex = -1;
            this.cmbUsuarios.Enabled = true;
            this.txtRazonSocial.Enabled = false;
            this.txtCuit.Enabled = false;
            this.cmbSitFiscal.Enabled = false;
            if(this.usuarios.Count == 0)
            {
                this.chbNuevoUsuario.Checked = true;
            }
            else
            {
                this.chbNuevoUsuario.Checked = false;
            }
        }

        private void chbNuevoUsuario_CheckedChanged(object sender, EventArgs e)
        {
            this.Refrescar();
            if(chbNuevoUsuario.Checked == true)
            {
                this.cmbUsuarios.Enabled = false;
                this.txtRazonSocial.Enabled = true;
                this.txtCuit.Enabled = true;
                this.cmbSitFiscal.Enabled = true;
            }
            else
            {
                this.cmbUsuarios.Enabled = true;
                this.txtRazonSocial.Enabled = false;
                this.txtCuit.Enabled = false;
                this.cmbSitFiscal.Enabled = false;
            }
           
        }
        private void cmbUsuarios_SelectedValueChanged(object sender, EventArgs e)
        {
            Ente aux = (Ente)this.cmbUsuarios.SelectedItem;
            if(aux is not null)
            {
                this.txtRazonSocial.Text = aux.RazonSocial;
                this.txtCuit.Text = aux.Cuit;
                switch (aux.SitFiscal)
            {
                case ESitFiscal.Responsable_Inscripto:
                    this.cmbSitFiscal.SelectedItem = ESitFiscal.Responsable_Inscripto;
                    break;
                case ESitFiscal.Monotributista:
                    this.cmbSitFiscal.SelectedItem = ESitFiscal.Monotributista;
                    break;
                case ESitFiscal.Consumidor_Final:
                    this.cmbSitFiscal.SelectedItem = ESitFiscal.Consumidor_Final;
                    break;
            }
            }
            else
            {
                this.txtRazonSocial.Text = string.Empty;
                this.txtCuit.Text = string.Empty;
                this.cmbSitFiscal.SelectedIndex = -1;
            }
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if(txtRazonSocial.Text != string.Empty && txtCuit.Text !=string.Empty && cmbSitFiscal.SelectedItem is not null)
            {
                Ente usuarioElegido;
                if (this.chbNuevoUsuario.Checked == false)
                {
                    usuarioElegido = (Ente)this.cmbUsuarios.SelectedItem;
                    if(usuarioElegido is not null)
                    {
                        this.registro = new RegistroContable(usuarioElegido, GestorBD.CargarListaVentas(usuarioElegido),
                            GestorBD.CargarListaCompras(usuarioElegido));
                    }
                }
                else
                {
                    usuarioElegido = new Ente(this.txtRazonSocial.Text, this.txtCuit.Text, (ESitFiscal)cmbSitFiscal.SelectedItem);
                    if(usuarioElegido is not null)
                    {
                        GestorBD.GenerarUsuario(usuarioElegido);
                        GestorBD.GenerarTablaVentas(usuarioElegido);
                        GestorBD.GenerarTablaCompras(usuarioElegido);
                        this.registro = new RegistroContable(usuarioElegido, GestorBD.CargarListaVentas(usuarioElegido),
                            GestorBD.CargarListaCompras(usuarioElegido));
                    }
                }
                EventLoad += MostrarBotones;
                // this.loadSimulator = new Task(() => this.cargarBotones(token));
                this.loadSimulator = new Task(() => this.cargarBotones());
                this.loadSimulator.Start();

                //this.loadSimulator.Wait();
                
                //if (this.registro is not null)
                //{
                //    this.Close();
                //}
            }
            else
            {
                lblError.Visible = true;
            }
        }
    
        private void MostrarBotones()
        {
            this.picGif.Visible = true;
            
        }
    
        private void cargarBotones(/*CancellationToken cancelTaskToken*/)
        {
            int cuenta = 0;
            //while(!cancelTaskToken.IsCancellationRequested)
            while(true)
            {
                if(this.picGif.InvokeRequired && cuenta < 4)
                {
                    this.picGif.BeginInvoke((MethodInvoker)delegate ()
                    {
                        EventLoad.Invoke();
                    });
                    Thread.Sleep(1000);
                    cuenta++;
                }
                else
                {
                    this.picGif.BeginInvoke((MethodInvoker)delegate ()
                    {
                        this.Close();
                    });
                break;
                }

            }
        }
    
        public void Refrescar()
        {
            this.txtRazonSocial.Text = string.Empty;
            this.txtCuit.Text = string.Empty;
            this.cmbSitFiscal.SelectedIndex = -1;
            this.cmbUsuarios.SelectedIndex = -1;
            lblError.Visible = false;
        }


        private void KeypressValidator(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void FrmLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.cancelTask.Cancel();
        }


        //Eliminar usuario



    }
}
