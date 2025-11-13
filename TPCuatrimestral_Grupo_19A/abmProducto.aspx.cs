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
                    int id = int.Parse(Request.QueryString["IdProducto"].ToString());
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
                // Validar campos obligatorios
                if (string.IsNullOrWhiteSpace(TxtNombre.Text) ||
                    string.IsNullOrWhiteSpace(TxtDescripcion.Text) ||
                    string.IsNullOrWhiteSpace(TxtProvedores.Text) ||
                    string.IsNullOrWhiteSpace(TxtMarca.Text) ||
                    string.IsNullOrWhiteSpace(txtCategoria.Text) ||
                    string.IsNullOrWhiteSpace(TxtStock.Text) ||
                    string.IsNullOrWhiteSpace(TxtPrecio.Text))
                {
                    lblMensaje.Text = "Por favor, completá todos los campos antes de continuar.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }

             
                Producto nuevo = new Producto();
                ProductoNegocio negocio = new ProductoNegocio();

                nuevo.Nombre = TxtNombre.Text;
                nuevo.Descripcion = TxtDescripcion.Text;
                nuevo.Proveedor = TxtProvedores.Text;
                nuevo.IdMarca = int.Parse(TxtMarca.Text);
                nuevo.IdCategoria = int.Parse(txtCategoria.Text);
                nuevo.Stock = int.Parse(TxtStock.Text);
                nuevo.Precio = decimal.Parse(TxtPrecio.Text);

                if (Request.QueryString["IdProducto"] != null)
                {
                    nuevo.IdProducto = int.Parse(Request.QueryString["IdProducto"].ToString());
                    negocio.modificarProducto(nuevo);
                    lblMensaje.Text = "Producto modificado correctamente.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    negocio.Agregar(nuevo);
                    lblMensaje.Text = "Producto agregado correctamente.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                }

                Response.Redirect("Catalogo.aspx", false);
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al guardar el producto: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }



        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalogo.aspx", false);
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string idProducto = Request.QueryString["IdProducto"];


            if (string.IsNullOrEmpty(idProducto))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No hay un producto seleccionado para eliminar (ID no encontrado en la URL).');", true);
                return;
            }

            int id;
            if (!int.TryParse(idProducto, out id))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El ID de producto en la URL no es válido.');", true);
                return;
            }
            try
            {
                ProductoNegocio negocio = new ProductoNegocio();
                negocio.eliminar(id);

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Producto eliminado correctamente.');", true);
                Response.Redirect("Catalogo.aspx", false);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error al eliminar: {ex.Message}');", true);
            }
        }


    }



}