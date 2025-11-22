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
                Response.Redirect("Default.aspx");

            string rol = Session["RolUsuario"].ToString();

            if (rol != "ADMIN")
                Response.Redirect("NoAutorizado.aspx");



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
            dgvClientes.DataSource = negocio.Listar();
            dgvClientes.DataBind();
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
                ClienteNegocio negocio = new ClienteNegocio();
                negocio.eliminar(id);

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Proveedor eliminado correctamente.');", true);

                CargarClientes(); // recarga la grilla
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error al eliminar: {ex.Message}');", true);
            }
        }




        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("abmCliente.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            // if (listaclientes.Any())
            // {
            //  listaclientes[0].Nombre += " (Modificado)";
            //  CargarClientes();
            //     ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Cliente modificado correctamente');", true);
            // }
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

