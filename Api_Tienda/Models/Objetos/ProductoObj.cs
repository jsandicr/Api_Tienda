using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Tienda.Models.Objetos
{
    public class ProductoObj
    {
        public int IdProducto { get; set; }
        public int IdMarca { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
        public bool Estado { get; set; }
    }

    public class RespuestaProducto
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public ProductoObj respuestaObj { get; set; }
        public List<ProductoObj> respuestaLista { get; set; }
    }
}