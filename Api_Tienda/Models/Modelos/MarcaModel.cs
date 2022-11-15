using Api_Tienda.BaseDatos;
using Api_Tienda.Models.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Tienda.Models.Modelos
{
    public class MarcaModel
    {
        RespuestaUsuario respuestaUsuario = new RespuestaUsuario();

        public RespuestaUsuario RegistrarMarca(MarcaObj marca)
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = BaseDatos.SP_REGISTRAR_MARCA(marca.Descripcion);

                if (respuesta > 0)
                {
                    respuestaUsuario.Codigo = 1;
                    respuestaUsuario.Mensaje = "Marca registrada correctamente";
                }
                else
                {
                    respuestaUsuario.Codigo = 0;
                    respuestaUsuario.Mensaje = "Error al registrar marca";
                }

                return respuestaUsuario;
            }
        }

        public RespuestaUsuario ActualizarMarca(MarcaObj marca)
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = BaseDatos.SP_ACTUALIZAR_MARCA(marca.IdMarca, marca.Descripcion, marca.Estado);

                if (respuesta > 0)
                {
                    respuestaUsuario.Codigo = 1;
                    respuestaUsuario.Mensaje = "Marca actualizada correctamente";
                }
                else
                {
                    respuestaUsuario.Codigo = 0;
                    respuestaUsuario.Mensaje = "Error al actualizar marca";
                }

                return respuestaUsuario;
            }
        }
    }
}