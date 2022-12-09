using Antlr.Runtime.Misc;
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

        public RespuestaUsuario GetUsuarios()
        {
            RespuestaUsuario respuestaUsuario = new RespuestaUsuario();
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = (from x in BaseDatos.USUARIO join r in BaseDatos.ROL on x.USR_ROL equals r.ROL_ID join t in BaseDatos.USR_TELEFONO on x.USR_ID equals t.TEL_ID_USUARIO_FK select new { x, r, t }).ToList();

                if (respuesta.Count > 0)
                {
                    List<UsuarioObj> datos = new List<UsuarioObj>();
                    foreach (var item in respuesta)
                    {
                        RolObj rol = new RolObj();
                        rol.IdRol = item.r.ROL_ID;
                        rol.Descripcion = item.r.ROL_DESCRIPCION;

                        List<TelefonoObj> telefonos = new List<TelefonoObj>();

                        foreach (var telefono in respuesta)
                        {
                            telefonos.Add(new TelefonoObj
                            {
                                IdTelefono = telefono.t.TEL_ID,
                                Numero = telefono.t.TEL_NUMERO
                            });
                        }

                        datos.Add(new UsuarioObj
                        {
                            IdUsuario = item.x.USR_ID,
                            TipoUsuario = rol,
                            Nombre = item.x.USR_NOMBRE,
                            Identificacion = item.x.USR_IDENTIFICACION,
                            Correo = item.x.USR_CORREO,
                            Telefono = telefonos,
                            Activo = (bool)item.x.USR_ACTIVO
                        });
                    }
                    respuestaUsuario.Codigo = 1;
                    respuestaUsuario.Mensaje = "Usuarios obtenidas con exito";
                    respuestaUsuario.respuestaLista = datos;
                }
                else
                {
                    respuestaUsuario.Codigo = 0;
                    respuestaUsuario.Mensaje = "No hay usuarios aun";
                }

                return respuestaUsuario;
            }
        }

        public RespuestaUsuario GetUsuarioById(int id)
        {
            RespuestaUsuario respuestaUsuario = new RespuestaUsuario();
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = (from x in BaseDatos.USUARIO join r in BaseDatos.ROL on x.USR_ROL equals r.ROL_ID join t in BaseDatos.USR_TELEFONO on x.USR_ID equals t.TEL_ID_USUARIO_FK where x.USR_ID == id select new { x, r, t }).ToList();
                UsuarioObj usuario = new UsuarioObj();

                if (respuesta.Count > 0)
                {
                    UsuarioObj datos = new UsuarioObj();
                    foreach (var item in respuesta)
                    {
                        RolObj rol = new RolObj();
                        rol.IdRol = item.r.ROL_ID;
                        rol.Descripcion = item.r.ROL_DESCRIPCION;

                        List<TelefonoObj> telefonos = new List<TelefonoObj>();

                        foreach (var telefono in respuesta)
                        {
                            telefonos.Add(new TelefonoObj
                            {
                                IdTelefono = telefono.t.TEL_ID,
                                Numero = telefono.t.TEL_NUMERO
                            });
                        }

                        usuario.IdUsuario = item.x.USR_ID;
                        usuario.TipoUsuario = rol;
                        usuario.Nombre = item.x.USR_NOMBRE;
                        usuario.Identificacion = item.x.USR_IDENTIFICACION;
                        usuario.Correo = item.x.USR_CORREO;
                        usuario.Telefono = telefonos;
                        usuario.Activo = (bool)item.x.USR_ACTIVO;
                    }
                    respuestaUsuario.Codigo = 1;
                    respuestaUsuario.Mensaje = "Usuarios obtenidas con exito";
                    respuestaUsuario.respuestaObj = usuario;
                }
                else
                {
                    respuestaUsuario.Codigo = 0;
                    respuestaUsuario.Mensaje = "No hay usuarios aun";
                }

                return respuestaUsuario;
            }
        }

        public RespuestaUsuario RegistrarUsuario(UsuarioObj usuario)
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = BaseDatos.SP_REGISTRAR_USUARIO(usuario.Nombre, usuario.Identificacion, usuario.Correo, usuario.Contrasenna, usuario.Telefono[0].Numero);

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

        public RespuestaUsuario RegistrarUsuarioAdmin(UsuarioObj usuario)
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = BaseDatos.SP_REGISTRAR_USUARIOADMIN(usuario.Nombre, usuario.Identificacion, usuario.Correo, usuario.Contrasenna, usuario.Telefono[0].Numero, usuario.TipoUsuario.IdRol);

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
                    RolObj rol = new RolObj();
                    rol.IdRol = respuesta.ROL_ID;
                    rol.Descripcion = respuesta.ROL_DESCRIPCION;

                    usuarioObj.IdUsuario = respuesta.USR_ID;
                    usuarioObj.TipoUsuario = rol;
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
                var respuesta = BaseDatos.SP_ACTUALIZAR_USUARIO(usuario.IdUsuario, usuario.TipoUsuario.IdRol, usuario.Nombre, usuario.Identificacion, usuario.Correo, usuario.Activo);

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

        public RespuestaUsuario EliminarUsuario(int IdUsuario)
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = BaseDatos.SP_ELIMINAR_USUARIO(IdUsuario);

                if (respuesta > 0)
                {
                    respuestaUsuario.Codigo = 1;
                    respuestaUsuario.Mensaje = "OK";
                }
                else
                {
                    respuestaUsuario.Codigo = 0;
                    respuestaUsuario.Mensaje = "No se pudo eliminar";
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
