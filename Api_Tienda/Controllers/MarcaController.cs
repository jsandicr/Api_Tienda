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
        MarcaModel marcaModel = new MarcaModel();
        ErrorModel modelError = new ErrorModel();

        [Authorize]
        [HttpGet]
        [Route("api/Marca")]
        public MarcaRespuesta ObtenerMarcas()
        {
            try
            {
                return marcaModel.ObtenerMarcas();
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(0, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                MarcaRespuesta respuesta = new MarcaRespuesta(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/MarcaAdmin")]
        public MarcaRespuesta ObtenerMarcasAdmin()
        {
            try
            {
                return marcaModel.ObtenerMarcasAdmin();
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(0, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                MarcaRespuesta respuesta = new MarcaRespuesta(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/Marca/{id}")]
        public MarcaRespuesta GetMarcaById(int id)
        {
            try
            {
                return marcaModel.GetMarcaById(id);
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(0, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                MarcaRespuesta respuesta = new MarcaRespuesta(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

        [Authorize]
        [HttpPost]
        [Route("api/Marca/RegistrarMarca")]
        public MarcaRespuesta RegistrarMarca(MarcaObj marca)
        {
            try
            {
                return marcaModel.RegistrarMarca(marca);
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(0, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                MarcaRespuesta respuesta = new MarcaRespuesta(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

        [Authorize]
        [HttpPost]
        [Route("api/Marca/ActualizarMarca")]
        public MarcaRespuesta ActualizarMarca(MarcaObj marca)
        {
            try
            {
                return marcaModel.ActualizarMarca(marca);
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(0, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                MarcaRespuesta respuesta = new MarcaRespuesta(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }

        //[Authorize]
        [HttpPost]
        [Route("api/Marca/EliminarMarca")]
        public MarcaRespuesta EliminarMarca(int IdMarca)
        {
            try
            {
                return marcaModel.EliminarMarca(IdMarca);
            }
            catch (Exception ex)
            {
                modelError.RegistrarErroresId(IdMarca, ex, MethodBase.GetCurrentMethod().Name); //Registro de errores
                MarcaRespuesta respuesta = new MarcaRespuesta(); //Creacion del nuevo objeto de respuesta
                respuesta.Codigo = -1; //El -1 se significa que ocurrió un error
                respuesta.Mensaje = "Se presentó un error"; //Mensaje de error
                return respuesta; //Retorna los datos
            }
        }
    }
}