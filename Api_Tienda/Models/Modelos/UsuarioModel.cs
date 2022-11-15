using Api_Tienda.BaseDatos;
using Api_Tienda.Models.Objetos;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Api_Tienda.Models.Modelos
{
    public class UsuarioModel
    {
        RespuestaUsuario respuestaUsuario = new RespuestaUsuario();

        public RespuestaUsuario RegistrarUsuario(UsuarioObj usuario)
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = BaseDatos.SP_REGISTRAR_USUARIO(usuario.Nombre, usuario.Identificacion, usuario.Correo, usuario.Contrasenna, usuario.Telefono);

                if (respuesta > 0)
                {
                    respuestaUsuario.Codigo = 1;
                    respuestaUsuario.Mensaje = "OK";
                    var inicioSesion = IniciarSesion(usuario);
                    respuestaUsuario.respuestaObj = inicioSesion.respuestaObj;
                }
                else
                {
                    respuestaUsuario.Codigo = 0;
                    respuestaUsuario.Mensaje = "No se pudo registrar";
                }

                return respuestaUsuario;
            }
        }

        public RespuestaUsuario IniciarSesion(UsuarioObj usuario)
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = BaseDatos.SP_INCIAR_SESION(usuario.Correo, usuario.Contrasenna).FirstOrDefault();
                
                UsuarioObj usuarioObj = new UsuarioObj();

                if (respuesta != null)
                {
                    usuarioObj.IdUsuario = respuesta.USR_ID;
                    usuarioObj.TipoUsuario = (int)respuesta.USR_ROL;
                    usuarioObj.Nombre = respuesta.USR_NOMBRE;
                    usuarioObj.Identificacion = respuesta.USR_IDENTIFICACION;
                    usuarioObj.Correo = respuesta.USR_CORREO;
                    usuarioObj.Contrasenna = respuesta.USR_CONTRASENNA;
                    usuarioObj.Token = CrearToken(usuario.Correo);

                    respuestaUsuario.Codigo = 1;
                    respuestaUsuario.Mensaje = "OK";
                    respuestaUsuario.respuestaObj = usuarioObj;
                }
                else
                {
                    respuestaUsuario.Codigo = 0;
                    respuestaUsuario.Mensaje = "No se pudo iniciar sesión";
                }

                return respuestaUsuario;
            }
        }

        public RespuestaUsuario ActualizarUsuario(UsuarioObj usuario)
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = BaseDatos.SP_ACTUALIZAR_USUARIO(usuario.IdUsuario, usuario.Correo,  usuario.Telefono);

                if (respuesta > 0)
                {
                    respuestaUsuario.Codigo = 1;
                    respuestaUsuario.Mensaje = "OK";
                }
                else
                {
                    respuestaUsuario.Codigo = 0;
                    respuestaUsuario.Mensaje = "No se pudo actualizar";
                }

                return respuestaUsuario;
            }
        }

        public RespuestaUsuario ActualizarUsuarioAdmin(UsuarioObj usuario)
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = BaseDatos.SP_ACTUALIZAR_USUARIO_ADM(usuario.IdUsuario, usuario.Correo, usuario.Telefono, usuario.TipoUsuario);

                if (respuesta > 0)
                {
                    respuestaUsuario.Codigo = 1;
                    respuestaUsuario.Mensaje = "OK";
                }
                else
                {
                    respuestaUsuario.Codigo = 0;
                    respuestaUsuario.Mensaje = "No se pudo actualizar";
                }

                return respuestaUsuario;
            }
        }
        public RespuestaUsuario RegistrarDireccion(DireccionObj direccion)
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = BaseDatos.SP_REGISTRAR_DIRECCION(direccion.IdUsuario, direccion.Exacta, direccion.Pais, direccion.Provincia, direccion.Canton, direccion.Distrito);

                if (respuesta > 0)
                {
                    respuestaUsuario.Codigo = 1;
                    respuestaUsuario.Mensaje = "OK";
                }
                else
                {
                    respuestaUsuario.Codigo = 0;
                    respuestaUsuario.Mensaje = "No se pudo registrar";
                }
                return respuestaUsuario;
            }
        }

        public RespuestaUsuario ActualizarDireccion(DireccionObj direccion)
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = BaseDatos.SP_ACTUALIZAR_DIRECCION(direccion.IdUsuario, direccion.Exacta, direccion.Pais, direccion.Provincia, direccion.Canton, direccion.Distrito);

                if (respuesta > 0)
                {
                    respuestaUsuario.Codigo = 1;
                    respuestaUsuario.Mensaje = "OK";
                }
                else
                {
                    respuestaUsuario.Codigo = 0;
                    respuestaUsuario.Mensaje = "No se pudo actualizar";
                }

                return respuestaUsuario;
            }
        }

        private string CrearToken(string Correo)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, Correo)
            };

            var Token = "b14ca5898a4e4133bbce2ea2315a1916";
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Token));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(10), //Cantidad en minutos de la duración del token
                signingCredentials: cred);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public RespuestaUsuario Recovery_Token(Recovery recovery)
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = BaseDatos.SP_RECOVERY_TOKEN(recovery.Token, recovery.Correo);

                if (respuesta > 0)
                {
                    respuestaUsuario.Codigo = 1;
                    respuestaUsuario.Mensaje = "OK";
                }
                else
                {
                    respuestaUsuario.Codigo = 0;
                    respuestaUsuario.Mensaje = "No se pudo almacenar";
                }

                return respuestaUsuario;
            }
        }
    }
}
