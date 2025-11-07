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

                datos.setearConsulta("SELECT ProductoId, Nombre, Proveedor, Stock, Valor FROM Productos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();

                    aux.IdProducto = (int)datos.Lector["ProductoId"];
                    aux.Nombre = datos.Lector["Nombre"].ToString();
                    aux.Proveedor = datos.Lector["Proveedor"].ToString();
                    aux.Stock = (int)datos.Lector["Stock"];
                    aux.Precio = Convert.ToDecimal(datos.Lector["Valor"]);

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
    }
}
