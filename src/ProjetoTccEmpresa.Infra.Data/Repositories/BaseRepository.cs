using Dapper;
using Infra.CrossCutting.ExteralAndHelpers;
using ProjetoTccEmpresa.Domain.Interfaces.Repositories;
using ProjetoTccEmpresa.Infra.Data.Context;
using System.Linq;
using System.Reflection;

namespace ProjetoTccEmpresa.Infra.Data.Repositories
{
    public class BaseRepository<TContext, TEntity> : IBaseRepository<TEntity> where TContext : BaseContext where TEntity : class
    {
        public BaseRepository(TContext context)
        {
            _context = context;
        }

        #region Properties

        protected readonly TContext _context;
        protected string TableName => typeof(TEntity).Name;
        protected IEnumerable<PropertyInfo> Properties
            => typeof(TEntity).GetProperties()
                              .Where(propertyInfo =>
                                propertyInfo.PropertyType == typeof(Guid) || Type.GetTypeCode(propertyInfo.PropertyType) != TypeCode.Object);
        #endregion

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _context.Connection.QueryAsync<TEntity>($"SELECT * FROM [{TableName}]");
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            string query = $@"SELECT * FROM [{TableName}] WHERE Id = @id";

            return await _context.Connection.QuerySingleAsync<TEntity>(query, new { id });
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            string query = GetInsertQuery();
            
            return await _context.Connection.QuerySingleAsync<TEntity>(query, entity, _context.Transaction);
        }

        public async Task<int> InsertRangeAsync(IEnumerable<TEntity> entities)
        {
            string query = GetInsertQuery();

            return await _context.Connection.ExecuteAsync(query, entities, _context.Transaction);
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            string query = GetUpdateQuery();

            int affectedRows = await _context.Connection.ExecuteAsync(query, entity, _context.Transaction);

            return affectedRows > 0;
        }

        public void Dispose() => GC.SuppressFinalize(this);

        #region Private

        private string GetInsertQuery()
        {
            string columns = Properties.Select(property => $"[{property.Name}]").ToStringList();

            string valus = Properties.Select(property => $"[{property.Name}]").ToStringList();

            return $"INSERT INTO [{TableName}] ({columns}) OUTPUT INSERTED.* VALUES ( {valus} )";
        }

        public string GetUpdateQuery()
        {
            IEnumerable<PropertyInfo> propertyInfos = Properties.Where(propertyInfos => propertyInfos.Name != "Id");

            string colunsAndValues = propertyInfos.Select(propertyInfos => $"[{propertyInfos.Name}]=@{propertyInfos.Name}").ToStringList();

            string query = $@"UPDATE [{TableName} SET {colunsAndValues} WHERE [Id] = @Id";

            return query;
        }
        #endregion
    }
}
