using Api_Tienda.BaseDatos;
using Api_Tienda.Models.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Tienda.Models.Modelos
{
    public class RolModel
    {

        RespuestaUsuario respuestaUsuario = new RespuestaUsuario();

        public RespuestaUsuario RegistrarRol(RolObj rol)
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = BaseDatos.SP_REGISTRAR_ROL(rol.Descripcion);


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

        public RespuestaUsuario ActualizarRol(RolObj rol)
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = BaseDatos.SP_ACTUALIZAR_ROL(rol.IdRol, rol.Descripcion, rol.activo);

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
    }
}