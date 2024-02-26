using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;  // esta libreria la utilizamos para acceder a la base de datos

namespace pVTA
{
    public partial class frmStarts : Form
    {
        string password;

        public frmStarts()
        {
            InitializeComponent();
        }

        private void frmStarts_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;  // activa las teclas de funciones
            this.Text = "Inicio de sesion";  // este texto se coloca solo cuando se ejecuta el formulario
        }

        private void frmStarts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        // ----------------------------------------------------------
        // TEXTBOX
        // ----------------------------------------------------------
        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // pregunta aqui que si la tecla que presionaste es igual a enter
            {
                e.Handled = true;   // aqui de preguntar si presionaste la tecla enter
                if (txtUsuario.Text.Trim() != string.Empty)   // aqui pregunta si el contenido del textbox es diferente de vacio
                {
                    txtPassword.Focus(); // mueve el cursor hacia el textbox llamado txtpassword
                }
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() != string.Empty)   // aqui pregunta si el contenido del textbox es diferente de vacio
            {
                BuscarUsuario(txtUsuario.Text);  // ejecuta este metodo
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // pregunta aqui que si la tecla que presionaste es igual a enter
            {
                e.Handled = true;   // aqui de preguntar si presionaste la tecla enter
                if (txtPassword.Text.Trim() != string.Empty)   // aqui pregunta si el contenido del textbox es diferente de vacio
                {
                    btnAceptar.Focus(); // mueve el cursor hacia el boton aceptar
                }
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            btnAceptar.PerformClick(); // ejecuta el evento del boton aceptar y vuelve aqui de nuevo y sale
        }

        // ----------------------------------------------------------
        // BOTONES
        // ----------------------------------------------------------
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() != string.Empty)   // aqui pregunta si el contenido del textbox es diferente de vacio
            {
                if (txtPassword.Text.Trim() != string.Empty)   // aqui pregunta si el contenido del textbox es diferente de vacio
                {
                    if (txtPassword.Text.Trim() == password)  // pregunta si son iguales
                    {
                        frmMenu frm = new frmMenu();  // asigna al objeto frm el formulario frmmenu
                        frm.Show();   // te muestra el formulario 

                        this.Hide();  // esconde el formulario y lo mantiene abierto
                    }
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit(); // este codigo cierra todos los formulario que esten abierto y cierra la aplicacion
        }

        // ----------------------------------------------------------
        // METODOS
        // ----------------------------------------------------------

        private void BuscarUsuario(string miUsuario)
        {
            SqlConnection cnx = new SqlConnection(cnn.db);  // le indicamos el stringConnection a la base de datos
            cnx.Open();   // abrimos la base datos

            string stQuery = "SELECT NOMBRECORTO, CLAVE FROM USUARIO WHERE NOMBRECORTO = @A0";

            SqlCommand cmd = new SqlCommand(stQuery, cnx);  // Le indicamos el script de sql
            cmd.Parameters.AddWithValue("@A0", miUsuario);  // declaramo una variable y le asignamos un valor que proviene del parametro de entrada
                                                            // al metodo
            SqlDataReader rcd = cmd.ExecuteReader();   // aqui ejecutamos el script de sql

            if (rcd.Read())  // verificamos si tiene data el contenedor
            {
                password = Convert.ToString(rcd["CLAVE"]);  // asignamos la data del campo a la variable
            }

            cmd.Dispose();  // descomponemos el sqlcommand
            cnx.Close();    // cierra la base de datos
        }


    }
}
