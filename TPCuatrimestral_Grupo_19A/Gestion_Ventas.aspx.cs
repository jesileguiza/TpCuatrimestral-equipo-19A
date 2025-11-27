using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Collections.Generic;

namespace TPCuatrimestral_Grupo_19A
{
    public partial class Gestion_Ventas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["RolUsuario"] == null)
                Response.Redirect("Default.aspx");

            string rol = Session["RolUsuario"].ToString();
            if (rol != "ADMIN" && rol != "OPERADOR")
                Response.Redirect("NoAutorizado.aspx");

            if (!IsPostBack)
            {
                CargarVentas();
            }
        }

        private void CargarVentas()
        {
            VentaNegocio negocio = new VentaNegocio();
            dgvVentas.DataSource = negocio.Listar();
            dgvVentas.DataBind();
        }

        protected void btnAgregarVenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("abmVentas.aspx", false);
        }

        protected void dgvVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerDetalle")
            {
                int ventaId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("detalleVentas.aspx?VentaId=" + ventaId);
            }
        }


        protected void dgvVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ventaId = dgvVentas.SelectedDataKey.Value.ToString();
            Response.Redirect("abmVentas.aspx?VentaId=" + ventaId);
        }
    }
}




