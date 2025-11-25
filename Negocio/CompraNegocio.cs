using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CompraNegocio
    {
        public List<Compra> listar(string CompraId = "")
        {
            List<Compra> lista = new List<Compra>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = @"
                                  SELECT 
    C.CompraId,
    C.Fecha,
    C.Stock,
    C.Total,
    P.ProductoId,
    P.Nombre AS Nombre,
    P.Descripcion AS Descripcion,
    Prov.id_Proveedor AS IdProveedor,
    Prov.Nombre AS ProveedorNombre,
    Cat.Id AS IdCategoria,
    Cat.Descripcion AS CategoriaNombre,
    M.Id AS IdMarca,
    M.Descripcion AS MarcaNombre
FROM Compras C
LEFT JOIN Productos P ON C.IdProducto = P.ProductoId
LEFT JOIN Proveedores Prov ON C.ProveedorId = Prov.id_Proveedor
LEFT JOIN CATEGORIAS Cat ON P.IdCategoria = Cat.Id
LEFT JOIN MARCAS M ON P.IdMarca = M.Id";

                if (!string.IsNullOrEmpty(CompraId))
                {
                    consulta += " WHERE CompraId = @CompraId";
                    datos.setearConsulta(consulta);
                    datos.setearParametro("@CompraId", CompraId);
                }
                else
                {
                    datos.setearConsulta(consulta);
                }

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Compra aux = new Compra();

                    aux.CompraId = (int)datos.Lector["CompraId"];
                    aux.idProducto = datos.Lector["ProductoId"] != DBNull.Value ? (int)datos.Lector["ProductoId"] : 0;
                    aux.ProveedorNombre = datos.Lector["ProveedorNombre"].ToString();
                    aux.ProveedorId = datos.Lector["IdProveedor"] != DBNull.Value ? (int)datos.Lector["IdProveedor"] : 0;
                    aux.Nombre = datos.Lector["Nombre"].ToString();
                    aux.Descripcion = datos.Lector["Descripcion"].ToString();

                    aux.categoria = new Categoria
                    {
                        IdCategoria = datos.Lector["IdCategoria"] != DBNull.Value ? (int)datos.Lector["IdCategoria"] : 0,
                        Descripcion = datos.Lector["CategoriaNombre"].ToString()
                    };

                    aux.Marca = new Marca
                    {
                        IdMarca = datos.Lector["IdMarca"] != DBNull.Value ? (int)datos.Lector["IdMarca"] : 0,
                        Descripcion = datos.Lector["MarcaNombre"].ToString()
                    };

                    aux.Stock = datos.Lector["Stock"] != DBNull.Value ? (int)datos.Lector["Stock"] : 0;
                    aux.Total = datos.Lector["Total"] != DBNull.Value ? Convert.ToDecimal(datos.Lector["Total"]) : 0;

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




        public void agregar(Compra nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("insert into Compras(ProveedorId,Stock,IdProducto, Fecha, Total) values (@ProveedorId,@Stock,@IdProducto,@Fecha,@Total);");
                datos.setearParametro("@ProveedorId", nuevo.ProveedorId);
                datos.setearParametro("@Stock", nuevo.Stock);
                datos.setearParametro("@IdProducto", nuevo.idProducto);
                datos.setearParametro("@Fecha", nuevo.Fecha);
                datos.setearParametro("@Total", nuevo.Total);
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

        public void modificarCompra(Compra modificado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {


                datos.setearConsulta("update Compras set ProveedorId = @ProveedorId, Stock = @Stock, IdProducto = @IdProducto, Fecha = @Fecha, Total = @Total;");
                datos.setearParametro("@ProveedorId", modificado.ProveedorId);
                datos.setearParametro("@Stock", modificado.Stock);
                datos.setearParametro("@IdProducto", modificado.idProducto);
                datos.setearParametro("@Fecha", modificado.Fecha);
                datos.setearParametro("@Total", modificado.Total);
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
