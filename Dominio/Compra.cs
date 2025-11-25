using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra
    {

        public int CompraId { get; set; }
        public int ProveedorId { get; set; }
        public string ProveedorNombre { get; set; }
        public string Nombre { get; set; }  /// del producto
        public string Descripcion { get; set; }

        public int Stock { get; set; }
        public int idProducto { get; set; }
        public Categoria categoria { get; set; }
        public Marca Marca { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }



    }
}
