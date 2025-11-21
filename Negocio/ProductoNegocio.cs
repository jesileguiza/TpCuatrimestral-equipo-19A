using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listar(string IdProducto = "")
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                string consulta = "SELECT P.ProductoId,P.Nombre,P.Descripcion,P.Proveedor,P.Stock,P.Precio, c.Id AS IdCategoria,C.Descripcion AS Categoria,M.Id AS IdMarca,M.Descripcion AS Marca FROM Productos P LEFT JOIN Categorias C ON P.IdCategoria = C.Id LEFT JOIN Marcas M ON P.IdMarca = M.Id  ";

                if (!string.IsNullOrEmpty(IdProducto))
                {
                    consulta += " WHERE ProductoId = @IdProducto"; 
                    datos.setearConsulta(consulta);
                    datos.setearParametro("@IdProducto", IdProducto);
                }
                else
                {
                    datos.setearConsulta(consulta);
                }

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();

                    aux.IdProducto = (int)datos.Lector["ProductoId"];
                    aux.Nombre = datos.Lector["Nombre"].ToString();
                    aux.Descripcion = datos.Lector["Descripcion"].ToString();
                    aux.Proveedor = datos.Lector["Proveedor"].ToString();
                    aux.categoria = new Categoria();
                    aux.categoria.IdCategoria =(int)datos.Lector["IdCategoria"];
                    aux.categoria.Descripcion = datos.Lector["categoria"].ToString();
                    aux.Marca = new Marca();
                    aux.Marca.IdMarca = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = datos.Lector["marca"].ToString();
                    aux.Stock = (int)datos.Lector["Stock"];
                    aux.Precio = Convert.ToDecimal(datos.Lector["Precio"]);


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


        public void agregar(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("insert into Productos(Nombre, Descripcion,Proveedor,IdMarca,IdCategoria,Stock,Precio) values (@Nombre,@Descripcion,@Proveedor,@IdMarca,@IdCategoria,@stock,@precio);");
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Proveedor" , nuevo.Proveedor);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IdMarca", nuevo.Marca.IdMarca);
                datos.setearParametro("@IdCategoria", nuevo.categoria.IdCategoria);
                datos.setearParametro("@stock", nuevo.Stock);
                datos.setearParametro("@precio", nuevo.Precio);

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
                datos.setearConsulta("update Productos set Nombre = @Nombre, Proveedor = @proveedor, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, stock = @stock, precio=@precio where ProductoId = @IdProducto;");
                datos.setearParametro("@Nombre", modificado.Nombre);
                datos.setearParametro("@Proveedor", modificado.Proveedor);
                datos.setearParametro("@Descripcion", modificado.Descripcion);
                datos.setearParametro("@IdMarca", modificado.Marca.IdMarca);
                datos.setearParametro("@IdCategoria", modificado.categoria.IdCategoria);
                datos.setearParametro("@stock", modificado.Stock);
                datos.setearParametro("@precio", modificado.Precio);
                datos.setearParametro("@IdProducto", modificado.IdProducto);
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


                datos.setearConsulta("UPDATE Productos SET Activo = 0 WHERE ProductoId = @IdProducto;");
                datos.setearParametro("@IdProducto", id);

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


                datos.setearConsulta("UPDATE Productos SET Activo = 1 WHERE ProductoId = @IdProducto;");
                datos.setearParametro("@IdProducto", id);

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

        public void darBaja(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Productos SET Activo = 0 WHERE ProductoId = @IdProducto;");
                datos.setearParametro("@IdProducto", id);

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





