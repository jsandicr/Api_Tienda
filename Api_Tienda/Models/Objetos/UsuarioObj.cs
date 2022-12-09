using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Tienda.Models.Objetos
{
    public class UsuarioObj
    {
        public int IdUsuario { get; set; }
        public RolObj TipoUsuario { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string Correo { get; set; }
        public string Contrasenna { get; set; }
        public List<TelefonoObj> Telefono { get; set; }
        public bool Activo { get; set; }
        public string Token { get; set; }
    }

    public class TelefonoObj
    {
        public int IdTelefono { get; set; }
        public int IdUsuario { get; set; }
        public string Numero { get; set; }
    }

    public class RespuestaUsuario
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public UsuarioObj respuestaObj { get; set; }
        public List<UsuarioObj> respuestaLista { get; set; }
    }
}