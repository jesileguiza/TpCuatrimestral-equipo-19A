using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
        public int VentaId { get; set; }
        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public List<VentaDetalle> Detalles { get; set; } = new List<VentaDetalle>();



    }
}
