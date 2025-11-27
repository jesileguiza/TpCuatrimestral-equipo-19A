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

                                //guardo categoria seleccionado

                                Session.Add("CategoriaSeleccionado", seleccionado);


                                TxtNombreCategoria.Text = seleccionado.Descripcion;

                                //configurar acciones
                                if (!seleccionado.Activo)
                                    btnInactivar.Text = "Reactivar";
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
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                  "alert",
                  "alert('Categoria Modificada correctamente'); window.location='categorias.aspx';",
                  true);
                }
                else
                {
                    negocio.agregar(nuevo);
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "alert",
                    "alert('Categoria agregado correctamente'); window.location='categorias.aspx';",
                    true);

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

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                CategoriaNegocio negocio = new CategoriaNegocio();
                Categoria seleccionado = (Categoria)Session["CategoriaSeleccionado"];
                bool nuevoEstado = !seleccionado.Activo;


                negocio.Estado(int.Parse(Request.QueryString["IdCategoria"].ToString()), nuevoEstado);

                string mensaje = nuevoEstado ?
                "la categoria fue reactivada correctamente" :
                "La categoria fue inactivada correctamente";

                ScriptManager.RegisterStartupScript(this, this.GetType(),
                   "alert",
                   $"alert('{mensaje}'); window.location='categorias.aspx';",
                   true);




            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {




        }
    }
}