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

            if (Session["RolUsuario"] == null)
                Response.Redirect("Default.aspx");

            string rol = Session["RolUsuario"].ToString();

            if (rol != "ADMIN")
                Response.Redirect("NoAutorizado.aspx");



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

        protected void chkActivo_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chk.NamingContainer;

            int IdProducto = Convert.ToInt32(dgvProductos.DataKeys[row.RowIndex].Value);

            ProductoNegocio negocio = new ProductoNegocio();

            if (chk.Checked)
            {

                negocio.darAlta(IdProducto);
                ScriptManager.RegisterStartupScript(this, this.GetType(),
               "alertAlta",
               "alert('El producto fue dado de alta correctamente.');",
               true);


            }
            else
            {
                negocio.darBaja(IdProducto);
                ScriptManager.RegisterStartupScript(this, this.GetType(),
              "alertBaja",
              "alert('El producto fue dado de baja correctamente.');",
              true);
            }
        }
    }
}