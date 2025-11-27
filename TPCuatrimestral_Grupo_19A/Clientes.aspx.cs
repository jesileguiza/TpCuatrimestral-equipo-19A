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

        private void CargarClientes()
        {
            ClienteNegocio negocio = new ClienteNegocio();
            dgvClientes.DataSource = negocio.listar();
            dgvClientes.DataBind();
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
                Response.Redirect("abmClientes.aspx?IdCliente=" + idCliente);

            }
        }

        protected void Filtro_TextChanged(object sender, EventArgs e)
        {
            string filtro = Filtro.Text.Trim();
            string columna = ddlFiltro.SelectedValue;

            ClienteNegocio negocio = new ClienteNegocio();
            List<Cliente> lista = negocio.listar();

            if (!string.IsNullOrEmpty(filtro))
            {
                switch (columna)
                {

                    case "ClientesId":
                        lista = lista.FindAll(x => x.ClientesId.ToString().Contains(filtro));
                        break;

                    case "Apellido":
                        lista = lista.FindAll(x => x.Apellido.ToUpper().Contains(filtro.ToUpper()));
                        break;

                    case "Dni":
                        lista = lista.FindAll(x => x.DNI.ToUpper().Contains(filtro.ToUpper()));
                        break;
                    case "Nombre":
                        lista = lista.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()));
                        break;
                }

            }

            dgvClientes.DataSource = lista;
            dgvClientes.DataBind();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Filtro.Text = "";
            ddlFiltro.SelectedIndex = 0;

            ClienteNegocio negocio = new ClienteNegocio();
            dgvClientes.DataSource = negocio.listar();
            dgvClientes.DataBind();

        }

        protected void dgvClientes_SelectedIndexChanged1(object sender, EventArgs e)
        {

            int ClientesId= Convert.ToInt32(dgvClientes.SelectedDataKey.Value);
            Response.Redirect("abmCliente.aspx?ClientesId=" + ClientesId);
        }


    }





}

