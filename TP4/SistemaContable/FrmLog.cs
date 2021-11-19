﻿using System;
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
    public partial class FrmLog : Form
    {
        private RegistroContable registro;
        private List<Ente> usuarios;
        private frmMenu menu;
        



        public FrmLog()
        {
            InitializeComponent();

        }

        private void Log_Load(object sender, EventArgs e)
        {
            cmbSitFiscal.DataSource = Enum.GetValues(typeof(ESitFiscal));
            this.usuarios = GestorBD.CargarListaUsuarios();
            this.cmbUsuarios.DataSource = this.usuarios;

            this.cmbUsuarios.Enabled = true;
            this.txtRazonSocial.Enabled = false;
            this.txtCuit.Enabled = false;
            this.cmbSitFiscal.Enabled = false;
            this.chbNuevoUsuario.Checked = false;
        }

        private void chbNuevoUsuario_CheckedChanged(object sender, EventArgs e)
        {
            this.Refrescar();
            this.cmbUsuarios.Enabled = false;
            this.txtRazonSocial.Enabled = true;
            this.txtCuit.Enabled = true;
            this.cmbSitFiscal.Enabled = true;
        }

        public void Refrescar()
        {
            this.txtRazonSocial.Text = string.Empty;
            this.txtCuit.Text = string.Empty;
            this.cmbSitFiscal.SelectedIndex = -1;
            this.cmbUsuarios.SelectedIndex = -1;
        }

        private void cmbUsuarios_SelectedValueChanged(object sender, EventArgs e)
        {
            Ente aux = (Ente)this.cmbUsuarios.SelectedItem;
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

        private void btnIngresar_Click(object sender, EventArgs e)
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
                    GestorBD.GenerarTablaVentas(usuarioElegido.RazonSocial);
                    GestorBD.GenerarTablaCompras(usuarioElegido.RazonSocial);
                    this.registro = new RegistroContable(usuarioElegido, GestorBD.CargarListaVentas(usuarioElegido),
                        GestorBD.CargarListaCompras(usuarioElegido));
                }
            }
            if(this.registro is not null)
            {
                this.menu = new frmMenu(this.registro);
                this.Visible = false;
                this.menu.ShowDialog();
            }
        }
    }
}
