using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bankCore.Models.Answers
{
    public class InsertarClienteResp
    {
        public long Id { get; set; }
        public User Usuario { get; set; }
        public string Name { get; set; }
        public string Cedula { get; set; }  
        public bool sex { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool estado { get; set; }

    }
}