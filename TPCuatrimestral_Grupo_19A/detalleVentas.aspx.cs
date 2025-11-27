using System;
using System.Collections.Generic;
using System.Web.UI;
using Dominio;
using Negocio;

namespace TPCuatrimestral_Grupo_19A
{
    public partial class DetalleVenta : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["VentaId"] != null)
                {
                    int ventaId;
                    if (int.TryParse(Request.QueryString["VentaId"], out ventaId))
                    {
                        CargarDetalle(ventaId);
                    }
                    else
                    {
                        lblMensaje.Text = "ID de venta inválido.";
                    }
                }
                else
                {
                    lblMensaje.Text = "No se recibió el ID de venta.";
                }
            }
        }

        private void CargarDetalle(int ventaId)
        {
            try
            {
                VentaNegocio negocio = new VentaNegocio();
                List<VentaDetalle> detalles = negocio.ListarDetallesPorVenta(ventaId);

                if (detalles.Count == 0)
                {
                    lblMensaje.Text = "No se encontraron detalles para esta venta.";
                    return;
                }

                gvDetalleVenta.DataSource = detalles;
                gvDetalleVenta.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar detalles: " + ex.Message;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Gestion_Ventas.aspx");
        }
    }
}
