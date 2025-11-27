using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCuatrimestral_Grupo_19A
{
    public partial class abmVentas : System.Web.UI.Page
    {
        private List<VentaDetalle> ListaDetalles
        {
            get
            {
                if (Session["DetallesVenta"] == null)
                    Session["DetallesVenta"] = new List<VentaDetalle>();
                return (List<VentaDetalle>)Session["DetallesVenta"];
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
                CargarProductos();
                CargarProximoIdVenta();
                LimpiarMensaje();
            }
        }

        private void LimpiarMensaje() => lblMensaje.Text = "";

        private void CargarClientes()
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearConsulta("SELECT ClientesId, Nombre FROM Clientes");
                    datos.ejecutarLectura();

                    ddlCliente.DataSource = datos.Lector;
                    ddlCliente.DataValueField = "ClientesId";
                    ddlCliente.DataTextField = "Nombre";
                    ddlCliente.DataBind();
                    ddlCliente.Items.Insert(0, new ListItem("--Seleccione--", ""));
                    datos.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error cargando clientes: " + ex.Message;
            }
        }

        private void CargarProductos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            ddlProducto.DataSource = negocio.listar();
            ddlProducto.DataTextField = "Nombre";
            ddlProducto.DataValueField = "IdProducto";
            ddlProducto.DataBind();
            ddlProducto.Items.Insert(0, new ListItem("--Seleccione--", ""));
        }

        private void CargarProximoIdVenta()
        {
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearConsulta("SELECT ISNULL(MAX(VentaId),0)+1 AS ProximoId FROM Ventas");
                    datos.ejecutarLectura();

                    if (datos.Lector.Read())
                        TxtVentaId.Text = datos.Lector["ProximoId"].ToString();

                    datos.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error cargando ID: " + ex.Message;
            }
        }

        protected void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoNegocio negocio = new ProductoNegocio();
                if (ddlProducto.SelectedValue == "") return;

                int id = int.Parse(ddlProducto.SelectedValue);
                int cant = int.Parse(txtCantidad.Text);

                var producto = negocio.listar().First(p => p.IdProducto == id);

                if (cant > producto.Stock)
                {
                    lblMensaje.Text = "No hay stock suficiente.";
                    return;
                }

                decimal ganancia = 30; // 30%
                decimal precioVenta = producto.Precio + (producto.Precio * (ganancia / 100));
                decimal subtotal = precioVenta * cant;

                VentaDetalle det = new VentaDetalle
                {
                    ProductoId = producto.IdProducto,
                    Nombre = producto.Nombre,
                    Cantidad = cant,
                    PrecioUnitario = producto.Precio,
                    Ganancia = ganancia,
                    Subtotal = subtotal
                };

                ListaDetalles.Add(det);
                ActualizarGrillaYTotal();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error agregando producto: " + ex.Message;
            }
        }

        private void ActualizarGrillaYTotal()
        {
            gvDetalles.DataSource = ListaDetalles;
            gvDetalles.DataBind();

            decimal total = ListaDetalles.Sum(x => x.Subtotal);
            total = total * 1.30m; // aplicar ganancia global
            TxtTotal.Text = total.ToString("0.00");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ListaDetalles.Count == 0)
                {
                    lblMensaje.Text = "Debe agregar al menos un producto.";
                    return;
                }

                Venta v = new Venta
                {
                    ClienteId = int.Parse(ddlCliente.SelectedValue),
                    Fecha = DateTime.Parse(TxtFecha.Text),
                    DNI = TxtDNI.Text,
                    Email = TxtEmail.Text,
                    Total = decimal.Parse(TxtTotal.Text),
                    Detalles = ListaDetalles
                };

                VentaNegocio negocio = new VentaNegocio();
                negocio.AgregarVentaConDetalles(v);

                ListaDetalles.Clear();
                Session["DetallesVenta"] = null;

                ClientScript.RegisterStartupScript(this.GetType(), "ok",
                    "alert('Venta guardada correctamente'); window.location='Gestion_Ventas.aspx';", true);
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al guardar la venta: " + ex.Message;
            }
        }

        protected void gvDetalles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Quitar")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                ListaDetalles.RemoveAt(index);
                ActualizarGrillaYTotal();
            }
        }

        protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlCliente.SelectedValue == "") return;

                int idCliente = int.Parse(ddlCliente.SelectedValue);
                using (AccesoDatos datos = new AccesoDatos())
                {
                    datos.setearConsulta("SELECT DNI, Email FROM Clientes WHERE ClientesId = @id");
                    datos.setearParametro("@id", idCliente);
                    datos.ejecutarLectura();

                    if (datos.Lector.Read())
                    {
                        TxtDNI.Text = datos.Lector["DNI"].ToString();
                        TxtEmail.Text = datos.Lector["Email"].ToString();
                    }

                    datos.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar datos del cliente: " + ex.Message;
            }
        }

        // ✅ Nuevo método agregado para evitar el error CS1061
        protected void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            // Redirige a la página de ABM de clientes, puede ajustar el query string si quieres volver a ventas
            Response.Redirect("abmClientes.aspx?volverA=Ventas");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // Limpiar todo
            ListaDetalles.Clear();
            Session["DetallesVenta"] = null;
            Response.Redirect("Gestion_Ventas.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    int ventaId = int.Parse(TxtVentaId.Text);
            //    VentaNegocio negocio = new VentaNegocio();
            //    negocio.Eliminar(ventaId);

            //    ListaDetalles.Clear();
            //    Session["DetallesVenta"] = null;

            //    ClientScript.RegisterStartupScript(this.GetType(), "ok",
            //        "alert('Venta eliminada correctamente'); window.location='Gestion_Ventas.aspx';", true);
            //}
            //catch (Exception ex)
            //{
            //    lblMensaje.Text = "Error al eliminar la venta: " + ex.Message;
            //}
        }
    }
}
