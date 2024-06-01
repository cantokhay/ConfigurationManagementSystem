using System.Linq.Expressions;

namespace Configuration.DataAccess.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll(); //Tüm verileri getirir.
        T GetById(int id);  //id'ye göre veri getirir.
        IEnumerable<T> FindPredicate(Expression<Func<T, bool>> predicate); //predicate'in LINQ sorgusu olacağını belirtir ve bu sorguya göre veri getirir.
        Task AddAsync(T entity); 
        Task UpdateAsync(T entity);

    }
}
