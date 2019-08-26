using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace TinTucCTSV.Data.Utility
{
    public static class UploadData
    {
        public static void UploadFiles(IHostingEnvironment hostingEnvironment, IFormFileCollection files, string nameFile, string pathFile, string extension)
        {
            string roorPath = hostingEnvironment.WebRootPath;
            if (files.Count != 0)
            {
                var uploads = Path.Combine(roorPath, SD.FolderDefault + "/" + pathFile);
                
                using (var filestream = new FileStream(Path.Combine(uploads, nameFile + extension), FileMode.Create))
                {
                    files[0].CopyTo(filestream);

                }
            }
        }

        public static void UploadImages(IHostingEnvironment hostingEnvironment, IFormFileCollection files, string nameFile,string pathFolder, string pathFile, string extension)
        {
            string roorPath = hostingEnvironment.WebRootPath;
            if (files.Count != 0)
            {
                var uploads = Path.Combine(roorPath, SD.FolderDefault + "/"+ pathFolder +"/" + pathFile);

                using (var filestream = new FileStream(Path.Combine(uploads, nameFile + extension), FileMode.Create))
                {
                    files[0].CopyTo(filestream);

                }
            }
        }
    }
}
