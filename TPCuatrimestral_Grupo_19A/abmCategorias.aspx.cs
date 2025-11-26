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
    public partial class abmCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();

                if (!IsPostBack)
                {


                    string IdCategoria = Request.QueryString["IdCategoria"];


                    if (!string.IsNullOrEmpty(IdCategoria))
                    {
                        //modo modificar
                        btnAgregarCategoria.Text = "Modificar";
                        tituloCategoria.InnerText = "Modificar Categoria";

                        try
                        {
                            CategoriaNegocio negocio = new CategoriaNegocio();
                            List<Categoria> lista = negocio.Listar(IdCategoria);


                            if (lista != null && lista.Count > 0)
                            {
                                Categoria seleccionado = lista[0];


                                TxtNombreCategoria.Text = seleccionado.Descripcion;


                            }
                            else
                            {

                                lblMensaje.Text = "No se encontró la categoria especificada.";
                                lblMensaje.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        catch (Exception ex)
                        {

                            lblMensaje.Text = "Ocurrió un error al cargar los datos: " + ex.Message;
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }

        }

        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(TxtNombreCategoria.Text))
                {
                    lblMensaje.Text = "Por favor, completá todos los campos antes de continuar.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                CategoriaNegocio negocio = new CategoriaNegocio();
                Categoria nuevo = new Categoria();

                nuevo.Descripcion = TxtNombreCategoria.Text;



                if (Request.QueryString["IdCategoria"] != null)
                {
                    nuevo.IdCategoria = int.Parse(Request.QueryString["IdCategoria"].ToString());
                    negocio.modificarCategoria(nuevo);
                    lblMensaje.Text = "Categoria Modificada correctamente.";
                }
                else
                {
                    negocio.agregar(nuevo);
                    lblMensaje.Text = "Categoria agregada correctamente.";

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        protected void btnCancelarCategoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("Categorias.aspx");
        }
    }
}