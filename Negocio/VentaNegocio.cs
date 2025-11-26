using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class VentaNegocio
    {
        public List<Venta> Listar() {
            List<Venta> lista = new List<Venta>();
            AccesoDatos datos = new AccesoDatos();
        try{
                datos.setearConsulta(@"SELECT V.VentaId, V.ClienteId, 
                                     C.Nombre AS ClienteNombre, C.Email,
                                     C.DNI, V.FechaVenta, V.Total
                                     FROM Ventas V
                                     INNER JOIN Clientes C ON V.ClienteId = C.ClientesId");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Venta v = new Venta
                    {
                        VentaId = (int)datos.Lector["VentaId"],
                        ClienteId = (int)datos.Lector["ClienteId"],
                        ClienteNombre = (string)datos.Lector["ClienteNombre"],
                        DNI = (string)datos.Lector["DNI"].ToString(),
                        Email = (string)datos.Lector["Email"].ToString(),
                        Fecha = (DateTime)datos.Lector["FechaVenta"],
                        Total = (decimal)datos.Lector["Total"]
                    };
                    lista.Add(v);
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


        public void Agregar(Venta venta)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Ventas (ClienteId, FechaVenta, Total) VALUES (@ClienteId, @FechaVenta, @Total)");
                datos.setearParametro("@ClienteId", venta.ClienteId);
                //datos.setearParametro("@DNI", venta.DNI);
                //datos.setearParametro("@Email", venta.Email);
                datos.setearParametro("@FechaVenta", venta.Fecha);
                datos.setearParametro("@Total", venta.Total);
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


        public int AgregarVentaConDetalles(Venta venta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(
                    "INSERT INTO Ventas (ClienteId, FechaVenta, Total) OUTPUT INSERTED.VentaId " +
                    "VALUES (@ClienteId, @Fecha, @Total)");

                datos.setearParametro("@ClienteId", venta.ClienteId);
                datos.setearParametro("@Fecha", venta.Fecha);
                datos.setearParametro("@Total", venta.Total);

                int idVenta = (int)datos.ejecutarScalar();

                foreach (var d in venta.Detalles)
                {
                    datos.setearConsulta(
                        "INSERT INTO VentaDetalle (VentaId, ProductoId, Cantidad, PrecioUnitario) " +
                        "VALUES (@VentaId, @ProductoId, @Cantidad, @Precio)");

                    datos.setearParametro("@VentaId", idVenta);
                    datos.setearParametro("@ProductoId", d.ProductoId);
                    datos.setearParametro("@Cantidad", d.Cantidad);
                    datos.setearParametro("@Precio", d.PrecioUnitario);

                    datos.ejecutarAccion();

                    datos.setearConsulta(
                        "UPDATE Productos SET Stock = Stock - @cantidad WHERE ProductoId = @id");
                    datos.setearParametro("@cantidad", d.Cantidad);
                    datos.setearParametro("@id", d.ProductoId);
                    datos.ejecutarAccion();
                }

                return idVenta;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }



    }


    }

