using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MarcaNegocio
    {

        public List<Marca> Listar(string IdMarca = "")
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT Id, Descripcion, Activo FROM Marcas";
                if (!string.IsNullOrEmpty(IdMarca))
                {
                    consulta += " WHERE Id = @IdMarcas";
                    datos.setearConsulta(consulta);
                    datos.setearParametro("@IdMarcas", IdMarca);
                   
                }
                else
                {
                    datos.setearConsulta(consulta);
                }
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                   Marca aux = new Marca();
                    {

                        aux.IdMarca = (int)datos.Lector["id"];
                        aux.Descripcion = datos.Lector["Descripcion"].ToString();
                        aux.Activo = (bool)datos.Lector["Activo"];

                    }
                    ;
                    lista.Add(aux);
                }
                return lista;
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

        public void agregar(Marca nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into Marcas (Descripcion) values (@Descripcion);");
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
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

        public void modificarMarca(Marca modificado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update Marcas set Descripcion = @Descripcion where Id = @IdMarca");
                datos.setearParametro("@Descripcion", modificado.Descripcion);
                datos.setearParametro("@IdMarca", modificado.IdMarca);
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


                datos.setearConsulta("update Marcas set Activo = 0 where Id = @IdMarca;");
                datos.setearParametro("@IdMarca", id);

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


                datos.setearConsulta("update Marcas set Activo = 1 where Id = @IdMarca;");
                datos.setearParametro("@IdMarca", id);

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
                datos.setearConsulta("SELECT Id FROM Marcas WHERE Descripcion = '@Descripcion'");
                datos.setearParametro("@Descripcion", nombre);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                    return (int)datos.Lector["Id"];
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
