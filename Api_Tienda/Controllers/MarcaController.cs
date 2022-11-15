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
    public class MarcaController : ApiController
    {
        MarcaModel categoriaModel = new MarcaModel();
        ErrorModel modelError = new ErrorModel();

        [Authorize]
        [HttpPost]
        [Route("api/Marca/RegistrarMarca")]
        public RespuestaUsuario RegistrarMarca(MarcaObj marca)
        {
            try
            {
                return categoriaModel.RegistrarMarca(marca);
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(marca.IdUsuario, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                RespuestaUsuario respuesta = new RespuestaUsuario(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

        [Authorize]
        [HttpPost]
        [Route("api/Marca/ActualizarMarca")]
        public RespuestaUsuario ActualizarMarca(MarcaObj marca)
        {
            try
            {
                return categoriaModel.ActualizarMarca(marca);
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(marca.IdUsuario, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                RespuestaUsuario respuesta = new RespuestaUsuario(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }
    }
}