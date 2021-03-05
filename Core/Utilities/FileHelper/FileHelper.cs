using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        public static string fullPath;
        public static string AddAsync(IFormFile file)
        {
            var result = NewPath(file);
            try
            {
                using (FileStream stream = File.Create(result.path))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                }

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            return result.halfPath;
        }

        public static string UpdateAsync(string sourcePath, IFormFile file)
        {
            var result = NewPath(file);

            try
            {
                using (FileStream stream = File.Create(result.path))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                }

                DeleteAsync(sourcePath);
            }
            catch (Exception exception)
            {

                return exception.Message;
            }

            return result.halfPath;
        }

        public static IResult DeleteAsync(string path)
        {
            try
            {
                File.Delete(Environment.CurrentDirectory + path);
            }

            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        public static (string path, string halfPath) NewPath(IFormFile file)
        {

            string fileExtension = Path.GetExtension(file.FileName);

            var creatingUniqueFilename = Guid.NewGuid().ToString("B") + fileExtension;

            string result = fullPath + creatingUniqueFilename;

            if (!Directory.Exists(fullPath))
                Directory.CreateDirectory(result);

            return (result, @"\wwwroot\Images\" + creatingUniqueFilename);
        }
    }
}
