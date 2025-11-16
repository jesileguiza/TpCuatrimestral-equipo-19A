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
          
            CategoriaNegocio negocio = new CategoriaNegocio();
            MarcaNegocio negocio1 = new MarcaNegocio();

            try
            {


                if (!IsPostBack)
                {
                    List<Categoria> lista = negocio.Listar();

                    ddlCategoria.DataSource = lista;
                    ddlCategoria.DataValueField = "IdCategoria";
                    ddlCategoria.DataTextField= "Descripcion";
                    ddlCategoria.DataBind();

                    List<Marca> listaMarca = negocio1.Listar();
                    ddlMarca.DataSource = listaMarca;
                    ddlMarca.DataValueField= "IdMarca";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                }

            }
            catch (Exception ex)
            {

                throw ex ;
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {

                Producto nuevo= new Producto();
                ProductoNegocio negocio= new ProductoNegocio();

                nuevo.Nombre= TxtNombre.Text;
                nuevo.Descripcion= TxtDescripcion.Text;
                nuevo.Proveedor= TxtProvedores.Text;

                nuevo.categoria = new Categoria();
                nuevo.categoria.IdCategoria = int.Parse(ddlCategoria.SelectedValue);

                nuevo.Marca = new Marca();
                nuevo.Marca.IdMarca = int.Parse(ddlMarca.SelectedValue);

                nuevo.Stock = int.Parse(TxtStock.Text);
                nuevo.Precio= int.Parse(TxtPrecio.Text);

                negocio.agregar(nuevo);

                ScriptManager.RegisterStartupScript(this, this.GetType(),"alert","alert('Producto agregado correctamente'); window.location='catalogo.aspx';",true);

    
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalogo.aspx", false);
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
           
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }



}