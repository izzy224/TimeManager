namespace ASPBackend.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Insert(T obj);
        Task Update(T obj);
        Task Delete(int id);
        Task Save();
    }
}
