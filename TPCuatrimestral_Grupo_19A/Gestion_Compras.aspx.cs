using Negocio;
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


            if (!IsPostBack)
            {
                CargarCompras();
            }

        }

        protected void btnAgregarCompra_Click(object sender, EventArgs e)
        {
            Response.Redirect("abmCompras.aspx", false);
        }

        protected void DgvCompras_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CompraId = dgvCompras.SelectedDataKey.Value.ToString();
            Response.Redirect("abmCompras.aspx?CompraId=" + CompraId);
        }

        private void CargarCompras()
        {
            CompraNegocio negocio = new CompraNegocio();
            dgvCompras.DataSource = negocio.listar();
            dgvCompras.DataBind();
        }

    }
}
