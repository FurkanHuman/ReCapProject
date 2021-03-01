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
            var result = NewPath(file);
            try
            {
                using (FileStream stream = File.Create(result))
                {                    
                    file.CopyTo(stream);
                    stream.Flush();
                }

            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            return result;

        }

        public static string UpdateAsync(string sourcePath, IFormFile file)
        {
            var result = NewPath(file);

            try
            {
                using (var stream = File.Create(result))
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

            string fileExtension = Path.GetExtension(file.FileName);

            var creatingUniqueFilename = Guid.NewGuid().ToString("B") + fileExtension;

            string result = Environment.CurrentDirectory + @"\wwwroot\Images\" + creatingUniqueFilename;
            
            /*if (!Directory.Exists(@"\wwwroot\Images\"))
                Directory.CreateDirectory(result);
            */
            return (result);
        }
    }
}
