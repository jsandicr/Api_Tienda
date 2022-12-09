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
    public class ProductoController : ApiController
    {
        ProductoModel productoModel = new ProductoModel();
        ErrorModel modelError = new ErrorModel();

        [Authorize]
        [HttpGet]
        [Route("api/Producto")]
        public RespuestaProducto GetProductos()
        {
            try
            {
                return productoModel.GetProductos();
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(0, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                RespuestaProducto respuesta = new RespuestaProducto(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/ProductoAdmin")]
        public RespuestaProducto GetProductosAdmin()
        {
            try
            {
                return productoModel.GetProductosAdmin();
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(0, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                RespuestaProducto respuesta = new RespuestaProducto(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Authorize]
        [HttpGet]
        [Route("api/Producto/{id}")]
        public RespuestaProducto GetProductoById(int id)
        {
            try
            {
                return productoModel.GetProductoById(id);
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(0, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                RespuestaProducto respuesta = new RespuestaProducto(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Authorize]
        [HttpGet]
        [Route("api/Producto/Categorias/{id}")]
        public RespuestaProducto GetProductoByCategoria(int id)
        {
            try
            {
                return productoModel.GetProductoByCategoria(id);
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(0, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                RespuestaProducto respuesta = new RespuestaProducto(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

        [Authorize]
        [HttpPost]
        [Route("api/Producto/RegistrarProducto")]
        public RespuestaUsuario RegistrarProducto(ProductoObj producto)
        {
            try
            {
                return productoModel.RegistrarProducto(producto);
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

        [Authorize]
        [HttpPost]
        [Route("api/Producto/ActualizarProducto")]
        public RespuestaUsuario ActualizarProducto(ProductoObj producto)
        {
            try
            {
                return productoModel.ActualizarProducto(producto);
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

        //[Authorize]
        [HttpPost]
        [Route("api/Producto/EliminarProducto")]
        public RespuestaUsuario EliminarProducto(int IdProducto)
        {
            try
            {
                return productoModel.EliminarProducto(IdProducto);
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(IdProducto, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                RespuestaUsuario respuesta = new RespuestaUsuario(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }
    }
}