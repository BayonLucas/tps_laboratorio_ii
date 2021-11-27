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
    }
}
