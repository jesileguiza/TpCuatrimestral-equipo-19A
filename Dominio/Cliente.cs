using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente
    {
        public int ClientesId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }

        public bool Activo { get; set; }

        public int CantidadCompras { get; set; }
        public DateTime UltimaCompra { get; set; }
        public decimal MontoMaximo { get; set; }
        
    }
}
