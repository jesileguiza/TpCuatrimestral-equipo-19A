using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Proveedor { get; set; }

        public Categoria categoria { get; set; }
        public Marca Marca { get; set; }
        public int? IdMarca { get; set; }
        public int? IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public Decimal Precio { get; set; }
    }
}
