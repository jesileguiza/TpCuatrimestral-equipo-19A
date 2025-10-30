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
                new Producto { Marca = "Hawaiano", Descripcion = "COLLAR HAWAIANO FLUO CON FLECOS SURTIDOSx10 u.\r\n", Precio = 1918.00m, Stock = 15 },
                new Producto { Marca = "Rayban", Descripcion = "ANTEOJO RAYBAN LISO BLANCO  x1 LE12/01360 PS\r\n", Precio = 1093.26m, Stock = 8 },
                new Producto { Marca = "Rayban", Descripcion = "ANTEOJO RAYBAN BICOLOR AMARILLO x1 LE17AM  PS\r\n", Precio = 1126.83m, Stock = 25 },
                new Producto { Marca = "Generico", Descripcion = "GORRO PAÑO ARGENTINA (varios modelos) x1\r\n", Precio = 1246.20m, Stock = 12 },
                new Producto { Marca = "RM", Descripcion = "CORONA REY BOCA RMx1\r\n", Precio = 9750m, Stock = 10 }
            };
        }
    }
}
