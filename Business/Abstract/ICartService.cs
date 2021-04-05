using Core.Utilities.Results.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface ICartService
    {
        IResult CartToValidate(Cart cart); 
    }
}
