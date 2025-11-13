using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCuatrimestral_Grupo_19A
{
    public partial class abmProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregarPROV_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = "Proveedor agregado correctamente.";
        }

        protected void btnCancelarPROV_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proveedores.aspx");
        }
    }
}