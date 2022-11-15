using Api_Tienda.Models.Modelos;
using Api_Tienda.Models.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Api_Tienda.Controllers
{
    public class RolController : ApiController
    {
        RolModel modelRol = new RolModel();

        [Authorize]
        [HttpPost]
        [Route("api/Roles/RegistrarRol")]
        public RespuestaUsuario RegistrarRol(RolObj rol) 
        {
            return modelRol.RegistrarRol(rol);
        }

        [Authorize]
        [HttpPost]
        [Route("api/Roles/ActualizarRol")]
        public RespuestaUsuario ActualizarRol(RolObj rol)
        {
            return modelRol.ActualizarRol(rol);
        }
    }
}