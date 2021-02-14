using Core.Utilities.Results.Abstract;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IServiceRepository<T> where T : class, new()
    {
        IDataResult<List<T>> GetAll();
        IDataResult<T> GetById(int id);
        IResult Add(T entity);
        IResult Delete(T entity);
        IResult Update(T entity);
    }
}
