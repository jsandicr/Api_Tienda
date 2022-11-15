using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Tienda.Models.Objetos
{
    public class ErrorObj
    {
        public int idError { get; set; }
        public int idUsuario { get; set; }
        public DateTime fechaRegistro { get; set; } 
        public int codigo { get; set; }
        public string mensaje { get; set; }
        public string origen { get; set; }

        
    }
}