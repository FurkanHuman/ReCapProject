﻿using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Aspects.Autofac.Validation;
using Core.Utilities.Busines;
using Core.Utilities.FileHelper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        readonly ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
            FileHelper.fullPath = Environment.CurrentDirectory + @"\wwwroot\Images\";
        }

        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageLimit(carImage.CarId),
                CheckIfimageGetExtension(formFile)
                );

            if (result != null)
                return result;

            CarImage cImage = new CarImage() { CarId = carImage.CarId };

            cImage.Date = DateTime.Now;
            cImage.ImagePath = FileHelper.AddAsync(formFile);
            _carImageDal.Add(cImage);

            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult AddCollective(IFormFile[] files, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageCount(files));

            if (result != null)
                return result;

            foreach (var file in files)
                Add(file, carImage);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage entity)
        {
            FileHelper.DeleteAsync(GetById(entity.Id).Data.ImagePath);
            _carImageDal.Delete(entity);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        [CacheAspect(20)]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        [ValidationAspect(typeof(CarImageValidator))]
        [CacheAspect(10)]
        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        [CacheAspect(10)]
        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            //return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == id)).Data==null?:;
            var result = _carImageDal.GetAll(p => p.CarId == id);
            return result.Count > 0 ?
                new SuccessDataResult<List<CarImage>>(result) :
                new SuccessDataResult<List<CarImage>>(new List<CarImage>() { new CarImage { ImagePath = @"\Images\default.png", CarId = id } });
        }

        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Update(IFormFile formFile, CarImage entity)
        {
            var oldpath = GetById(entity.Id).Data.ImagePath;
            entity.ImagePath = FileHelper.UpdateAsync(oldpath, formFile);
            entity.Date = DateTime.Now;
            _carImageDal.Update(entity);
            return new SuccessResult();
        }

        private IResult CheckIfImageLimit(int carid)
        {
            var carImagecount = _carImageDal.GetAll(p => p.CarId == carid).Count;
            if (carImagecount >= 5)
                return new ErrorResult();
            return new SuccessResult();
        }
        private IResult CheckIfimageGetExtension(IFormFile formFile)
        {
            string fileName = Path.GetExtension(formFile.FileName.ToUpper());
            if (!Messages.ValidImageFileTypes.Any(t => t == fileName))
                return new ErrorResult();
            return new SuccessResult();
        }
        private IResult CheckIfImageCount(IFormFile[] formFiles)
        {
            if (formFiles.Count() > 5 && formFiles.Count() < 0)
                return new ErrorResult();
            return new SuccessResult();
        }
    }
}
