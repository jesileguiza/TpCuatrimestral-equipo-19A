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
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;


            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=TPCuatri_DB ; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT P.ProductoId,P.Nombre,P.Descripcion,P.Proveedor,P.Stock,P.Precio, c.Id AS IdCategoria,C.Descripcion AS Categoria,M.Id AS IdMarca,M.Descripcion AS Marca FROM Productos P LEFT JOIN Categorias C ON P.IdCategoria = C.Id LEFT JOIN Marcas M ON P.IdMarca = M.Id;";


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
                    aux.categoria = new Categoria();
                    aux.categoria.IdCategoria =(int)lector["IdCategoria"];
                    aux.categoria.Descripcion = lector["categoria"].ToString();
                    aux.Marca = new Marca();
                    aux.Marca.IdMarca = (int)lector["IdMarca"];
                    aux.Marca.Descripcion = lector["marca"].ToString();
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

        
    }
}





