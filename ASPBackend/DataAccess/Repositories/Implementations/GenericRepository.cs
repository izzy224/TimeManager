using ASPBackend.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASPBackend.DataAccess.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DataContext Context;

        public GenericRepository(DataContext _context)
        {
            this.Context = _context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }
        public async Task Delete(int id)
        {
            var x = await GetById(id);
            Context.Set<T>().Remove(x);
            await Save();
        }

        public async Task Insert(T obj)
        {
            await Context.Set<T>().AddAsync(obj);
            await Save();
        }
        public async Task Update(T obj)
        {
            await Task.Run(() => Context.Set<T>().Update(obj));//Might reconsider, not true async
            await Save();
        }
        public async Task Save()
        {
            await Context.SaveChangesAsync();
        }
    }
}
