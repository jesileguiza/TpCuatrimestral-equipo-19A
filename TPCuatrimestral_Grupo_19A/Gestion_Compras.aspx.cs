using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCuatrimestral_Grupo_19A
{
    public partial class Gestion_Compras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RolUsuario"] == null)
                Response.Redirect("Default.aspx");

            string rol = Session["RolUsuario"].ToString();

            if (rol != "ADMIN" && rol != "OPERADOR")
                Response.Redirect("NoAutorizado.aspx");
        }

    }
    }
