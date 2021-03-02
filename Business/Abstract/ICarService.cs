using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService 
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IResult Add(Car entity);
        IResult Delete(Car entity);
        IResult Update(Car entity);
        IDataResult<List<CarDetailDto>> GetCarDetailDtos();
    }
}
