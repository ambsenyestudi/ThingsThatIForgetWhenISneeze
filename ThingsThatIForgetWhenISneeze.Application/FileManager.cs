using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingsThatIForgetWhenISneeze.Application
{
    public class FileManager
    {
        private string _basePath = null;
        /// <summary>
        /// constructor need a basePath to be used through out the app, this makes possible to use this class from any .net app
        /// </summary>
        /// <param name="basePath">on asp.net HttpContext.Current.Server.MapPath(""), on console AppDomain.CurrentDomain.BaseDirectory</param>
        public FileManager(string basePath)
        {
            _basePath = basePath;
        }
        public string GetPath(string fileName, string fileExtension, bool createIfNotExists = false, string folderPath = "")
        {
            if(string.IsNullOrWhiteSpace(_basePath))
            {
                throw new IOException("File Manager needs a basePath to work with");
            }
            string path = null;
            if (!string.IsNullOrWhiteSpace(fileName) && !string.IsNullOrWhiteSpace(fileExtension))
            {


                if (fileExtension.Contains("."))
                {
                    fileExtension = fileExtension.Replace(".", "");
                }
                if (string.IsNullOrWhiteSpace(folderPath))
                {
                    folderPath = "";
                }
                else if (!folderPath.EndsWith(@"\"))
                {
                    folderPath += @"\";
                }
                //this ensures directory creation
                if (!string.IsNullOrWhiteSpace(folderPath) && !Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                
                var baseAndFolder = string.Format(@"{0}\{1}", _basePath, folderPath);
                if(!baseAndFolder.EndsWith(@"\"))
                {
                    baseAndFolder += @"\";
                }
                baseAndFolder= baseAndFolder.Replace(@"\\", @"\");
                path = string.Format(@"{0}{1}.{2}", baseAndFolder, fileName, fileExtension);
                path = path.Replace(@"\\", @"\");
                if (createIfNotExists)
                {
                    //this ensures file creation
                    var fs = File.Open(path, FileMode.OpenOrCreate);
                    fs.Close();
                }


            }
            return path;
        }
        public void WriteFile(string fileName, string fileExtension,string fileContent, string folderPath = "")
        {
            string path = GetPath(fileName, fileExtension, true, folderPath);
            if(path==null)
            {
                throw new InvalidOperationException("write file path was invalid");
            }
            
            File.WriteAllText(path, fileContent);
        }
        public string ReadFile(string fileName, string fileExtension, string folderPath = "")
        {
            return File.ReadAllText(GetPath(fileName, fileExtension, true, folderPath));
        }
    }
}
