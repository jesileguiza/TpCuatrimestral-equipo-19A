using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPCuatrimestral_Grupo_19A
{
    public partial class abmProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto nuevo = new Producto();
                ProductoNegocio negocio = new ProductoNegocio();

                nuevo.Nombre = TxtNombre.Text;
                nuevo.Descripcion= TxtDescripcion.Text;
                nuevo.Proveedor= TxtProvedores.Text;
                nuevo.IdMarca = int.Parse(TxtMarca.Text);
                nuevo.IdCategoria = int.Parse(txtCategoria.Text);
                nuevo.Stock = int.Parse(TxtPrecio.Text);
                nuevo.Precio = int.Parse(TxtPrecio.Text);

                negocio.Agregar(nuevo);
                Response.Redirect("Catalogo.aspx", false);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalogo.aspx", false);
        }
    }
}