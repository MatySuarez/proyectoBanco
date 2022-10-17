using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public bool logueado;
        public string email;
        public string password;
        public Banco elBanco;

        public TransfDelegado TransfEvento;
        public Form2(Banco b)
        {
            logueado = false;
            InitializeComponent();
            elBanco = b;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            email = textBox1.Text;
            password = textBox4.Text;
            if (email != null && password != "")
            {
                this.TransfEvento(email, password);
            }
            else
                MessageBox.Show("Debe ingresar un usuario!");

        }
        public delegate void TransfDelegado(string email, string pass);

        private void button4_Click(object sender, EventArgs e)
        {
            if(elBanco.agregarUsuario(int.Parse(textBox2.Text), textBox3.Text, textBox5.Text, textBox6.Text, textBox7.Text))
                MessageBox.Show("Usuario agregado");
            else
                MessageBox.Show("No se pudo agregar al usuario");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
