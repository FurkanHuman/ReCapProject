using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    class CartManager : ICartService
    {
        public IResult CartToValidate(Cart cart)
        {
            if (cart.CartNumber.Length==16&&cart.Month!=DateTime.Now.Month&&cart.Year!=DateTime.Now.Year)
            {
                return new SuccessResult("Ödeme Alındı.");
            }
            return new ErrorResult("Ödeme Başarısız.");
        }
    }
}
