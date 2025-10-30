using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    internal class ClienteNegocio
    {
        public List<Cliente> Listar()
        {
            return new List<Cliente>
            {
                new Cliente { IdCliente = 1, Nombre = "Juan Pérez", DNI = "30123456", CantidadCompras = 5, UltimaCompra = new DateTime(2025, 10, 25), MontoMaximo = 1200.50m },
                new Cliente { IdCliente = 2, Nombre = "María Gómez", DNI = "28999888", CantidadCompras = 3, UltimaCompra = new DateTime(2025, 10, 20), MontoMaximo = 890.00m },
                new Cliente { IdCliente = 3, Nombre = "Carlos Díaz", DNI = "31777888", CantidadCompras = 7, UltimaCompra = new DateTime(2025, 10, 27), MontoMaximo = 1560.75m },
                new Cliente { IdCliente = 4, Nombre = "Laura Sánchez", DNI = "29555444", CantidadCompras = 2, UltimaCompra = new DateTime(2025, 9, 30), MontoMaximo = 420.00m },
                new Cliente { IdCliente = 5, Nombre = "Pedro López", DNI = "30111888", CantidadCompras = 4, UltimaCompra = new DateTime(2025, 10, 22), MontoMaximo = 980.30m }
            };
        }
    }
}
