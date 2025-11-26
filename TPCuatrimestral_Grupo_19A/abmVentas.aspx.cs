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

                ///borrar
                ProductoNegocio negocio = new ProductoNegocio();
                var listaProductos = negocio.listar();

                // Mostrar la cantidad de productos encontrados
                lblMensaje.Text = "Productos encontrados: " + listaProductos.Count;

                // Mostrar nombres de productos encontrados (para debug)
                if (listaProductos.Count > 0)
                {
                    string nombres = string.Join(", ", listaProductos.Select(p => p.Nombre));
                    lblMensaje.Text += "<br/>Productos: " + nombres;
                }

                // Asignar al DropDownList solo si hay productos
                if (listaProductos.Count > 0)
                {
                    ddlProducto.DataSource = listaProductos;
                    ddlProducto.DataTextField = "Nombre";
                    ddlProducto.DataValueField = "IdProducto"; // recuerda que en tu clase Producto es IdProducto
                    ddlProducto.DataBind();
                    ddlProducto.Items.Insert(0, new ListItem("--Seleccione--", "")); // opción inicial
                }
                else
                {
                    ddlProducto.Items.Clear();
                    ddlProducto.Items.Add(new ListItem("No hay productos disponibles", ""));
                }
                ///borrar

                string ventaId = Request.QueryString["VentaId"];
                if (!string.IsNullOrEmpty(ventaId))
                {
                    CargarVenta(int.Parse(ventaId));
                }
            }
        }

        private void CargarClientes()
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("SELECT ClientesId, Nombre FROM Clientes");
                datos.ejecutarLectura();

                ddlCliente.DataSource = datos.Lector;
                ddlCliente.DataValueField = "ClientesId";
                ddlCliente.DataTextField = "Nombre";
                ddlCliente.DataBind();

                datos.cerrarConexion();
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
        }

        private void CargarProximoIdVenta()
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("SELECT ISNULL(MAX(VentaId), 0) + 1 AS ProximoId FROM Ventas");
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                    TxtVentaId.Text = datos.Lector["ProximoId"].ToString();

                datos.cerrarConexion();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error cargando ID: " + ex.Message;
            }
        }

        private void CargarVenta(int ventaId)
        {
            try
            {
                VentaNegocio negocio = new VentaNegocio();
                Venta v = negocio.Listar().Find(x => x.VentaId == ventaId);

                if (v != null)
                {
                    TxtVentaId.Text = v.VentaId.ToString();
                    ddlCliente.SelectedValue = v.ClienteId.ToString();
                    TxtDNI.Text = v.DNI;
                    TxtEmail.Text = v.Email;
                    TxtFecha.Text = v.Fecha.ToString("yyyy-MM-dd");
                    TxtTotal.Text = v.Total.ToString();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error cargando venta: " + ex.Message;
            }
        }

        /* protected void btnAgregar_Click(object sender, EventArgs e)
         {
             try
             {
                 VentaNegocio negocio = new VentaNegocio();
                 Venta v = new Venta
                 {
                     ClienteId = int.Parse(ddlCliente.SelectedValue),
                     Fecha = DateTime.Parse(TxtFecha.Text),
                     Total = decimal.Parse(TxtTotal.Text),
                     DNI = TxtDNI.Text,
                     Email = TxtEmail.Text
                 };

                 negocio.Agregar(v);

                 ClientScript.RegisterStartupScript(this.GetType(), "VentaExitosa",
                     "alert('Venta registrada correctamente'); window.location='Gestion_Ventas.aspx';", true);
             }
             catch (Exception ex)
             {
                 lblMensaje.Text = "Error al agregar la venta: " + ex.Message;
             }
         }*/

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

                Session["DetallesVenta"] = null;

                ClientScript.RegisterStartupScript(this.GetType(), "ok",
                    "alert('Venta guardada correctamente'); window.location='Gestion_Ventas.aspx';", true);
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al guardar la venta: " + ex.Message;
            }
        }
        

        protected void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                ProductoNegocio negocio = new ProductoNegocio();
                int id = int.Parse(ddlProducto.SelectedValue);
                int cant = int.Parse(txtCantidad.Text);

                var producto = negocio.listar().First(p => p.IdProducto == id);

                if (cant > producto.Stock)
                {
                    lblMensaje.Text = "No hay stock suficiente.";
                    return;
                }

                VentaDetalle det = new VentaDetalle
                {
                    ProductoId = producto.IdProducto,
                    Nombre = producto.Nombre,
                    Cantidad = cant,
                    PrecioUnitario = producto.Precio,
                };

                ListaDetalles.Add(det);

                ActualizarGrillaYTotal();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error agregando producto: " + ex.Message;
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

        private void ActualizarGrillaYTotal()
        {
            gvDetalles.DataSource = ListaDetalles;
            gvDetalles.DataBind();

            decimal total = ListaDetalles.Sum(x => x.Subtotal);

            // Aplica aumento del 30%
            total = total * 1.30m;

            TxtTotal.Text = total.ToString("0.00");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Gestion_Ventas.aspx", false);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("abmCliente.aspx?volverA=Ventas");
        }

        protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idCliente = int.Parse(ddlCliente.SelectedValue);

                AccesoDatos datos = new AccesoDatos();
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
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar datos del cliente: " + ex.Message;
            }
        }









    }
}
