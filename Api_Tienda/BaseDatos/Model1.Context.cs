﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DB_TIENDAEntities : DbContext
    {
        public DB_TIENDAEntities()
            : base("name=DB_TIENDAEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BITACORA> BITACORA { get; set; }
        public virtual DbSet<CARRITO> CARRITO { get; set; }
        public virtual DbSet<CATEGORIA> CATEGORIA { get; set; }
        public virtual DbSet<COMPRA> COMPRA { get; set; }
        public virtual DbSet<DETALLE_COMPRA> DETALLE_COMPRA { get; set; }
        public virtual DbSet<MARCA> MARCA { get; set; }
        public virtual DbSet<PRODUCTO> PRODUCTO { get; set; }
        public virtual DbSet<ROL> ROL { get; set; }
        public virtual DbSet<USR_TELEFONO> USR_TELEFONO { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
    
        public virtual int SP_ACTUALIZAR_CATEGORIA(Nullable<int> iD_DESCRIPCION, string dESCRIPCION, Nullable<bool> aCTVIVO)
        {
            var iD_DESCRIPCIONParameter = iD_DESCRIPCION.HasValue ?
                new ObjectParameter("ID_DESCRIPCION", iD_DESCRIPCION) :
                new ObjectParameter("ID_DESCRIPCION", typeof(int));
    
            var dESCRIPCIONParameter = dESCRIPCION != null ?
                new ObjectParameter("DESCRIPCION", dESCRIPCION) :
                new ObjectParameter("DESCRIPCION", typeof(string));
    
            var aCTVIVOParameter = aCTVIVO.HasValue ?
                new ObjectParameter("ACTVIVO", aCTVIVO) :
                new ObjectParameter("ACTVIVO", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ACTUALIZAR_CATEGORIA", iD_DESCRIPCIONParameter, dESCRIPCIONParameter, aCTVIVOParameter);
        }
    
        public virtual int SP_ACTUALIZAR_DIRECCION(Nullable<int> iD_USUARIO, string eXACTA, string pAIS, string pROVINCIA, string cANTON, string dISTRITO)
        {
            var iD_USUARIOParameter = iD_USUARIO.HasValue ?
                new ObjectParameter("ID_USUARIO", iD_USUARIO) :
                new ObjectParameter("ID_USUARIO", typeof(int));
    
            var eXACTAParameter = eXACTA != null ?
                new ObjectParameter("EXACTA", eXACTA) :
                new ObjectParameter("EXACTA", typeof(string));
    
            var pAISParameter = pAIS != null ?
                new ObjectParameter("PAIS", pAIS) :
                new ObjectParameter("PAIS", typeof(string));
    
            var pROVINCIAParameter = pROVINCIA != null ?
                new ObjectParameter("PROVINCIA", pROVINCIA) :
                new ObjectParameter("PROVINCIA", typeof(string));
    
            var cANTONParameter = cANTON != null ?
                new ObjectParameter("CANTON", cANTON) :
                new ObjectParameter("CANTON", typeof(string));
    
            var dISTRITOParameter = dISTRITO != null ?
                new ObjectParameter("DISTRITO", dISTRITO) :
                new ObjectParameter("DISTRITO", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ACTUALIZAR_DIRECCION", iD_USUARIOParameter, eXACTAParameter, pAISParameter, pROVINCIAParameter, cANTONParameter, dISTRITOParameter);
        }
    
        public virtual int SP_ACTUALIZAR_MARCA(Nullable<int> iD_MARCA, string dESCRIPCION, Nullable<bool> aCTIVO)
        {
            var iD_MARCAParameter = iD_MARCA.HasValue ?
                new ObjectParameter("ID_MARCA", iD_MARCA) :
                new ObjectParameter("ID_MARCA", typeof(int));
    
            var dESCRIPCIONParameter = dESCRIPCION != null ?
                new ObjectParameter("DESCRIPCION", dESCRIPCION) :
                new ObjectParameter("DESCRIPCION", typeof(string));
    
            var aCTIVOParameter = aCTIVO.HasValue ?
                new ObjectParameter("ACTIVO", aCTIVO) :
                new ObjectParameter("ACTIVO", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ACTUALIZAR_MARCA", iD_MARCAParameter, dESCRIPCIONParameter, aCTIVOParameter);
        }
    
        public virtual int SP_ACTUALIZAR_PRODUCTO(Nullable<int> iD_PRODUCTO, string nOMBRE, string dESCRIPCION, Nullable<int> iD_MARCA, Nullable<int> iD_CATEGORIA, Nullable<decimal> pRECIO, Nullable<int> sTOCK, Nullable<bool> aCTIVO)
        {
            var iD_PRODUCTOParameter = iD_PRODUCTO.HasValue ?
                new ObjectParameter("ID_PRODUCTO", iD_PRODUCTO) :
                new ObjectParameter("ID_PRODUCTO", typeof(int));
    
            var nOMBREParameter = nOMBRE != null ?
                new ObjectParameter("NOMBRE", nOMBRE) :
                new ObjectParameter("NOMBRE", typeof(string));
    
            var dESCRIPCIONParameter = dESCRIPCION != null ?
                new ObjectParameter("DESCRIPCION", dESCRIPCION) :
                new ObjectParameter("DESCRIPCION", typeof(string));
    
            var iD_MARCAParameter = iD_MARCA.HasValue ?
                new ObjectParameter("ID_MARCA", iD_MARCA) :
                new ObjectParameter("ID_MARCA", typeof(int));
    
            var iD_CATEGORIAParameter = iD_CATEGORIA.HasValue ?
                new ObjectParameter("ID_CATEGORIA", iD_CATEGORIA) :
                new ObjectParameter("ID_CATEGORIA", typeof(int));
    
            var pRECIOParameter = pRECIO.HasValue ?
                new ObjectParameter("PRECIO", pRECIO) :
                new ObjectParameter("PRECIO", typeof(decimal));
    
            var sTOCKParameter = sTOCK.HasValue ?
                new ObjectParameter("STOCK", sTOCK) :
                new ObjectParameter("STOCK", typeof(int));
    
            var aCTIVOParameter = aCTIVO.HasValue ?
                new ObjectParameter("ACTIVO", aCTIVO) :
                new ObjectParameter("ACTIVO", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ACTUALIZAR_PRODUCTO", iD_PRODUCTOParameter, nOMBREParameter, dESCRIPCIONParameter, iD_MARCAParameter, iD_CATEGORIAParameter, pRECIOParameter, sTOCKParameter, aCTIVOParameter);
        }
    
        public virtual int SP_ACTUALIZAR_ROL(Nullable<int> iD, string dESCRIPCION, Nullable<bool> aCTIVO)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var dESCRIPCIONParameter = dESCRIPCION != null ?
                new ObjectParameter("DESCRIPCION", dESCRIPCION) :
                new ObjectParameter("DESCRIPCION", typeof(string));
    
            var aCTIVOParameter = aCTIVO.HasValue ?
                new ObjectParameter("ACTIVO", aCTIVO) :
                new ObjectParameter("ACTIVO", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ACTUALIZAR_ROL", iDParameter, dESCRIPCIONParameter, aCTIVOParameter);
        }
    
        public virtual int SP_ACTUALIZAR_USUARIO(Nullable<int> iD_USUARIO, Nullable<int> rOL, string nOMBRE, string iDENTIFICACION, string cORREO, Nullable<bool> aCTIVO)
        {
            var iD_USUARIOParameter = iD_USUARIO.HasValue ?
                new ObjectParameter("ID_USUARIO", iD_USUARIO) :
                new ObjectParameter("ID_USUARIO", typeof(int));
    
            var rOLParameter = rOL.HasValue ?
                new ObjectParameter("ROL", rOL) :
                new ObjectParameter("ROL", typeof(int));
    
            var nOMBREParameter = nOMBRE != null ?
                new ObjectParameter("NOMBRE", nOMBRE) :
                new ObjectParameter("NOMBRE", typeof(string));
    
            var iDENTIFICACIONParameter = iDENTIFICACION != null ?
                new ObjectParameter("IDENTIFICACION", iDENTIFICACION) :
                new ObjectParameter("IDENTIFICACION", typeof(string));
    
            var cORREOParameter = cORREO != null ?
                new ObjectParameter("CORREO", cORREO) :
                new ObjectParameter("CORREO", typeof(string));
    
            var aCTIVOParameter = aCTIVO.HasValue ?
                new ObjectParameter("ACTIVO", aCTIVO) :
                new ObjectParameter("ACTIVO", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ACTUALIZAR_USUARIO", iD_USUARIOParameter, rOLParameter, nOMBREParameter, iDENTIFICACIONParameter, cORREOParameter, aCTIVOParameter);
        }
    
        public virtual int SP_ACTUALIZAR_USUARIO_ADM(Nullable<int> iD_USUARIO, string cORREO, string tELEFONO, Nullable<int> rOL)
        {
            var iD_USUARIOParameter = iD_USUARIO.HasValue ?
                new ObjectParameter("ID_USUARIO", iD_USUARIO) :
                new ObjectParameter("ID_USUARIO", typeof(int));
    
            var cORREOParameter = cORREO != null ?
                new ObjectParameter("CORREO", cORREO) :
                new ObjectParameter("CORREO", typeof(string));
    
            var tELEFONOParameter = tELEFONO != null ?
                new ObjectParameter("TELEFONO", tELEFONO) :
                new ObjectParameter("TELEFONO", typeof(string));
    
            var rOLParameter = rOL.HasValue ?
                new ObjectParameter("ROL", rOL) :
                new ObjectParameter("ROL", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ACTUALIZAR_USUARIO_ADM", iD_USUARIOParameter, cORREOParameter, tELEFONOParameter, rOLParameter);
        }
    
        public virtual int SP_ANNADIR_CANTIDAD_PRODUCTO(Nullable<int> iD_USUARIO, Nullable<int> iD_PRODUCTO)
        {
            var iD_USUARIOParameter = iD_USUARIO.HasValue ?
                new ObjectParameter("ID_USUARIO", iD_USUARIO) :
                new ObjectParameter("ID_USUARIO", typeof(int));
    
            var iD_PRODUCTOParameter = iD_PRODUCTO.HasValue ?
                new ObjectParameter("ID_PRODUCTO", iD_PRODUCTO) :
                new ObjectParameter("ID_PRODUCTO", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ANNADIR_CANTIDAD_PRODUCTO", iD_USUARIOParameter, iD_PRODUCTOParameter);
        }
    
        public virtual int SP_ELIMINAR_CATEGORIA(Nullable<int> cAT_ID)
        {
            var cAT_IDParameter = cAT_ID.HasValue ?
                new ObjectParameter("CAT_ID", cAT_ID) :
                new ObjectParameter("CAT_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ELIMINAR_CATEGORIA", cAT_IDParameter);
        }
    
        public virtual int SP_ELIMINAR_MARCA(Nullable<int> mCA_ID)
        {
            var mCA_IDParameter = mCA_ID.HasValue ?
                new ObjectParameter("MCA_ID", mCA_ID) :
                new ObjectParameter("MCA_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ELIMINAR_MARCA", mCA_IDParameter);
        }
    
        public virtual int SP_ELIMINAR_PRODUCTO(Nullable<int> pRD_ID)
        {
            var pRD_IDParameter = pRD_ID.HasValue ?
                new ObjectParameter("PRD_ID", pRD_ID) :
                new ObjectParameter("PRD_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ELIMINAR_PRODUCTO", pRD_IDParameter);
        }
    
        public virtual int SP_ELIMINAR_PRODUCTO_CARRITO(Nullable<int> cAR_ID, Nullable<int> pRD_ID, Nullable<int> cANTIDAD_PRODUCTO)
        {
            var cAR_IDParameter = cAR_ID.HasValue ?
                new ObjectParameter("CAR_ID", cAR_ID) :
                new ObjectParameter("CAR_ID", typeof(int));
    
            var pRD_IDParameter = pRD_ID.HasValue ?
                new ObjectParameter("PRD_ID", pRD_ID) :
                new ObjectParameter("PRD_ID", typeof(int));
    
            var cANTIDAD_PRODUCTOParameter = cANTIDAD_PRODUCTO.HasValue ?
                new ObjectParameter("CANTIDAD_PRODUCTO", cANTIDAD_PRODUCTO) :
                new ObjectParameter("CANTIDAD_PRODUCTO", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ELIMINAR_PRODUCTO_CARRITO", cAR_IDParameter, pRD_IDParameter, cANTIDAD_PRODUCTOParameter);
        }
    
        public virtual int SP_ELIMINAR_ROL(Nullable<int> rOL_ID)
        {
            var rOL_IDParameter = rOL_ID.HasValue ?
                new ObjectParameter("ROL_ID", rOL_ID) :
                new ObjectParameter("ROL_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ELIMINAR_ROL", rOL_IDParameter);
        }
    
        public virtual int SP_ELIMINAR_USUARIO(Nullable<int> uSR_ID)
        {
            var uSR_IDParameter = uSR_ID.HasValue ?
                new ObjectParameter("USR_ID", uSR_ID) :
                new ObjectParameter("USR_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_ELIMINAR_USUARIO", uSR_IDParameter);
        }
    
        public virtual ObjectResult<SP_INCIAR_SESION_Result> SP_INCIAR_SESION(string cORREO, string cONTRASENNA)
        {
            var cORREOParameter = cORREO != null ?
                new ObjectParameter("CORREO", cORREO) :
                new ObjectParameter("CORREO", typeof(string));
    
            var cONTRASENNAParameter = cONTRASENNA != null ?
                new ObjectParameter("CONTRASENNA", cONTRASENNA) :
                new ObjectParameter("CONTRASENNA", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_INCIAR_SESION_Result>("SP_INCIAR_SESION", cORREOParameter, cONTRASENNAParameter);
        }
    
        public virtual int SP_RECOVERY_TOKEN(string uSR_RECOVERY_TOKEN, string cORREO)
        {
            var uSR_RECOVERY_TOKENParameter = uSR_RECOVERY_TOKEN != null ?
                new ObjectParameter("USR_RECOVERY_TOKEN", uSR_RECOVERY_TOKEN) :
                new ObjectParameter("USR_RECOVERY_TOKEN", typeof(string));
    
            var cORREOParameter = cORREO != null ?
                new ObjectParameter("CORREO", cORREO) :
                new ObjectParameter("CORREO", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_RECOVERY_TOKEN", uSR_RECOVERY_TOKENParameter, cORREOParameter);
        }
    
        public virtual int SP_REGISTRAR_CATEGORIA(string dESCRIPCION)
        {
            var dESCRIPCIONParameter = dESCRIPCION != null ?
                new ObjectParameter("DESCRIPCION", dESCRIPCION) :
                new ObjectParameter("DESCRIPCION", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_REGISTRAR_CATEGORIA", dESCRIPCIONParameter);
        }
    
        public virtual int SP_REGISTRAR_DIRECCION(Nullable<int> iD_USUARIO, string eXACTA, string pAIS, string pROVINCIA, string cANTON, string dISTRITO)
        {
            var iD_USUARIOParameter = iD_USUARIO.HasValue ?
                new ObjectParameter("ID_USUARIO", iD_USUARIO) :
                new ObjectParameter("ID_USUARIO", typeof(int));
    
            var eXACTAParameter = eXACTA != null ?
                new ObjectParameter("EXACTA", eXACTA) :
                new ObjectParameter("EXACTA", typeof(string));
    
            var pAISParameter = pAIS != null ?
                new ObjectParameter("PAIS", pAIS) :
                new ObjectParameter("PAIS", typeof(string));
    
            var pROVINCIAParameter = pROVINCIA != null ?
                new ObjectParameter("PROVINCIA", pROVINCIA) :
                new ObjectParameter("PROVINCIA", typeof(string));
    
            var cANTONParameter = cANTON != null ?
                new ObjectParameter("CANTON", cANTON) :
                new ObjectParameter("CANTON", typeof(string));
    
            var dISTRITOParameter = dISTRITO != null ?
                new ObjectParameter("DISTRITO", dISTRITO) :
                new ObjectParameter("DISTRITO", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_REGISTRAR_DIRECCION", iD_USUARIOParameter, eXACTAParameter, pAISParameter, pROVINCIAParameter, cANTONParameter, dISTRITOParameter);
        }
    
        public virtual int SP_REGISTRAR_ERROR(string correo, Nullable<int> eRROR_CODIGO, string eRROR_MENSAJE, string eRROR_ORIGEN)
        {
            var correoParameter = correo != null ?
                new ObjectParameter("Correo", correo) :
                new ObjectParameter("Correo", typeof(string));
    
            var eRROR_CODIGOParameter = eRROR_CODIGO.HasValue ?
                new ObjectParameter("ERROR_CODIGO", eRROR_CODIGO) :
                new ObjectParameter("ERROR_CODIGO", typeof(int));
    
            var eRROR_MENSAJEParameter = eRROR_MENSAJE != null ?
                new ObjectParameter("ERROR_MENSAJE", eRROR_MENSAJE) :
                new ObjectParameter("ERROR_MENSAJE", typeof(string));
    
            var eRROR_ORIGENParameter = eRROR_ORIGEN != null ?
                new ObjectParameter("ERROR_ORIGEN", eRROR_ORIGEN) :
                new ObjectParameter("ERROR_ORIGEN", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_REGISTRAR_ERROR", correoParameter, eRROR_CODIGOParameter, eRROR_MENSAJEParameter, eRROR_ORIGENParameter);
        }
    
        public virtual int SP_REGISTRAR_ERROR_ID(Nullable<int> eRROR_USR_FK, Nullable<int> eRROR_CODIGO, string eRROR_MENSAJE, string eRROR_ORIGEN)
        {
            var eRROR_USR_FKParameter = eRROR_USR_FK.HasValue ?
                new ObjectParameter("ERROR_USR_FK", eRROR_USR_FK) :
                new ObjectParameter("ERROR_USR_FK", typeof(int));
    
            var eRROR_CODIGOParameter = eRROR_CODIGO.HasValue ?
                new ObjectParameter("ERROR_CODIGO", eRROR_CODIGO) :
                new ObjectParameter("ERROR_CODIGO", typeof(int));
    
            var eRROR_MENSAJEParameter = eRROR_MENSAJE != null ?
                new ObjectParameter("ERROR_MENSAJE", eRROR_MENSAJE) :
                new ObjectParameter("ERROR_MENSAJE", typeof(string));
    
            var eRROR_ORIGENParameter = eRROR_ORIGEN != null ?
                new ObjectParameter("ERROR_ORIGEN", eRROR_ORIGEN) :
                new ObjectParameter("ERROR_ORIGEN", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_REGISTRAR_ERROR_ID", eRROR_USR_FKParameter, eRROR_CODIGOParameter, eRROR_MENSAJEParameter, eRROR_ORIGENParameter);
        }
    
        public virtual int SP_REGISTRAR_MARCA(string dESCRIPCION)
        {
            var dESCRIPCIONParameter = dESCRIPCION != null ?
                new ObjectParameter("DESCRIPCION", dESCRIPCION) :
                new ObjectParameter("DESCRIPCION", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_REGISTRAR_MARCA", dESCRIPCIONParameter);
        }
    
        public virtual int SP_REGISTRAR_PRODUCTO(string nOMBRE, string dESCRIPCION, Nullable<int> iD_MARCA, Nullable<int> iD_CATEGORIA, Nullable<decimal> pRECIO, Nullable<int> sTOCK)
        {
            var nOMBREParameter = nOMBRE != null ?
                new ObjectParameter("NOMBRE", nOMBRE) :
                new ObjectParameter("NOMBRE", typeof(string));
    
            var dESCRIPCIONParameter = dESCRIPCION != null ?
                new ObjectParameter("DESCRIPCION", dESCRIPCION) :
                new ObjectParameter("DESCRIPCION", typeof(string));
    
            var iD_MARCAParameter = iD_MARCA.HasValue ?
                new ObjectParameter("ID_MARCA", iD_MARCA) :
                new ObjectParameter("ID_MARCA", typeof(int));
    
            var iD_CATEGORIAParameter = iD_CATEGORIA.HasValue ?
                new ObjectParameter("ID_CATEGORIA", iD_CATEGORIA) :
                new ObjectParameter("ID_CATEGORIA", typeof(int));
    
            var pRECIOParameter = pRECIO.HasValue ?
                new ObjectParameter("PRECIO", pRECIO) :
                new ObjectParameter("PRECIO", typeof(decimal));
    
            var sTOCKParameter = sTOCK.HasValue ?
                new ObjectParameter("STOCK", sTOCK) :
                new ObjectParameter("STOCK", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_REGISTRAR_PRODUCTO", nOMBREParameter, dESCRIPCIONParameter, iD_MARCAParameter, iD_CATEGORIAParameter, pRECIOParameter, sTOCKParameter);
        }
    
        public virtual int SP_REGISTRAR_PRODUCTO_CARRITO(Nullable<int> uSR_ID, Nullable<int> pRD_ID)
        {
            var uSR_IDParameter = uSR_ID.HasValue ?
                new ObjectParameter("USR_ID", uSR_ID) :
                new ObjectParameter("USR_ID", typeof(int));
    
            var pRD_IDParameter = pRD_ID.HasValue ?
                new ObjectParameter("PRD_ID", pRD_ID) :
                new ObjectParameter("PRD_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_REGISTRAR_PRODUCTO_CARRITO", uSR_IDParameter, pRD_IDParameter);
        }
    
        public virtual int SP_REGISTRAR_ROL(string dESCRIPCION)
        {
            var dESCRIPCIONParameter = dESCRIPCION != null ?
                new ObjectParameter("DESCRIPCION", dESCRIPCION) :
                new ObjectParameter("DESCRIPCION", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_REGISTRAR_ROL", dESCRIPCIONParameter);
        }
    
        public virtual int SP_REGISTRAR_USUARIO(string nOMBRE, string iDENTIFICACION, string cORREO, string cONTRASENNA, string tELEFONO)
        {
            var nOMBREParameter = nOMBRE != null ?
                new ObjectParameter("NOMBRE", nOMBRE) :
                new ObjectParameter("NOMBRE", typeof(string));
    
            var iDENTIFICACIONParameter = iDENTIFICACION != null ?
                new ObjectParameter("IDENTIFICACION", iDENTIFICACION) :
                new ObjectParameter("IDENTIFICACION", typeof(string));
    
            var cORREOParameter = cORREO != null ?
                new ObjectParameter("CORREO", cORREO) :
                new ObjectParameter("CORREO", typeof(string));
    
            var cONTRASENNAParameter = cONTRASENNA != null ?
                new ObjectParameter("CONTRASENNA", cONTRASENNA) :
                new ObjectParameter("CONTRASENNA", typeof(string));
    
            var tELEFONOParameter = tELEFONO != null ?
                new ObjectParameter("TELEFONO", tELEFONO) :
                new ObjectParameter("TELEFONO", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_REGISTRAR_USUARIO", nOMBREParameter, iDENTIFICACIONParameter, cORREOParameter, cONTRASENNAParameter, tELEFONOParameter);
        }
    
        public virtual int SP_RESTAR_CANTIDAD_PRODUCTO(Nullable<int> iD_USUARIO, Nullable<int> iD_PRODUCTO)
        {
            var iD_USUARIOParameter = iD_USUARIO.HasValue ?
                new ObjectParameter("ID_USUARIO", iD_USUARIO) :
                new ObjectParameter("ID_USUARIO", typeof(int));
    
            var iD_PRODUCTOParameter = iD_PRODUCTO.HasValue ?
                new ObjectParameter("ID_PRODUCTO", iD_PRODUCTO) :
                new ObjectParameter("ID_PRODUCTO", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_RESTAR_CANTIDAD_PRODUCTO", iD_USUARIOParameter, iD_PRODUCTOParameter);
        }
    
        public virtual int SP_REGISTRAR_USUARIOADMIN(string nOMBRE, string iDENTIFICACION, string cORREO, string cONTRASENNA, string tELEFONO, Nullable<int> rOL)
        {
            var nOMBREParameter = nOMBRE != null ?
                new ObjectParameter("NOMBRE", nOMBRE) :
                new ObjectParameter("NOMBRE", typeof(string));
    
            var iDENTIFICACIONParameter = iDENTIFICACION != null ?
                new ObjectParameter("IDENTIFICACION", iDENTIFICACION) :
                new ObjectParameter("IDENTIFICACION", typeof(string));
    
            var cORREOParameter = cORREO != null ?
                new ObjectParameter("CORREO", cORREO) :
                new ObjectParameter("CORREO", typeof(string));
    
            var cONTRASENNAParameter = cONTRASENNA != null ?
                new ObjectParameter("CONTRASENNA", cONTRASENNA) :
                new ObjectParameter("CONTRASENNA", typeof(string));
    
            var tELEFONOParameter = tELEFONO != null ?
                new ObjectParameter("TELEFONO", tELEFONO) :
                new ObjectParameter("TELEFONO", typeof(string));
    
            var rOLParameter = rOL.HasValue ?
                new ObjectParameter("ROL", rOL) :
                new ObjectParameter("ROL", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_REGISTRAR_USUARIOADMIN", nOMBREParameter, iDENTIFICACIONParameter, cORREOParameter, cONTRASENNAParameter, tELEFONOParameter, rOLParameter);
        }
    
        public virtual int SP_CHECKOUT(Nullable<int> iD_USUARIO)
        {
            var iD_USUARIOParameter = iD_USUARIO.HasValue ?
                new ObjectParameter("ID_USUARIO", iD_USUARIO) :
                new ObjectParameter("ID_USUARIO", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_CHECKOUT", iD_USUARIOParameter);
        }
    }
}
