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
        public FrmCompra(RegistroContable registro)
        {
            InitializeComponent();
            this.registro = registro;
        }

        private void FrmCargarCompra_Load(object sender, EventArgs e)
        {
            this.cmbSitFiscal.DataSource = Enum.GetValues(typeof(ESitFiscal));
            this.cmbAlicuota.Items.Add("");
            this.cmbAlicuota.Items.Add(21);
            this.cmbAlicuota.Items.Add(27);
            this.cmbAlicuota.Items.Add(10.5);
            this.cmbConcepto.DataSource = Enum.GetValues(typeof(EConcepto));
            this.Refrescar();
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
            this.cmbAlicuota.SelectedIndex = 0;
            this.cmbConcepto.SelectedIndex = 0;
            this.cmbSitFiscal.SelectedIndex = 0;
            //this.rtbListaCompras.DataBindings = this.registro.Compras;
            foreach(Compras item in this.registro.Compras)
            {
                this.rtbListaCompras.Text = $"{item.MostrarDatos()}\n";
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.txtPtoVenta.Text) && !string.IsNullOrWhiteSpace(this.txtNroComprobante.Text) && !string.IsNullOrWhiteSpace(this.txtEmisor.Text) &&
                !string.IsNullOrWhiteSpace(this.txtCuitEmisor.Text) && !string.IsNullOrWhiteSpace(this.cmbSitFiscal.Text) && !string.IsNullOrWhiteSpace(this.txtImporte.Text) &&
                !string.IsNullOrWhiteSpace(this.cmbAlicuota.Text) && !string.IsNullOrWhiteSpace(this.cmbConcepto.Text))
            {
                //this.CalculoTotal();
                this.registro.Compras.Add(new Compras(new Ente(this.txtEmisor.Text, this.txtCuitEmisor.Text, (ESitFiscal)this.cmbSitFiscal.SelectedValue),
                    this.txtPtoVenta.Text, this.txtNroComprobante.Text, this.dtpFecha.Value, float.Parse(this.txtImporte.Text), float.Parse(this.cmbAlicuota.Text),this.registro.Usuario, (EConcepto)this.cmbConcepto.SelectedValue));
                
            }
            this.Refrescar();
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
    }
}
