namespace LeaveManagement.Application.Persistence.Contracts;
internal interface IGenericRepository<T> where T : class
{
    Task<T> Get(int id);
    Task<IReadOnlyList<T>> GetAll();
    Task<T> Add(T entity);
    Task<T> Delete(T entity);
    Task<T> Update(T entity);
}
