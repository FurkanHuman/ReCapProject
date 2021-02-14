using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService : IServiceRepository<Car>
    {
        IDataResult<List<CarDetailDto>> GetCarDetailDtos();
    }
}
