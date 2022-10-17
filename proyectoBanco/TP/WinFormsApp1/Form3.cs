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
    public partial class Form3 : Form
    {
        public object[] argumentos;
        List<List<string>> datos;
        public string email;
        public Banco miBanco;
        public Form3(string email, Banco b)
        {
            this.miBanco = b;
            this.email = email;
        }
        public Form3(object[] args)
        {
            InitializeComponent();
            miBanco = (Banco)args[1];
            argumentos = args;
            label2.Text = (string)args[0];
            datos = new List<List<string>>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        private void refreshData()
        {            
            dataGridView1.Rows.Clear();            
            //foreach (CajaDeAhorro caja in this.miBanco.mostrarCajaDeAhorro())
                dataGridView1.Rows.Add(caja.toArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void agregarCaja_Click(object sender, EventArgs e)
        {
            refreshData();
            dataGridView1.Rows.Clear();
            //agrego lo nuevo
            //foreach (Usuario user in miBanco.obtenerCajaDeAhorro())
                dataGridView1.Rows.Add(user.toArray());
        }
        /*Metodo crear caja que hicieron en otro grupo. crearCaja esta en Banco
        private void confirmar_Click(object sender, EventArgs e)
        {
            Cbu = int.Parse(Cbu.Text);
            saldoCaja = float.Parse(Saldo.Text);
            Banco.crearCajaDeAhorro(cbuCaja, saldoCaja);
        }
        */
    }
}
