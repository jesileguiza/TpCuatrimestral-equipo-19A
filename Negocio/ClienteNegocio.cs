using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select ClientesId,Nombre, Apellido, DNI, Email from Clientes");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.ClientesId = datos.Lector["ClientesId"] != DBNull.Value ? (int)datos.Lector["ClientesId"] : 0;
                    aux.Nombre = datos.Lector["Nombre"] != DBNull.Value ? (string)datos.Lector["Nombre"] : "VACIO";
                    aux.Apellido = datos.Lector["Apellido"] != DBNull.Value ? (string)datos.Lector["Apellido"] : "VACIO";
                    aux.DNI = datos.Lector["DNI"] != DBNull.Value ? (string)datos.Lector["DNI"] : "VACIO";
                    aux.Email = datos.Lector["Email"] != DBNull.Value ? (string)datos.Lector["Email"] : "VACIO";



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

        public void agregar(Cliente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into Clientes (Nombre, Apellido, DNI, Email) values (@Nombre, @Apellido, @DNI, @Email)");
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@DNI", nuevo.DNI);
                datos.setearParametro("@Email", nuevo.Email);
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

        public void modificarCliente(Cliente modificado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update Clientes set Nombre = @Nombre, Apellido = @Apellido, DNI = @DNI, Email = @Email where ClientesId = @ClientesId");
                datos.setearParametro("@Nombre", modificado.Nombre);
                datos.setearParametro("@Apellido", modificado.Apellido);
                datos.setearParametro("@Email", modificado.Email);
                datos.setearParametro("@ClientesId", modificado.ClientesId);
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


                datos.setearConsulta("Delete Clientes where ClientesId = @ClientesId");
                datos.setearParametro("@ClientesId", id);

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

        public int ObtenerIdPorNombre(string nombre)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT ClientesId FROM Clientes WHERE Nombre = @Nombre");
                datos.setearParametro("@Nombre", nombre);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                    return (int)datos.Lector["ClientesId"];
                else
                    return 0; // No encontrado
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

