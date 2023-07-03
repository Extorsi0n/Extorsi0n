using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IGPM_V0
{
    public partial class CerrarSes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
                // Limpia los datos de sesión
                Session["IDUsuario"] = null;
                Session["NombreUsu"] = null;

                // Redirecciona a la página de inicio
                Response.Redirect("Inicio.aspx");
            
        }
    }
}