using Api_Tienda.Models.Modelos;
using Api_Tienda.Models.Objetos;
using System;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api_Tienda.Controllers
{
    public class RolController : ApiController
    {
        RolModel modelRol = new RolModel();
        ErrorModel modelError = new ErrorModel();

        [Authorize]
        [HttpGet]
        [Route("api/Roles")]
        public RespuestaRol GetProductos()
        {
            try
            {
                return modelRol.GetRoles();
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(0, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                RespuestaRol respuesta = new RespuestaRol(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Authorize]
        [HttpGet]
        [Route("api/Roles/{id}")]
        public RespuestaRol GetRolById(int id)
        {
            try
            {
                return modelRol.GetRolById(id);
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(0, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                RespuestaRol respuesta = new RespuestaRol(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

        [Authorize]
        [HttpPost]
        [Route("api/Roles/RegistrarRol")]
        public RespuestaRol RegistrarRol(RolObj rol) 
        {
            return modelRol.RegistrarRol(rol);
        }

        [Authorize]
        [HttpPost]
        [Route("api/Roles/ActualizarRol")]
        public RespuestaRol ActualizarRol(RolObj rol)
        {
            return modelRol.ActualizarRol(rol);
        }

        [Authorize]
        [HttpPost]
        [Route("api/Roles/EliminarRol")]
        public RespuestaRol EliminarRol(int IdRol)
        {
            return modelRol.EliminarRol(IdRol);
        }
    }
}