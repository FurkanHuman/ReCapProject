﻿using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [CacheRemoveAspect("IRentalService.Get")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental entity)
        {
            if (entity.ReturnDate == null)
            {
                return new ErrorResult();
            }

            _rentalDal.Add(entity);

            return new SuccessResult();
        }

        [CacheRemoveAspect("IRentalService.Get")]
        [ValidationAspect(typeof(RentalValidator))]
        [SecuredOperation("Manager")]
        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.Listed);
        }

        [CacheAspect]
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id), Messages.Listed);
        }


        [CacheAspect(15)]
        // [PerformanceAspect(1000)]
        public IDataResult<List<RentalDetailDto>> GetRentalDetailsDtos()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetailDtos(), Messages.Listed);
        }

        public IDataResult<List<Rental>> GetRentalByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r=>r.CarId==carId),Messages.Listed);
        }

        [CacheRemoveAspect("IRentalService.Get")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult();
        }
    }
}
