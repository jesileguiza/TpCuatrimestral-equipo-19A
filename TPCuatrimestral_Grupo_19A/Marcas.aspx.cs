using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCuatrimestral_Grupo_19A
{
    public partial class Marcas : System.Web.UI.Page
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

                CargarMarcas();
            }
        }

        protected void dgvMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idSeleccionado = Convert.ToInt32(dgvMarcas.SelectedDataKey.Value);
            ViewState["IdSeleccionado"] = idSeleccionado;
        }

        private void CargarMarcas()
        {
            MarcaNegocio negocio = new MarcaNegocio();
            dgvMarcas.DataSource = negocio.Listar();
            dgvMarcas.DataBind();
        }

        protected void btnModificarMarca_Click(object sender, EventArgs e)
        {
            if (dgvMarcas.SelectedDataKey == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Seleccioná una marca para modificar.');", true);
            }
            else
            {
                int IdMarca = Convert.ToInt32(dgvMarcas.SelectedDataKey.Value);
                Response.Redirect("abmMarcas.aspx?IdMarca=" + IdMarca);

            }
        }

        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            Response.Redirect("abmMarcas.aspx");
        }

        protected void btnBuscarMarca_Click(object sender, EventArgs e)
        {
            //string filtro = txtBuscar.Text.Trim().ToLower();
            //  var filtrados = listaclientes
            //     .Where(c => c.Nombre.ToLower().Contains(filtro) || c.DNI.Contains(filtro))
            //    .ToList();

            // dgvClientes.DataSource = filtrados;
            //  dgvClientes.DataBind();
        }

        protected void btnDarAltaMarca_Click(object sender, EventArgs e)
        {
            if (ViewState["IdSeleccionado"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Seleccioná una marca antes de dar de alta.');", true);
                return;
            }

            int id = (int)ViewState["IdSeleccionado"];

            try
            {
                MarcaNegocio negocio = new MarcaNegocio();
                negocio.darAlta(id);

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Marca dada de alta correctamente.');", true);

                CargarMarcas();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error al dar de alta: {ex.Message}');", true);
            }
        }

        protected void btnEliminarMarca_Click(object sender, EventArgs e)
        {
            if (ViewState["IdSeleccionado"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Seleccioná una marca antes de eliminar.');", true);
                return;
            }

            int id = (int)ViewState["IdSeleccionado"];

            try
            {
                MarcaNegocio negocio = new MarcaNegocio();
                negocio.eliminar(id);

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Marca eliminada correctamente.');", true);

                CargarMarcas(); // recarga la grilla
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error al eliminar: {ex.Message}');", true);
            }
        }
    }
}