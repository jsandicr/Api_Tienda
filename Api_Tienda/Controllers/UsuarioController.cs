using Api_Tienda.Models.Modelos;
using Api_Tienda.Models.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api_Tienda.Controllers
{
    public class UsuarioController : ApiController
    {
        UsuarioModel modelUsuario = new UsuarioModel();
        ErrorModel modelError = new ErrorModel();

        [Authorize]
        [HttpGet]
        [Route("api/Usuario")]
        public RespuestaUsuario GetUsuarios()
        {
            try
            {
                return modelUsuario.GetUsuarios();
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(0, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                RespuestaUsuario respuesta = new RespuestaUsuario(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Authorize]
        [HttpGet]
        [Route("api/Usuario/{id}")]
        public RespuestaUsuario GetUsuarioById(int id)
        {
            try
            {
                return modelUsuario.GetUsuarioById(id);
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(0, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                RespuestaUsuario respuesta = new RespuestaUsuario(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Usuario/RegistrarUsuario")] //Ruta del api
        public RespuestaUsuario RegistrarUsuario(UsuarioObj usuario) //Controller para registrar al usuario
        {
            try
            {
                return modelUsuario.RegistrarUsuario(usuario); //Registro de usuarios llamando al model
            }
            catch (Exception ex)
            {
                modelError.RegistrarError(usuario.Correo, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                RespuestaUsuario respuesta = new RespuestaUsuario(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

        [Authorize]
        [HttpPost]
        [Route("api/Usuario/RegistrarUsuarioAdmin")] //Ruta del api
        public RespuestaUsuario RegistrarUsuarioAdmin(UsuarioObj usuario) //Controller para registrar al usuario
        {
            try
            {
                return modelUsuario.RegistrarUsuarioAdmin(usuario);
            }
            catch (Exception ex)
            {
                modelError.RegistrarError(usuario.Correo, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                RespuestaUsuario respuesta = new RespuestaUsuario(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Usuario/IniciarSesion")] //Ruta del api
        public RespuestaUsuario IniciarSesion(UsuarioObj usuario) //Controller para iniciar sesión
        {
            try
            {
                return modelUsuario.IniciarSesion(usuario); //Iniciar sesión llamando al model
            }
            catch (Exception ex)
            {
                modelError.RegistrarError(usuario.Correo, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                RespuestaUsuario respuesta = new RespuestaUsuario(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

        [Authorize]
        [HttpPost]
        [Route("api/Usuario/ActualizarUsuario")] //Ruta del api
        public RespuestaUsuario ActualizarUsuario(UsuarioObj usuario)
        {
            
            try
            {
                return modelUsuario.ActualizarUsuario(usuario); //Actualizar usuario llamando al model
            }
            catch (Exception ex)
            {
                modelError.RegistrarError(usuario.Correo, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                RespuestaUsuario respuesta = new RespuestaUsuario(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

        //[Authorize]
        [HttpPost]
        [Route("api/Usuario/EliminarUsuario")] //Ruta del api
        public RespuestaUsuario EliminarUsuario(int IdUsuario)
        {

            try
            {
                return modelUsuario.EliminarUsuario(IdUsuario); //Eliminar usuario llamando al model
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(0, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                RespuestaUsuario respuesta = new RespuestaUsuario(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Usuario/Recovery")]
        public RespuestaUsuario RegistrarToken(Recovery recovery)
        {
            try
            {
                return modelUsuario.Recovery_Token(recovery); //Registrar direccion llamando al model
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(0, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                RespuestaUsuario respuesta = new RespuestaUsuario(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

    }
}