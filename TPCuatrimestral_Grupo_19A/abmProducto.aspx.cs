using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPCuatrimestral_Grupo_19A
{
    public partial class abmProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
         
        }



        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalogo.aspx", false);
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
           
        }


    }



}