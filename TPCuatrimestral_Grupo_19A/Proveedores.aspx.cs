using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCuatrimestral_Grupo_19A
{
    public partial class Proveedores : Page
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


            if (!IsPostBack)
            {
                CargarProveedores();
            }
        }

        private void CargarProveedores()
        {
            ProveedorNegocio negocio = new ProveedorNegocio();
            dgvProveedores.DataSource = negocio.listar();
            dgvProveedores.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("abmProveedor.aspx",false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedDataKey == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Seleccioná un proveedor para modificar.');", true);
            }
            else
            {
            int idProveedor = Convert.ToInt32(dgvProveedores.SelectedDataKey.Value);
            Response.Redirect("abmProveedor.aspx?IdProveedor=" + idProveedor);

            }
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (ViewState["IdSeleccionado"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Seleccioná un proveedor antes de Dar de alta.');", true);
                return;
            }

            int id = (int)ViewState["IdSeleccionado"];

            try
            {
                ProveedorNegocio negocio = new ProveedorNegocio();
                negocio.darAlta(id);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Proveedor dado de alta correctamente.');", true);
                CargarProveedores();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error al dar de alta: {ex.Message}');", true);
            }
        }

        protected void Filtro_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        protected void dgvProveedores_SelectedIndexChanged1(object sender, EventArgs e)
        {

            int IdProveedor = Convert.ToInt32(dgvProveedores.SelectedDataKey.Value);
            Response.Redirect("abmProveedor.aspx?IdProveedor=" + IdProveedor);
        }

        protected void btnAgregar_Click1(object sender, EventArgs e)
        {
            Response.Redirect("abmProveedor.aspx", false);
        }
    }
}