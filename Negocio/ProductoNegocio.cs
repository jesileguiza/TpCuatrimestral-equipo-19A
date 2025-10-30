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
        public List<Producto> Listar()
        {
            return new List<Producto>
            {
                new Producto { Marca = "Samsung", Descripcion = "Smartphone Galaxy S22", Precio = 899.99m, Stock = 15 },
                new Producto { Marca = "Apple", Descripcion = "iPhone 15 Pro", Precio = 1299.00m, Stock = 8 },
                new Producto { Marca = "Sony", Descripcion = "Auriculares WH-1000XM5", Precio = 399.50m, Stock = 25 },
                new Producto { Marca = "HP", Descripcion = "Notebook Pavilion 14\"", Precio = 750.00m, Stock = 12 },
                new Producto { Marca = "LG", Descripcion = "Monitor 27'' UltraGear", Precio = 299.99m, Stock = 10 }
            };
        }
    }
}
