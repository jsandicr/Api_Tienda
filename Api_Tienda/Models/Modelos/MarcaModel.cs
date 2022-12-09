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
        MarcaRespuesta respuestaMarca = new MarcaRespuesta();

        public MarcaRespuesta ObtenerMarcas()
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = (from x in BaseDatos.MARCA where x.MCA_ACTIVO == true select x).ToList();

                if (respuesta.Count > 0)
                {
                    List<MarcaObj> datos = new List<MarcaObj>();
                    foreach (var item in respuesta)
                    {
                        datos.Add(new MarcaObj
                        {
                            IdMarca = item.MCA_ID,
                            Descripcion = item.MCA_DESCRIPCION,
                            Estado = (bool)item.MCA_ACTIVO
                        });
                    }
                    respuestaMarca.Codigo = 1;
                    respuestaMarca.Mensaje = "Marcas obtenidas con exito";
                    respuestaMarca.respuestaLista = datos;
                }
                else
                {
                    respuestaMarca.Codigo = 0;
                    respuestaMarca.Mensaje = "No hay marcas aun";
                }

                return respuestaMarca;
            }
        }

        public MarcaRespuesta ObtenerMarcasAdmin()
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = (from x in BaseDatos.MARCA select x).ToList();

                if (respuesta.Count > 0)
                {
                    List<MarcaObj> datos = new List<MarcaObj>();
                    foreach (var item in respuesta)
                    {
                        datos.Add(new MarcaObj
                        {
                            IdMarca = item.MCA_ID,
                            Descripcion = item.MCA_DESCRIPCION,
                            Estado = (bool)item.MCA_ACTIVO
                        });
                    }
                    respuestaMarca.Codigo = 1;
                    respuestaMarca.Mensaje = "Marcas obtenidas con exito";
                    respuestaMarca.respuestaLista = datos;
                }
                else
                {
                    respuestaMarca.Codigo = 0;
                    respuestaMarca.Mensaje = "No hay marcas aun";
                }

                return respuestaMarca;
            }
        }

        public MarcaRespuesta GetMarcaById(int id)
        {
            MarcaRespuesta respuestaMarca = new MarcaRespuesta();
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = (from x in BaseDatos.MARCA where x.MCA_ID == id select x).FirstOrDefault();

                if (respuesta != null)
                {
                    MarcaObj marca = new MarcaObj();
                    marca.IdMarca = respuesta.MCA_ID;
                    marca.Descripcion = respuesta.MCA_DESCRIPCION;
                    marca.Estado = (bool)respuesta.MCA_ACTIVO;
                    respuestaMarca.Codigo = 1;
                    respuestaMarca.Mensaje = "Marca obtenida con exito";
                    respuestaMarca.respuestaObj = marca;
                }
                else
                {
                    respuestaMarca.Codigo = 0;
                    respuestaMarca.Mensaje = "No hay marcas";
                }

                return respuestaMarca;
            }
        }

        public MarcaRespuesta RegistrarMarca(MarcaObj marca)
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = BaseDatos.SP_REGISTRAR_MARCA(marca.Descripcion);

                if (respuesta > 0)
                {
                    respuestaMarca.Codigo = 1;
                    respuestaMarca.Mensaje = "Marca registrada correctamente";
                }
                else
                {
                    respuestaMarca.Codigo = 0;
                    respuestaMarca.Mensaje = "Error al registrar marca";
                }

                return respuestaMarca;
            }
        }

        public MarcaRespuesta ActualizarMarca(MarcaObj marca)
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = BaseDatos.SP_ACTUALIZAR_MARCA(marca.IdMarca, marca.Descripcion, marca.Estado);

                if (respuesta > 0)
                {
                    respuestaMarca.Codigo = 1;
                    respuestaMarca.Mensaje = "Marca actualizada correctamente";
                }
                else
                {
                    respuestaMarca.Codigo = 0;
                    respuestaMarca.Mensaje = "Error al actualizar marca";
                }

                return respuestaMarca;
            }
        }

        public MarcaRespuesta EliminarMarca(int IdMarca)
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = BaseDatos.SP_ELIMINAR_MARCA(IdMarca);

                if (respuesta > 0)
                {
                    respuestaMarca.Codigo = 1;
                    respuestaMarca.Mensaje = "Marca eliminada correctamente";
                }
                else
                {
                    respuestaMarca.Codigo = 0;
                    respuestaMarca.Mensaje = "Error al eliminar marca";
                }

                return respuestaMarca;
            }
        }
    }
}