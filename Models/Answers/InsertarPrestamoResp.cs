using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bankCore.Models.Answers
{
    public class InsertarPrestamoResp
    {
        public long id { get; set; }
        public long id_Cliente { get; set; }
        public byte id_EstadoPrestamo { get; set; }
        public byte id_TipoPrestamo { get; set; }
        public long Fuente { get; set; }
        public decimal Monto { get; set; }
        public decimal MontoPago { get; set; }
        public decimal Interes { get; set; }
        public DateTime fechaCreacion { get; set; }
    }
}