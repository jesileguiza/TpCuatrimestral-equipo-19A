using System;
using Negocio;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TPCuatrimestral_Grupo_19A
{
    public partial class abmProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();



            if (!IsPostBack)
            {


                string idProveedor = Request.QueryString["IdProveedor"];


                if (!string.IsNullOrEmpty(idProveedor))
                {
                    //modo modificar
                    btnAgregarPROV.Text = "Modificar";
                    tituloProveedor.InnerText = "Modificar proveedor";

                    try
                    {
                        ProveedorNegocio negocio = new ProveedorNegocio();
                        List<Proveedor> lista = negocio.listar(idProveedor);


                        if (lista != null && lista.Count > 0)
                        {
                            Proveedor seleccionado = lista[0];


                            TxtRazonSocialPROV.Text = seleccionado.RazonSocial;
                            TxtNombrePROV.Text = seleccionado.Nombre;
                            TxtCuitPROV.Text = seleccionado.Cuit;
                            TxtTelefonoPROV.Text = seleccionado.Telefono;
                            txtEmailPROV.Text = seleccionado.Email;
                            TxtDireccionPROV.Text = seleccionado.Direccion;
                            TxtLocalidadPROV.Text = seleccionado.Localidad;
                        }
                        else
                        {

                            lblMensaje.Text = "No se encontró el proveedor especificado.";
                            lblMensaje.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    catch (Exception ex)
                    {

                        lblMensaje.Text = "Ocurrió un error al cargar los datos: " + ex.Message;
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    btnInactivar.Visible = false;
                }
                
            }

        
        }

        protected void btnAgregarPROV_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(TxtRazonSocialPROV.Text) ||
                string.IsNullOrWhiteSpace(TxtNombrePROV.Text) ||
                string.IsNullOrWhiteSpace(TxtCuitPROV.Text) ||
                string.IsNullOrWhiteSpace(TxtTelefonoPROV.Text) ||
                string.IsNullOrWhiteSpace(txtEmailPROV.Text) ||
                string.IsNullOrWhiteSpace(TxtDireccionPROV.Text) ||
                string.IsNullOrWhiteSpace(TxtLocalidadPROV.Text))
                {
                    lblMensaje.Text = "Por favor, completá todos los campos antes de continuar.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                ProveedorNegocio negocio = new ProveedorNegocio();
                Proveedor nuevo = new Proveedor();
                
                nuevo.RazonSocial = TxtRazonSocialPROV.Text;
                nuevo.Nombre = TxtNombrePROV.Text;
                nuevo.Cuit = TxtCuitPROV.Text;
                nuevo.Telefono = TxtTelefonoPROV.Text;
                nuevo.Email = txtEmailPROV.Text;
                nuevo.Direccion = TxtDireccionPROV.Text;
                nuevo.Localidad = TxtLocalidadPROV.Text;

                if (Request.QueryString["IdProveedor"] != null)
                {
                    nuevo.IdProveedor = int.Parse(Request.QueryString["IdProveedor"].ToString());
                    negocio.modificarProveedor(nuevo);
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                "alert",
                "alert('Proveedor modificado correctamente'); window.location='Proveedores.aspx';",
                true);
                }
                else
                {
                    negocio.agregar(nuevo);
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                     "alert",
                      "alert('Proveedor agregado correctamente'); window.location='Proveedores.aspx';",
                     true);

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }

        protected void btnCancelarPROV_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proveedores.aspx");
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            //try
            //{

            //    ProveedorNegocio negocio = new ProveedorNegocio();
            //    Proveedor seleccionado = (Proveedor)Session["proveedorSeleccionado"];
            //    bool nuevoEstado = !seleccionado.Activo;


            //    negocio.Estado(int.Parse(Request.QueryString["IdProducto"].ToString()), nuevoEstado);

            //    string mensaje = nuevoEstado ?
            //     "El producto fue reactivado correctamente" :
            //     "El producto fue inactivado correctamente";

            //    ScriptManager.RegisterStartupScript(this, this.GetType(),
            //       "alert",
            //       $"alert('{mensaje}'); window.location='catalogo.aspx';",
            //       true);



            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
        }
    }
}