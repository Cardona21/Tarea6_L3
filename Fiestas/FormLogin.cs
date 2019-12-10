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
    public partial class FormLogin : Form
    {

        SeguridadBL _seguridad; 

        public FormLogin()
        {
            InitializeComponent();

            _seguridad = new SeguridadBL();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Usuario;
            string Contraseña;

            Usuario = textBox1.Text;
            Contraseña = textBox2.Text;

            button1.Enabled = false;
            button1.Text = "Verificar....";
            Application.DoEvents();

            var UsuarioBD = _seguridad.Autorizar(Usuario, Contraseña);

            if (UsuarioBD == null) 
            {
                Program.UsuarioLogueado = UsuarioBD;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña Incorrecta");
            }

            button1.Enabled = true;
            button1.Text = "Aceptar";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (textBox2.PasswordChar == '*')
                {
                    textBox2.PasswordChar = '\0';
                }
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && !string.IsNullOrEmpty(textBox1.Text))
            {
                textBox2.Focus();
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && !string.IsNullOrEmpty(textBox2.Text))
            {
                button1.PerformClick();
            }

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
} 
