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
    public partial class Marcas : System.Web.UI.Page
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

                CargarMarcas();
            }
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

        protected void dgvMarcas_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int IdMarca = Convert.ToInt32(dgvMarcas.SelectedDataKey.Value);
            Response.Redirect("abmMarcas.aspx?IdMarca=" + IdMarca);
        }

        protected void btnAgregarMarca_Click1(object sender, EventArgs e)
        {
            Response.Redirect("abmMarcas.aspx");
        }

        protected void Filtro_TextChanged(object sender, EventArgs e)
        {
            string filtro = Filtro.Text.Trim();
            string columna = ddlFiltro.SelectedValue;

            MarcaNegocio negocio = new MarcaNegocio();
 
            List<Marca> lista = negocio.Listar();

            if (!string.IsNullOrEmpty(filtro))
            {
                switch (columna)
                {

                    case "IdMarca":
                        lista = lista.FindAll(x => x.IdMarca.ToString().Contains(filtro));
                        break;

                    case "Descripcion":
                        lista = lista.FindAll(x => x.Descripcion.ToUpper().Contains(filtro.ToUpper()));
                        break;

                }

            }

            dgvMarcas.DataSource = lista;
            dgvMarcas.DataBind();

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Filtro.Text = "";
            ddlFiltro.SelectedIndex = 0;

            MarcaNegocio negocio= new MarcaNegocio();
            dgvMarcas.DataSource = negocio.Listar();
            dgvMarcas.DataBind();
        }
    }
}