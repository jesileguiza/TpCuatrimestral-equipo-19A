﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public Decimal Precio { get; set; }
    }
}
