using BL_Fiestas;
using Fiestas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fiestas
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void resarvasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formLogin = new FormLogin();
            formLogin.ShowDialog();

            if (Program.UsuarioLogueado != null)
            {
                toolStripStatusLabel1.Text = "Usuario: " + Program.UsuarioLogueado.Nombre;

            }
            else
            {
                Application.Exit();
            }

            
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mesasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formgaleria = new FormGaleria();
            formgaleria.ShowDialog();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            var formLogin = new FormLogin();
            formLogin.ShowDialog();
        }

        private void contratoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mesasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var formReservar = new Inventario();
            formReservar.ShowDialog();
        }

        private void politicasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formPolitica = new Politicas();
            formPolitica.ShowDialog();
        }

        private void contratoFinalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formContrato = new Contrato();
           formContrato.ShowDialog();
        }

        private void sociosToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formClientes = new Clientes();
           formClientes.ShowDialog();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var ReporteCliente = new ReporteCliente();
           ReporteCliente.ShowDialog();
        }

        private void sociosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var reporteInventario = new FromReporteInventario();
            reporteInventario.MdiParent = this;
            reporteInventario.Show();
        }

        private void reservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var reporteFactura = new FormReporteFactura();
            reporteFactura.MdiParent = this;
            reporteFactura.Show();
        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formFactura = new FormFactura();
            formFactura.ShowDialog();
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        private void registrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formUsuario = new FormUsuario();
            formUsuario.ShowDialog();
        }
    }
}
