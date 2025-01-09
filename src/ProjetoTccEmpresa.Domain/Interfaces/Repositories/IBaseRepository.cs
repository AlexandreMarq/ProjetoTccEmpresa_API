namespace ProjetoTccEmpresa.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> InsertAsync(TEntity entity);
        Task<int> InsertRangeAsync(IEnumerable<TEntity> entities);
        Task<bool> UpdateAsync(TEntity entities);
    }
}
