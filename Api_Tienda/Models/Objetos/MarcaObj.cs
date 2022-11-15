using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Tienda.Models.Objetos
{
    public class MarcaObj
    {
        public int IdMarca { get; set; }
        public int IdUsuario { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}