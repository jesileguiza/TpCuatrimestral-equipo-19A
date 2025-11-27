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
    public partial class abmCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (!IsPostBack)
            {


                string idCliente = Request.QueryString["ClientesId"];


                if (!string.IsNullOrEmpty(idCliente))
                {
                    //modo modificar
                    btnAgregarCliente.Text = "Modificar";
                    tituloCliente.InnerText = "Modificar Cliente";

                    try
                    {
                        ClienteNegocio negocio = new ClienteNegocio();
                        List<Cliente> lista = negocio.listar(idCliente);


                        if (lista != null && lista.Count > 0)
                        {
                            Cliente seleccionado = lista[0];

                            

                            Session.Add("ClienteSeleccionado", seleccionado);


                            TxtNombreCliente.Text = seleccionado.Nombre;
                            TxtApellidoCliente.Text = seleccionado.Apellido;
                            TxtDNICliente.Text = seleccionado.DNI;
                            TxtEmailCliente.Text = seleccionado.Email;

                            
                            if (!seleccionado.Activo)
                                btnInactivar.Text = "Reactivar";
                           

                        }
                        else
                        {

                            lblMensaje.Text = "No se encontró el Cliente especificado.";
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
        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TxtNombreCliente.Text) ||
                    string.IsNullOrWhiteSpace(TxtApellidoCliente.Text) ||
                    string.IsNullOrWhiteSpace(TxtDNICliente.Text) ||
                    string.IsNullOrWhiteSpace(TxtEmailCliente.Text))
                {
                    lblMensaje.Text = "Por favor, completá todos los campos antes de continuar.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                ClienteNegocio negocio = new ClienteNegocio();
                Cliente nuevo = new Cliente
                {
                    Nombre = TxtNombreCliente.Text,
                    Apellido = TxtApellidoCliente.Text,
                    DNI = TxtDNICliente.Text,
                    Email = TxtEmailCliente.Text
                };

                // Revisamos si hay un cliente seleccionado en Session
                if (Session["ClienteSeleccionado"] != null)
                {
                    Cliente seleccionado = (Cliente)Session["ClienteSeleccionado"];
                    nuevo.ClientesId = seleccionado.ClientesId;
                    negocio.modificarCliente(nuevo);

                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                        "alert",
                        "alert('Cliente Modificado correctamente'); window.location='clientes.aspx';",
                        true);

                    Session.Remove("ClienteSeleccionado"); // limpiamos la Session
                }
                else
                {
                    negocio.agregar(nuevo);
                    ScriptManager.RegisterStartupScript(this, this.GetType(),
                        "alert",
                        "alert('Cliente agregado correctamente'); window.location='clientes.aspx';",
                        true);
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Ocurrió un error: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCancelarCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("Clientes.aspx");
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
          try
            {

            ClienteNegocio negocio = new ClienteNegocio();
            Cliente seleccionado = (Cliente)Session["ClienteSeleccionado"];
            bool nuevoEstado = !seleccionado.Activo;


            negocio.Estado(int.Parse(Request.QueryString["ClientesId"].ToString()), nuevoEstado);

            string mensaje = nuevoEstado ?
            "El cliente fue reactivado correctamente" :
            "El cliente fue inactivado correctamente";

            ScriptManager.RegisterStartupScript(this, this.GetType(),
               "alert",
               $"alert('{mensaje}'); window.location='clientes.aspx';",
               true);


            }
            catch (Exception ex)
            {

                throw ex;
            }



        }
    }
}