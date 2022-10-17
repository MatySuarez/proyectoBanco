using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Tarjeta
    {
        public int id { get; set; }
        public Usuario titular { get; set; }
        public int numero { get; set; }
        public int codigoV { get; set; }
        public float limite { get; set; }
        public float consumos { get; set; }

        public Tarjeta()
        {

        }
        public Tarjeta(int Id, Usuario Titular, int Numero, int CodigoV, float Limite, float Consumos)
        {
            this.id = Id;
            this.titular = Titular;
            this.numero = Numero;
            this.codigoV = CodigoV;
            this.limite = Limite;
            this.consumos = Consumos;
        }
        
    }
}
