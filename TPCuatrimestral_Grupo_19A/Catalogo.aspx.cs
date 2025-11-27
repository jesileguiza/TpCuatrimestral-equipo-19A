using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace TPCuatrimestral_Grupo_19A
{
    public partial class Catalogo : System.Web.UI.Page
    {
        Dominio.Producto Prodcat = new Producto();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["RolUsuario"] == null)
                Response.Redirect("Default.aspx?error=sesion");

            string rol = Session["RolUsuario"].ToString();

            if (rol != "ADMIN")
            {
                string aviso = @"
        <html>
            <body style='font-family:Segoe UI; text-align:center; margin-top:40px;'>
                <h2 style='color:red;'>Acceso denegado</h2>
                <p>No estás autorizado para acceder a esta sección.</p>
                <br/>
                <a href='Gestion_Ventas.aspx' 
                   style='padding:10px 20px; background:#28a745; color:white; 
                          text-decoration:none; border-radius:5px;'>
                    Volver
                </a>
            </body>
        </html>";

                Response.Write(aviso);
                Response.End();

            }

            try
            {
               

                if (!IsPostBack)
                {
                    CargarProductos();
                    

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
   
        private void CargarProductos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            dgvProductos.DataSource = negocio.listar();
            dgvProductos.DataBind();
        }


        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            Response.Redirect("abmProducto.aspx" ,false);
        }

        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IdProducto = dgvProductos.SelectedDataKey.Value.ToString();
            Response.Redirect("abmProducto.aspx?IdProducto=" + IdProducto);
                
        }

        protected void Filtro_TextChanged1(object sender, EventArgs e)
        {
            string filtro = Filtro.Text.Trim();
            string columna = ddlFiltro.SelectedValue;

            ProductoNegocio negocio = new ProductoNegocio();
            List<Producto> lista = negocio.listar();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                switch (columna)
                {
                    case "IdProducto":
                        lista = lista.FindAll(x => x.IdProducto.ToString().Contains(filtro));
                        break;

                    case "Nombre":
                        lista = lista.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()));
                        break;

                    case "Descripcion":
                        lista = lista.FindAll(x => x.Descripcion.ToUpper().Contains(filtro.ToUpper()));
                        break;

                    case "Proveedor":
                        lista = lista.FindAll(x => x.proveedor.RazonSocial.ToUpper().Contains(filtro.ToUpper()));
                        break;

                    case "Categoria":
                        lista = lista.FindAll(x => x.categoria.IdCategoria.ToString().Contains(filtro) || x.categoria.Descripcion.ToUpper().Contains(filtro.ToUpper()));
                        break;
                    case "Marca":
                        lista = lista.FindAll(x => x.Marca.IdMarca.ToString().Contains(filtro) || x.Marca.Descripcion.ToUpper().Contains(filtro.ToUpper()));
                        break;
                }
            }

            dgvProductos.DataSource = lista;
            dgvProductos.DataBind();

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Filtro.Text = "";
            ddlFiltro.SelectedIndex = 0;

            ProductoNegocio negocio = new ProductoNegocio();
            dgvProductos.DataSource = negocio.listar();
            dgvProductos.DataBind();
        }
    }
}