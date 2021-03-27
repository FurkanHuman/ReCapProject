using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int id);
        IDataResult<List<CarImage>> GetByCarId(int id);
        IResult Delete(CarImage entity);
        IResult Add(IFormFile formFile, CarImage entity);
        IResult AddCollective(IFormFile[] files, CarImage carImage);
        IResult Update(IFormFile formFile, CarImage entity);
    }
}
