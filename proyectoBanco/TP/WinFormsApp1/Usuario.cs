using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Usuario
    {
        public List<CajaDeAhorro> misCajasDeAhorro;
        public List<PlazoFijo> misPlazosFijos;
        public List<Tarjeta> misTarjetas;
        public List<Pago> misPagos;

        public int id { get; set; }
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int intentosFallidos { get; set; }
        public bool bloqueado { get; set; }



        /* No estoy seguro si aca se ponia getter y setter de la lista o eso se hacia en banco
         * public List<CajaDeAhorro> cajas { get; set; }
        public List<PlazoFijo> plazosFijos { get; set; }
        public List<Tarjeta> tarjetas { get; set; }
        public List<Pago> pagos { get; set; }
        */

        public Usuario()
        {
            misCajasDeAhorro = new List<CajaDeAhorro>();
            misPlazosFijos = new List<PlazoFijo>();
            misPagos = new List<Pago>();
            misTarjetas = new List<Tarjeta>();
        }
        public Usuario(string Nombre, string Apellido, int Id, int Dni, string Password, string Email)
        {
            this.nombre = Nombre;
            this.apellido = Apellido;
            this.id = Id;
            this.dni = Dni;
            this.email = Email;
            this.password = Password;
            this.intentosFallidos = 0;
            this.bloqueado = false;
        }

        public Usuario(int dni, string nombre, string apellido, string email, string password)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.password = password;
        }

        public bool agregarCajaDeAhorro(CajaDeAhorro cajaDeAhorro)
        {

            this.misCajasDeAhorro.Add(cajaDeAhorro);
            return true;

        }

        public bool eliminarCajaDeAhorro(CajaDeAhorro cajaDeAhorro)
        {
            this.misCajasDeAhorro.Remove(cajaDeAhorro);
            return true;

        }

        public bool agregarPago(Pago pago)
        {
            this.misPagos.Add(pago);
            return true;
        }
        public void errorInicio()
        {
            this.intentosFallidos++;
            if (this.intentosFallidos == 3)
            {
                this.bloqueado = true;
            }
        }
    }
}
