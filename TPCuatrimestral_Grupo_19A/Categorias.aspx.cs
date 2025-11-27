using Dominio;
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

                CargarCategorias();
            }

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

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Filtro.Text = "";
            ddlFiltro.SelectedIndex = 0;

            CategoriaNegocio negocio = new CategoriaNegocio();
            dgvCategorias.DataSource = negocio.Listar();
            dgvCategorias.DataBind();
        }

        protected void dgvCategorias_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int IdCategoria = Convert.ToInt32(dgvCategorias.SelectedDataKey.Value);
            Response.Redirect("abmCategorias.aspx?IdCategoria=" + IdCategoria );
        }

        protected void btnAgregarCategoria_Click1(object sender, EventArgs e)
        {
            Response.Redirect("abmCategorias.aspx", false);
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            string filtro = Filtro.Text.Trim();
            string columna =ddlFiltro.SelectedValue;

            CategoriaNegocio negocio = new CategoriaNegocio();
            List<Categoria> lista = negocio.Listar();

            if (!string.IsNullOrEmpty(filtro))
            {
                switch (columna)
                {

                    case "IdCategoria":
                        lista = lista.FindAll(x => x.IdCategoria.ToString().Contains(filtro));
                    break;

                    case "Descripcion":
                        lista = lista.FindAll(x => x.Descripcion.ToUpper().Contains(filtro.ToUpper()));
                    break;

                }

            }

            dgvCategorias.DataSource = lista;
            dgvCategorias.DataBind();

        }
    }
}