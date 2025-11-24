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
    public partial class abmMarcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();

                if (!IsPostBack)
                {


                    string IdMarca = Request.QueryString["IdMarca"];


                    if (!string.IsNullOrEmpty(IdMarca))
                    {
                        //modo modificar
                        btnAgregarMarca.Text = "Modificar";
                        tituloMarca.InnerText = "Modificar Marca";

                        try
                        {
                            MarcaNegocio negocio = new MarcaNegocio();
                            List<Marca> lista = negocio.Listar(IdMarca);


                            if (lista != null && lista.Count > 0)
                            {
                                Marca seleccionado = lista[0];


                                TxtNombreMarca.Text = seleccionado.Descripcion;


                            }
                            else
                            {

                                lblMensaje.Text = "No se encontró la marca especificada.";
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
        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(TxtNombreMarca.Text))
                {
                    lblMensaje.Text = "Por favor, completá todos los campos antes de continuar.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                MarcaNegocio negocio = new MarcaNegocio();
                Marca nuevo = new Marca();

                nuevo.Descripcion = TxtNombreMarca.Text;



                if (Request.QueryString["IdMarca"] != null)
                {
                    nuevo.IdMarca = int.Parse(Request.QueryString["IdMarca"].ToString());
                    negocio.modificarMarca(nuevo);
                    lblMensaje.Text = "Marca Modificada correctamente.";
                }
                else
                {
                    negocio.agregar(nuevo);
                    lblMensaje.Text = "Marca agregada correctamente.";

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        protected void btnCancelarMarca_Click(object sender, EventArgs e)
        {
            Response.Redirect("Marcas.aspx");
        }
    }
}