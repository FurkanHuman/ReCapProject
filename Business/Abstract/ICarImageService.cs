using Core.Aspects.Autofac.Performance;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int id);
        IResult Delete(CarImage entity);
        IResult Add(IFormFile formFile, CarImage entity);
        IResult AddCollective(IFormFile[] files, CarImage carImage);
        IResult Update(IFormFile formFile, CarImage entity);
        IDataResult<List<CarImage>> GetImagesByCarId(int id);
    }
}
