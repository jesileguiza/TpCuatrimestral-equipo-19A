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
            try
            {
                if (Request.QueryString["IdProducto"] != null && !IsPostBack)
                {
                    ProductoNegocio negocio = new ProductoNegocio();
                    List<Producto> lista = negocio.listar(Request.QueryString["IdProducto"].ToString());
                    Producto seleccionado = lista[0];

                    //precargo todos los datos del producto, asi no hay necesidad de rellenar todo 

                    TxtNombre.Text = seleccionado.Nombre;
                    TxtDescripcion.Text = seleccionado.Descripcion;
                    TxtProvedores.Text= seleccionado.Proveedor.ToString();
                    TxtMarca.Text = seleccionado.Marca?.ToString() ?? string.Empty;
                    txtCategoria.Text = seleccionado.categoria?.ToString() ?? string.Empty;
                    TxtStock.Text= seleccionado.Stock.ToString();
                    TxtPrecio.Text=seleccionado.Precio.ToString();


                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
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
                nuevo.Stock = int.Parse(TxtStock.Text);
                nuevo.Precio = decimal.Parse(TxtPrecio.Text);

                if (Request.QueryString["IdProducto"] != null)
                {
                    nuevo.IdProducto = int.Parse(Request.QueryString["IdProducto"].ToString());
                    negocio.modificarProducto(nuevo);
                }
                else
                {

                    negocio.Agregar(nuevo);

                }

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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

       
    }
}