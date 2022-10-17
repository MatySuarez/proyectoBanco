using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class PlazoFijo
    {
        public int id { get; set; }
        public Usuario titular { get; set; }
        public float monto { get; set; }
        public DateTime fechaIni { get; set; }
        public DateTime fechaFin { get; set; }
        public float tasa { get; set; }
        public bool pagado { get; set; }


        public PlazoFijo() { }
        public PlazoFijo(int Id, Usuario Titular, float Monto, DateTime FechaIni, DateTime FechaFin, float Tasa, bool Pagado)
        {
            this.id = Id;
            this.titular = Titular;
            this.monto = Monto;
            this.fechaIni = FechaIni;
            this.fechaFin = FechaFin;
            this.tasa = Tasa;
            this.pagado = Pagado;
        }
    }
}
