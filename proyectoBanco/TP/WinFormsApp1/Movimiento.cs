using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Movimiento
    {
        public int id { get; set; }
        public CajaDeAhorro caja { get; set; }
        public string detalle { get; set; }
        public float monto { get; set; }
        public DateTime fecha { get; set; }

        public Movimiento() { }
        public Movimiento(int Id, CajaDeAhorro Caja, string Detalle, float Monto, DateTime Fecha)
        {
            this.id = Id;
            this.caja = Caja;
            this.detalle = Detalle;
            this.monto = Monto;
            this.fecha = Fecha;
        }
    }
}
