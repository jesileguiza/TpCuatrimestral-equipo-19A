using Negocio;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;

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

            string[] peligrosos = { "<", ">", "'", "\"", ";", "--" };

            if (peligrosos.Any(p => usuario.Contains(p)))
            {
                MostrarError("El usuario contiene caracteres no permitidos.");
                return;
            }

            if (ValidarCredenciales(usuario, contrasena))
            {
                Response.Redirect("Gestion_Ventas.aspx");
            }
            else
            {
                MostrarError("Usuario o contraseña incorrectos.");
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
            if (Pass.Length < 4)
            {
                MostrarError("La contraseña debe tener al menos 4 caracteres.");
                return false;
            }

            try
            {
                using (SqlConnection conexion = new SqlConnection("server=.\\SQLEXPRESS; database=TPCuatri_DB; integrated security=true"))
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT Password, Rol FROM Usuario WHERE Usuario = @Usuario", conexion))
                    {
                        cmd.Parameters.AddWithValue("@Usuario", User);

                        using (SqlDataReader lector = cmd.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                string passwordReal = lector["Password"].ToString().Trim();
                                string rol = lector["Rol"].ToString();

                                if (passwordReal == Pass.Trim())
                                {
                                    Session["RolUsuario"] = rol;
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error de conexión: " + ex.Message);
                return false;
            }
        }

    }
}
