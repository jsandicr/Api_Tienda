using Api_Tienda.BaseDatos;
using Api_Tienda.Models.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Tienda.Models.Modelos
{
    public class CategoriaModel
    {
        RespuestaUsuario respuestaUsuario = new RespuestaUsuario();
        public RespuestaCategoria GetCategorias()
        {
            RespuestaCategoria respuestaCategoria = new RespuestaCategoria();
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = (from x in BaseDatos.CATEGORIA where x.CAT_ACTVIVO == true select x).ToList();

                if (respuesta.Count > 0)
                {
                    List<CategoriaObj> datos = new List<CategoriaObj>();
                    foreach (var item in respuesta)
                    {
                        datos.Add(new CategoriaObj
                        {
                            IdCategoria = item.CAT_ID,
                            Descripcion = item.CAT_DESCRIPCION,
                            Estado = (bool)item.CAT_ACTVIVO
                        });
                    }
                    respuestaCategoria.Codigo = 1;
                    respuestaCategoria.Mensaje = "Categorias obtenidas con exito";
                    respuestaCategoria.respuestaLista = datos;
                }
                else
                {
                    respuestaCategoria.Codigo = 0;
                    respuestaCategoria.Mensaje = "No hay categorias aun";
                }
                        
                return respuestaCategoria;
            }
        }

        public RespuestaCategoria GetCategoriaById(int id)
        {
            RespuestaCategoria respuestaCategoria = new RespuestaCategoria();
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = (from x in BaseDatos.CATEGORIA where x.CAT_ACTVIVO == true && x.CAT_ID == id select x).FirstOrDefault();

                if (respuesta != null)
                {
                    CategoriaObj categoria = new CategoriaObj();
                    categoria.IdCategoria = respuesta.CAT_ID;
                    categoria.Descripcion = respuesta.CAT_DESCRIPCION;
                    categoria.Estado = (bool)respuesta.CAT_ACTVIVO;
                    respuestaCategoria.Codigo = 1;
                    respuestaCategoria.Mensaje = "Categorias obtenidas con exito";
                    respuestaCategoria.respuestaObj = categoria;
                }
                else
                {
                    respuestaCategoria.Codigo = 0;
                    respuestaCategoria.Mensaje = "No hay categorias aun";
                }

                return respuestaCategoria;
            }
        }
        public RespuestaUsuario RegistrarCategoria(CategoriaObj categoria)
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = BaseDatos.SP_REGISTRAR_CATEGORIA(categoria.Descripcion);

                if (respuesta > 0)
                {

                    respuestaUsuario.Codigo = 1;
                    respuestaUsuario.Mensaje = "Categoria registrada correctamente";

                }
                else
                {
                    respuestaUsuario.Codigo = 0;
                    respuestaUsuario.Mensaje = "Error al registrar categoria";
                }

                return respuestaUsuario;
            }
        }

        public RespuestaUsuario ActualizarCategoria(CategoriaObj categoria)
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = BaseDatos.SP_ACTUALIZAR_CATEGORIA(categoria.IdCategoria, categoria.Descripcion, categoria.Estado);

                if (respuesta > 0)
                {
                    respuestaUsuario.Codigo = 1;
                    respuestaUsuario.Mensaje = "Categoria actualizada correctamente";
                }
                else
                {
                    respuestaUsuario.Codigo = 0;
                    respuestaUsuario.Mensaje = "Error al actualizar categoria";
                }

                return respuestaUsuario;
            }
        }
    }
}