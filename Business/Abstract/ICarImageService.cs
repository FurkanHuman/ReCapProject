using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarImageService : IServiceRepository<CarImage>
    {
        IResult Add2(IFormFile formFile, CarImage entity);
        IResult Update(IFormFile formFile, CarImage entity);
        IDataResult<List<CarImage>> GetImagesByCarId(int id);
    }
}
