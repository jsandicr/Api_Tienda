using Api_Tienda.BaseDatos;
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
    public class CategoriaController : ApiController
    {
        CategoriaModel categoriaModel = new CategoriaModel();
        ErrorModel modelError = new ErrorModel();

        [Authorize]
        [HttpGet]
        [Route("api/Categoria")]
        public RespuestaCategoria GetCategorias()
        {
            try
            {
                return categoriaModel.GetCategorias();
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(0, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                RespuestaCategoria respuesta = new RespuestaCategoria(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/CategoriaAdmin")]
        public RespuestaCategoria GetCategoriasAdmin()
        {
            try
            {
                return categoriaModel.GetCategoriasAdmin();
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(0, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                RespuestaCategoria respuesta = new RespuestaCategoria(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/Categoria/{id}")]
        public RespuestaCategoria GetCategoriaById(int id)
        {
            try
            {
                return categoriaModel.GetCategoriaById(id);
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(0, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                RespuestaCategoria respuesta = new RespuestaCategoria(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

        [Authorize]
        [HttpPost]
        [Route("api/Categoria/RegistrarCategoria")]
        public RespuestaUsuario RegistrarCategoria(CategoriaObj categoria)
        {
            try
            {
                return categoriaModel.RegistrarCategoria(categoria);
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(categoria.IdCategoria, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                RespuestaUsuario respuesta = new RespuestaUsuario(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

        [Authorize]
        [HttpPost]
        [Route("api/Categoria/ActualizarCategoria")]
        public RespuestaUsuario ActualizarCategoria(CategoriaObj categoria)
        {
            try
            {
                return categoriaModel.ActualizarCategoria(categoria);
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(categoria.IdCategoria, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                RespuestaUsuario respuesta = new RespuestaUsuario(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

        [Authorize]
        [HttpPost]
        [Route("api/Categoria/EliminarCategoria")]
        public RespuestaUsuario EliminarCategoria(int IdCategoria)
        {
            try
            {
                return categoriaModel.EliminarCategoria(IdCategoria);
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(IdCategoria, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                RespuestaUsuario respuesta = new RespuestaUsuario(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }
    }
}