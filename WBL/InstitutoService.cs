using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IInstitutoService
    {
        Task<DBEntity> CREATE(InstitucionEntity entity);
        Task<DBEntity> DELETE(InstitucionEntity entity);
        Task<IEnumerable<InstitucionEntity>> GET();
        Task<InstitucionEntity> GETBYID(InstitucionEntity entity);
        Task<DBEntity> UPDATE(InstitucionEntity entity);
    }

    public class InstitutoService : IInstitutoService
    {
        private readonly IDataAccess sql;

        public InstitutoService(IDataAccess _sql)
        {
            sql = _sql;
        }
        #region MetodosCRUD

        //Metodo Get
        public async Task<IEnumerable<InstitucionEntity>> GET()
        {
            try
            {
                var result = sql.QueryAsync<InstitucionEntity>("dbo.InstitucionObtener");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        //MetodoGetById
        public async Task<InstitucionEntity> GETBYID(InstitucionEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<InstitucionEntity>(sp: "dbo.InstitucionObtener", Param: new { entity.Id_Institucion });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        //Metodo Create
        public async Task<DBEntity> CREATE(InstitucionEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.InstitucionInsertar", new
                {
                    entity.Codigo,
                    entity.Nombre,
                    entity.Telefono,
                    entity.Estado
                });


                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        //Metodo Update
        public async Task<DBEntity> UPDATE(InstitucionEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.InstitucionActualizar", new
                {
                    entity.Id_Institucion,
                    entity.Codigo,
                    entity.Nombre,
                    entity.Telefono,
                    entity.Estado
                });


                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Delete
        public async Task<DBEntity> DELETE(InstitucionEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.InstitucionEliminar", new
                {
                    entity.Id_Institucion
                });


                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

    }
}
