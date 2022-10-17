﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Pago
    {
        public int id { get; set; }
        public Usuario user { get; set; }
        public string nombre { get; set; }
        public float monto { get; set; }
        public bool pagado { get; set; }
        public string metodo { get; set; }

        public Pago() { }
        public Pago(int Id, Usuario User, string Nombre, float Monto, bool Pagado, string Metodo)
        {
            this.id = Id;
            this.user = User;
            this.nombre = Nombre;
            this.monto = Monto;
            this.pagado = Pagado;
            this.metodo = Metodo;
        }
    }
}
