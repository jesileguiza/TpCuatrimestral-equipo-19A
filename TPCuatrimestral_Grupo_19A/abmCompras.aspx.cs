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
            try
            {
                if (Session["RolUsuario"] == null)
                    Response.Redirect("Default.aspx");

                string rol = Session["RolUsuario"].ToString();

                if (rol != "ADMIN" && rol != "OPERADOR")
                    Response.Redirect("NoAutorizado.aspx");

                if (!IsPostBack)
                {
                    CargarListas();
                    CargarProximoIdCompra();

                    if (Request.QueryString["nuevoProductoId"] != null)
                        ddlProducto.SelectedValue = Request.QueryString["nuevoProductoId"].ToString();

                    if (Request.QueryString["CompraId"] != null)
                    {
                        int id = int.Parse(Request.QueryString["CompraId"]);
                        CargarCompra(id);

                        formTitle.InnerText = "Modificar Compra";
                        btnAgregar.Text = "Modificar";
                        btnEliminar.Visible = true;
                        TxtCompraId.Enabled = false;
                    }
                    else
                    {
                        formTitle.InnerText = "Agregar Compra";
                        btnAgregar.Text = "Agregar";
                        btnEliminar.Visible = false;
                    }
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
                if (string.IsNullOrEmpty(ddlProveedor.SelectedValue) ||
                    string.IsNullOrEmpty(ddlProducto.SelectedValue) ||
                    string.IsNullOrEmpty(ddlCategoria.SelectedValue) ||
                    string.IsNullOrEmpty(ddlMarca.SelectedValue))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                        "alert('Debe seleccionar PROVEEDOR, PRODUCTO, CATEGORÍA y MARCA.');", true);
                    return;
                }

                if (string.IsNullOrWhiteSpace(TxtCompraId.Text) ||
                    string.IsNullOrWhiteSpace(TxtStock.Text) ||
                    string.IsNullOrWhiteSpace(TxtPrecio.Text) ||
                    string.IsNullOrWhiteSpace(TxtFecha.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                        "alert('Complete todos los campos antes de continuar.');", true);
                    return;
                }

                int stock;
                decimal precio;
                DateTime fecha;

                if (!int.TryParse(TxtStock.Text, out stock) ||
                    !decimal.TryParse(TxtPrecio.Text, out precio) ||
                    !DateTime.TryParse(TxtFecha.Text, out fecha))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                        "alert('Revise que los campos numéricos y la fecha sean válidos.');", true);
                    return;
                }

                string compraIdQS = Request.QueryString["CompraId"];

                AccesoDatos datos = new AccesoDatos();

                // ------------------------------------------------------------
                //  MODO EDITAR (si viene CompraId en la URL)
                // ------------------------------------------------------------
                if (compraIdQS != null)
                {
                    datos.setearConsulta(@"
                UPDATE Compras 
                SET ProveedorId = @ProveedorId,
                    Stock = @Stock,
                    IdProducto = @IdProducto,
                    Fecha = @Fecha,
                    Total = @Total
                WHERE CompraId = @CompraId");

                    datos.setearParametro("@CompraId", int.Parse(compraIdQS));
                }
                else
                {
                    // ------------------------------------------------------------
                    //  MODO AGREGAR (si NO viene CompraId)
                    // ------------------------------------------------------------
                    datos.setearConsulta(@"
                INSERT INTO Compras (ProveedorId, Stock, IdProducto, Fecha, Total)
                VALUES (@ProveedorId, @Stock, @IdProducto, @Fecha, @Total)");
                }

                datos.setearParametro("@ProveedorId", int.Parse(ddlProveedor.SelectedValue));
                datos.setearParametro("@Stock", stock);
                datos.setearParametro("@IdProducto", int.Parse(ddlProducto.SelectedValue));
                datos.setearParametro("@Fecha", fecha);
                datos.setearParametro("@Total", precio);

                datos.ejecutarAccion();

                string mensaje = (compraIdQS != null)
                    ? "¡Compra modificada correctamente!"
                    : "¡Compra agregada correctamente!";

                string script = $@"
            Swal.fire({{
                icon: 'success',
                title: '{mensaje}',
                confirmButtonText: 'Aceptar'
            }}).then((result) => {{
                if (result.isConfirmed) {{
                    window.location.href = 'Gestion_Compras.aspx';
                }}
            }});
        ";

                ClientScript.RegisterStartupScript(this.GetType(), "OperacionExitosa", script, true);
            }
            catch (Exception ex)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Gestion_Compras.aspx", false);
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Request.QueryString["CompraId"]))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                        "alert('No hay compra seleccionada para eliminar.');", true);
                    return;
                }

                int id = int.Parse(Request.QueryString["CompraId"]);

                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("DELETE FROM Compras WHERE CompraId = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();

                string script = @"
            Swal.fire({
                icon: 'success',
                title: 'Compra eliminada',
                text: 'La compra fue borrada correctamente.',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.isConfirmed) {
                    window.location.href = 'Gestion_Compras.aspx';
                }
            });
        ";

                ClientScript.RegisterStartupScript(this.GetType(), "CompraEliminada", script, true);
            }
            catch (Exception ex)
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Error al eliminar compra: " + ex.Message;
            }
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

        private void CargarListas()
        {
            // Categorías
            CategoriaNegocio negocioCategoria = new CategoriaNegocio();
            ddlCategoria.DataSource = negocioCategoria.Listar();
            ddlCategoria.DataValueField = "IdCategoria";
            ddlCategoria.DataTextField = "Descripcion";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem("-- Seleccionar --", ""));

            // Marcas
            MarcaNegocio negocioMarca = new MarcaNegocio();
            ddlMarca.DataSource = negocioMarca.Listar();
            ddlMarca.DataValueField = "IdMarca";
            ddlMarca.DataTextField = "Descripcion";
            ddlMarca.DataBind();
            ddlMarca.Items.Insert(0, new ListItem("-- Seleccionar --", ""));

            // Proveedores
            AccesoDatos datosProveedor = new AccesoDatos();
            datosProveedor.setearConsulta("SELECT id_Proveedor, Nombre FROM Proveedores");
            datosProveedor.ejecutarLectura();
            ddlProveedor.DataSource = datosProveedor.Lector;
            ddlProveedor.DataValueField = "id_Proveedor";
            ddlProveedor.DataTextField = "Nombre";
            ddlProveedor.DataBind();
            datosProveedor.cerrarConexion();
            ddlProveedor.Items.Insert(0, new ListItem("-- Seleccionar --", ""));

            // Productos
            CargarProductos();
            ddlProducto.Items.Insert(0, new ListItem("-- Seleccionar --", ""));
        }

        private void CargarCompra(int id)
        {
            CompraNegocio negocio = new CompraNegocio();
            Compra seleccionado = negocio.listar(id)[0];

            TxtCompraId.Text = seleccionado.CompraId.ToString();
            ddlProveedor.SelectedValue = seleccionado.ProveedorId.ToString();
            ddlProducto.SelectedValue = seleccionado.idProducto.ToString();
            ddlCategoria.SelectedValue = seleccionado.categoria.IdCategoria.ToString();
            ddlMarca.SelectedValue = seleccionado.Marca.IdMarca.ToString();
            TxtStock.Text = seleccionado.Stock.ToString();
            TxtPrecio.Text = seleccionado.Total.ToString();
            TxtFecha.Text = seleccionado.Fecha.ToString("yyyy-MM-dd");

            formTitle.InnerText = "Modificar Compra";
            btnAgregar.Text = "Modificar";
            btnEliminar.Visible = true;
        }







    }
}
