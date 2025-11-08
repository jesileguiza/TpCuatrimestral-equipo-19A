using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listar()
        {

            AccesoDatos datos = new AccesoDatos();
            List<Producto> lista = new List<Producto>();


            try
            {

                datos.setearConsulta("SELECT ProductoId, Nombre, Descripcion, Proveedor, IdMarca, IdCategoria, Stock, Precio FROM Productos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();

                    aux.IdProducto = (int)datos.Lector["ProductoId"];
                    aux.Nombre = datos.Lector["Nombre"].ToString();
                    aux.Proveedor = datos.Lector["Proveedor"].ToString();
                    aux.Stock = (int)datos.Lector["Stock"];
                    aux.Precio = Convert.ToDecimal(datos.Lector["Precio"]);

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

        public void Agregar(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"
            INSERT INTO Productos (Nombre, Descripcion, Proveedor, IdMarca, IdCategoria, Stock, Precio)
            VALUES (@Nombre, @Descripcion, @Proveedor, @IdMarca, @IdCategoria, @Stock, @Precio)
        ");

                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion ?? (object)DBNull.Value);
                datos.setearParametro("@Proveedor", nuevo.Proveedor);
                datos.setearParametro("@IdMarca", nuevo.IdMarca.HasValue ? (object)nuevo.IdMarca.Value : DBNull.Value);
                datos.setearParametro("@IdCategoria", nuevo.IdCategoria.HasValue ? (object)nuevo.IdCategoria.Value : DBNull.Value);
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














    }
}
