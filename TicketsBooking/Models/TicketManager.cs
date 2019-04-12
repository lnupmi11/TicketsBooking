using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FilmSearch.Models
{
    public static class FileManager
    {
        public static void Save(IFormFile formFile, string location)
        {
            DirectoryInfo dir = new DirectoryInfo(location);

            if (!dir.Exists)
            {
                dir.Create();
            }

            long fileLength = formFile.Length;

            byte[] buf = new byte[fileLength];

            formFile.OpenReadStream().Read(buf, 0, (int)fileLength);

            string fileName = $"{location}/{formFile.FileName}";

            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                fs.Write(buf, 0, (int)fileLength);
            }
        }

        public static void Save(IFormFile formFile, string location, string fileName)
        {
            DirectoryInfo dir = new DirectoryInfo(location);

            if (!dir.Exists)
            {
                dir.Create();
            }

            long fileLength = formFile.Length;

            byte[] buf = new byte[fileLength];

            formFile.OpenReadStream().Read(buf, 0, (int)fileLength);

            string path = $"{location}/{fileName}";

            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                fs.Write(buf, 0, (int)fileLength);
            }
        }

        public static byte[] Read(string location)
        {
            using (FileStream fs = new FileStream(location, FileMode.Open, FileAccess.Read))
            {
                byte[] toReturn = new byte[fs.Length];
                fs.Read(toReturn, 0, (int)fs.Length);

                return toReturn;
            }
        }

        public static void RemoveDirectory(string location)
        {
            string[] files = Directory.GetFiles(location);
            string[] dirs = Directory.GetDirectories(location);

            foreach (string file in files)
            {
                System.IO.File.SetAttributes(file, FileAttributes.Normal);
                System.IO.File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                RemoveDirectory(dir);
            }


            Directory.Delete(location);
        }
    }
}
