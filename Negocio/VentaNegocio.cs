using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Negocio
{
    public class VentaNegocio
    {
        // Lista ventas
        public List<Venta> Listar()
        {
            List<Venta> lista = new List<Venta>();
            using (AccesoDatos datos = new AccesoDatos())
            {
                try
                {
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
                            ClienteNombre = datos.Lector["ClienteNombre"].ToString(),
                            DNI = datos.Lector["DNI"].ToString(),
                            Email = datos.Lector["Email"].ToString(),
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
            }
        }

        // Guardar venta simple (solo tabla Ventas)
        public void Agregar(Venta venta)
        {
            using (AccesoDatos datos = new AccesoDatos())
            {
                try
                {
                    datos.setearConsulta("INSERT INTO Ventas (ClienteId, FechaVenta, Total) VALUES (@ClienteId, @FechaVenta, @Total)");
                    datos.setearParametro("@ClienteId", venta.ClienteId);
                    datos.setearParametro("@FechaVenta", venta.Fecha);
                    datos.setearParametro("@Total", venta.Total);

                    datos.ejecutarAccion();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<VentaDetalle> ListarDetallesPorVenta(int ventaId)
        {
            List<VentaDetalle> lista = new List<VentaDetalle>();
            try
            {
                using (AccesoDatos datos = new AccesoDatos())
                {
                    string consulta = @"
                        SELECT vd.ProductoId, p.Nombre, vd.Cantidad, vd.PrecioUnitario, vd.Ganancia, vd.Subtotal
                        FROM VentaDetalle vd
                        INNER JOIN Productos p ON vd.ProductoId = p.ProductoId
                        WHERE vd.VentaId = @VentaId";

                    datos.setearConsulta(consulta);
                    datos.setearParametro("@VentaId", ventaId);
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        VentaDetalle det = new VentaDetalle
                        {
                            ProductoId = Convert.ToInt32(datos.Lector["ProductoId"]),
                            Nombre = datos.Lector["Nombre"].ToString(),
                            Cantidad = Convert.ToInt32(datos.Lector["Cantidad"]),
                            PrecioUnitario = Convert.ToDecimal(datos.Lector["PrecioUnitario"]),
                            Ganancia = Convert.ToDecimal(datos.Lector["Ganancia"]),
                            Subtotal = Convert.ToDecimal(datos.Lector["Subtotal"])
                        };
                        lista.Add(det);
                    }

                    datos.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar detalles de venta: " + ex.Message);
            }

            return lista;
        }

        public int AgregarVentaConDetalles(Venta venta)
        {
            int idVenta;

            string connectionString = "server=.\\SQLEXPRESS; database=TPCuatri_DB ; integrated security=true";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                // Insert Venta
                using (SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Ventas (ClienteId, FechaVenta, Total) OUTPUT INSERTED.VentaId VALUES (@ClienteId, @Fecha, @Total)", conexion))
                {
                    cmd.Parameters.AddWithValue("@ClienteId", venta.ClienteId);
                    cmd.Parameters.AddWithValue("@Fecha", venta.Fecha);
                    cmd.Parameters.AddWithValue("@Total", venta.Total);

                    idVenta = (int)cmd.ExecuteScalar();
                }

                // Insert Detalles
                foreach (var d in venta.Detalles)
                {
                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO VentaDetalle (VentaId, ProductoId, Cantidad, PrecioUnitario, Ganancia, Subtotal) " +
                        "VALUES (@VentaId, @ProductoId, @Cantidad, @Precio, @Ganancia, @Subtotal)", conexion))
                    {
                        cmd.Parameters.AddWithValue("@VentaId", idVenta);
                        cmd.Parameters.AddWithValue("@ProductoId", d.ProductoId);
                        cmd.Parameters.AddWithValue("@Cantidad", d.Cantidad);
                        cmd.Parameters.AddWithValue("@Precio", d.PrecioUnitario);
                        cmd.Parameters.AddWithValue("@Ganancia", d.Ganancia);
                        cmd.Parameters.AddWithValue("@Subtotal", d.Subtotal);

                        cmd.ExecuteNonQuery();
                    }

                    // Actualizar stock
                    using (SqlCommand cmd = new SqlCommand(
                        "UPDATE Productos SET Stock = Stock - @cantidad WHERE ProductoId = @id", conexion))
                    {
                        cmd.Parameters.AddWithValue("@cantidad", d.Cantidad);
                        cmd.Parameters.AddWithValue("@id", d.ProductoId);
                        cmd.ExecuteNonQuery();
                    }
                }

                conexion.Close();
            }

            return idVenta;
        }
    }
}
