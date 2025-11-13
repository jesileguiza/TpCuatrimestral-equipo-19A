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

        protected void dgvProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Guarda el ID del proveedor seleccionado en el ViewState
            int idSeleccionado = Convert.ToInt32(dgvProveedores.SelectedDataKey.Value);
            ViewState["IdSeleccionado"] = idSeleccionado;
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            Response.Redirect("agregarProveedor.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            // Acá la lógica para modificar un proveedor
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Botón Modificar presionado');", true);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            // Acá la lógica para modificar un proveedor
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Botón Modificar presionado');", true);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ViewState["IdSeleccionado"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Seleccioná un proveedor antes de eliminar.');", true);
                return;
            }

            int id = (int)ViewState["IdSeleccionado"];

            try
            {
                ProveedorNegocio negocio = new ProveedorNegocio();
                negocio.eliminar(id);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Proveedor eliminado correctamente.');", true);
                CargarProveedores();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error al eliminar: {ex.Message}');", true);
            }
        }
    }
}