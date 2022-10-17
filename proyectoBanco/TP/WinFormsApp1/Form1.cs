using System.Configuration;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Banco banco;
        Form2 hijoLogin;
        Form3 hijoMain;
        internal string texto;
        string email;
        string password;
        bool logueado;
        public bool touched;
        public Form1()
        {
            InitializeComponent();
            banco = new Banco();
            logueado = false;
            hijoLogin = new Form2(banco);
            hijoLogin.logueado = false;
            hijoLogin.MdiParent = this;
            hijoLogin.TransfEvento += TransfDelegado;
            hijoLogin.Show();
            touched = false;
        }
        private void TransfDelegado(string Email, string Pass)
        {
            this.email = Email;
            this.password = Pass;
            if (banco.iniciarSesion(email,password))
            {
                MessageBox.Show("Usuario logueado, email: " + email, "titulo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hijoLogin.Close();
                hijoMain = new Form3(new object[] { email,banco });
                hijoMain.email = Email;
                hijoMain.MdiParent = this;
                hijoMain.Show();
            }
            else
            {
                MessageBox.Show("Inicio de sesion incorrecto", "titulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                hijoLogin.Show();
            }

        }
    }
}