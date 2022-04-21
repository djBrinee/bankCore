using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bankCore.Models.Calls
{
    public class InsertarPrestamo
    {
        public long ID_Cliente { get; set; }
        public byte ID_EstadoPrestamo { get; set; }
        public byte ID_TipoPrestamo { get; set; }
        public long Fuente { get; set; }
        public decimal Monto { get; set; }
        public decimal Interes { get; set; }
    }
}