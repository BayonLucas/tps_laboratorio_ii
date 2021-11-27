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
    public partial class FrmInformes : Form
    {
        private RegistroContable registroContable;



        public FrmInformes() : this(null)
        {
            
        }
        public FrmInformes(RegistroContable registroContable)
        {
            this.registroContable = registroContable;
            InitializeComponent();
        }

        private void FrmInformes_Load(object sender, EventArgs e)
        {
            this.nudAño.Minimum = (decimal.Parse(DateTime.Now.Year.ToString()) - 10);
            this.nudAño.Maximum = (decimal.Parse(DateTime.Now.Year.ToString()));
            this.cmbConcepto.DataSource = Enum.GetValues(typeof(EConcepto));
            
        }


        public int CarcularPorcentaje(string concepto, int año)
        {
            int contadorPorConcepto = 0;
            int contadorPorAnio = 0;
            int total = 0;
            if(!string.IsNullOrEmpty(concepto) && año >= this.nudAño.Minimum)
            {

                foreach(Compra item in this.registroContable.Compras)
                {
                    if(item.Fecha.Year == año)
                    {
                        contadorPorAnio++;
                    }
                    if(concepto == item.Concepto.ToString() && item.Fecha.Year == año)
                    {
                        contadorPorConcepto++;
                    }
                }
                total = contadorPorConcepto / contadorPorAnio * 100; 

            }
            return total;
        }
















        private void nudAño_ValueChanged(object sender, EventArgs e)
        {
            //Aca yo implementaría el evento que actualizaría todo

            //Busqueda en SQL compras segun concepto
            this.prbBienDeUso.Value = this.CarcularPorcentaje(EConcepto.Bien_de_uso.ToString(), int.Parse(this.nudAño.Value.ToString()));
            this.prbServicios.Value = this.CarcularPorcentaje(EConcepto.Servicio.ToString(), int.Parse(this.nudAño.Value.ToString()));
            this.prbBienDeConsumo.Value = this.CarcularPorcentaje(EConcepto.Bien_de_consumo.ToString(), int.Parse(this.nudAño.Value.ToString()));
            this.prbVarios.Value = this.CarcularPorcentaje(EConcepto.Varios.ToString(), int.Parse(this.nudAño.Value.ToString()));
            //Credito Fiscal (Ventas)
            //Debito Fiscal (Compras)
            //


        }
    }
}
