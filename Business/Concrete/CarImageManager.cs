using Business.Abstract;
using Business.ValidationRules.FluentValidation;
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
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile formFile, CarImage entity)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimit(entity.CarId),CheckIfimageGetExtension(formFile));
            if (result != null)
                return result;

            
            entity.Date = DateTime.Now;
            entity.ImagePath = FileHelper.AddAsync(formFile);
            _carImageDal.Add(entity);

            return new SuccessResult();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage entity)
        {
            var oldpath = GetById(entity.Id).Data.ImagePath;

            IResult result = BusinessRules.Run(
                FileHelper.DeleteAsync(oldpath));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(id));

            if (result!=null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }

            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id).Data);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile formFile, CarImage entity)
        {
            var oldpath =  GetById(entity.Id).Data.ImagePath;
            entity.ImagePath = FileHelper.UpdateAsync(oldpath, formFile);
            entity.Date = DateTime.Now;
            _carImageDal.Update(entity);
            return new SuccessResult();
        }
        private IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
        {
            try
            {
                string path = @"\Images\default.jpg";
                var result = _carImageDal.GetAll(c => c.CarId == id).Any();
                if (!result)
                {
                    List<CarImage> carimage = new List<CarImage>
                    {
                        new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now }
                    };
                    return new SuccessDataResult<List<CarImage>>(carimage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == id).ToList());
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
            string[] ValidImageFileTypes = { ".JPG", ".JPEG", ".PNG", ".TIF", ".TIFF", ".GIF", ".BMP", ".ICO" };
            string file = Path.GetExtension(formFile.FileName.ToUpper());
            if(ValidImageFileTypes.Any(t => t == file))
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
