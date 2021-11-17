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
    public partial class FrmCompra : Form
    {
        private RegistroContable registro;
        private string optionSelected;
        public FrmCompra(RegistroContable registro)
        {
            InitializeComponent();
            this.registro = registro;
        }
        public FrmCompra(RegistroContable registro, string optionSelected) : this(registro)
        {
            this.optionSelected = optionSelected;
            
        }

        private void FrmCargarCompra_Load(object sender, EventArgs e)
        {
            switch (this.optionSelected)
            {
                case "Cargar":
                    this.dtpFecha.Enabled = true;
                    this.txtPtoVenta.Enabled = true;
                    this.txtNroComprobante.Enabled = true;
                    this.txtEmisor.Enabled = true;
                    this.txtCuitEmisor.Enabled = true;
                    this.txtImporte.Enabled = true;
                    this.txtTotal.Enabled = false;
                    this.cmbAlicuota.Enabled = true;
                    this.cmbConcepto.Enabled = true;
                    this.cmbSitFiscal.Enabled = true;
                    this.lstListaCompras.Enabled = false;
                    this.btnCargar.Visible = true;
                    this.btnModificar.Visible = false;
                    this.btnEliminar.Visible = false;
                    break;
                case "Modificar":
                    this.dtpFecha.Enabled = true;
                    this.txtPtoVenta.Enabled = true;
                    this.txtNroComprobante.Enabled = true;
                    this.txtEmisor.Enabled = true;
                    this.txtCuitEmisor.Enabled = true;
                    this.txtImporte.Enabled = true;
                    this.txtTotal.Enabled = false;
                    this.cmbAlicuota.Enabled = true;
                    this.cmbConcepto.Enabled = true;
                    this.cmbSitFiscal.Enabled = true;
                    this.lstListaCompras.Enabled = true;
                    this.btnCargar.Visible = false;
                    this.btnModificar.Visible = true; 
                    this.btnEliminar.Visible = false;
                    break;
                case "Eliminar":
                    this.dtpFecha.Enabled = false;
                    this.txtPtoVenta.Enabled = false;
                    this.txtNroComprobante.Enabled = false;
                    this.txtEmisor.Enabled = false;
                    this.txtCuitEmisor.Enabled = false;
                    this.txtImporte.Enabled = false;
                    this.txtTotal.Enabled = false;
                    this.cmbAlicuota.Enabled = false;
                    this.cmbConcepto.Enabled = false;
                    this.cmbSitFiscal.Enabled = false;
                    this.lstListaCompras.Enabled = true;
                    this.btnCargar.Visible = false;
                    this.btnModificar.Visible = false;
                    this.btnEliminar.Visible = true;
                    break;
            }
            this.cmbSitFiscal.DataSource = Enum.GetValues(typeof(ESitFiscal));
            this.cmbAlicuota.Items.Add(21);
            this.cmbAlicuota.Items.Add(27);
            this.cmbAlicuota.Items.Add(10.5);
            this.cmbConcepto.DataSource = Enum.GetValues(typeof(EConcepto));
            this.Refrescar();
        }











        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (ValidarDatosIngresados())
            {
                this.registro.Compras.Add(new Compras(new Ente(this.txtEmisor.Text, this.txtCuitEmisor.Text, (ESitFiscal)this.cmbSitFiscal.SelectedValue),
                    this.txtPtoVenta.Text, this.txtNroComprobante.Text, this.dtpFecha.Value, float.Parse(this.txtImporte.Text), float.Parse(this.cmbAlicuota.Text),this.registro.Usuario, (EConcepto)this.cmbConcepto.SelectedValue));
                
                this.Refrescar();
            }
            else
            {
                this.lblEstadoBoton.Visible = true;
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            foreach(Compras item in registro.Compras)
            {
                if(item == (Compras)lstListaCompras.SelectedItem)
                {
                    if(MessageBox.Show("Desea eliminar esta compra?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        registro -= item;
                        this.Refrescar();
                        break;
                    }
                }
            }
        }







        private void cmbAlicuota_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(this.txtImporte.Text))
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
        private void lstListaCompras_SelectedValueChanged(object sender, EventArgs e)
        {
            Compras aux = (Compras)this.lstListaCompras.SelectedItem;
            if(aux is not null)
                this.MostrarDatosCompra(aux);
        }
        public void MostrarDatosCompra(Compras c1)
        {
            this.dtpFecha.Value = c1.Fecha;
            this.txtPtoVenta.Text = c1.PtoVenta;
            this.txtNroComprobante.Text = c1.NroComprobante;
            this.txtEmisor.Text = c1.Ente.RazonSocial;
            this.txtCuitEmisor.Text = c1.Ente.Cuit;
            switch(c1.Ente.SitFiscal)
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
            this.txtImporte.Text = c1.Importe.ToString();
            //this.cmbAlicuota.SelectedItem = c1.Alicuota;
            this.txtTotal.Text = c1.CalculoTotal.ToString();
            this.cmbConcepto.SelectedItem = c1.Concepto;
        }
        private void CalculoTotal()
        {
            float auxIVA;
            float auxTotal;
            auxIVA = float.Parse(txtImporte.Text) * float.Parse(cmbAlicuota.Text) / 100;
            auxTotal = float.Parse(txtImporte.Text) + auxIVA;
            this.txtTotal.Text = auxTotal.ToString(); 
        }
        private void Refrescar()
        {
            this.txtEmisor.Text = "";
            this.txtCuitEmisor.Text = "";
            this.txtImporte.Text = "";
            this.txtNroComprobante.Text = "";
            this.txtPtoVenta.Text = "";
            this.txtTotal.Text = "";
            this.cmbAlicuota.SelectedIndex = -1;
            this.cmbConcepto.SelectedIndex = -1;
            this.cmbSitFiscal.SelectedIndex = -1;
            this.lstListaCompras.DataSource = null;
            this.lstListaCompras.DataSource = this.registro.Compras;
            this.lblEstadoBoton.Visible = false;
        }
        private bool ValidarDatosIngresados()
        {
            bool ret = false;
            if (!string.IsNullOrWhiteSpace(this.txtPtoVenta.Text) && !string.IsNullOrWhiteSpace(this.txtNroComprobante.Text) && !string.IsNullOrWhiteSpace(this.txtEmisor.Text) &&
                !string.IsNullOrWhiteSpace(this.txtCuitEmisor.Text) && !string.IsNullOrWhiteSpace(this.cmbSitFiscal.Text) && !string.IsNullOrWhiteSpace(this.txtImporte.Text) &&
                !string.IsNullOrWhiteSpace(this.cmbAlicuota.Text) && !string.IsNullOrWhiteSpace(this.cmbConcepto.Text))
            {
                ret = true;
            }
            return ret;
        }

    }
}
