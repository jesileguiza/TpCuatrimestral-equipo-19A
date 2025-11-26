using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCuatrimestral_Grupo_19A
{
    public partial class Categorias : System.Web.UI.Page
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

                CargarCategorias();
            }

        }

        protected void dgvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idSeleccionado = Convert.ToInt32(dgvCategorias.SelectedDataKey.Value);
            ViewState["IdSeleccionado"] = idSeleccionado;
        }

        private void CargarCategorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            dgvCategorias.DataSource = negocio.Listar();
            dgvCategorias.DataBind();
        }

        protected void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedDataKey == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Seleccioná una categoria para modificar.');", true);
            }
            else
            {
                int IdCategoria = Convert.ToInt32(dgvCategorias.SelectedDataKey.Value);
                Response.Redirect("abmCategorias.aspx?IdCategoria=" + IdCategoria);

            }
        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("abmCategorias.aspx");
        }

        protected void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            //string filtro = txtBuscar.Text.Trim().ToLower();
            //  var filtrados = listaclientes
            //     .Where(c => c.Nombre.ToLower().Contains(filtro) || c.DNI.Contains(filtro))
            //    .ToList();

            // dgvClientes.DataSource = filtrados;
            //  dgvClientes.DataBind();
        }

        protected void btnDarAltaCategoria_Click(object sender, EventArgs e)
        {
            if (ViewState["IdSeleccionado"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Seleccioná una categoria antes de dar de alta.');", true);
                return;
            }

            int id = (int)ViewState["IdSeleccionado"];

            try
            {
                CategoriaNegocio negocio = new CategoriaNegocio();
                negocio.darAlta(id);

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Categoria dada de alta correctamente.');", true);

                CargarCategorias();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error al dar de alta: {ex.Message}');", true);
            }
        }

        protected void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            if (ViewState["IdSeleccionado"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Seleccioná una categoria antes de eliminar.');", true);
                return;
            }

            int id = (int)ViewState["IdSeleccionado"];

            try
            {
                CategoriaNegocio negocio = new CategoriaNegocio();
                negocio.eliminar(id);

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Categoria eliminada correctamente.');", true);

                CargarCategorias(); // recarga la grilla
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error al eliminar: {ex.Message}');", true);
            }
        }

    }
}