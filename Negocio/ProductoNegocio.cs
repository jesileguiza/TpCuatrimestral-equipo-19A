using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listar(string IdProducto = "")
        {
            List<Producto> lista = new List<Producto>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;


            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=TPCuatri_DB ; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT ProductoId, Nombre, Descripcion, Proveedor, IdMarca, IdCategoria, Stock, Precio FROM Productos ";

                if (IdProducto != "")
                {
                    
                    comando.CommandText += "where ProductoId = " + IdProducto;
                }

                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Producto aux = new Producto();

                    aux.IdProducto = (int)lector["ProductoId"];
                    aux.Nombre = lector["Nombre"].ToString();
                    aux.Descripcion = lector["Descripcion"].ToString();
                    aux.Proveedor = lector["Proveedor"].ToString();
                    aux.Stock = (int)lector["Stock"];
                    aux.Precio = Convert.ToDecimal(lector["Precio"]);


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
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public void Agregar(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

          try
            {
             datos.setearConsulta(@"
                   INSERT INTO Productos (Nombre, Descripcion, Proveedor, IdMarca, IdCategoria, Stock, Precio)
                  (@Nombre, @Descripcion, @Proveedor, @IdMarca, @IdCategoria, @Stock, @Precio)
                   ");

                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@Proveedor", nuevo.Proveedor);
                datos.setearParametro("@IdMarca", nuevo.IdMarca);
                datos.setearParametro("@IdCategoria", nuevo.IdCategoria);
                datos.setearParametro("@Stock", nuevo.Stock);
                datos.setearParametro("@Precio", nuevo.Precio);

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

        public void modificarProducto(Producto modificado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
             
         
                datos.setearConsulta("UPDATE Productos SET Nombre = @Nombre, Descripcion = @Descripcion, Proveedor = @Proveedor, IdMarca = @IdMarca, IdCategoria = @IdCategoria, Stock = @Stock, Precio = @Precio WHERE ProductoId = @ProductoId;");

                datos.setearParametro("@Nombre", modificado.Nombre);
                datos.setearParametro("@Descripcion", modificado.Descripcion);
                datos.setearParametro("@Proveedor", modificado.Proveedor);
                datos.setearParametro("@IdMarca", modificado.IdMarca);
                datos.setearParametro("@IdCategoria", modificado.IdCategoria);
                datos.setearParametro("@Stock", modificado.Stock);
                datos.setearParametro("@Precio", modificado.Precio);
                datos.setearParametro("@ProductoId", modificado.IdProducto);

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
               
                datos.setearConsulta("DELETE FROM Productos WHERE ProductoId = @ProductoId");
                datos.setearParametro("@ProductoId", id);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                
                throw new Exception("Error al intentar eliminar el producto. Verifica si está asociado a ventas o movimientos de stock.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}





