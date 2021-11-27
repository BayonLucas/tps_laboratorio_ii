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

namespace SistemaContable
{
    public partial class FrmVentas : Form, IForm
    {
        private RegistroContable registroContable;
        private string optionSelected;
        

        public FrmVentas() : this(null)
        { }
        public FrmVentas(RegistroContable registro) : this(registro, string.Empty)
        { }
        public FrmVentas(RegistroContable registro, string optionSelected)
        {
            InitializeComponent();
            this.registroContable = registro;
            this.optionSelected = optionSelected;
        }

        public string GetOption
        {
            get
            {
                return this.optionSelected;
            }
            set
            {
                this.optionSelected = value;
            }
        }



        private void FrmVentas_Load(object sender, EventArgs e)
        {
            this.lblRazonSocialUsuario.Text = this.registroContable.Usuario.RazonSocial;
            this.lblCuitUsuario.Text = $"CUIT: {this.registroContable.Usuario.Cuit}";
            this.lblSitFiscalUsuario.Text = $"Situación Fiscal: {this.registroContable.Usuario.SitFiscal.ToString()}"; 
            switch (this.GetOption)
            {
                case "Emitir":
                    this.Text = "Emitir Venta";
                    this.dtpFecha.Enabled = true;
                    this.txtRazonSocialReceptor.Enabled = true;
                    this.txtCuitReceptor.Enabled = true;
                    this.cmbSitFiscalReceptor.Enabled = true;
                    this.lblImporte.Enabled = true;
                    this.txtCuitReceptor.Enabled = true;
                    this.btnEmitir.Visible = true;
                    this.btnAnular.Visible = false;
                    this.lstListaVentas.Enabled = false;
                    break;
                case "Anular":
                    this.Text = "Anular Venta";
                    this.dtpFecha.Enabled = false;
                    this.txtRazonSocialReceptor.Enabled = false;
                    this.txtCuitReceptor.Enabled = false;
                    this.cmbSitFiscalReceptor.Enabled = false;
                    this.txtImporte.Enabled = false;
                    this.txtCuitReceptor.Enabled = false;
                    this.btnEmitir.Visible = false;
                    this.btnAnular.Visible = true;
                    this.lstListaVentas.Enabled = true;
                    this.cmbAlicuota.Enabled = false;

                    break;
            }
            this.cmbSitFiscalReceptor.DataSource = Enum.GetValues(typeof(ESitFiscal));
            this.cmbAlicuota.Items.Add(21);
            this.cmbAlicuota.Items.Add(27);
            this.cmbAlicuota.Items.Add(10.5);
            this.Refrescar();

            this.dtpFecha.MaxDate = DateTime.Now.AddDays(10);
            this.dtpFecha.Value = DateTime.Now;
        }



        private void btnEmitir_Click(object sender, EventArgs e)
        {
            if(ValidarDatosIngresados())
            {
                Factura fc = new Factura(this.registroContable.Usuario, "99", this.txtNroComprobante.Text, dtpFecha.Value,
                    float.Parse(this.txtImporte.Text), float.Parse(this.cmbAlicuota.Text),
                    new Ente(txtRazonSocialReceptor.Text, txtCuitReceptor.Text, (ESitFiscal)this.cmbSitFiscalReceptor.SelectedValue), false);
                this.registroContable += fc;
                        //Generar evento que encapsule una serializacion XML de la Fc, la carga a la base de datos y la adhision a la lista del usuario
                if(!GestorBD.CargarVenta(fc))
                {
                    DataBasesException ex = new DataBasesException("Error al agregar la venta a la Base de Datos");
                    throw ex;
                }
                this.Refrescar();
            }
            else
            {
                this.lblError.Visible = true;
            }
        }
        private void btnAnular_Click(object sender, EventArgs e)
        {
            foreach (Factura item in registroContable.Ventas)
            {
                if (item == (Factura)lstListaVentas.SelectedItem)
                {
                    this.MostrarDatos(item);
                    if(item.Anulado == false)
                    {
                        if (MessageBox.Show("Desea anular esta factura?", "Anular", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            item.Anulado = true;
                            GestorBD.ModificarVenta(item);
                            this.Refrescar();
                            break;
                        }
                    }
                }
            }
        }



        public void Refrescar()
        {
            this.txtRazonSocialReceptor.Text = string.Empty;
            this.txtCuitReceptor.Text = string.Empty;
            this.txtImporte.Text = string.Empty;
            this.txtPtoVenta.Text = "99";
            this.txtNroComprobante.Text = (UltimoNroComprobante(this.registroContable.Ventas)+1).ToString();
            this.txtTotal.Text = string.Empty;
            this.cmbAlicuota.SelectedIndex = -1;
            this.cmbSitFiscalReceptor.SelectedIndex = -1;
            this.lstListaVentas.DataSource = null;
            this.lstListaVentas.DataSource = this.registroContable.Ventas;
            this.lblError.Visible = false;
            this.dtpFecha.Value = DateTime.Now;
        }
        public void CalculoTotal()
        {
            float auxIVA;
            float auxTotal;
            auxIVA = float.Parse(txtImporte.Text) * float.Parse(cmbAlicuota.Text) / 100;
            auxTotal = float.Parse(txtImporte.Text) + auxIVA;
            this.txtTotal.Text = auxTotal.ToString();
        }
        public bool ValidarDatosIngresados()
        {
            bool ret = false;
            if (!string.IsNullOrWhiteSpace(this.txtRazonSocialReceptor.Text) && !string.IsNullOrWhiteSpace(this.txtCuitReceptor.Text) && !string.IsNullOrWhiteSpace(this.cmbSitFiscalReceptor.Text) && 
                !string.IsNullOrWhiteSpace(this.txtImporte.Text) && !string.IsNullOrWhiteSpace(this.cmbAlicuota.Text))
            {
                ret = true;
            }
            return ret;
        }
        private int UltimoNroComprobante(List<Factura> listaVentas)
        {
            int aux = 0; ;
            if(listaVentas is not null)
            {
                if(listaVentas.Count>0)
                {
                    Factura auxFc = listaVentas.Last();
                    if(auxFc is not null)
                        aux = int.Parse(auxFc.NroComprobante);
                }
            }
            return aux;
        }
        private void MostrarDatos(Factura f1) 
        {
            this.txtRazonSocialReceptor.Text = f1.EnteReceptor.RazonSocial;
            this.txtCuitReceptor.Text = f1.EnteReceptor.Cuit;
            this.dtpFecha.Value = f1.Fecha;
            this.txtPtoVenta.Text = f1.PtoVenta;
            this.txtNroComprobante.Text = f1.NroComprobante;
            this.txtImporte.Text = f1.Importe.ToString();
            switch (f1.Ente.SitFiscal)
            {
                case ESitFiscal.Responsable_Inscripto:
                    this.cmbSitFiscalReceptor.SelectedItem = ESitFiscal.Responsable_Inscripto;
                    break;
                case ESitFiscal.Monotributista:
                    this.cmbSitFiscalReceptor.SelectedItem = ESitFiscal.Monotributista;
                    break;
                case ESitFiscal.Consumidor_Final:
                    this.cmbSitFiscalReceptor.SelectedItem = ESitFiscal.Consumidor_Final;
                    break;
            }
            switch((int)f1.Alicuota)
            {
                case 21:
                    this.cmbAlicuota.SelectedIndex = 0;
                    break;
                case 27:
                    this.cmbAlicuota.SelectedIndex = 1;
                    break;
                case 10:
                    this.cmbAlicuota.SelectedIndex = 2;
                    break;
            }
            //this.txtTotal.Text = f1.CalculoTotal.ToString();
        }



        private void cmbAlicuota_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txtImporte.Text))
            {
                this.CalculoTotal();
            }
        }
        private void cmbAlicuota_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txtImporte.Text))
            {
                this.CalculoTotal();
            }
        }
        private void lstListaVentas_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if(this.GetOption == "Anular")
            {
                Factura auxFc = (Factura)this.lstListaVentas.SelectedItem;
                if (auxFc is not null && auxFc.Anulado != true)
                {
                    this.MostrarDatos(auxFc);
                }
                else
                {
                    this.Refrescar();
                }
            }
        }

        private void KeypressValidator(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }



    }

}

