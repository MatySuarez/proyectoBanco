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
        public int Cbu { get; set; }
        public float saldo { get; set; }
        
        public CajaDeAhorro()
        {
            misTitulares = new List<Usuario>();
            misMovimientos = new List<Movimiento>();
        }
        public CajaDeAhorro(int id, int Cbu, float saldo)
        {            
            this.id = id;
            this.Cbu = Cbu;
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
    }
}
