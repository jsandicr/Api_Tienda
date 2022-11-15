using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Tienda.Models.Objetos
{
    public class CategoriaObj
    {
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }

    public class RespuestaCategoria
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public CategoriaObj respuestaObj { get; set; }
        public List<CategoriaObj> respuestaLista { get; set; }
    }
}