using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        public static string AddAsync(IFormFile file)
        {
            var result = NewPath(file);

            try
            {
                var sourcePath = Path.GetTempFileName();
                using (var stream = new FileStream(sourcePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                File.Move(sourcePath, result.newPath);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return result.path;
        }

        public static (string newPath, string path) NewPath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtensions = fileInfo.Extension;
            var createUniqueFileName = Guid.NewGuid().ToString("N") + fileExtensions;
            string result = $@"{Environment.CurrentDirectory + @"\wwwroot\Images"}\{createUniqueFileName}";
            return (result, $@"\Images\{createUniqueFileName}");
        }
    }
}
