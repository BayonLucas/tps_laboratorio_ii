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
    public partial class FrmCompra : Form, IForm
    {
        private RegistroContable registro;
        private string optionSelected;

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

        public FrmCompra() :this(null, string.Empty)
        {     }
        public FrmCompra(RegistroContable registro) :this(registro, string.Empty)
        {     }
        public FrmCompra(RegistroContable registro, string optionSelected) 
        {
            InitializeComponent();
            this.optionSelected = optionSelected;
            this.registro = registro;
        }

        private void FrmCargarCompra_Load(object sender, EventArgs e)
        {
            switch (this.GetOption)
            {
                case "Cargar":
                    this.Text = "Cargar Compra";
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
                    this.Text = "Modificar Compra";
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
                    this.btnModificar.Visible = true; 
                    this.btnEliminar.Visible = false;
                    break;
                case "Eliminar":
                    this.Text = "Eliminar Compra";
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
            this.dtpFecha.MaxDate = DateTime.Today;
            this.cmbSitFiscal.DataSource = Enum.GetValues(typeof(ESitFiscal));
            this.cmbAlicuota.Items.Add(21);
            this.cmbAlicuota.Items.Add(27);
            this.cmbAlicuota.Items.Add(10.5);
            this.cmbConcepto.DataSource = Enum.GetValues(typeof(EConcepto));
            this.Refrescar();
        }

        /// <summary>
        /// Luego de validaciones, genera una compra ya la carga a Lista de compras y a la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarDatosIngresados())
                {
                    Compra compra = new Compra(new Ente(this.txtEmisor.Text, this.txtCuitEmisor.Text, (ESitFiscal)this.cmbSitFiscal.SelectedValue),
                        this.txtPtoVenta.Text, this.txtNroComprobante.Text, this.dtpFecha.Value, float.Parse(this.txtImporte.Text), float.Parse(this.cmbAlicuota.Text),
                        this.registro.Usuario, (EConcepto)this.cmbConcepto.SelectedValue);
                    this.registro += compra;
                    GestorBD.CargarCompra(compra);
                    this.Refrescar();
                }
                else
                {
                    this.lblEstadoBoton.Visible = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Modifica una compra, cargandola en la base de datos y lista Compras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {

                if(ValidarDatosIngresados())
                {
                    foreach (Compra item in registro.Compras)
                    {
                        if (item == (Compra)lstListaCompras.SelectedItem)
                        {
                            if (MessageBox.Show("Desea modificar los datos de esta compra?", "Modificar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                Compra compra = new Compra(new Ente(this.txtEmisor.Text, this.txtCuitEmisor.Text, (ESitFiscal)this.cmbSitFiscal.SelectedValue),
                                this.txtPtoVenta.Text, this.txtNroComprobante.Text, this.dtpFecha.Value, float.Parse(this.txtImporte.Text), float.Parse(this.cmbAlicuota.Text),
                                this.registro.Usuario, (EConcepto)this.cmbConcepto.SelectedValue);
                                this.registro += compra;
                                GestorBD.CargarCompra(compra);
                                registro -= item;
                                GestorBD.EliminarCompra(item);
                                this.Refrescar();
                                break;
                            }
                        }
                    }
                }
                {
                    this.lblEstadoBoton.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Elimina una compra tanto de la lista de Compras como de la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach(Compra item in registro.Compras)
                {
                    if(item == (Compra)lstListaCompras.SelectedItem)
                    {
                        if(MessageBox.Show("Desea eliminar esta compra?", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            registro -= item;
                            GestorBD.EliminarCompra(item);
                            this.Refrescar();
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Muestra los datos de una compra en los campos del formulario
        /// </summary>
        /// <param name="c1"></param>
        public void MostrarDatos(Compra c1)
        {
            try
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
                switch ((int)c1.Alicuota)
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
                this.cmbConcepto.SelectedItem = c1.Concepto;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        /// <summary>
        /// Calcula el total de una Compra y lo imprime en el TextBox Total
        /// </summary>
        public void CalculoTotal()
        {
            try
            {
                float auxIVA;
                float auxTotal;
                auxIVA = float.Parse(txtImporte.Text) * float.Parse(cmbAlicuota.Text) / 100;
                auxTotal = float.Parse(txtImporte.Text) + auxIVA;
                this.txtTotal.Text = auxTotal.ToString(); 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        /// <summary>
        /// Limpia los campos del formulario
        /// </summary>
        public void Refrescar()
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
            this.dtpFecha.Value = DateTime.Today;

        }
       
        /// <summary>
        /// Valida que se hayan completados todos los campos del formulario
        /// </summary>
        /// <returns></returns>
        public bool ValidarDatosIngresados()
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
            if(this.GetOption == "Modificar" || this.GetOption == "Eliminar")
            {
                Compra aux = (Compra)this.lstListaCompras.SelectedItem;
                if (aux is not null)
                    this.MostrarDatos(aux);
                if (this.optionSelected == "Modificar")
                {
                    this.dtpFecha.Enabled = true;
                    this.txtPtoVenta.Enabled = true;
                    this.txtNroComprobante.Enabled = true;
                    this.txtEmisor.Enabled = true;
                    this.txtCuitEmisor.Enabled = true;
                    this.txtImporte.Enabled = true;
                    this.txtTotal.Enabled = true;
                    this.cmbAlicuota.Enabled = true;
                    this.cmbConcepto.Enabled = true;
                    this.cmbSitFiscal.Enabled = true;
                    this.lstListaCompras.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Limita el ingreso de caracteres de un TextBox a solo digitos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeypressValidator(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Reemplaza el "_" por un espacio vacio para una vista mas agradable del item del ComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cmbformat(object sender, ListControlConvertEventArgs e)
        {
            e.Value = e.ListItem.ToString().Replace("_", " ");
        }
    }
}
