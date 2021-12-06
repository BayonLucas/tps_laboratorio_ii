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
using System.IO;

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
            this.Dock = DockStyle.Fill;
            try
            {
                float porcBienDeUso = this.CarcularPorcentaje(EConcepto.Bien_de_uso.ToString());
                float porcServicio = this.CarcularPorcentaje(EConcepto.Servicio.ToString());
                float porcBienDeConsumo = this.CarcularPorcentaje(EConcepto.Bien_de_consumo.ToString());
                float porcVarios = this.CarcularPorcentaje(EConcepto.Varios.ToString());

                this.nudAño.Minimum = (decimal.Parse(DateTime.Now.Year.ToString()) - 5);
                this.nudAño.Maximum = (decimal.Parse(DateTime.Now.Year.ToString()));
                this.cmbConcepto.DataSource = Enum.GetValues(typeof(EConcepto));
                this.Refrescar();

                this.prbBienDeUso.Value = (int)porcBienDeUso;
                this.lblBienDeUso.Text = $"Bien de Uso: %{(porcBienDeUso.ToString("0.##"))}";
                this.prbServicios.Value = (int)porcServicio;
                this.lblServicios.Text = $"Servicios: %{porcServicio.ToString("0.##")}";
                this.prbBienDeConsumo.Value = (int)porcBienDeConsumo;
                this.lblBienDeConsumo.Text = $"Bien de Consumo: %{porcBienDeConsumo.ToString("0.##")}";
                this.prbVarios.Value = (int)porcVarios;
                this.lblVarios.Text = $"Varios: %{porcVarios.ToString("0.##")}";


                Gif += ApagarGif;
                this.IntroInformes = new Task(() => this.CargarGif(token));
                IntroInformes.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Calcula el porcentaje de todas las existentes Compras por concepto
        /// </summary>
        /// <param name="concepto"></param>
        /// <returns></returns>
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
                    total = (float)((float)contadorPorConcepto / (float)this.registroContable.Compras.Count) * 100;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return total;
        }
        
        /// <summary>
        /// Calcula el Credito Fiscal de las compras de una lista dada
        /// </summary>
        /// <param name="listaFiltrada"></param>
        /// <returns></returns>
        public float CalcularCreditoFiscal(List<Compra> listaFiltrada) 
        {
            float importeFiscal = 0;
            try
            {
                
                if(listaFiltrada is not null && listaFiltrada.Count > 0)
                {
                    foreach(Compra item in listaFiltrada)
                    {
                        importeFiscal = item.Importe * item.Alicuota / 100;
                    }
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return importeFiscal;
        }

        /// <summary>
        /// Calcula el Debito Fiscal de las ventas de una lista dada
        /// </summary>
        /// <param name="listaFiltrada"></param>
        /// <returns></returns>
        public float CalcularDebitoFiscal(List<Factura> listaFiltrada)
        {
            float importeFiscal = 0;
            try
            {
                if (listaFiltrada is not null && listaFiltrada.Count > 0)
                {
                    foreach (Factura item in listaFiltrada)
                    {
                        importeFiscal = item.Importe * item.Alicuota / 100;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return importeFiscal;
        }
       
        /// <summary>
        /// En el evento presente se epondran todos los informes y estadisticas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudAño_ValueChanged(object sender, EventArgs e)
        {
            this.ActualizarVistaInformes();
        }
       
        /// <summary>
        /// Limpia los campos del formulario
        /// </summary>
        public void Refrescar()
        {
            this.lblCreditoFiscal.Text = "El crédito fiscal generado en el período seleccionado es de: $0";
            this.lblDebitoFsical.Text = "El débito fiscal generado en el período seleccionado es de: $0";
            this.lblTotalSitFiscal.Text = "El total acumulado es de: $0";
            this.lblAvisoEmergente.Visible = false;
            this.lstComprasPorConcepto.DataSource = null;
        }
       
        private void chbMes_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbMes.Enabled = !this.cmbMes.Enabled;
        }

        /// <summary>
        /// Vuelve invisible el GIF
        /// </summary>
        private void ApagarGif()
        {
            this.picGif.Visible = false;
        }
       
        /// <summary>
        /// Hilo donde se muestra el GIF Intro por una determinada cantidad de tiempo. El mismo se inicia en el evento Load del formulario
        /// </summary>
        /// <param name="cancelToken"></param>
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

        private void cmbMes_SelectedValueChanged(object sender, EventArgs e)
        {
            this.ActualizarVistaInformes();
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

        private void cmbConcepto_SelectedValueChanged(object sender, EventArgs e)
        {
            List<Compra> auxFilterListCompras = null;
            if (this.cmbConcepto.SelectedItem is not null)
            {
                if (this.chbMes.Checked == false)
                {
                    auxFilterListCompras = GestorBD.BuscarComprasSegun(this.registroContable.Usuario, (EConcepto)this.cmbConcepto.SelectedItem, this.nudAño.Value, string.Empty);

                }
                else
                {
                    auxFilterListCompras = GestorBD.BuscarComprasSegun(this.registroContable.Usuario, (EConcepto)this.cmbConcepto.SelectedItem, this.nudAño.Value, this.cmbMes.Text);
                }
                this.lstComprasPorConcepto.DataSource = null;
                this.lstComprasPorConcepto.DataSource = auxFilterListCompras;
            }
        }

        /// <summary>
        /// Actualiza los datos del informe segun el contexto
        /// </summary>
        public void ActualizarVistaInformes()
        {
            try
            {
                float auxCredFiscal = 0;
                float auxDebFiscal = 0;

                List<Compra> auxFilterListCompras = null;
                List<Factura> auxFilterListVentas = null;

                this.Refrescar();

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExportarTxt_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                List<Compra> auxFilterListCompras = new List<Compra>();
                string path;

                sb.AppendLine("**********************************************************************************************************");
                sb.AppendLine(this.registroContable.Usuario.RazonSocial);
                sb.AppendLine($"{this.registroContable.Usuario.Cuit} - {this.registroContable.Usuario.SitFiscal}");
                sb.AppendLine($"\nLista de Compras Por Concepto: {(EConcepto)this.cmbConcepto.SelectedItem}\n");
                sb.AppendLine("Fecha - Razon Social | CUIT | Situacion Fiscal - ptoVenta-nroComprobante - Total - Concepto - CUIT Receptor");

                if (this.chbMes.Checked == false)
                {
                    auxFilterListCompras = GestorBD.BuscarComprasSegun(this.registroContable.Usuario, (EConcepto)this.cmbConcepto.SelectedItem, this.nudAño.Value, string.Empty);
                    path = $"InformeCompras{this.nudAño.Value}.txt";
                }
                else
                {
                    auxFilterListCompras = GestorBD.BuscarComprasSegun(this.registroContable.Usuario, (EConcepto)this.cmbConcepto.SelectedItem, this.nudAño.Value, this.cmbMes.Text);
                    path = $"InformeCompras{this.nudAño.Value}-{this.cmbMes.Text}.txt";
                }

                foreach(Compra item in auxFilterListCompras)
                {
                    sb.AppendLine(item.MostrarDatos());
                }
                sb.AppendLine("\n**********************************************************************************************************");

                Ruta.GenerarTxt(Ruta.GenerarRuta(path), sb.ToString(), false);
                if (File.Exists(path))
                {
                    MessageBox.Show($"El txt del Informe se creó con exito.\n La direccion donde se encuentra es: {Path.GetFullPath(path)}");
                }
                else
                {
                    MessageBox.Show("No se ha podido generar el archivo txt");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("No se ha podido generar el archivo txt");
            }
        }
    }
}
