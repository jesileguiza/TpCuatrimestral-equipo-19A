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
    P.IdProducto,
    P.Nombre AS Producto,
    Prov.ProveedorId,
    Prov.Nombre AS Proveedor
FROM Compras C
LEFT JOIN Productos P ON C.IdProducto = P.IdProducto
LEFT JOIN Proveedores Prov ON C.ProveedorId = Prov.ProveedorId
";

                if (!string.IsNullOrEmpty(CompraId))
                {
                    consulta += " WHERE CompraId = @CompraId";
                    datos.setearConsulta(consulta);
                    datos.setearParametro("@IdProducto", CompraId);
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
                    aux.idProducto = (int)datos.Lector["IdProducto"];
                    aux.ProveedorId = (int)datos.Lector["ProveedorId"];
                    aux.categoria = new Categoria();
                    aux.categoria.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.categoria.Descripcion = datos.Lector["categoria"].ToString();
                    aux.Marca = new Marca();
                    aux.Marca.IdMarca = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = datos.Lector["marca"].ToString();
                    aux.Stock = (int)datos.Lector["Stock"];
                    aux.Total = Convert.ToDecimal(datos.Lector["Total"]);


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
