using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IGPM_V0
{
    public partial class Gestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnAgreEmp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GestionEmp/AgreEmp.aspx");
        }

        protected void btnEmpresas_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/GestionEmp/Empresas.aspx");
        }
    }
}