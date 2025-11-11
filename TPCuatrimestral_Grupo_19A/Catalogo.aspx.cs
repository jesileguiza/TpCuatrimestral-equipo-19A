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
          
          ProductoNegocio negocio = new ProductoNegocio();
            dgvProductos.DataSource = negocio.listar();
            dgvProductos.DataBind();
        }



        private void CargarProductos()
        {
           
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {




        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            Response.Redirect("abmProducto.aspx" ,false);
        }
    }
}