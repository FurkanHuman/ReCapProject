using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        public static string AddAsync(IFormFile file)
        {
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                    file.CopyTo(stream);

            var result = NewPath(file);

            File.Move(sourcepath, result);

            return result;
        }

        public static string UpdateAsync(string sourcePath, IFormFile file)
        {
            var result = NewPath(file);

            //File.Copy(sourcePath,result);

            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            File.Delete(sourcePath);

            return result;
        }

        public static IResult DeleteAsync(string path)
        {
            try
            {
                File.Delete(path);
            }

            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        public static string NewPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;

            var creatingUniqueFilename = Guid.NewGuid().ToString("D")
               + "_" + DateTime.Now.Month + "_"
               + DateTime.Now.Day + "_"
               + DateTime.Now.Year + fileExtension;

            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\wwwroot\Images");

            string result = $@"{path}\{creatingUniqueFilename}";

            return result;
        }

    }
}
