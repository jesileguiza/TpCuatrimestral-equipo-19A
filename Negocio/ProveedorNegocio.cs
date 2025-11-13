using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Negocio
{
    public class ProveedorNegocio
    {
        public List<Proveedor> listar(string IdProveedor = "")
        {
            List<Proveedor> lista = new List<Proveedor>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "SELECT id_Proveedor, RazonSocial, Nombre, Cuit, Telefono, Email, Direccion, Localidad, Activo FROM Proveedores";

                if (!string.IsNullOrEmpty(IdProveedor))
                {
                    consulta += " WHERE id_Proveedor = @IdProveedor";
                    datos.setearConsulta(consulta);
                    datos.setearParametro("@IdProveedor", IdProveedor);
                }
                else
                {
                    datos.setearConsulta(consulta);
                }

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Proveedor aux = new Proveedor();
                    aux.IdProveedor = datos.Lector["id_Proveedor"] != DBNull.Value ? (int)datos.Lector["id_Proveedor"] : 0;
                    aux.RazonSocial = datos.Lector["RazonSocial"] != DBNull.Value ? (string)datos.Lector["RazonSocial"] : "VACIO";
                    aux.Nombre = datos.Lector["Nombre"] != DBNull.Value ? (string)datos.Lector["Nombre"] : "VACIO";
                    aux.Cuit = datos.Lector["Cuit"] != DBNull.Value ? (string)datos.Lector["Cuit"] : "VACIO";
                    aux.Telefono = datos.Lector["Telefono"] != DBNull.Value ? (string)datos.Lector["Telefono"] : "VACIO";
                    aux.Email = datos.Lector["Email"] != DBNull.Value ? (string)datos.Lector["Email"] : "VACIO";
                    aux.Direccion = datos.Lector["Direccion"] != DBNull.Value ? (string)datos.Lector["Direccion"] : "VACIO";
                    aux.Localidad = datos.Lector["Localidad"] != DBNull.Value ? (string)datos.Lector["Localidad"] : "VACIO";
                    aux.Activo = (bool)datos.Lector["Activo"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Proveedor nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into Proveedores(RazonSocial, Nombre, Cuit, Telefono, Email, Direccion, Localidad) values(@RazonSocial, @Nombre, @Cuit, @Telefono, @Email, @Direccion, @Localidad);");
                datos.setearParametro("@RazonSocial", nuevo.RazonSocial);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Cuit", nuevo.Cuit);
                datos.setearParametro("@Telefono", nuevo.Telefono);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Direccion", nuevo.Direccion);
                datos.setearParametro("@Localidad", nuevo.Localidad);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificarProveedor(Proveedor modificado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update Proveedores set RazonSocial = @RazonSocial, Nombre = @Nombre, Cuit = @Cuit, Telefono = @Telefono, Email = @Email, Direccion = @Direccion, Localidad = @Localidad where id_Proveedor = @id_Proveedor;");
                datos.setearParametro("@RazonSocial", modificado.RazonSocial);
                datos.setearParametro("@Nombre", modificado.Nombre);
                datos.setearParametro("@Cuit", modificado.Cuit);
                datos.setearParametro("@Telefono", modificado.Telefono);
                datos.setearParametro("@Email", modificado.Email);
                datos.setearParametro("@Direccion", modificado.Direccion);
                datos.setearParametro("@Localidad", modificado.Localidad);
                datos.setearParametro("@id_Proveedor", modificado.IdProveedor);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                

                datos.setearConsulta("UPDATE Proveedores SET Activo = 0 WHERE id_Proveedor = @id_Proveedor;");
                datos.setearParametro("@id_Proveedor", id);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void darAlta(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {


                datos.setearConsulta("UPDATE Proveedores SET Activo = 1 WHERE id_Proveedor = @id_Proveedor;");
                datos.setearParametro("@id_Proveedor", id);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
