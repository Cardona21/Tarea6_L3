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
    public partial class FormGaleria : Form
    {
        Double A;
        public FormGaleria()
        {
            InitializeComponent();
        }

        private void FormGaleria_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            A = A + 1;
            if (A == 2)
            {
                Presentar.Image = pictureBox16.Image;
            }
            else
            {
                if (A == 3)
                {
                    Presentar.Image = pictureBox1.Image;
            }
                else
                {
                    if (A == 4)
                    {
                        Presentar.Image = pictureBox2.Image;
                }
                    else
                    {
                        if (A == 5)
                        {
                            Presentar.Image = pictureBox5.Image;
                    }
                        else
                        {
                            if (A == 6)
                            {
                                Presentar.Image = pictureBox6.Image;
                            }
                            else
                            {
                                if (A == 7)
                                {
                                    Presentar.Image = pictureBox7.Image;
                                }
                                else
                                {
                                    if (A == 8)
                                    {
                                        Presentar.Image = pictureBox8.Image;
                                    }
                                    else
                                    {
                                        if (A == 9)
                                        {
                                            Presentar.Image = pictureBox9.Image;
                                        }
                                        else
                                        {
                                            if (A == 10)
                                            {
                                                Presentar.Image = pictureBox10.Image;
                                            }
                                            if (A == 11)
                                            {
                                                Presentar.Image = pictureBox11.Image;
                                            }
                                            else
                                            {
                                                if (A == 12)
                                                {
                                                    Presentar.Image = pictureBox12.Image;
                                                }
                                                else
                                                {
                                                    if (A == 13)
                                                    {
                                                        Presentar.Image = pictureBox13.Image;
                                                    }
                                                    else
                                                    {
                                                        if (A == 14)
                                                        {
                                                            Presentar.Image = pictureBox14.Image;
                                                        }
                                                        else
                                                        {
                                                            if (A == 15)
                                                            {
                                                                Presentar.Image = pictureBox15.Image;
                                                            }
                                                            else
                                                            {
                                                                if (A == 16)
                                                                {
                                                                    Presentar.Image = pictureBox18.Image;
                                                                }
                                                                else
                                                                {
                                                                    if (A == 17)
                                                                    {
                                                                        Presentar.Image = pictureBox17.Image;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (A == 18)
                                                                        {
                                                                            Presentar.Image = pictureBox3.Image;
                                                                        }
                                                                    }
                                                                    if (A == 19)
                                                                    {
                                                                        Presentar.Image = pictureBox4.Image;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (A == 20)
                                                                        {
                                                                            Presentar.Image = pictureBox19.Image;
                                                                        }
                                                                        else
                                                                        {
                                                                            if (A == 21)
                                                                            {
                                                                                Presentar.Image = pictureBox20.Image;
                                                                            }
                                                                            else
                                                                            {
                                                                                if (A == 22)
                                                                                {
                                                                                    Presentar.Image = pictureBox21.Image;
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (A == 23)
                                                                                    {
                                                                                        Presentar.Image = pictureBox22.Image;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (A == 24)
                                                                                        {
                                                                                            Presentar.Image = pictureBox23.Image;
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (A == 25)
                                                                                            {
                                                                                                Presentar.Image = pictureBox24.Image;
                                                                                            }
                                                                                            if (A == 26)
                                                                                            {
                                                                                                Presentar.Image = pictureBox25.Image;
                                                                                            }
                                                                                            if (A == 27)
                                                                                            {
                                                                                                A = 1;
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {

        }

        private void Reproducir_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled=false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }

}