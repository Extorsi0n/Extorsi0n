using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Web.Configuration;

namespace IGPM_V0
{
    public partial class InSes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        string patron = "IGPMDB1";

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            string conectar = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection sqlConectar = new SqlConnection(conectar);
            SqlCommand cmd = new SqlCommand("ValidarUsu", sqlConectar)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Connection.Open();
            cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = tbEmailUsu.Text;
            cmd.Parameters.Add("@PassUsu", SqlDbType.VarChar, 50).Value = tbPassword.Text;
            cmd.Parameters.Add("@Patron", SqlDbType.VarChar, 50).Value = patron;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                // Obtener el IDUsuario y NombreUsu del resultado de la consulta
                int IDUsuario = Convert.ToInt32(dr["IDUsuario"]);
                string NombreUsu = dr["NombreUsu"].ToString();

                // Cerrar el DataReader y la conexión
                dr.Close();
                cmd.Connection.Close();

                // Agregar las sesiones de usuario
                Session["IDUsuario"] = IDUsuario;
                Session["NombreUsu"] = NombreUsu;

                // Redirigir a la página de inicio
                Response.Redirect("Inicio.aspx");
            }
            else
            {
                lblError.Text = "Error de Usuario o Contraseña";
            }

            cmd.Connection.Close();
        }
    }
}


