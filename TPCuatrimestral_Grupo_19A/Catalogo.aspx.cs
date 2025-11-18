using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace TPCuatrimestral_Grupo_19A
{
    public partial class Catalogo : System.Web.UI.Page
    {
        Dominio.Producto Prodcat = new Producto();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               

                if (!IsPostBack)
                {
                    CargarProductos();
                    

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
   
        private void CargarProductos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            dgvProductos.DataSource = negocio.listar();
            dgvProductos.DataBind();
        }


        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            Response.Redirect("abmProducto.aspx" ,false);
        }

        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IdProducto = dgvProductos.SelectedDataKey.Value.ToString();
            Response.Redirect("abmProducto.aspx?IdProducto=" + IdProducto);
                
        }

    }
}