using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int id);
        IResult Add(Rental entity);
        IResult Delete(Rental entity);
        IResult Update(Rental entity);
        IDataResult<List<RentalDetailDto>> GetRentalDetailsDtos();
    }
}
