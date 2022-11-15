using Api_Tienda.BaseDatos;
using Api_Tienda.Models.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Tienda.Models.Modelos
{
    public class ProductoModel
    {
        RespuestaUsuario respuestaUsuario = new RespuestaUsuario();

        public RespuestaProducto GetProductos()
        {
            RespuestaProducto respuestaProducto = new RespuestaProducto();
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = (from x in BaseDatos.PRODUCTO where x.PRD_ACTIVO == true && x.PRD_STOCK > 0 select x).ToList();

                if (respuesta.Count > 0)
                {
                    List<ProductoObj> datos = new List<ProductoObj>();
                    foreach (var item in respuesta)
                    {
                        datos.Add(new ProductoObj
                        {
                            IdProducto = item.PRD_ID,
                            Nombre = item.PRD_NOMBRE,
                            Descripcion = item.PRD_DESCRIPCION,
                            Precio = (decimal)item.PRD_PRECIO,
                            Stock = (int)item.PRD_STOCK
                        });
                    }
                    respuestaProducto.Codigo = 1;
                    respuestaProducto.Mensaje = "Categorias obtenidas con exito";
                    respuestaProducto.respuestaLista = datos;
                }
                else
                {
                    List<ProductoObj> datos = new List<ProductoObj>();
                    respuestaProducto.Codigo = 0;
                    respuestaProducto.Mensaje = "No hay categorias aun";
                    respuestaProducto.respuestaLista = datos;
                }

                return respuestaProducto;
            }
        }

        public RespuestaProducto GetProductoById(int id)
        {
            RespuestaProducto respuestaProducto = new RespuestaProducto();
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = (from x in BaseDatos.PRODUCTO where x.PRD_ACTIVO == true && x.PRD_ID == id select x).FirstOrDefault();

                if (respuesta != null)
                {
                    ProductoObj producto = new ProductoObj();
                    producto.IdProducto = respuesta.PRD_ID;
                    producto.Nombre = respuesta.PRD_NOMBRE;
                    producto.Precio = (decimal)respuesta.PRD_PRECIO;
                    producto.Stock = (int)respuesta.PRD_STOCK;
                    respuestaProducto.Codigo = 1;
                    respuestaProducto.Mensaje = "Categorias obtenidas con exito";
                    respuestaProducto.respuestaObj = producto;
                }
                else
                {
                    respuestaProducto.Codigo = 0;
                    respuestaProducto.Mensaje = "El producto no existe";
                }

                return respuestaProducto;
            }
        }

        public RespuestaUsuario RegistrarProducto(ProductoObj producto)
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = BaseDatos.SP_REGISTRAR_PRODUCTO(producto.IdUsuario, producto.Nombre, producto.Descripcion, producto.IdMarca, producto.IdCategoria, producto.Precio, producto.Stock);

                if (respuesta > 0)
                {
                    respuestaUsuario.Codigo = 1;
                    respuestaUsuario.Mensaje = "Producto registrado correctamente";
                }
                else
                {
                    respuestaUsuario.Codigo = 0;
                    respuestaUsuario.Mensaje = "Error al registrar producto";
                }

                return respuestaUsuario;
            }
        }

        public RespuestaUsuario ActualizarProducto(ProductoObj producto)
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                var respuesta = BaseDatos.SP_ACTUALIZAR_PRODUCTO(producto.IdProducto, producto.IdUsuario, producto.Nombre, producto.Descripcion, producto.IdMarca, producto.IdCategoria, producto.Precio, producto.Stock, producto.Estado);

                if (respuesta > 0)
                {
                    respuestaUsuario.Codigo = 1;
                    respuestaUsuario.Mensaje = "Producto actualizado correctamente";
                }
                else
                {
                    respuestaUsuario.Codigo = 0;
                    respuestaUsuario.Mensaje = "Error al actualizar producto";
                }

                return respuestaUsuario;
            }
        }
    }
}