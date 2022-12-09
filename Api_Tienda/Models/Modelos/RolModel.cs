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

        RespuestaRol respuestaRol = new RespuestaRol();

        public RespuestaRol GetRoles()
        {
            RespuestaRol respuestaRol = new RespuestaRol();
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = (from x in BaseDatos.ROL select x).ToList();

                if (respuesta.Count > 0)
                {
                    List<RolObj> datos = new List<RolObj>();
                    foreach (var item in respuesta)
                    {
                        datos.Add(new RolObj
                        {
                            IdRol = item.ROL_ID,
                            Descripcion = item.ROL_DESCRIPCION,
                            activo = (bool)item.ROL_ACTIVO
                        });
                    }
                    respuestaRol.Codigo = 1;
                    respuestaRol.Mensaje = "Roles obtenidas con exito";
                    respuestaRol.respuestaLista = datos;
                }
                else
                {
                    List<RolObj> datos = new List<RolObj>();
                    respuestaRol.Codigo = 0;
                    respuestaRol.Mensaje = "No hay roles aun";
                    respuestaRol.respuestaLista = datos;
                }

                return respuestaRol;
            }
        }

        public RespuestaRol GetRolById(int id)
        {
            RespuestaRol respuestaRol = new RespuestaRol();
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = (from x in BaseDatos.ROL where x.ROL_ID == id select x).FirstOrDefault();

                if (respuesta != null)
                {
                    RolObj rol = new RolObj();
                    rol.IdRol = respuesta.ROL_ID;
                    rol.Descripcion = respuesta.ROL_DESCRIPCION;
                    rol.activo = (bool)respuesta.ROL_ACTIVO;
                    respuestaRol.Codigo = 1;
                    respuestaRol.Mensaje = "Rol obtenido con exito";
                    respuestaRol.respuestaObj = rol;
                }
                else
                {
                    respuestaRol.Codigo = 0;
                    respuestaRol.Mensaje = "El rol no existe";
                }

                return respuestaRol;
            }
        }

        public RespuestaRol RegistrarRol(RolObj rol)
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = BaseDatos.SP_REGISTRAR_ROL(rol.Descripcion);


                if (respuesta > 0)
                {
                    respuestaRol.Codigo = 1;
                    respuestaRol.Mensaje = "OK";
                }
                else
                {
                    respuestaRol.Codigo = 0;
                    respuestaRol.Mensaje = "No se pudo registrar";
                }

                return respuestaRol;
               
            }
        }

        public RespuestaRol ActualizarRol(RolObj rol)
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = BaseDatos.SP_ACTUALIZAR_ROL(rol.IdRol, rol.Descripcion, rol.activo);

                if (respuesta > 0)
                {
                    respuestaRol.Codigo = 1;
                    respuestaRol.Mensaje = "OK";
                }
                else
                {
                    respuestaRol.Codigo = 0;
                    respuestaRol.Mensaje = "No se pudo actualizar";
                }

                return respuestaRol;
            }
        }

        public RespuestaRol EliminarRol(int IdRol)
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = BaseDatos.SP_ELIMINAR_ROL(IdRol);

                if (respuesta > 0)
                {
                    respuestaRol.Codigo = 1;
                    respuestaRol.Mensaje = "OK";
                }
                else
                {
                    respuestaRol.Codigo = 0;
                    respuestaRol.Mensaje = "No se pudo eliminar";
                }

                return respuestaRol;
            }
        }
    }
}