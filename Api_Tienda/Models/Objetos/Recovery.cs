using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Tienda.Models.Objetos
{
    public class Recovery
    {
        public string Correo { get; set; }
        public string Token { get; set; }
    }
}