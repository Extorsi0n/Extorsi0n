using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IGPM_V0
{
    public partial class RegisSes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            string nombreUsu = tbUsuario.Text;
            string passUsu = tbPassword.Text;
            string patron = "IGPMDB1";
            string email = tbEmailUsu.Text;

            string connectionString = WebConfigurationManager.ConnectionStrings["conexion"].ConnectionString;

            // Crear la conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                connection.Open();

                // Verificar si el correo electrónico ya existe en la base de datos
                string queryVerificar = "SELECT COUNT(*) FROM Usuario WHERE Email = @Email";
                using (SqlCommand command = new SqlCommand(queryVerificar, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        // El correo electrónico ya está registrado
                        // Realizar alguna acción, como mostrar un mensaje de error
                        lblMensaje.Text = "El correo electrónico ya está registrado.";
                        return;
                    }
                }

                // Insertar el nuevo usuario en la tabla
                string queryInsertar = "INSERT INTO Usuario (NombreUsu, PassUsu, Email) VALUES (@NombreUsu, ENCRYPTBYPASSPHRASE(@Patron, @PassUsu), @Email)";
                using (SqlCommand command = new SqlCommand(queryInsertar, connection))
                {
                    command.Parameters.AddWithValue("@NombreUsu", nombreUsu);
                    command.Parameters.AddWithValue("@PassUsu", passUsu);
                    command.Parameters.AddWithValue("@Patron", patron);
                    command.Parameters.AddWithValue("@Email", email);
                    command.ExecuteNonQuery();

                    // Registro exitoso
                    // Realizar alguna acción, como redirigir a otra página
                    lblMensaje.Text = "Usuario creado existosamente";
                }
            }
        }
    }
}