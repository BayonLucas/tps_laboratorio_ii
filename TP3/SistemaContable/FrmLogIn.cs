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
    public partial class FrmLogIn : Form
    {

        private RegistroContable registro;
        public FrmLogIn(RegistroContable registro)
        {
            InitializeComponent();
             this.registro = registro;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            cmbSitFiscal.DataSource = Enum.GetValues(typeof(ESitFiscal));
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            
            this.registro.Usuario = new Ente(txtRazonSocial.Text, txtCuit.Text, (ESitFiscal)cmbSitFiscal.SelectedItem);
            
            this.Close();

        }
    }
}
