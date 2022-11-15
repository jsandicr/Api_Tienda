using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Tienda.Models.Objetos
{
    public class CarritoObj
    {
        public int IdUsuario { get; set; }
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioProducto { get; set; }
        public int IdCarrito { get; set; }
        public int Cantidad { get; set; }
    }

    public class CarritoRespuesta
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public CarritoObj respuestaObj { get; set; }
        public List<CarritoObj> respuestaLista { get; set; }
    }
}