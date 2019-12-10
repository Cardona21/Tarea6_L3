using BL_Fiestas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BL_Fiestas.ReservaBL;

namespace Fiestas
{
    public partial class Inventario : Form
    {
           ReservaBL _Reservas;
        CategoriaBL _Categorias;
          

        public Inventario()
        {
            InitializeComponent();

            _Reservas = new ReservaBL();
            listaReservaBindingSource.DataSource = _Reservas.ObtenerReservas();

            _Categorias = new CategoriaBL();  
            listaCategoriaBindingSource.DataSource = _Categorias.ObtenerCategoria();

            

        }

        private void listaReservaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaReservaBindingSource.EndEdit();
            var reserva = (BL_Fiestas.Reserva)listaReservaBindingSource.Current;

            if (fotoPictureBox.Image != null)
            {
                reserva.Foto = Program.imageToByteArray(fotoPictureBox.Image);
            }
            else
            {
                reserva.Foto = null;
            }
            var resultado = _Reservas.GuardarResrva(reserva);


            if (resultado.Exitoso == true)
            {
                listaReservaBindingSource.ResetBindings(false);
                DesHabilitarHabilitarBotones(true);
                MessageBox.Show("Inventario Guardado Exitosamente");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
          
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _Reservas.AgregarReserva();
            listaReservaBindingSource.MoveFirst();

            DesHabilitarHabilitarBotones(false );

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
            toolStripButtonCancelar.Visible = !valor;

        }
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

           
            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("Desea eliminar esta registro", "Eliminado", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }

            }
        }

        private void Eliminar(int id)
        {
          
            var resultado = _Reservas.EliminarResrva(id);

            if (resultado == true)
            {
                listaReservaBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurio un ERROR al eliminar el producto");
            }
        }

       

        private void FormReservar_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fotoLabel_Click(object sender, EventArgs e)
        {

        }

        private void fotoPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var reserva = (BL_Fiestas.Reserva)listaReservaBindingSource.Current;
            if (reserva != null)
            {
                openFileDialog1.ShowDialog();
                var archivo = openFileDialog1.FileName;

                if (archivo != "")
                {
                    var fileInfo = new FileInfo(archivo);
                    var fileStream = fileInfo.OpenRead();

                    fotoPictureBox.Image = Image.FromStream(fileStream);
                }

            }
            else
            {
                MessageBox.Show("Crea una Reserva antes de agregar la imagen");
            }
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            fotoPictureBox.Image = null;
        }

        private void listaReservaBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            listaReservaBindingSource.EndEdit();
            var reserva = (BL_Fiestas.Reserva)listaReservaBindingSource.Current;



            if (fotoPictureBox.Image != null)
            {
                reserva.Foto = Program.imageToByteArray(fotoPictureBox.Image);
            }
            else
            {
                reserva.Foto = null;
            }

            var resultado = _Reservas.GuardarResrva(reserva);

            if (resultado.Exitoso == true)
            {
                listaReservaBindingSource.ResetBindings(false);
                DesHabilitarHabilitarBotones(true);
                MessageBox.Show("Inventario Guardado");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        
    }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            _Reservas.CancelarCambios();
            DesHabilitarHabilitarBotones(true);
           
        }

        private void tipoIdComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tipoIdLabel_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorDeleteItem_Click_1(object sender, EventArgs e)
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

        private void bindingNavigatorAddNewItem_Click_1(object sender, EventArgs e)
        {
            _Reservas.AgregarReserva();
            listaReservaBindingSource.MoveLast();
            DesHabilitarHabilitarBotones(false);
        }

        private void toolStripButtonCancelar_Click_1(object sender, EventArgs e)
        {

            _Reservas.CancelarCambios();
            DesHabilitarHabilitarBotones(true);
        }

        private void precioLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var buscar = textBox1.Text;
            if (string.IsNullOrEmpty(buscar) == true)
            {
                listaReservaBindingSource.DataSource = _Reservas.ObtenerReservas();
            }
            else
            {
                listaReservaBindingSource.DataSource = _Reservas.ObtenerReservas(buscar);
            }
            listaReservaBindingSource.ResetBindings(false);




        }
    }
}
