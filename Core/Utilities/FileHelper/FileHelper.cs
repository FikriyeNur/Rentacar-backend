using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var sourcePath = Path.GetTempFileName();

            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            var result = newPath(file);
            File.Move(sourcePath, result.newPath);
            return result.resultPath.Replace("\\", "/");
        }

        public static string Update(string sourcePath, IFormFile file)
        {
            var result = newPath(file);

            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result.newPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);

            return result.resultPath.Replace("\\", "/");
        }

        public static IResult Delete(string path)
        {
            path = path.Replace("/", "\\");
            try
            {
                File.Delete(path);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
            return new SuccessResult();
        }

        public static (string newPath, string resultPath) newPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtensions = fileInfo.Extension;

            string path = @".\wwwroot\Images";
            var guidPath = Guid.NewGuid().ToString() + fileExtensions;

            string result = $@"{path}\{guidPath}";
            return (result, $"{guidPath}");
        }
    }

}
