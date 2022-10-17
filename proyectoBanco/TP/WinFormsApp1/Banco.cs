using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public class Banco
    {
        private List<Usuario> misUsuarios;
        private List<CajaDeAhorro> misCajasDeAhorro;       
        private List<Pago> misPagos;
        private List<Movimiento> misMovimientos;
        private Usuario usuarioLogueado;

        public Banco()
        {
            this.misUsuarios = new List<Usuario>();
            this.misCajasDeAhorro = new List<CajaDeAhorro>();
            this.misPagos = new List<Pago>();
            this.misMovimientos = new List<Movimiento>();  
            
        }

        public bool agregarUsuario(int Dni, string Nombre, string Apellido, string Email, string Password)
        {
            try
            {
                if (Password.Length < 8)
                    return false;
                else
                {
                    misUsuarios.Add(new Usuario(Dni, Nombre, Apellido, Email, Password));
                    int usuarioId = (this.misUsuarios.Count) + 1;
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool eliminarUsuario(int id)
        {
            try
            {
                int idUsuario = this.misUsuarios.FindIndex(u => u.id == id);

                Usuario usuarioLogueado = this.misUsuarios[idUsuario];
                misUsuarios.Remove(usuarioLogueado);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool modificarUsuario(int id, int dni, string email, string password, string nombre, string apellido)
        {
            try
            {
                int idUsuario = this.misUsuarios.FindIndex(u => u.id == id);

                Usuario usuarioLogueado = this.misUsuarios[idUsuario];
                usuarioLogueado.dni = dni;
                usuarioLogueado.email = email;
                usuarioLogueado.password = password;
                usuarioLogueado.nombre = nombre;
                usuarioLogueado.apellido = apellido;
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public List<Usuario> obtenerUsuarios()
        {
            return misUsuarios.ToList();
        }

        // AGREGAR DATOS
        public bool altaCajaAhorro(Usuario usuario)
        {
            try
            {
                int idUsuario = this.misUsuarios.FindIndex(u => u.id == usuario.id);
                usuarioLogueado = this.misUsuarios[idUsuario];

                int idCajaAhorro = (this.misCajasDeAhorro.Count) + 1;
                CajaDeAhorro cajaDeAhorro = this.misCajasDeAhorro[idCajaAhorro];

                this.misCajasDeAhorro.Add(cajaDeAhorro);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool bajaCajaAhorro(int id)
        {
            try
            {
                int idCaja = this.misCajasDeAhorro.FindIndex(c => c.id == id);

                CajaDeAhorro cajaDeAhorro = this.misCajasDeAhorro[idCaja];
                this.misCajasDeAhorro.Remove(cajaDeAhorro);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool modificarCajaAhorro(int idDeCaja, int dniUsuario, int opcion)
        {
            try
            {
                if (opcion != 1 && opcion != 2) return false; //opcion 1 agregar , opcion 2 eliminar

                int idCaja = this.misCajasDeAhorro.FindIndex(c => c.id == idDeCaja);

                CajaDeAhorro CajaDeAhorroActual = this.misCajasDeAhorro[idDeCaja];

                int idUsuario = this.misUsuarios.FindIndex(u => u.dni == dniUsuario);
                Usuario usuarioActual = this.misUsuarios[idUsuario];

                if (opcion == 1)
                {
                    if (!CajaDeAhorroActual.agregarTitular(usuarioActual)) return false;
                    if (!usuarioActual.agregarCajaDeAhorro(CajaDeAhorroActual)) return false;
                }
                else if (opcion == 2)
                {

                    if (this.usuarioLogueado.id == usuarioActual.id) return false;
                    if (!CajaDeAhorroActual.eliminarTitular(usuarioActual)) return false;
                    if (!usuarioActual.eliminarCajaDeAhorro(CajaDeAhorroActual)) return false;
                }


                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }
        public bool altaMovimiento(Movimiento mov, CajaDeAhorro caja)
        {
            try
            {
                int idCajaDeAhorro = this.misCajasDeAhorro.FindIndex(cajaDeAhorro => cajaDeAhorro.id == caja.id);

                int idMovimiento = (this.misMovimientos.Count) + 1;
                Movimiento movimiento = new Movimiento(mov.id, caja, mov.detalle, mov.monto, mov.fecha);
                caja.agregarMovimiento(movimiento);
                this.misMovimientos.Add(movimiento);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool altaPago(Pago pago, int usuarioId)
        {
            try
            {
                int idUsuario = this.misUsuarios.FindIndex(usuario => usuario.id == usuarioId);

                Usuario usuarioLogueado = this.misUsuarios[idUsuario];

                int idPago = (this.misPagos.Count) + 1;
                Pago pagoActual = new Pago(idPago, usuarioLogueado, pago.nombre, pago.monto, pago.pagado, pago.metodo);
                if (!usuarioLogueado.agregarPago(pagoActual)) return false;

                this.misPagos.Add(pagoActual);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool bajaPago(int pagoId)
        {
            try
            {
                int idPago = this.misPagos.FindIndex(p => p.id == pagoId);

                Pago pagoActual = this.misPagos[idPago];
                this.misPagos.Remove(pagoActual);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool modificarPago(int pagoId, string nombre, float monto, bool pagado)
        {
            try
            {
                int idPago = this.misPagos.FindIndex(pago => pago.id == pagoId);

                Pago pagoActual = this.misPagos[idPago];
                pagoActual.pagado = pagado;
                pagoActual.monto = monto;
                pagoActual.nombre = nombre;

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public string getNombreUsuarioLogueado()
        {
            return this.usuarioLogueado.nombre.ToString();
        }

        // Mostrar Datos
        public List<CajaDeAhorro> mostrarCajasDeAhorro()
        {
            return usuarioLogueado.misCajasDeAhorro.ToList();
        }
        
       public List<Movimiento> mostrarMovimientos(CajaDeAhorro cajaDeAhorro)
        {
            return cajaDeAhorro.misMovimientos.ToList();
        }
        public List<Movimiento> mostrarMovimientos(string Cbu)
        {
            foreach(CajaDeAhorro caja in usuarioLogueado.misCajasDeAhorro)
                {
                if(caja.Cbu == Cbu)
                {
                    return caja.misMovimientos.ToList();
                }
            }
            return null;
        }
        public List<Pago> mostrarPagos()
        {
            return usuarioLogueado.misPagos.ToList();
        }

        // Operaciones?
        public bool iniciarSesion(string email, string password)
        {
            try
            {
                int usuarioId = this.misUsuarios.FindIndex(u => u.email == email);

                Usuario usuarioLogueado = this.misUsuarios[usuarioId];
                if (usuarioLogueado.bloqueado) return false;

                if (usuarioLogueado.password != password)
                {
                    usuarioLogueado.errorInicio();
                    return false;
                }
                this.usuarioLogueado = usuarioLogueado;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool cerrarSesion()
        {
            try
            {
                this.usuarioLogueado = null;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void agregarCaja(CajaDeAhorro CajaNueva)
        {
            this.misCajasDeAhorro.Add(CajaNueva);
        }
        public void borrarCaja(CajaDeAhorro CajaABorrar)
        {
            this.misCajasDeAhorro.Remove(CajaABorrar);
        }
        public bool crearCajaAhorro(Usuario usuarioLogueado)
        {
            try
            {
                CajaDeAhorro cajaNueva = new CajaDeAhorro();
                cajaNueva.id = (this.misCajasDeAhorro.Count) + 1;
                usuarioLogueado.agregarCajaDeAhorro(cajaNueva);
                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }     
        public bool depositar(CajaDeAhorro caja, float monto)
        {
            try {
            int idCajaDeAhorro = this.misCajasDeAhorro.FindIndex(c => c.id == caja.id);
            CajaDeAhorro cajaActual = this.misCajasDeAhorro[idCajaDeAhorro];
            if (!cajaActual.depositarMonto(monto)) return false;
            return true;
            }
            catch (Exception ex){
                return false;
            }
        }
        public bool retirar(CajaDeAhorro caja, float monto)
        {
            try { 
            int idCajaDeAhorro = this.misCajasDeAhorro.FindIndex(c => c.id == caja.id);
            CajaDeAhorro cajaActual = this.misCajasDeAhorro[idCajaDeAhorro];
            if (!cajaActual.retirarMonto(monto)) return false;
            return true;
            }
            catch(Exception ex){
                return false;
            }
        }
        public bool transferir(CajaDeAhorro cajaOrigen, CajaDeAhorro cajaDestino, float monto)
        {
            try
            {
                int idCajaDestino = this.misCajasDeAhorro.FindIndex(c => c.id == cajaDestino.id);
                CajaDeAhorro cajaDestinoo = this.misCajasDeAhorro[idCajaDestino];
                if(!cajaOrigen.retirarMonto(monto)) return false;
                cajaDestinoo.depositarMonto(monto);
                return true;
            }
            catch (Exception ex){
                return false;
            }
        }
        public bool buscarMovimiento(CajaDeAhorro caja, String detalle, DateTime fecha, float monto)
        {
            return true;
        }

        internal IEnumerable<Usuario> obtenerCajaDeAhorro()
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<CajaDeAhorro> mostrarCajaDeAhorro()
        {
            throw new NotImplementedException();
        }
    }
}
