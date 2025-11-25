using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCuatrimestral_Grupo_19A
{
    public partial class AboutUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RolUsuario"] == null)
                Response.Redirect("Default.aspx?error=sesion");

            string rol = Session["RolUsuario"].ToString();

            if (rol != "ADMIN")
            {
                string script = @"
            Swal.fire({
                icon: 'error',
                title: 'Acceso denegado',
                text: 'No estás autorizado para acceder a esta sección.',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.isConfirmed) {
                    window.location.href = 'Gestion_Ventas.aspx';
                }
            });
             ";

                ClientScript.RegisterStartupScript(this.GetType(), "NoAutorizado", script, true);

            }



        }
    }
}
