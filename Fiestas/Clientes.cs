using BL_Fiestas;
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
    public partial class Clientes : Form
    {
     
        ClientesBL _ClientesBL;
        public Clientes()
        {
            InitializeComponent();
    
            _ClientesBL = new ClientesBL();
            listaClientesBindingSource.DataSource = _ClientesBL.ObtenerCliente();
            
        }

        private void Clientes_Load(object sender, EventArgs e)
        {

        }

        private void listaClientesBindingNavigator_RefreshItems(object sender, EventArgs e)
        {
          

         

        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {

            _ClientesBL.CancelarCambios();
            DeshabilitarHabilitarBontones(true);
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("Desea Eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }
            }
        }

        private void Eliminar(int id)
        {

            var resultado = _ClientesBL.EliminarCliente(id);

            if (resultado == true)
            {
                listaClientesBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al Eliminar");
            }
        }
        private void DeshabilitarHabilitarBontones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripButtonCancelar.Visible = !valor;

        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _ClientesBL.AgregarCliente();
            listaClientesBindingSource.MoveLast();
            DeshabilitarHabilitarBontones(false);
        }

        private void listaClientesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaClientesBindingSource.EndEdit();
            var reserva = (Cliente)listaClientesBindingSource.Current;
            var resultado = _ClientesBL.GuardarCliente(reserva);

            if (resultado.Exitoso == true)
            {
                listaClientesBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBontones(true);
                MessageBox.Show("Cliente Guardada");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }
    }
}
