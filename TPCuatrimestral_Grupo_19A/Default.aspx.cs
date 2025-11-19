using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Negocio;

namespace TPCuatrimestral_Grupo_19A
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = TxtUsuario.Text.Trim();
            string contrasena = TxtContra.Text.Trim();

            AccesoDatos datos = new AccesoDatos();
            // Aquí deberías implementar la lógica para validar el usuario y la contraseña
            // Por ejemplo, podrías consultar una base de datos para verificar las credenciales
            if (ValidarCredenciales(usuario, contrasena))
            {
                
                Response.Redirect("Pagina_Ppal.aspx");
            }
            else
            {
                MostrarError( "Usuario o contraseña incorrectos.");
            }
        }


        public void MostrarError(string mensaje)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.ForeColor = System.Drawing.Color.Red;
            lblMensaje.Visible = true;
        }


        public bool ValidarCredenciales(string User, string Pass)
        {
            AccesoDatos datos = new AccesoDatos();

            if (string.IsNullOrWhiteSpace(User))
            {
                MostrarError("Ingrese un usuario.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Pass))
            {
                MostrarError("Ingrese una contraseña.");
                return false;
            }

            if (Pass.Length < 4)
            {
                MostrarError("La contraseña debe tener al menos 4 caracteres.");
                return false;
            }

            if (User.Contains("'") || User.Contains(";"))
            {
                MostrarError("Usuario inválido.");
                return false;
            }


            try
            {
                datos.setearConsulta("SELECT Usuario, Password, Rol FROM Usuarios WHERE Usuario = @Usuario AND Password = @Password");
                datos.setearParametro("@Usuario", User);
                datos.setearParametro("@Password", Pass);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    string passwordReal = datos.Lector.GetString(1);
                    string rol = datos.Lector.GetString(2);

                    if (passwordReal == Pass)

                        Session["RolUsuario"] = rol;
                    
                    return true;

                }
                else
                {
                    // Usuario no encontrado
                    return false;
                }
            }
            catch (Exception )
            {
                return false;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }


        }


    
