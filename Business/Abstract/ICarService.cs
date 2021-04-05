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
        IDataResult<List<CarDetailDto>> GetCarDetailDtosById(int id);
        IDataResult<List<CarDetailDto>> GetByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetByBrandAndColorId(int brandId, int colorId);
    }
}
