using System.Linq.Expressions;

namespace Configuration.Business.Abstract
{
    public interface IGenericService<T> where T : class
    {
        IEnumerable<T> TGetAll();
        T TGetById(int id);
        IEnumerable<T> TFindPredicate(Expression<Func<T, bool>> predicate);
        Task TAddAsync(T entity);
        Task TUpdateAsync(T entity);
    }
}
