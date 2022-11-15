using Api_Tienda.Models.Modelos;
using Api_Tienda.Models.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Api_Tienda.Controllers
{
    public class UsuarioController : ApiController
    {
        UsuarioModel modelUsuario = new UsuarioModel();
        ErrorModel modelError = new ErrorModel();

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

        [Authorize]
        [HttpPost]
        [Route("api/Usuario/ActuzalizarUsuarioAdmin")]
        public RespuestaUsuario ActualizarUsuarioAdmin(UsuarioObj usuario)
        {
            try
            {
                return modelUsuario.ActualizarUsuarioAdmin(usuario); //Actualizar usuario llamando al model
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
        [Route("api/Usuario/RegistrarDireccion")]
        public RespuestaUsuario RegistrarDireccion(DireccionObj direccion)
        {
            try
            {
                return modelUsuario.RegistrarDireccion(direccion); //Registrar direccion llamando al model
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(direccion.IdUsuario, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                RespuestaUsuario respuesta = new RespuestaUsuario(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
            
        }

        [Authorize]
        [HttpPost]
        [Route("api/Usuario/ActualizarDireccion")]
        public RespuestaUsuario ActualizarDireccion(DireccionObj direccion)
        {
            try
            {
                return modelUsuario.ActualizarDireccion(direccion); //Registrar direccion llamando al model
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(direccion.IdUsuario, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
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