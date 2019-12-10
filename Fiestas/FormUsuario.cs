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
    public partial class FormUsuario : Form
    {
        SeguridadBL _seguridadBL;

        public FormUsuario()
        {
            InitializeComponent();
            _seguridadBL = new SeguridadBL();
            usuarioBindingSource.DataSource = _seguridadBL.ObtenerUsuario();
          
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _seguridadBL.AgregarReserva();
            usuarioBindingSource.MoveLast();
            DesHabilitarHabilitarBotones(false);
        }

        private void DesHabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripLabelCancelar.Visible = !valor;

        }
        private void usuarioBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void usuarioBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            usuarioBindingSource.EndEdit();
            var usuario = (Usuario)usuarioBindingSource.Current;



           

            var resultado = _seguridadBL.GuardarUsuario(usuario);

            if (resultado.Exitoso == true)
            {
                usuarioBindingSource.ResetBindings(false);
                DesHabilitarHabilitarBotones(true);
                MessageBox.Show("Usuario Guardado");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }

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

            var resultado = _seguridadBL.EliminarUsuario(id);

            if (resultado == true)
            {
               usuarioBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurio un ERROR al eliminar el Usuario");
            }
        }
    }
}
