using System;
using Negocio;
using Dominio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPCuatrimestral_Grupo_19A
{
    public partial class Gestion_Ventas : System.Web.UI.Page
    {
        VentaNegocio Negocio = new VentaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["RolUsuario"] == null)
                Response.Redirect("Default.aspx");

            string rol = Session["RolUsuario"].ToString();

            if (rol != "ADMIN" && rol != "OPERADOR")
                Response.Redirect("NoAutorizado.aspx");


            if (!IsPostBack)
            {
                CargarVentas();
            }

        }



        private void CargarVentas()
        {
            dgvVentas.DataSource = Negocio.Listar();
            dgvVentas.DataBind();
        }




        protected void btnMostrarFormulario_Click(object sender, EventArgs e)
        {
            PnlFormularioVenta.Visible = true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            PnlFormularioVenta.Visible = false;
        }

        protected void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreCliente = txtCliente.Text.Trim();

                ClienteNegocio clienteNegocio = new ClienteNegocio();
                int clienteId = clienteNegocio.ObtenerIdPorNombre(nombreCliente);

                if (clienteId == 0)
                {
                    lblMensaje.Text = "El cliente no existe.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Visible = true;
                }

                Venta nueva = new Venta
                {
                    ClienteId = clienteId,
                    Fecha = DateTime.Parse(txtFecha.Text),
                    Total = decimal.Parse(txtTotal.Text)
                };

                VentaNegocio ventaNegocio = new VentaNegocio();
                ventaNegocio.Agregar(nueva);

                PnlFormularioVenta.Visible = false;
                CargarVentas();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "')</script>");
            }
        }

        public int ObtenerIdPorNombre(string nombre)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT ClientesId FROM Clientes WHERE Nombre = @Nombre");
                datos.setearParametro("@Nombre", nombre);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                    return (int)datos.Lector["ClientesId"];
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}



