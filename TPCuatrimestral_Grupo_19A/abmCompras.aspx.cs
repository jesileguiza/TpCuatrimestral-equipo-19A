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
    public partial class abmCompras : System.Web.UI.Page
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
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                    List<Marca> listaMarca = negocioMarca.Listar();
                    ddlMarca.DataSource = listaMarca;
                    ddlMarca.DataValueField = "IdMarca";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                }

                CompraNegocio negocio = new CompraNegocio();
                string CompraId = Request.QueryString["CompraId"] != null ? Request.QueryString["CompraId"].ToString() : "";

                if (CompraId != "")
                {
                    Compra seleccionado = (negocio.listar(CompraId))[0];

                    //precargo la informacion
                    TxtCompraId.Text = seleccionado.CompraId.ToString();
                    TxtProveedorId.Text = seleccionado.ProveedorId.ToString();
                    TxtStock.Text = seleccionado.Stock.ToString();
                    TxtIdProducto.Text = seleccionado.idProducto.ToString();
                    TxtFecha.Text = seleccionado.Fecha.ToString("yyyy-MM-dd");
                    TxtPrecio.Text = seleccionado.Total.ToString();


                    //precargo los desplegables
                    ddlMarca.SelectedValue = seleccionado.Marca.IdMarca.ToString();
                    ddlCategoria.SelectedValue = seleccionado.categoria.IdCategoria.ToString();

                }


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {

                if (string.IsNullOrWhiteSpace(TxtCompraId.Text) ||
                    string.IsNullOrWhiteSpace(TxtProveedorId.Text) ||
                    string.IsNullOrWhiteSpace(TxtIdProducto.Text) ||
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


                /// modificar
                /*
                Compra nuevo = new Compra();
                CompraNegocio negocio = new CompraNegocio();

                nuevo.CompraId = TxtCompraId.Text;
                nuevo.Descripcion = TxtDescripcion.Text;
                nuevo.Proveedor = TxtProvedores.Text;

                nuevo.categoria = new Categoria();
                nuevo.categoria.IdCategoria = int.Parse(ddlCategoria.SelectedValue);

                nuevo.Marca = new Marca();
                nuevo.Marca.IdMarca = int.Parse(ddlMarca.SelectedValue);

                nuevo.Stock = int.Parse(TxtStock.Text);
                nuevo.Precio = int.Parse(TxtPrecio.Text);

                negocio.agregar(nuevo);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Producto agregado correctamente'); window.location='catalogo.aspx';", true);


                string IdProducto = Request.QueryString["IdProducto"] != null ? Request.QueryString["IdProducto"].ToString() : "";


                */
            }


            catch (Exception ex)
            {

                throw ex;
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Gestion_Compras.aspx", false);
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        /*protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }*/
    }
}
