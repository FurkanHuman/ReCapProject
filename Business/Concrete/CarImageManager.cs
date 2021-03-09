using Business.Abstract;
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

        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(IFormFile formFile, CarImage entity)
        {

            IResult result = BusinessRules.Run(CheckIfImageLimit(entity.CarId), CheckIfimageGetExtension(formFile));
            if (result != null)
                return result;

            entity.Date = DateTime.Now;
            entity.ImagePath = FileHelper.AddAsync(formFile);
            _carImageDal.Add(entity);

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


        [ValidationAspect(typeof(BrandValidator))]
        [SecuredOperation("Manager")]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }


        [ValidationAspect(typeof(CarImageValidator))]
        [CacheAspect(5)]
        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }


        [ValidationAspect(typeof(CarImageValidator))]
        [CacheAspect(5)]
        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id).Data);

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
        private IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
        {
            try
            {
                List<CarImage> carImages = new List<CarImage>();
                var result = _carImageDal.GetAll(ci => ci.CarId == id);
                foreach (var image in result)
                {


                    if (image.ImagePath == null)
                    {

                        carImages.Add(new CarImage
                        {
                            ImagePath = @"/Images/default.jpg"
                        });
                        return new SuccessDataResult<List<CarImage>>(carImages);
                    }
                    else
                    {
                        image.ImagePath.Replace("\\", "/");
                        carImages.Add(image);
                    }
                }
                return new SuccessDataResult<List<CarImage>>(result);

            }
            catch (Exception e)
            {

                return new ErrorDataResult<List<CarImage>>(e.Message);
            }
        }

        private IResult CheckIfImageLimit(int carid)
        {
            var carImagecount = _carImageDal.GetAll(p => p.CarId == carid).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private IResult CheckIfimageGetExtension(IFormFile formFile)
        {
            string file = Path.GetExtension(formFile.FileName.ToUpper());
            if (Messages.ValidImageFileTypes.Any(t => t == file))
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
