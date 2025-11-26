using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> Listar(string IdCategoria = "")
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT Id, Descripcion, Activo FROM Categorias";
                if (!string.IsNullOrEmpty(IdCategoria))
                {
                    consulta += " WHERE Id = @IdCategoria";
                    datos.setearConsulta(consulta);
                    datos.setearParametro("@IdCategoria", IdCategoria);

                }
                else
                {
                    datos.setearConsulta(consulta);
                }
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    {

                        aux.IdCategoria = (int)datos.Lector["id"];
                        aux.Descripcion= datos.Lector["Descripcion"].ToString();
                        aux.Activo= (bool)datos.Lector["Activo"];


                    };
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
        public void agregar(Categoria nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into Categorias (Descripcion) values (@Descripcion);");
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

        public void modificarCategoria(Categoria modificado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update Categorias set Descripcion = @Descripcion where Id = @IdCategoria");
                datos.setearParametro("@Descripcion", modificado.Descripcion);
                datos.setearParametro("@IdCategoria", modificado.IdCategoria);
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


                datos.setearConsulta("update Categorias set Activo = 0 where Id = @IdCategoria;");
                datos.setearParametro("@IdCategoria", id);

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


                datos.setearConsulta("update Categorias set Activo = 1 where Id = @IdCategoria;");
                datos.setearParametro("@IdCategoria", id);

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
                datos.setearConsulta("SELECT Id FROM Categorias WHERE Descripcion = '@Descripcion'");
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
