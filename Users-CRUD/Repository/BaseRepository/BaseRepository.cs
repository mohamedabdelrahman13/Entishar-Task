using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Users_CRUD.Data;
using Users_CRUD.Repository.Interfaces;

namespace Users_CRUD.Repository.BaseRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;
        private readonly DbSet<T> dbSet;

        public BaseRepository(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }
        public IQueryable<T> GetAll() => dbSet.AsNoTracking().AsQueryable();
        public async Task<T?> GetByID(string id) => await dbSet.FindAsync(id);
        public async Task AddAsync(T entity) => await dbSet.AddAsync(entity);
        public void Update(T entity) => dbSet.Update(entity);
        public async Task SaveAsync() => await dbContext.SaveChangesAsync();
       
    }
}
