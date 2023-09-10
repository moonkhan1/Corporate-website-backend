using Microsoft.AspNetCore.Http;
using System.IO;

namespace NetCoreWebApp1.Utils
{
    public class FileHelper
    {
        public static string FileLoader(IFormFile formFile, string filePath = "/Img/")
        {
            var fileName = "";

            if(formFile != null && formFile.Length > 0)
            {
                fileName = formFile.FileName;
                string directory = Directory.GetCurrentDirectory() + "/wwwroot" + filePath + fileName;
                using(var stream = new FileStream(directory, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
            return fileName;
        }

        public static bool FileTreminator(string fileName, string filePath = "/Img/")
        {
            string deleteFile = Directory.GetCurrentDirectory() + "/wwwroot" + filePath + fileName;
            if(File.Exists(deleteFile)) 
            { 
                File.Delete(deleteFile);
                return true;
            }
            return false;
        }
    }
}
