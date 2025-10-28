using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Proveedor
    {
 
        public int IdProveedor { get; set; }

        public string RazonSocial { get; set; }

        public string Nombre { get; set; }

        public string Cuit { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public bool Activo { get; set; }
        //public DateTime FechaAlta { get; set; }
    }
}
