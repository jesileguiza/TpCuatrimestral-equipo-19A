using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCuatrimestral_Grupo_19A
{
    public partial class MasterComercio : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();        // borra datos de sesión
            Session.Abandon();      // destruye la sesión
            Response.Cache.SetNoStore(); // evita volver atrás con el navegador

            Response.Redirect("Default.aspx"); // ajustá al nombre real de tu página de login
        }


    }
}