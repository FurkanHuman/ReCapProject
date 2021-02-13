﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService:IServiceRepository<Car>
    { 
        IDataResult<List<CarDetailDto>> GetCarDetailDtos();
    }
}
