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
    public partial class abmCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            CategoriaNegocio negocioCategoria = new CategoriaNegocio();
            MarcaNegocio negocioMarca = new MarcaNegocio();


            try
            {


                if (!IsPostBack)
                {
                    List<Categoria> lista = negocioCategoria.Listar();



                    ddlCategoria.DataSource = lista;
                    ddlCategoria.DataValueField = "IdCategoria";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    List<Marca> listaMarca = negocioMarca.Listar();
                    ddlMarca.DataSource = listaMarca;
                    ddlMarca.DataValueField = "IdMarca";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    CargarProximoIdCompra();

                    AccesoDatos datosProveedor = new AccesoDatos();
                    datosProveedor.setearConsulta("SELECT id_Proveedor, Nombre FROM Proveedores");
                    datosProveedor.ejecutarLectura();

                    ddlProveedor.DataSource = datosProveedor.Lector;
                    ddlProveedor.DataValueField = "id_Proveedor";
                    ddlProveedor.DataTextField = "Nombre";
                    ddlProveedor.DataBind();
                    datosProveedor.cerrarConexion();


                    AccesoDatos datosProducto = new AccesoDatos();
                    datosProducto.setearConsulta("SELECT ProductoId, Nombre FROM Productos");
                    datosProducto.ejecutarLectura();

                    ddlProducto.DataSource = datosProducto.Lector;
                    ddlProducto.DataValueField = "ProductoId";
                    ddlProducto.DataTextField = "Nombre";
                    ddlProducto.DataBind();
                    datosProducto.cerrarConexion();

                    CargarProductos();

                    if (Request.QueryString["nuevoProductoId"] != null)
                    {
                        string nuevoId = Request.QueryString["nuevoProductoId"].ToString();
                        ddlProducto.SelectedValue = nuevoId;
                    }

                }

                CompraNegocio negocio = new CompraNegocio();
                string CompraId = Request.QueryString["CompraId"] != null ? Request.QueryString["CompraId"].ToString() : "";

                if (CompraId != "")
                {
                    Compra seleccionado = (negocio.listar(CompraId))[0];

                    //precargo la informacion
                    TxtCompraId.Text = seleccionado.CompraId.ToString();
                    ddlProveedor.SelectedValue = seleccionado.ProveedorId.ToString();
                    TxtStock.Text = seleccionado.Stock.ToString();
                    ddlProducto.SelectedValue = seleccionado.idProducto.ToString();
                    TxtFecha.Text = seleccionado.Fecha.ToString("yyyy-MM-dd");
                    TxtPrecio.Text = seleccionado.Total.ToString();


                    //precargo los desplegables
                    ddlMarca.SelectedValue = seleccionado.Marca.IdMarca.ToString();
                    ddlCategoria.SelectedValue = seleccionado.categoria.IdCategoria.ToString();

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

                if (string.IsNullOrWhiteSpace(TxtCompraId.Text) ||
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
                decimal precio;
                DateTime fecha;

                if (
                    !int.TryParse(TxtStock.Text, out stock) ||
                    !decimal.TryParse(TxtPrecio.Text, out precio) ||
                    !DateTime.TryParse(TxtFecha.Text, out fecha))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                        "alert('Revise que todos los campos numéricos y la fecha sean válidos.');", true);
                    return;
                }




                /*
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
                }*/


                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta(@"INSERT INTO Compras (ProveedorId, Stock, IdProducto, Fecha, Total) VALUES (@ProveedorId, @Stock, @IdProducto, @Fecha, @Total)");

                datos.setearParametro("@ProveedorId", int.Parse(ddlProveedor.SelectedValue));
                datos.setearParametro("@Stock", int.Parse(TxtStock.Text));
                datos.setearParametro("@IdProducto", int.Parse(ddlProducto.SelectedValue));
                datos.setearParametro("@Fecha", DateTime.Parse(TxtFecha.Text));
                datos.setearParametro("@Total", decimal.Parse(TxtPrecio.Text));

                datos.ejecutarAccion();

                string script = @"
                                Swal.fire({
                                icon: 'success',
                                title: '¡Compra registrada!' ,
                                text: 'La compra se ha agregado correctamente al sistema.' ,
                                confirmButtonText: 'Aceptar' 
                                }).then((result) => {
                                if (result.isConfirmed) {
                                window.location.href = 'Gestion_Compras.aspx';
                                }
                                });
                                ";

                ClientScript.RegisterStartupScript(this.GetType(), "CompraExitosa", script, true);


                TxtStock.Text = "";
                TxtFecha.Text = "";
                TxtPrecio.Text = "";



                /// modificar
                /*
                Compra nuevo = new Compra();
                CompraNegocio negocio = new CompraNegocio();

                nuevo.CompraId = TxtCompraId.Text;
                nuevo.Descripcion = TxtDescripcion.Text;
                nuevo.Proveedor = TxtProvedores.Text;

                nuevo.categoria = new Categoria();
                nuevo.categoria.IdCategoria = int.Parse(ddlCategoria.SelectedValue);

                nuevo.Marca = new Marca();
                nuevo.Marca.IdMarca = int.Parse(ddlMarca.SelectedValue);

                nuevo.Stock = int.Parse(TxtStock.Text);
                nuevo.Precio = int.Parse(TxtPrecio.Text);

                negocio.agregar(nuevo);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Producto agregado correctamente'); window.location='catalogo.aspx';", true);


                string IdProducto = Request.QueryString["IdProducto"] != null ? Request.QueryString["IdProducto"].ToString() : "";


                */
                //Response.Redirect(Gestion_Ventas.aspx);
            }


            catch (Exception ex)
            {

                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Error al agregar la compra: " + ex.Message;
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Gestion_Compras.aspx", false);
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void CargarProximoIdCompra()
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("SELECT ISNULL(MAX(CompraId), 0) + 1 AS ProximoId FROM Compras");
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    TxtCompraId.Text = datos.Lector["ProximoId"].ToString();
                    TxtCompraId.ReadOnly = true;  // evita modificarlo
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error cargando ID automático: " + ex.Message;
            }

        }

        private void CargarProductos()
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("SELECT ProductoId, Nombre FROM Productos");
                datos.ejecutarLectura();

                ddlProducto.DataSource = datos.Lector;
                ddlProducto.DataValueField = "ProductoId";
                ddlProducto.DataTextField = "Nombre";
                ddlProducto.DataBind();

                datos.cerrarConexion();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error cargando productos: " + ex.Message;
            }
        }
        protected void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            Response.Redirect("abmProducto.aspx?volverA=Compras");
        }




    }
}
