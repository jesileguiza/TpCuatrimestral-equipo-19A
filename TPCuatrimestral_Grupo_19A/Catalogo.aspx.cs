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
    public partial class Catalogo : System.Web.UI.Page
    {
        Dominio.Producto Prodcat = new Producto();

        protected void Page_Load(object sender, EventArgs e)
        {
           /* 
            if (!IsPostBack)
            {
                CargarCatalogo();
            } 
           */

            if (!IsPostBack)
            {
                ProductoNegocio negocio = new ProductoNegocio();
                dgvProductos.DataSource = negocio.listar();
                dgvProductos.DataBind();
            }
        }

        private void CargarCatalogo()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            dgvCatalogo.DataSource = negocio.listar();
            dgvCatalogo.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            
        }

      


    }
}