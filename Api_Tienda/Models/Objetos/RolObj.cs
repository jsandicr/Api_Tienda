﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Tienda.Models.Objetos
{
    public class RolObj
    {
        public int IdRol { get; set; }
        public string Descripcion { get; set; }
        public bool activo { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}