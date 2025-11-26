using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TPCuatrimestral_Grupo_19A
{
    public partial class Clientes : System.Web.UI.Page
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

                CargarClientes();
            }
        }

        protected void dgvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idSeleccionado = Convert.ToInt32(dgvClientes.SelectedDataKey.Value);
            ViewState["IdSeleccionado"] = idSeleccionado;
        }

        private void CargarClientes()
        {
            ClienteNegocio negocio = new ClienteNegocio();
            dgvClientes.DataSource = negocio.listar();
            dgvClientes.DataBind();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ViewState["IdSeleccionado"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Seleccioná un Cliente antes de eliminar.');", true);
                return;
            }

            int id = (int)ViewState["IdSeleccionado"];

            try
            {
                ClienteNegocio negocio = new ClienteNegocio();
                negocio.eliminar(id);

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Cliente eliminado correctamente.');", true);

                CargarClientes(); // recarga la grilla
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error al eliminar: {ex.Message}');", true);
            }
        }

        protected void btnDarAlta_Click(object sender, EventArgs e)
        {
            if (ViewState["IdSeleccionado"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Seleccioná un Cliente antes de dar de alta.');", true);
                return;
            }

            int id = (int)ViewState["IdSeleccionado"];

            try
            {
                ClienteNegocio negocio = new ClienteNegocio();
                negocio.darAlta(id);

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Cliente dado de alta correctamente.');", true);

                CargarClientes();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error al dar de alta: {ex.Message}');", true);
            }
        }




        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("abmCliente.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedDataKey == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Seleccioná un proveedor para modificar.');", true);
            }
            else
            {
                int idCliente = Convert.ToInt32(dgvClientes.SelectedDataKey.Value);
                Response.Redirect("abmCliente.aspx?IdCliente=" + idCliente);

            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //string filtro = txtBuscar.Text.Trim().ToLower();
            //  var filtrados = listaclientes
            //     .Where(c => c.Nombre.ToLower().Contains(filtro) || c.DNI.Contains(filtro))
            //    .ToList();

            // dgvClientes.DataSource = filtrados;
            //  dgvClientes.DataBind();
        }
    }





}

