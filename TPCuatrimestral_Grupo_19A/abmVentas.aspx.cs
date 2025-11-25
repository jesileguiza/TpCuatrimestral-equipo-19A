using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace TPCuatrimestral_Grupo_19A
{
    public partial class abmVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
                CargarProximoIdVenta();

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

        protected void btnAgregar_Click(object sender, EventArgs e)
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
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Gestion_Ventas.aspx", false);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
