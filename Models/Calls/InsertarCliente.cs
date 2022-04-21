using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bankCore.Models.Calls
{
    public class InsertarCliente
    {
        public string CLientName { get; set; }
        public string ClientCedula { get; set; }
        public string ClientUsername { get; set; }
        public string ClientPassword { get; set; }
        public bool sex {  get; set; }
    }
}