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
           /* 
            if (!IsPostBack)
            {
                CargarCatalogo();
            } 
           */

            if (!IsPostBack)
            {
                CargarProductos();
               
            }
        }



        private void CargarProductos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            dgvProductos.DataSource = negocio.listar();
            dgvProductos.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                Producto nuevo = new Producto
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Proveedor = txtProveedor.Text,
                    IdMarca = string.IsNullOrEmpty(txtIdMarca.Text) ? (int?)null : int.Parse(txtIdMarca.Text),
                    IdCategoria = string.IsNullOrEmpty(txtIdCategoria.Text) ? (int?)null : int.Parse(txtIdCategoria.Text),
                    Stock = int.Parse(txtStock.Text),
                    Precio = decimal.Parse(txtPrecio.Text)
                };

                ProductoNegocio negocio = new ProductoNegocio();
                negocio.Agregar(nuevo);

                lblMensaje.Text = "✅ Producto agregado correctamente.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Visible = true;

                // Recargar el grid
                CargarProductos();

                // Limpiar campos
                txtNombre.Text = "";
                txtDescripcion.Text = "";
                txtProveedor.Text = "";
                txtIdMarca.Text = "";
                txtIdCategoria.Text = "";
                txtStock.Text = "";
                txtPrecio.Text = "";

                // Ocultar el formulario desde el servidor
                ScriptManager.RegisterStartupScript(this, GetType(), "HideForm", "ocultarFormulario();", true);
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "❌ Error al agregar producto: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
            }
        }

      


    }
}