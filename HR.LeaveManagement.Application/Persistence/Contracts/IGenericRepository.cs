namespace HR.LeaveManagement.Application.Persistence.Contracts;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetById(int id);
    Task<IReadOnlyList<T>> GetAll();
    Task<bool> Exists(int id);
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(int id);
}
