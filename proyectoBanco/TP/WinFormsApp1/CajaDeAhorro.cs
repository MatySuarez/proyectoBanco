using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class CajaDeAhorro
    {
        public List<Usuario> misTitulares { get; set; }
        public List<Movimiento> misMovimientos { get; set; }
        public int id { get; set; }
        public string Cbu { get; set; }
        public float saldo { get; set; }
        
        public CajaDeAhorro()
        {
            misTitulares = new List<Usuario>();
            misMovimientos = new List<Movimiento>();
            this.Cbu = this.crearCBU();
            this.saldo = 0;
        }
        public CajaDeAhorro(int id)
        {
            this.id = id;
            this.Cbu = this.crearCBU();
            this.saldo = 0;
        }
        public bool agregarTitular(Usuario usuario)
        {          
            misTitulares.Add(usuario);
            return true;
        }

        public bool eliminarTitular(Usuario usuario)
        {            
            misTitulares.Remove(usuario);
            return true;
        }

        public bool agregarMovimiento(Movimiento movimiento)
        {
            misMovimientos.Add(movimiento);
            return true;
        }
        public bool depositarMonto(float monto)
        {
            this.saldo += monto;
            return true;
        }
        public bool retirarMonto(float monto)
        {
            if(saldo < monto) return false;
            saldo -= monto;
            return true;
        }
        private string crearCBU()
        {
            string cbu = "0";
            Random num = new Random();
            for (int i = 0; i < 5; i++)
            {
                cbu += num.Next(0, 9999);
            }
            while (cbu.Length < 22)
            {
                cbu = "0" + cbu;
            }
            return cbu;
        }

        internal object[] toArray()
        {
            throw new NotImplementedException();
        }
    }
}
