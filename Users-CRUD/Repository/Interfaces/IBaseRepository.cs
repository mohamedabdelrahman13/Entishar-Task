namespace Users_CRUD.Repository.Interfaces
{
    public interface IBaseRepository<T>  where T : class
    {
         IQueryable<T> GetAll();
        Task<T?> GetByID(string id);
        Task AddAsync(T entity);
        void Update(T entity);
        Task SaveAsync();
    }
}
