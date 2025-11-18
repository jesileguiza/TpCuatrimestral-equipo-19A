using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace TPCuatrimestral_Grupo_19A
{
    public partial class abmProducto : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
          
            CategoriaNegocio negocioCategoria = new CategoriaNegocio();
            MarcaNegocio negocioMarca = new MarcaNegocio();
           

            try
            {


                if (!IsPostBack)
                {
                    List<Categoria> lista = negocioCategoria.Listar();

                    ddlCategoria.DataSource = lista;
                    ddlCategoria.DataValueField = "IdCategoria";
                    ddlCategoria.DataTextField= "Descripcion";
                    ddlCategoria.DataBind();

                    List<Marca> listaMarca = negocioMarca.Listar();
                    ddlMarca.DataSource = listaMarca;
                    ddlMarca.DataValueField= "IdMarca";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                }

                ProductoNegocio negocio = new ProductoNegocio();
                string IdProducto = Request.QueryString["IdProducto"] != null ? Request.QueryString["IdProducto"].ToString() : "";
               
                if (IdProducto != "")
                {
                    Producto seleccionado = (negocio.listar(IdProducto))[0];

                    //precargo la informacion
                    TxtNombre.Text = seleccionado.Nombre;
                    TxtDescripcion.Text = seleccionado.Descripcion;
                    TxtProvedores.Text = seleccionado.Proveedor;
                    TxtStock.Text = seleccionado.Stock.ToString();
                    TxtPrecio.Text = seleccionado.Precio.ToString();


                    //precargo los desplegables
                    ddlMarca.SelectedValue = seleccionado.Marca.IdMarca.ToString();
                    ddlCategoria.SelectedValue = seleccionado.categoria.IdCategoria.ToString();

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

                if (string.IsNullOrWhiteSpace(TxtNombre.Text) ||
                    string.IsNullOrWhiteSpace(TxtDescripcion.Text) ||
                    string.IsNullOrWhiteSpace(TxtProvedores.Text) ||
                    string.IsNullOrWhiteSpace(TxtStock.Text) ||
                    string.IsNullOrWhiteSpace(TxtPrecio.Text))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                        "alert",
                        "alert('Por favor complete todos los campos antes de agregar.');",
                        true);

                        return; 
                }
                    int stock;
                if (!int.TryParse(TxtStock.Text, out stock))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                        "alert",
                        "alert('El campo Stock debe contener solo números.');",
                        true);
                    return;
                }

                decimal precio;
                if (!decimal.TryParse(TxtPrecio.Text, out precio))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                        "alert",
                        "alert('El campo Precio debe contener un número válido.');",
                        true);
                    return;
                }

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


                string IdProducto = Request.QueryString["IdProducto"] != null ? Request.QueryString["IdProducto"].ToString() : "";

             
    
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