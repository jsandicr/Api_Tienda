using Api_Tienda.BaseDatos;
using Api_Tienda.Models.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Tienda.Models.Modelos
{
    public class CarritoModel
    {
        public CarritoRespuesta AgregarProductoACarrito(CarritoObj carrito)
        {

            CarritoRespuesta carritoRespuesta = new CarritoRespuesta();

            using (var BaseDatos = new DB_TIENDAEntities())
            {

                var respuesta = BaseDatos.SP_REGISTRAR_PRODUCTO_CARRITO(carrito.IdUsuario,carrito.IdProducto);

                if (respuesta > 0)
                {
                    carritoRespuesta.Codigo = 1;
                    carritoRespuesta.Mensaje = "Producto agregado al carrito";

                }
                else
                {
                    carritoRespuesta.Codigo = 0;
                    carritoRespuesta.Mensaje = "Error al agregar producto al carrito";
                }

                return carritoRespuesta;
            }

        }

        public CarritoRespuesta GetCarrito(int id)
        {

            CarritoRespuesta carritoRespuesta = new CarritoRespuesta();

            using (var BaseDatos = new DB_TIENDAEntities())
            {

                var respuesta = (from x in BaseDatos.CARRITO join p in BaseDatos.PRODUCTO on x.CAR_ID_PRODUCTO equals p.PRD_ID  where x.CAR_ID_USUARIO == id select new {x.CAR_ID, x.CAR_ID_PRODUCTO, p.PRD_NOMBRE, p.PRD_PRECIO,x.CAR_ID_USUARIO, x.CAR_CANTIDAD_X_PRODUCTO }).ToList();

                if (respuesta.Count > 0)
                {
                    List<CarritoObj> datos = new List<CarritoObj>();
                    foreach (var item in respuesta)
                    {
                        datos.Add(new CarritoObj
                        {
                            IdCarrito = item.CAR_ID,
                            IdProducto = item.CAR_ID_PRODUCTO,
                            NombreProducto = item.PRD_NOMBRE.ToString(),
                            PrecioProducto = (decimal)item.PRD_PRECIO,
                            IdUsuario = item.CAR_ID_USUARIO,
                            Cantidad = item.CAR_CANTIDAD_X_PRODUCTO
                        });
                    }
                    carritoRespuesta.Codigo = 1;
                    carritoRespuesta.Mensaje = "Categorias obtenidas con exito";
                    carritoRespuesta.respuestaLista = datos;
                }
                else
                {
                    carritoRespuesta.Codigo = 0;
                    carritoRespuesta.Mensaje = "No hay productos en el carrito";
                }

                return carritoRespuesta;
            }

        }

        //Metodo para aumentar cantidad de articulo en el carrito
        public RespuestaProducto AumentarCantidadProducto(ProductoObj producto)
        {
            RespuestaProducto respuestaProducto = new RespuestaProducto();
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = BaseDatos.SP_ANNADIR_CANTIDAD_PRODUCTO(producto.IdUsuario, producto.IdProducto);

                if (respuesta > 0)
                {
                    respuestaProducto.Codigo = 1;
                    respuestaProducto.Mensaje = "Carrito actualizado correctamente";
                }
                else
                {
                    respuestaProducto.Codigo = 0;
                    respuestaProducto.Mensaje = "Error al actualizar carrito";
                }

                return respuestaProducto;
            }
        }

        //Metodo para disminuir cantidad de articulo en el carrito
        public RespuestaProducto RestarCantidadProducto(ProductoObj producto)
        {
            RespuestaProducto respuestaProducto = new RespuestaProducto();
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = BaseDatos.SP_RESTAR_CANTIDAD_PRODUCTO(producto.IdUsuario, producto.IdProducto);

                if (respuesta > 0)
                {
                    respuestaProducto.Codigo = 1;
                    respuestaProducto.Mensaje = "Carrito actualizado correctamente";
                }
                else
                {
                    respuestaProducto.Codigo = 0;
                    respuestaProducto.Mensaje = "Error al actualizar carrito";
                }

                return respuestaProducto;
            }
        }
    }
}