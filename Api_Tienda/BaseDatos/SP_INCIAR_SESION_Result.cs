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
    
    public partial class SP_INCIAR_SESION_Result
    {
        public int USR_ID { get; set; }
        public string USR_NOMBRE { get; set; }
        public string USR_IDENTIFICACION { get; set; }
        public string USR_CORREO { get; set; }
        public string USR_CONTRASENNA { get; set; }
        public Nullable<int> USR_ROL { get; set; }
        public Nullable<bool> USR_ACTIVO { get; set; }
        public Nullable<System.DateTime> USR_FECHA_REGISTRO { get; set; }
        public string USR_RECOVERY_TOKEN { get; set; }
        public int ROL_ID { get; set; }
        public string ROL_DESCRIPCION { get; set; }
        public Nullable<bool> ROL_ACTIVO { get; set; }
        public Nullable<System.DateTime> ROL_FECHA_REGISTRO { get; set; }
    }
}
