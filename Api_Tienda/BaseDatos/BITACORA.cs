//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Api_Tienda.BaseDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class BITACORA
    {
        public int ERROR_ID { get; set; }
        public int ERROR_USR_FK { get; set; }
        public System.DateTime ERROR_FECHA_HORA { get; set; }
        public int ERROR_CODIGO { get; set; }
        public string ERROR_MENSAJE { get; set; }
        public string ERROR_ORIGEN { get; set; }
    
        public virtual USUARIO USUARIO { get; set; }
    }
}
