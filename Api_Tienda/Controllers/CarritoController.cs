using Api_Tienda.BaseDatos;
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
    public class CarritoController : ApiController
    {
        CarritoModel modelCarrito = new CarritoModel();
        ErrorModel modelError = new ErrorModel();

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Authorize]
        [HttpPost]
        [Route("api/Carrito/AgregarACarrito")] //Ruta del api
        public CarritoRespuesta AgregarProductoACarrito(CarritoObj carrito) //Controller para registrar el producto al carrito
        {
            try
            {
                return modelCarrito.AgregarProductoACarrito(carrito); //Registro de producto en carrito llamando al model
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(carrito.IdUsuario, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                CarritoRespuesta respuesta = new CarritoRespuesta(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Authorize]
        [HttpGet]
        [Route("api/Carrito/GetCarrito")] //Ruta del api
        public CarritoRespuesta GetCarrito(int id) //Controller para registrar el producto al carrito
        {
            try
            {
                return modelCarrito.GetCarrito(id); //Registro de producto en carrito llamando al model
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(id, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                CarritoRespuesta respuesta = new CarritoRespuesta(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }

        }

        //Este metodo es para restar una unidad de un producto existente
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Authorize]
        [HttpPost]
        [Route("api/Carrito/RestCart")]
        public CarritoRespuesta DisminuirProducto(CarritoObj carrito)
        {
            try
            {
                return modelCarrito.RestarCantidadProducto(carrito);
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(0, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                CarritoRespuesta respuesta = new CarritoRespuesta(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Authorize]
        [HttpPost]
        [Route("api/Carrito/Checkout")]
        public CarritoRespuesta Checkout(CarritoObj carrito)
        {
            try
            {
                return modelCarrito.Checkout(carrito);
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(0, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                CarritoRespuesta respuesta = new CarritoRespuesta(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }
    }
}