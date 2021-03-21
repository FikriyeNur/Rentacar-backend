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
            var result = NewPath(file);

            try
            {
                var sourcePath = Path.GetTempFileName();
                if (file.Length > 0)
                {
                    using (var stream = new FileStream(sourcePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                File.Move(sourcePath, result);
            }
            catch (Exception ex)
            {
                return ex.Message;
                throw ex;
            }

            return result;
        }

        public static string Update(string sourcePath, IFormFile file)
        {
            var result = NewPath(file);

            try
            {
                if (sourcePath.Length > 0)
                {
                    using (var stream = new FileStream(result, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                File.Delete(sourcePath);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return result;
        }

        public static IResult Delete(string path)
        {
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

        public static string NewPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtensions = fileInfo.Extension;

            var createUniqueFileName = Guid.NewGuid().ToString("N") + fileExtensions;
            string result = $@"{@".\wwwroot\Images"}\{createUniqueFileName}";
            return result;
        }
    }
}
