using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCuatrimestral_Grupo_19A
{
    public partial class abmProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            try
            {
                if (!IsPostBack)
                {
                    string IdProducto = Request.QueryString["IdProducto"];
                    CategoriaNegocio negocioCategoria = new CategoriaNegocio();
                    MarcaNegocio negocioMarca = new MarcaNegocio();
                    ProveedorNegocio proveedorNegocio = new ProveedorNegocio();

                    ddlProveedores.DataSource = proveedorNegocio.listar();
                    ddlProveedores.DataValueField = "IdProveedor";
                    ddlProveedores.DataTextField = "RazonSocial";
                    ddlProveedores.DataBind();


                    ddlCategoria.DataSource = negocioCategoria.Listar();
                    ddlCategoria.DataValueField = "IdCategoria";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    ddlMarca.DataSource = negocioMarca.Listar();
                    ddlMarca.DataValueField = "IdMarca";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    //modificacion
                    if (!string.IsNullOrEmpty(IdProducto))
                    {
                        btnAgregar.Text = "Modificar";
                        tituloProducto.InnerText = "Modificar producto";

                        try
                        {
                            ProductoNegocio negocio = new ProductoNegocio();
                            List<Producto> lista = negocio.listar(IdProducto);
                            btnInactivar.Visible = false;
                            if (lista != null && lista.Count > 0)
                            {
                                Producto seleccionado = lista[0];

                                

                                Session.Add("productoSeleccionado", seleccionado);

                                
                                TxtNombre.Text = seleccionado.Nombre;
                                TxtDescripcion.Text = seleccionado.Descripcion;
                                ddlProveedores.SelectedValue = seleccionado.proveedor.IdProveedor.ToString();
                                TxtStock.Text = seleccionado.Stock.ToString();
                                TxtPrecio.Text = seleccionado.Precio.ToString();


                                ddlCategoria.SelectedValue = seleccionado.categoria.IdCategoria.ToString();
                                ddlMarca.SelectedValue = seleccionado.Marca.IdMarca.ToString();

                                
                                if (!seleccionado.Activo)
                                    btnInactivar.Text = "Reactivar";
                                btnInactivar.Visible = true;
                            }
                            else
                            {
                                lblMensaje.Text = "No se encontró el producto especificado.";
                                lblMensaje.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        catch (Exception ex)
                        {
                            lblMensaje.Text = "Ocurrió un error al cargar los datos: " + ex.Message;
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        btnInactivar.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error inesperado: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TxtNombre.Text) ||
                    string.IsNullOrWhiteSpace(TxtDescripcion.Text) ||
                    string.IsNullOrWhiteSpace(TxtStock.Text) ||
                    string.IsNullOrWhiteSpace(TxtPrecio.Text))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                        "alert",
                        "alert('Por favor complete todos los campos antes de agregar.');",
                        true);
                    return;
                }

                int stock;
                if (!int.TryParse(TxtStock.Text, out stock))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                        "alert",
                        "alert('El campo Stock debe contener solo números.');",
                        true);
                    return;
                }

                decimal precio;
                if (!decimal.TryParse(TxtPrecio.Text, out precio))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                        "alert",
                        "alert('El campo Precio debe contener un número válido.');",
                        true);
                    return;
                }

                Producto nuevo = new Producto();
                ProductoNegocio negocio = new ProductoNegocio();

               

                nuevo.Nombre = TxtNombre.Text;
                nuevo.Descripcion = TxtDescripcion.Text;

                nuevo.proveedor = new Proveedor();
                nuevo.proveedor.IdProveedor = int.Parse(ddlProveedores.SelectedValue);

                nuevo.categoria = new Categoria();
                nuevo.categoria.IdCategoria = int.Parse(ddlCategoria.SelectedValue);

                nuevo.Marca = new Marca();
                nuevo.Marca.IdMarca = int.Parse(ddlMarca.SelectedValue);

                nuevo.Stock = stock;
                nuevo.Precio = precio;


                if (!string.IsNullOrEmpty(Request.QueryString["IdProducto"]))
                {
                    nuevo.IdProducto = int.Parse(Request.QueryString["IdProducto"].ToString());
                    negocio.modificarProducto(nuevo);
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                   "alert",
                   "alert('Producto Modificado correctamente'); window.location='catalogo.aspx';",
                   true);

                }
                else
                {
                    negocio.agregar(nuevo);

                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "alert",
                    "alert('Producto agregado correctamente'); window.location='catalogo.aspx';",
                    true);

                    if (Request.QueryString["volverA"] == "Compras")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                            "alert('Producto agregado correctamente'); window.location='abmCompras.aspx';", true);
                    }
                    else
                    {
                        Response.Redirect("Catalogo.aspx");
                    }
                    Response.Redirect("abmCompras.aspx?nuevoProductoId=" + nuevo.IdProducto);


                }

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al agregar: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalogo.aspx", false);
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                
                ProductoNegocio negocio = new ProductoNegocio();
                Producto seleccionado = (Producto)Session["productoSeleccionado"];
                bool nuevoEstado = !seleccionado.Activo;


                negocio.Estado(int.Parse(Request.QueryString["IdProducto"].ToString()), nuevoEstado);

                string mensaje = nuevoEstado ?
                 "El producto fue reactivado correctamente" :
                 "El producto fue inactivado correctamente";

                ScriptManager.RegisterStartupScript(this, this.GetType(),
                   "alert",
                   $"alert('{mensaje}'); window.location='catalogo.aspx';",
                   true);



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
