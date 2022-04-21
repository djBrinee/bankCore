using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bankCore.Models.Calls
{
    public class InsertarTransaccion
    {
        public byte id_TipoTransaccion { get; set; }
        public long CuentaOrigen { get; set; }
        public long CuentaDestino { get; set; }
        public decimal Monto { get; set; }

    }
}