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
    public partial class FrmInformes : Form
    {
        private RegistroContable registroContable;

        CancellationTokenSource cancelTask;
        CancellationToken token;

        public delegate void DelegateManejador();
        public event DelegateManejador Gif;
        private Task IntroInformes;

        public FrmInformes() : this(null)
        {        }
        public FrmInformes(RegistroContable registroContable)
        {
            this.registroContable = registroContable;
            InitializeComponent();

            this.cancelTask = new CancellationTokenSource();
            this.token = cancelTask.Token;
        }

        private void FrmInformes_Load(object sender, EventArgs e)
        {
            this.nudAño.Minimum = (decimal.Parse(DateTime.Now.Year.ToString()) - 5);
            this.nudAño.Maximum = (decimal.Parse(DateTime.Now.Year.ToString()));
            this.cmbConcepto.DataSource = Enum.GetValues(typeof(EConcepto));
            this.Refrescar();

            this.prbBienDeUso.Value = (int)this.CarcularPorcentaje(EConcepto.Bien_de_uso.ToString());
            this.prbServicios.Value = (int)this.CarcularPorcentaje(EConcepto.Servicio.ToString());
            this.prbBienDeConsumo.Value = (int)this.CarcularPorcentaje(EConcepto.Bien_de_consumo.ToString());
            this.prbVarios.Value = (int)this.CarcularPorcentaje(EConcepto.Varios.ToString());

            Gif += ApagarGif;
            this.IntroInformes = new Task(() => this.CargarGif(token));
            IntroInformes.Start();
        }

       
        public float CarcularPorcentaje(string concepto)
        {
            int contadorPorConcepto = 0;
            float total = 0;
            try
            {

                if (!string.IsNullOrEmpty(concepto) && this.registroContable.Compras.Count != 0)
                {

                    foreach (Compra item in this.registroContable.Compras)
                    {
                        if (concepto == item.Concepto.ToString())
                        {
                            contadorPorConcepto++;
                        }
                    }
                    total = (float)contadorPorConcepto / this.registroContable.Compras.Count * 100;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return total;
        }
        public float CalcularCreditoFiscal(List<Compra> listaFiltrada) 
        {
            float importeFiscal = 0;
            if(listaFiltrada is not null && listaFiltrada.Count > 0)
            {
                foreach(Compra item in listaFiltrada)
                {
                    importeFiscal = item.Importe * item.Alicuota / 100;
                }
            }
            return importeFiscal;
        }
        public float CalcularDebitoFiscal(List<Factura> listaFiltrada)
        {
            float importeFiscal = 0;
            if (listaFiltrada is not null && listaFiltrada.Count > 0)
            {
                foreach (Factura item in listaFiltrada)
                {
                    importeFiscal = item.Importe * item.Alicuota / 100;
                }
            }
            return importeFiscal;
        }
        private void nudAño_ValueChanged(object sender, EventArgs e)
        {
            float auxCredFiscal = 0;
            float auxDebFiscal = 0;

            List<Compra> auxFilterListCompras = null;
            List<Factura> auxFilterListVentas = null;

            this.Refrescar();
            try
            {
                if (this.cmbConcepto.SelectedItem is not null)
                {
                    if (this.chbMes.Checked == false)
                    {
                        auxFilterListCompras = GestorBD.BuscarComprasSegun(this.registroContable.Usuario, (EConcepto)this.cmbConcepto.SelectedItem, this.nudAño.Value, string.Empty);
                        auxFilterListVentas = GestorBD.BuscarVentasSegun(this.registroContable.Usuario, this.nudAño.Value, string.Empty);

                    }
                    else
                    {
                        auxFilterListCompras = GestorBD.BuscarComprasSegun(this.registroContable.Usuario, (EConcepto)this.cmbConcepto.SelectedItem, this.nudAño.Value, this.cmbMes.Text);
                        auxFilterListVentas = GestorBD.BuscarVentasSegun(this.registroContable.Usuario, this.nudAño.Value, this.cmbMes.Text);
                    }

                }

                this.lstComprasPorConcepto.DataSource = null;
                this.lstComprasPorConcepto.DataSource = auxFilterListCompras;

                auxCredFiscal = this.CalcularCreditoFiscal(auxFilterListCompras);
                this.lblCreditoFiscal.Text = $"El crédito fiscal generado en el período seleccionado es de: ${auxCredFiscal}";

                auxDebFiscal = this.CalcularDebitoFiscal(auxFilterListVentas);
                this.lblDebitoFsical.Text = $"El débito fiscal generado en el período seleccionado es de: ${auxDebFiscal}";

                float auxTotal = auxDebFiscal - auxCredFiscal;
                this.lblTotalSitFiscal.Text = $"El total acumulado es de: ${auxTotal}";
                if (auxTotal < 0)
                {
                    this.lblAvisoEmergente.Visible = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        public void Refrescar()
        {
            this.lblCreditoFiscal.Text = "El crédito fiscal generado en el período seleccionado es de: $0";
            this.lblCreditoFiscal.Text = "El débito fiscal generado en el período seleccionado es de: $0";
            this.lblTotalSitFiscal.Text = "El total acumulado es de: $0";
            this.lblAvisoEmergente.Visible = false;
            this.lstComprasPorConcepto.DataSource = null;
        }
        private void chbMes_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbMes.Enabled = !this.cmbMes.Enabled;
        }

        #region Gif
        private void ApagarGif()
        {
            this.picGif.Visible = false;
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
        private void FrmInformes_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.cancelTask.Cancel();
        }

        #endregion

        private void cmbConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Compra> auxFilterListCompras = null;
            List<Factura> auxFilterListVentas = null;
            if (this.cmbConcepto.SelectedItem is not null)
            {
                if (this.chbMes.Checked == false)
                {
                    auxFilterListCompras = GestorBD.BuscarComprasSegun(this.registroContable.Usuario, (EConcepto)this.cmbConcepto.SelectedItem, this.nudAño.Value, string.Empty);
                    auxFilterListVentas = GestorBD.BuscarVentasSegun(this.registroContable.Usuario, this.nudAño.Value, string.Empty);

                }
                else
                {
                    auxFilterListCompras = GestorBD.BuscarComprasSegun(this.registroContable.Usuario, (EConcepto)this.cmbConcepto.SelectedItem, this.nudAño.Value, this.cmbMes.Text);
                    auxFilterListVentas = GestorBD.BuscarVentasSegun(this.registroContable.Usuario, this.nudAño.Value, this.cmbMes.Text);
                }

            }
        }

        private void cmbMes_SelectedValueChanged(object sender, EventArgs e)
        {
            float auxCredFiscal = 0;
            float auxDebFiscal = 0;

            List<Compra> auxFilterListCompras = null;
            List<Factura> auxFilterListVentas = null;


            this.Refrescar();
            try
            {
                if (this.cmbConcepto.SelectedItem is not null)
                {
                    if (this.chbMes.Checked == false)
                    {
                        auxFilterListCompras = GestorBD.BuscarComprasSegun(this.registroContable.Usuario, (EConcepto)this.cmbConcepto.SelectedItem, this.nudAño.Value, string.Empty);
                        auxFilterListVentas = GestorBD.BuscarVentasSegun(this.registroContable.Usuario, this.nudAño.Value, string.Empty);

                    }
                    else
                    {
                        auxFilterListCompras = GestorBD.BuscarComprasSegun(this.registroContable.Usuario, (EConcepto)this.cmbConcepto.SelectedItem, this.nudAño.Value, this.cmbMes.Text);
                        auxFilterListVentas = GestorBD.BuscarVentasSegun(this.registroContable.Usuario, this.nudAño.Value, this.cmbMes.Text);
                    }

                }


                this.lstComprasPorConcepto.DataSource = null;
                this.lstComprasPorConcepto.DataSource = auxFilterListCompras;



                auxCredFiscal = this.CalcularCreditoFiscal(auxFilterListCompras);
                this.lblCreditoFiscal.Text = $"El crédito fiscal generado en el período seleccionado es de: ${auxCredFiscal}";

                auxDebFiscal = this.CalcularDebitoFiscal(auxFilterListVentas);
                this.lblCreditoFiscal.Text = $"El débito fiscal generado en el período seleccionado es de: ${auxDebFiscal}";

                float auxTotal = auxDebFiscal - auxCredFiscal;
                this.lblTotalSitFiscal.Text = $"El total acumulado es de: ${auxTotal}";
                if (auxTotal < 0)
                {
                    this.lblAvisoEmergente.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
