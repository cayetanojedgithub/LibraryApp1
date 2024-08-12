namespace LibraryApp.Core.Services.Contracts
{
    public interface IBaseService<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> SaveAsync(T entity);
    }
}
