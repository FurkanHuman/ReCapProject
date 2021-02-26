using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Aspects.Autıfac.Validation;
using Core.Utilities.Busines;
using Core.Utilities.FileHelper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
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
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add2(IFormFile formFile, CarImage entity)
        {

            IResult result = BusinessRules.Run(PicturesOfLimit(entity.CarId));
            if (result != null)
                return result;

            entity.Date = DateTime.Now;
            entity.ImagePath = FileHelper.AddAsync(formFile);

            _carImageDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Add(CarImage entity)
        {
           return new ErrorResult("Hata kullanım dışı");
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage entity)
        {
            IResult result = BusinessRules.Run(CarImageDelete(entity),
                FileHelper.DeleteAsync(_carImageDal.Get(ci => ci.Id == entity.Id).ImagePath));

            if (result != null)
                return null;
            _carImageDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.Listed);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.Id == id));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile formFile, CarImage entity)
        {
            entity.ImagePath = FileHelper.UpdateAsync(_carImageDal.Get(ci => ci.Id == entity.Id).ImagePath, formFile);
            entity.Date = DateTime.Now;
            _carImageDal.Update(entity);
            return new SuccessResult();
        }

        public IResult Update(CarImage entity)
        {
            return new ErrorResult("Hata kullanım dışı");
        }
        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id));
        }

        private List<CarImage> CheckIfCarImageNull(int id)
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\wwwroot\Images\default.png");
            var result = _carImageDal.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now } };
            }
            return _carImageDal.GetAll(p => p.CarId == id);
        }
        private IResult PicturesOfLimit(int id)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == id);
            if (result.Count >= 5)
                return new ErrorResult(Messages.OutOfRangePicCount);
            return new SuccessResult();
        }

        private IResult CarImageDelete(CarImage carImage)
        {
            try
            {
                File.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {
                return new SuccessResult(exception.Message);
            }
            return new SuccessResult();
        }
    }
}