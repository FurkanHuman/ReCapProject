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
            var (path, halfPath) = NewPath(file);
                using (FileStream stream = File.Create(path))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                }
            return halfPath;
        }

        public static string UpdateAsync(string sourcePath, IFormFile file)
        {
            var (path, halfPath) = NewPath(file);

            using (FileStream stream = File.Create(path))
            {
                file.CopyTo(stream);
                stream.Flush();
            }

            DeleteAsync(sourcePath);
            return halfPath;
        }

        public static IResult DeleteAsync(string path)
        {
            File.Delete(Environment.CurrentDirectory + path);
            return new SuccessResult();
        }

        public static (string path, string halfPath) NewPath(IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.FileName);

            var creatingUniqueFilename = Guid.NewGuid().ToString("B") + fileExtension;

            string result = fullPath + creatingUniqueFilename;

            if (!Directory.Exists(fullPath))
                Directory.CreateDirectory(result);

            return (result, @"\Images\" + creatingUniqueFilename);
        }
    }
}
