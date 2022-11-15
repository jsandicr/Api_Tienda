using Api_Tienda.BaseDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Api_Tienda.Models.Modelos
{
    public class ErrorModel
    {
        public void RegistrarError(string correo, Exception ex, string metodo)
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                BaseDatos.SP_REGISTRAR_ERROR(correo, ex.HResult, ex.Message, metodo);
            }
        }

        public void RegistrarErroresId(int IdUsr, Exception ex, string metodo)
        {
            using (var BaseDatos = new DB_TIENDAEntities())
            {
                BaseDatos.SP_REGISTRAR_ERROR_ID(IdUsr, ex.HResult, ex.Message, metodo);
            }
        }
    }
}