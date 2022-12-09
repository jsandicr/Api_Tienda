using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Tienda.Models.Objetos
{
    public class MarcaObj
    {
        public int IdMarca { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
    public class MarcaRespuesta
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public MarcaObj respuestaObj { get; set; }
        public List<MarcaObj> respuestaLista { get; set; }
    }
}